
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;
using TestOutlook.Models;

namespace TestOutlook.Controllers
{
    public class OutlookAPIController : Controller
    {
        // GET: OutlookAPI
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        // GET: GmailAPI


        public static string token1;
        public static string token2;


        public ActionResult Logout()
        {
            return View();
        }
        // [Authorize]
        //public readonly ITokenAcquisition tokenAcquisition;

        //     public OutlookAPIController(ITokenAcquisition tokenAcquisition)
        //     {
        //         this.tokenAcquisition = tokenAcquisition;
        //     }

        // Code for the controller actions (see code below)


        //public void SendEmail(EmailContent ec)
        //{

        //    string to = ec.to;
        //    MailMessage mm = new MailMessage(name, to);
        //    string subject = ec.subject;
        //    string body = ec.body;
        //    mm.Subject = subject;
        //    mm.Body = body;
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    smtp.Timeout = 1000000;
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    NetworkCredential nc = new NetworkCredential(name, "");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = nc;
        //    smtp.Send(mm);

        //}


        #region to Fetch Response from mail API 
        // lay ma uy quyen
        public static string name;
        public static string accessToken;
        public async Task<ActionResult> Code(string state, string code, string scope)
        {
            string MicrosoftWebAppClientID = WebConfigurationManager.AppSettings["MicrosoftWebAppClientID"];
            string MicrosoftWebAppClientSecret = WebConfigurationManager.AppSettings["MicrosoftWebAppClientSecret"];
            string RedirectUrl = WebConfigurationManager.AppSettings["RedirectUrl"];
            string Authority = "https://login.microsoftonline.com/86797743-5a99-4f12-92bb-03f64ec3af41/v2.0";
            // AccessToken:
            string Token = CreateOauthTokenForGmail(code, MicrosoftWebAppClientID, MicrosoftWebAppClientSecret, RedirectUrl);
            token1 = Token;
            Session["Token"] = Token;
            var a =GetMeAsync(Token);
            var b= SendMailAsync(Token,"haha","phuongred98@gmail.com phuong98.mta@gmail.com","phuongred98@gmail.com");
            return RedirectToAction("About");

           
        }


        #endregion
        #region to Create AccessToken by using this Parameters
        // Lay ma truy cap
        public string CreateOauthTokenForGmail(string code, string MicrosoftWebAppClientID, string MicrosoftWebAppClientSecret, string RedirectUrl)
        {
            var data = new Dictionary<string, string>
            {
                {"client_id", MicrosoftWebAppClientID},
                {"scope", "https://graph.microsoft.com/mail.read"},
                {"code", code},
                {"redirect_uri", RedirectUrl},
                {"grant_type", "authorization_code"},
                {"client_secret", MicrosoftWebAppClientSecret}
            };
            RequestParameters requestParameters = new RequestParameters()
            {   
                code = code,
                client_id = MicrosoftWebAppClientID,
                client_secret = MicrosoftWebAppClientSecret,
                redirect_uri = RedirectUrl,
                grant_type = "authorization_code",
                scope = "https://graph.microsoft.com/mail.read"
            };

            //string inputJson = JsonConvert.SerializeObject(requestParameters);
            //string requestURI = "token";
            string ResponseString = "";
            HttpResponseMessage respone;
            try
            {
                using (var client = new HttpClient())
                {
                  

                    var request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/common/oauth2/v2.0/token")
                    {
                        Content = new FormUrlEncodedContent(data)
                    };

                    respone = client.SendAsync(request).Result;

                    if (respone.IsSuccessStatusCode)
                    {
                        // chuyen doi chuoi tra ve
                        ResponseString = JsonConvert.DeserializeObject(respone.Content.ReadAsStringAsync().Result).ToString();
                        var result = JsonConvert.DeserializeObject<OAuthTokenViewModel>(ResponseString); // gan cho OAuthTokenViewModel
                        ResponseString = result.Access_token.ToString(); // access Token



                        // Lay thông tin user
                        //try
                        //{

                        //    //HttpClient client2 = new HttpClient();

                        //    var url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + ResponseString;

                        //    HttpResponseMessage output = client.GetAsync(url).Result;
                        //    GoogleUserOutputData serStatus = new GoogleUserOutputData();

                        //    if (output.IsSuccessStatusCode)

                        //    {

                        //        string outputData = output.Content.ReadAsStringAsync().Result;

                        //        serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);
                        //        name = serStatus.email;

                        //    }
                        //    else
                        //    {
                        //        ViewBag.test = "no";
                        //    }

                        //}

                        //catch (Exception ex)
                        //{
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return ResponseString;

        }
        #endregion
        public static async Task<List<EmailContent>> GetMeAsync(string accessToken)
        {
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    }));
            try
            {
                List<EmailContent> listMail = new List<EmailContent>();

                var mailBox = await graphClient.Me.MailFolders.Inbox.Messages.Request()
                   .Select("sender,from,toRecipients,receivedDateTime, subject,body")
                   .GetAsync();

                foreach (var message in mailBox)
                {
                    EmailContent mail = new EmailContent();
                    //mail.name = message.From.EmailAddress.Name;
                    mail.from = message.From.EmailAddress.Address;
                    mail.date = message.ReceivedDateTime.ToString();
                    mail.body = message.Body.Content.ToString();

                    mail.subject = message.Subject.ToString();
                    listMail.Add(mail);
                }
                return listMail;
            }
            catch (ServiceException ex)
            {
                return null;
            }
        }

        public static async Task SendMailAsync(string accessToken, string subject, string to, string body)
        {
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", accessToken);
                    }));
            try
            {
                string Mails = to;
                var toRecipients = Mails.Split(' ');
                List<Recipient> a = new List<Recipient>();
                foreach (var address in toRecipients)
                {

                    Recipient b = new Recipient
                    {

                        EmailAddress = new EmailAddress
                        {
                            Address = address,

                        }
                    };
                    a.Add(b);
                }
                var message = new Message
                {
                    Subject = subject,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = body
                    },
                    ToRecipients = a,


                };


                await graphClient.Me
                    .SendMail(message, null)
                            .Request()
                            .PostAsync();

            }
            catch (ServiceException ex)
            {

            }

        }
        public static async Task<CachedUser> GetUserDetailsAsync(string accessToken)
        {
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", accessToken);
                    }));

            var user = await graphClient.Me.Request()
                .Select(u => new
                {
                    u.DisplayName,
                    u.Mail,
                    u.UserPrincipalName
                })
                .GetAsync();

            return new CachedUser
            {
                Avatar = string.Empty,
                DisplayName = user.DisplayName,
                Email = string.IsNullOrEmpty(user.Mail) ?
                    user.UserPrincipalName : user.Mail
                    
            };
        }

        //#region to Display Emails
        //// get inboxes of gmail
        //public async Task<ActionResult> DisplayEmail()
        //{
        //    HttpClient client = new HttpClient();
        //    Root rootObj = new Root();
        //    // Gui ma truy cap cho gmail api
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer",
        //        parameter: Session["Token"].ToString());
        //    HttpResponseMessage responseMessage = await client.GetAsync("https://mail.google.com/mail/feed/atom");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var data = responseMessage.Content; // du lieu tu gmail tra ve
        //        var responseData = responseMessage.Content.ReadAsStringAsync().Result;// doc noi dung du lieu
        //        XmlDocument doc = new XmlDocument();
        //        doc.LoadXml(@responseData);//
        //        string json = JsonConvert.SerializeXmlNode(doc);//chuyen du lieu xml thanh json
        //        rootObj = JsonConvert.DeserializeObject<Root>(json); // gan du lieu gmail cho doi tuong nay
        //    }
        //    return View(rootObj);
        //}
        //#endregion
        //public async Task SendGmail(EmailContent model)
        //{


        //    var service = new GmailService(new BaseClientService.Initializer
        //    {
        //        HttpClientInitializer = GoogleCredential.FromAccessToken(token1),
        //    });

        //    //send email
        //    var msg = new AE.Net.Mail.MailMessage
        //    {
        //        Subject = model.subject,
        //        Body = model.body,

        //        From = new MailAddress(name),

        //    };
        //    string Mails = model.to;
        //    var recipients = Mails.Split(' ');

        //    foreach (var recipient in recipients)
        //    {
        //        msg.To.Add(new MailAddress(recipient));
        //        msg.ReplyTo.Add(msg.From);
        //        var msgStr = new StringWriter();
        //        msg.Save(msgStr);
        //        await service.Users.Messages.Send(new Message()
        //        {
        //            Raw = Base64UrlEncode(msgStr.ToString())
        //        }, "me").ExecuteAsync();
        //    }

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