using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json;
using OutlookFW.Mails;
using OutlookFW.Mails.Dto;
using OutlookFW.Senders.Dto;
using OutlookFW.Tokens;
using OutlookFW.Web.Models.Outlooks;
using OutlookFW.Web.TokenStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    public class OutlookController : Controller
    {
        // GET: Outlook
        public static IMailAppService _mailAppService;
        public static string email= null ;
        public static bool check = false;
 
        public OutlookController(IMailAppService mailAppService)
        {
            _mailAppService = mailAppService;
            
        }
        public async Task<ActionResult> Index()
        {
          if(check)
            {
                Session["Email"] = await GetUserDetails();
                email = await GetUserDetails();
                //get list mail
                var listMail = await GetMail();

                if (listMail != null)
                {
                    check = true;
                }
                var model = new IndexViewMail(listMail, email);
                model.isAuthenticated = true;
                return View(model);
            }
            else
            {
                var model = new IndexViewMail();
                return View(model);
            }
           
            
        }
        public ActionResult Error(string message, string debug)
        {
          
            return RedirectToAction("Index");
        }
        #region to Fetch Response from mail API 
        // lay ma uy quyen

       
        
        public async Task<ActionResult> Code(string state, string code, string scope)
        {
            string MicrosoftWebAppClientID = WebConfigurationManager.AppSettings["MicrosoftWebAppClientID"];
            string MicrosoftWebAppClientSecret = WebConfigurationManager.AppSettings["MicrosoftWebAppClientSecret"];
            string RedirectUrl = WebConfigurationManager.AppSettings["RedirectUrl"];

            // AccessToken:
            string Token = CreateOauthTokenForGmail(code, MicrosoftWebAppClientID, MicrosoftWebAppClientSecret, RedirectUrl);
            Session["Token"] = Token;
          
            if (Session["Token"].ToString() != null)
            {
                check = true;
            }

            //}
            return RedirectToAction("Index");




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
            //RequestParameters requestParameters = new RequestParameters()
            //{
            //    code = code,
            //    client_id = MicrosoftWebAppClientID,
            //    client_secret = MicrosoftWebAppClientSecret,
            //    redirect_uri = RedirectUrl,
            //    grant_type = "authorization_code",
            //    scope = "https://graph.microsoft.com/mail.read"
            //};

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

                        var result = JsonConvert.DeserializeObject<Token>(ResponseString); // gan cho OAuthTokenViewModel
                        ResponseString = result.Access_token.ToString(); // access Token
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return ResponseString;

        }
        #endregion
        public async Task<List<MailListDto>> GetMail()
        {
            var listMail = await _mailAppService.GetMailAsync(Session["Token"].ToString());
            //var model = new IndexViewMail(listMail);
            return listMail;
        }
        public async Task SendMail(string subject, string to, string body)
        {
            try
            {
                await _mailAppService.SendMailAsync(Session["Token"].ToString(), subject, to, body);
            }
            catch (Exception ex)
            {
                if (ex.Data == null)
                {
                    throw;
                }

            }
            

        }

        public async Task<string> GetUserDetails()
        {
            var userDetail = await _mailAppService.GetUserDetailsAsync(Session["Token"].ToString());
            var email = userDetail.Email;
            return email;
        }
        public async Task<ActionResult> SignOut()
        {
          
            this.Session.Clear();
            this.Session.Abandon();
           
            check = false;
            Session["Token"] = null;
            return RedirectToAction("Index");

        }

    }
}