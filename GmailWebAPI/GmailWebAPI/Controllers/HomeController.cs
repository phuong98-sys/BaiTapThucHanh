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

namespace Google.Apis.Sample.MVC4.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            var t = new AppFlowMetadata();
            var result = await new AuthorizationCodeMvcApp(this,t).
                AuthorizeAsync(cancellationToken);
            List<EmailContent> mails = new List<EmailContent>();
           
            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });
   //             UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

                
   //             IList<Label> labels = request.Execute().Labels;
         

   //             if (labels != null && labels.Count > 0)
   //             {
   //                 foreach (var labelItem in labels)
   //                 {
   //                     if (labelItem.Name == "Date")
   //                     {
                         
   //ViewBag.Message = labelItem.Name;
   //                     break;
   //                     }
                     

   //                 }
   //             }
   //             else
   //             {
   //                 ViewBag.Message = "Khong tim thay";
   //             }


                //YOUR CODE SHOULD BE HERE..SAMPLE CODE:
                //var list = await service.Files.List().ExecuteAsync();
                //foreach (var item in list.Items)
                //{
                //    item.Id
                //}
                //ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();



                // mới
                var request = service.Users.Messages.List("me");
                request.LabelIds = "INBOX";
                request.IncludeSpamTrash = false;
                request.Q = "is:unread"; // This was added because I only wanted unread emails...

                //    Get our emails
                var emailListResponse = request.Execute();

                if (emailListResponse != null && emailListResponse.Messages != null)
                {

                    // Loop through each email and get what fields you want...
                    foreach (var email in emailListResponse.Messages)
                    {
                        EmailContent mail = new EmailContent();
                        ViewBag.Message = email.Id;
                        var emailInfoRequest = service.Users.Messages.Get("phuongred98@gmail.com", email.Id);
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
                                    if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                                    {
                                        mail.body = emailInfoResponse.Payload.Body.Data;
                                    }
                                    else
                                    {
                                        mail.body = getNestedParts(emailInfoResponse.Payload.Parts, "");
                                    }
                                    // Need to replace some characters as the data for the email's body is base64
                                    String codedBody = mail.body.Replace("-", "+");
                                    codedBody = codedBody.Replace("_", "/");
                                    byte[] data = Convert.FromBase64String(codedBody.ToString());
                                    mail.body = Encoding.UTF8.GetString(data);

                                    // Now you have the data you want...                         
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
                return new RedirectResult(result.RedirectUri);
            }
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
