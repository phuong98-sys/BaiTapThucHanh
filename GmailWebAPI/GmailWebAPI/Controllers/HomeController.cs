using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

using Google.Apis.Sample.MVC4;
using GmailWebAPI.MVC4;
using Google.Apis.Gmail.v1;
using System.Collections.Generic;
using Google.Apis.Gmail.v1.Data;
using GmailWebAPI.Models;
using System;
using System.Text;
using iTextSharp.text.html;
using iText.StyledXmlParser.Jsoup;
using System.Net.Mail;
using System.IO;
using System.Web.Security;
using WebMatrix.WebData;

namespace Google.Apis.Sample.MVC4.Controllers
{
    public class HomeController : Controller
    {
        public static CancellationToken cancellationToken;
        public static GmailService service;
        public static Auth.OAuth2.Web.AuthorizationCodeWebApp.AuthResult result;
        public static string emailAddress;
        public async Task<Boolean> checkCredential()
        {

            var app = new AppFlowMetadata();
             result = await new AuthorizationCodeMvcApp(this, app).
                AuthorizeAsync(cancellationToken);
            //var accessToken =  result.Credential.Token.AccessToken;
            //string a = accessToken.Value;
            if (result.Credential != null)
            {
                
                service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<ActionResult> IndexAsync()
        {
           
            List<EmailContent> mails = new List<EmailContent>();     
            if (await checkCredential())
            {
                ViewBag.Success = 1;

                // mới
               
                var request = service.Users.Messages.List("me");
                
                request.LabelIds = "INBOX";
                request.IncludeSpamTrash = false;
                // request.Q = "is:unread"; // This was added because I only wanted unread emails...

                //    Get our emails
                var emailListResponse = request.Execute();

                if (emailListResponse != null && emailListResponse.Messages != null)
                {
                  
                    // Loop through each email and get what fields you want...
                    foreach (var email in emailListResponse.Messages)
                    {
                        EmailContent mail = new EmailContent();
              
                        var emailInfoRequest = service.Users.Messages.Get("me", email.Id);
                        // Make another request for that email id...
                        var emailInfoResponse = emailInfoRequest.Execute();
                       
                        if (emailInfoResponse != null)
                        {
                       
                            // Loop through the headers and get the fields we need...
                            foreach (var mParts in emailInfoResponse.Payload.Headers)
                            {

                                if (mParts.Name == "Date")
                                {
                                    mail.date = mParts.Value;

                                }
                                else if (mParts.Name == "Delivered-To")
                                {
                                    emailAddress = mParts.Value;
                                }
                                else if (mParts.Name == "From")
                                {
                                    mail.from = mParts.Value;
                                }
                                else if (mParts.Name == "Subject")
                                {
                                    mail.subject = mParts.Value;

                                }
                               

                                if (mail.date != "" && mail.from != "")
                                {
                                    if (emailInfoResponse.Payload.Parts == null)
                                    {   
                                            byte[] data = FromBase64ForUrlString(emailInfoResponse.Payload.Body.Data);
                                            string decodedString = Encoding.UTF8.GetString(data);
                                            mail.body = Jsoup.Parse(decodedString).Text();
                                        
                                        continue;
                                    }

                                    foreach (MessagePart p in emailInfoResponse.Payload.Parts)
                                    {
                                        if (p.MimeType == "text/html")
                                        {
                                            byte[] data = FromBase64ForUrlString(p.Body.Data);
                                            string decodedString = Encoding.UTF8.GetString(data);
                                            mail.body = Jsoup.Parse(decodedString).Text();
                                        }
                                    }
                                }
                               
                            }

                        }
                        mails.Add(mail);
                    }
                }

                return View(mails);
            }
            else
            {
                ViewBag.Success = 0;
               
                return new RedirectResult(result.RedirectUri);
                //return View(mails);
            }
        }

        public async Task SendEmail(EmailContent model, CancellationToken cancellationToken)
        {
           

            if (await checkCredential())
            {
              
                //send email
                var msg = new AE.Net.Mail.MailMessage
                {
                    Subject = model.subject,
                    Body = model.body,

                    From = new MailAddress(emailAddress),

                };
                string Mails = model.to;
                var recipients = Mails.Split(' ');
                //var recipients = new[] { model.to};
                foreach (var recipient in recipients)
                {
                    msg.To.Add(new MailAddress(recipient));
                    msg.ReplyTo.Add(msg.From);
                    var msgStr = new StringWriter();
                    msg.Save(msgStr);
                    await service.Users.Messages.Send(new Message()
                    {
                        Raw = Base64UrlEncode(msgStr.ToString())
                    }, "me").ExecuteAsync();
                }




            }

        }
  
        public async Task<ActionResult> Logout()
        {
            //FormsAuthentication.SignOut();
             WebSecurity.Logout();
            return new RedirectResult("/Home/Index");
        }
        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
        public static byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }
        static String getNestedParts(IList<MessagePart> part, string curr)
        {
            string str = curr;
            if (part == null)
            {
                return str;
            }
            else
            {
                foreach (var parts in part)
                {
                    if (parts.Parts == null)
                    {
                        if (parts.Body != null && parts.Body.Data != null)
                        {
                            str += parts.Body.Data;
                        }
                    }
                    else
                    {
                       
                        return getNestedParts(parts.Parts, str);
                    }
                }

                return str;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
       


    }
}