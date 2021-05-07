using DemoGmailWithOAuthAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using Google.Apis.Gmail.v1.Data;
using System;


using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

using Google.Apis.Gmail.v1;
using System.Collections.Generic;
using Google.Apis.Gmail.v1.Data;

using System;
using System.Text;

using System.Net.Mail;
using System.IO;
using System.Web.Security;

using System.Net.Http;
namespace DemoGmailWithOAuthAPI.Controllers
{
    public class GmailAPIController : Controller
    {
        // GET: GmailAPI
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public void SendEmail(EmailContent ec)
        {
            string subject = ec.subject;
            string body = ec.body;
            string to = ec.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("phuongred98@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("phuongred98@gmail.com", "Baoiba98@");
            smtp.Send(mm);
           
        }
        #region to Fetch Response from Gmail API
        public ActionResult Code(string state, string code, string scope)
        {
            string GoogleWebAppClientID = WebConfigurationManager.AppSettings["GoogleWebAppClientID"];
            string GoogleWebAppClientSecret = WebConfigurationManager.AppSettings["GoogleWebAppClientSecret"];
            string RedirectUrl = WebConfigurationManager.AppSettings["RedirectUrl"];
            string Token = CreateOauthTokenForGmail(code, GoogleWebAppClientID, GoogleWebAppClientSecret, RedirectUrl);
            Session["Token"] = Token;
            return RedirectToAction("DisplayEmail");
        }
        //
        //void SendMailWithXOAUTH2(string userEmail, string accessToken)
        //{
        //    try
        //    {
        //        // Gmail SMTP server address
        //        SmtpServer oServer = new SmtpServer("smtp.gmail.com")
        //        {
        //            // enable SSL connection
        //            ConnectType = SmtpConnectType.ConnectSSLAuto,
        //            // Using 587 port, you can also use 465 port
        //            Port = 587,

        //            // use Gmail SMTP OAUTH 2.0 authentication
        //            AuthType = SmtpAuthType.XOAUTH2,
        //            // set user authentication
        //            User = userEmail,
        //            // use access token as password
        //            Password = accessToken
        //        };

        //        SmtpMail oMail = new SmtpMail("TryIt");
        //        // Your gmail email address
        //        oMail.From = userEmail;
        //        oMail.To = "support@emailarchitect.net";

        //        oMail.Subject = "test email from gmail account with OAUTH 2";
        //        oMail.TextBody = "this is a test email sent from c# project with gmail.";

        //        Console.WriteLine("start to send email using OAUTH 2.0 ...");

        //        SmtpClient oSmtp = new SmtpClient();
        //        oSmtp.SendMail(oServer, oMail);

        //        Console.WriteLine("The email has been submitted to server successfully!");
        //    }
        //    catch (Exception ep)
        //    {
        //        Console.WriteLine("Exception: {0}", ep.Message);
        //    }
        //}
        //
        #endregion
        #region to Create AccessToken by using this Parameters
        public string CreateOauthTokenForGmail(string code, string GoogleWebAppClientID, string GoogleWebAppClientSecret, string RedirectUrl)
        {
            RequestParameters requestParameters = new RequestParameters()
            {
                code = code,
                client_id = WebConfigurationManager.AppSettings["GoogleWebAppClientID"],
                client_secret = WebConfigurationManager.AppSettings["GoogleWebAppClientSecret"],
                redirect_uri = RedirectUrl,
                grant_type = "authorization_code"
            };
            string inputJson = JsonConvert.SerializeObject(requestParameters);
            string requestURI = "token";
            string ResponseString = "";
            HttpResponseMessage respone;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://oauth2.googleapis.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                StringContent content = new StringContent(inputJson, Encoding.UTF8, "application/json");
                respone = client.PostAsync(requestURI, content).Result;

                if(respone.IsSuccessStatusCode)
                {
                    
                    ResponseString = JsonConvert.DeserializeObject(respone.Content.ReadAsStringAsync().Result).ToString();
                    var result = JsonConvert.DeserializeObject<OAuthTokenViewModel>(ResponseString);
                    ResponseString = result.Access_token.ToString();

                }
                return ResponseString;
            }
        }
        #endregion
        #region to Display Emails
        public async Task<ActionResult> DisplayEmail()
        {
            HttpClient client = new HttpClient();
            Root rootObj = new Root();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer",
                parameter: Session["Token"].ToString());
            HttpResponseMessage responseMessage = await client.GetAsync("https://mail.google.com/mail/feed/atom");
            if(responseMessage.IsSuccessStatusCode)
            {
                var data = responseMessage.Content;
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(@responseData);
                string json = JsonConvert.SerializeXmlNode(doc);
                rootObj = JsonConvert.DeserializeObject<Root>(json);
            }
            return View(rootObj);
        }
        #endregion

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //public async Task SendEmail(EmailContent model)
        //{



        //        //send email
        //        var msg = new AE.Net.Mail.MailMessage
        //        {
        //            Subject = model.subject,
        //            Body = model.body,

        //            From = new MailAddress("phuongred98@gmail.com"),

        //        };
        //        string Mails = model.to;
        //        var recipients = Mails.Split(' ');
        //        //var recipients = new[] { model.to};
        //        foreach (var recipient in recipients)
        //        {
        //            msg.To.Add(new MailAddress(recipient));
        //            msg.ReplyTo.Add(msg.From);
        //            var msgStr = new StringWriter();
        //            msg.Save(msgStr);
        //            await service.Users.Messages.Send(new Message()
        //            {
        //                Raw = Base64UrlEncode(msgStr.ToString())
        //            }, "me").ExecuteAsync();
        //        }

        //}
        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}