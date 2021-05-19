using DemoGmailWithOAuthAPI.Models;
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
        public static string name;

        public static string token1;
        public static string token2;

    
        public ActionResult Logout()
        {
            return View();
        }
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://oauth2.googleapis.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                StringContent content = new StringContent(inputJson, Encoding.UTF8, "application/json");
                respone = client.PostAsync(requestURI, content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    // chuyen doi chuoi tra ve
                    ResponseString = JsonConvert.DeserializeObject(respone.Content.ReadAsStringAsync().Result).ToString();
                    var result = JsonConvert.DeserializeObject<OAuthTokenViewModel>(ResponseString); // gan cho OAuthTokenViewModel
                    ResponseString = result.Access_token.ToString(); // access Token
                    // Lay thông tin user
                    try
                    {

                        //HttpClient client2 = new HttpClient();

                        var url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + ResponseString;

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
                    }
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
            if (responseMessage.IsSuccessStatusCode)
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