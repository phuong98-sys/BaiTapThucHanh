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
using System.Net;
using System.Web.Script.Serialization;
using MimeKit;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
//https://www.youtube.com/watch?v=RKBl33cklhc
namespace DemoGmailWithOAuthAPI.Controllers
{
    public class GmailAPIController : Controller
    {
        // GET: GmailAPI
        public static string name;
        public static string token1;
        public static string token2;
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
            string id= SendMail(name, name, "test", "teest");
            if(id!=null)
            {
                ViewBag.s = "thanh cong";
            }
            
            //string to = ec.to;
            //MailMessage mm = new MailMessage(name,to);
            //string subject = ec.subject;
            //string body = ec.body;
            //mm.Subject = subject;
            //mm.Body = body;
            //mm.IsBodyHtml = false;
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.Timeout = 1000000;
            //smtp.EnableSsl = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            ////NetworkCredential nc = new NetworkCredential()
            ////mm.From = new MailAddress(name);
            ////mm.To.Add(to);

            ////SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //smtp.UseDefaultCredentials = true;
            //smtp.Port = 587;
            //smtp.EnableSsl = true;
            //smtp.Credentials = new System.Net.NetworkCredential("phuongred98@gmail.com", "Baoiba98@");
            //smtp.Send(mm);

        }
        #region to Fetch Response from Gmail API 
        // lay ma uy quyen
        public ActionResult Code(string state, string code, string scope)
        {
            string GoogleWebAppClientID = WebConfigurationManager.AppSettings["GoogleWebAppClientID"];
            string GoogleWebAppClientSecret = WebConfigurationManager.AppSettings["GoogleWebAppClientSecret"];
            string RedirectUrl = WebConfigurationManager.AppSettings["RedirectUrl"];
                // AccessToken:
            string Token = CreateOauthTokenForGmail(code, GoogleWebAppClientID, GoogleWebAppClientSecret, RedirectUrl);
            token1 = Token;
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

        // sen moi

        #endregion
        #region to Create AccessToken by using this Parameters
        // Lay ma truy cap
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
                    // chuyen doi chuoi tra ve
                    string r = respone.Content.ReadAsStringAsync().ToString();
                    var t = JsonConvert.DeserializeObject<OAuthTokenViewModel>(r);
                    ResponseString = JsonConvert.DeserializeObject(respone.Content.ReadAsStringAsync().Result).ToString();
                    var result = JsonConvert.DeserializeObject<OAuthTokenViewModel>(ResponseString); // gan cho OAuthTokenViewModel
                    ResponseString = result.Access_token.ToString(); // access Token
                 

                    // Lay thông tin user
                    try

                    {

                        //HttpClient client2 = new HttpClient();

                        var url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + ResponseString;
                        //WebRequest request = WebRequest.Create(url);
                        //request.Credentials = CredentialCache.DefaultCredentials;
                        //WebResponse response = request.GetResponse();
                        //Stream dataStream = response.GetResponseStream();
                        //StreamReader reader = new StreamReader(dataStream);
                        //string responseFromServer = reader.ReadToEnd();
                        //reader.Close();
                        //response.Close();
                        //JavaScriptSerializer js = new JavaScriptSerializer();
                        //GoogleUserOutputData userinfo = js.Deserialize<GoogleUserOutputData>(responseFromServer);
                        //imgprofile.ImageUrl = userinfo.picture;
                        //lblid.Text = userinfo.id;
                        //lblgender.Text = userinfo.gender;
                        //lbllocale.Text = userinfo.locale;
                        //lblname.Text = userinfo.name;
                        //var name = userinfo.email;                    
                        client.CancelPendingRequests();

                        HttpResponseMessage output = client.GetAsync(url).Result;
                        GoogleUserOutputData serStatus = new GoogleUserOutputData();

                        if (output.IsSuccessStatusCode)

                        {

                            string outputData = output.Content.ReadAsStringAsync().Result;

                            serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);
                                name = serStatus.email;

                        }
                        else
                        {
                            ViewBag.test = "no";
                        }

                    }

                    catch (Exception ex)

                    {

                        //catching the exception

                    }

                    //return View(serStatus);

                }
                return ResponseString;
            }
        }
        #endregion
        #region to Display Emails
        // get inboxes of gmail
        public async Task<ActionResult> DisplayEmail()
        {
            HttpClient client = new HttpClient();
            Root rootObj = new Root();
            // Gui ma truy cap cho gmail api
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer",
                parameter: Session["Token"].ToString());
            HttpResponseMessage responseMessage = await client.GetAsync("https://mail.google.com/mail/feed/atom");
            if(responseMessage.IsSuccessStatusCode)
            {
                var data = responseMessage.Content; // du lieu tu gmail tra ve
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;// doc noi dung du lieu
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(@responseData);//
                string json = JsonConvert.SerializeXmlNode(doc);//chuyen du lieu xml thanh json
                rootObj = JsonConvert.DeserializeObject<Root>(json); // gan du lieu gmail cho doi tuong nay
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
        public string SendMail(string fromAddress, string toEmail, string subject, string body)
        {
            //Construct the message
            var mailMessage = new System.Net.Mail.MailMessage(fromAddress, toEmail, subject, body);
            mailMessage.ReplyToList.Add(new MailAddress(fromAddress));

            //Specify whether the body is HTML
            mailMessage.IsBodyHtml = true;

            //Convert to MimeMessage
            MimeMessage message = MimeMessage.CreateFromMailMessage(mailMessage);
            var rawMessage = message.ToString();

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "369518912260-5g5delg9bh600r6amuqsvmc0n995f2b7.apps.googleusercontent.com",
                    ClientSecret = "XA4yC-8Oj6pMWhdJS5CS7ZZH"
                },
                Scopes = new[] { GmailService.Scope.GmailCompose }
            });

            var token = new Google.Apis.Auth.OAuth2.Responses.TokenResponse()
            {
                AccessToken = token1,
                //RefreshToken =
            };

            //In my case the username is the same as the fromAddress
            var gmail = new GmailService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                ApplicationName = "App Name",
                HttpClientInitializer = new UserCredential(flow, fromAddress, token)
            });

            var result = gmail.Users.Messages.Send(new Message
            {
                Raw = Base64UrlEncode(rawMessage)
            }, "me").Execute();
            return result.Id;
        }
    
    /// <summary>
    /// Converts input string into a URL safe Base64 encoded string. Method thanks to Jason Pettys.
    /// http://jason.pettys.name/2014/10/27/sending-email-with-the-gmail-api-in-net-c/
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    //public void SendIt()
    //{
    //    var msg = new AE.Net.Mail.MailMessage
    //    {
    //        Subject = "Your Subject",
    //        Body = "Hello, World, from Gmail API!",
    //        From = new MailAddress("[you]@gmail.com")
    //    };
    //    msg.To.Add(new MailAddress("yourbuddy@gmail.com"));
    //    msg.ReplyTo.Add(msg.From); // Bounces without this!!
    //    var msgStr = new StringWriter();
    //    msg.Save(msgStr);

    //    // Context is a separate bit of code that provides OAuth context;
    //    // your construction of GmailService will be different from mine.
    //    var gmail = new GmailService(Context.GoogleOAuthInitializer);
    //    var result = gmail.Users.Messages.Send(new Message
    //    {
    //        Raw = Base64UrlEncode(msgStr.ToString())
    //    }, "me").Execute();
    //    Console.WriteLine("Message ID {0} sent.", result.Id);
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