using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    public class OutlookController : Controller
    {
        // GET: Outlook
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error(string message, string debug)
        {
            //Flash(message, debug);
            return RedirectToAction("Index");
        }
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
            var a = GetMeAsync(Token);
            var b = SendMailAsync(Token, "haha", "phuongred98@gmail.com phuong98.mta@gmail.com", "phuongred98@gmail.com");
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
        public async Task<ActionResult> GetMail()
        {
            return View();
        }
        public async Task<ActionResult> SendMail()
        {
            return View();
        }
    }
}