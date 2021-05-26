using Abp.Threading;
using OutlookFW.Gmails;
using OutlookFW.Mails.Dto;
using OutlookFW.Sessions;
using OutlookFW.Tokens;
using OutlookFW.Tokens.Dto;
using OutlookFW.Web.Models.Layout;
using OutlookFW.Web.Models.Outlooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    public class GmailController : Controller
    {
        // GET: Outlook
        public static IGmailAppService _gmailAppService;
        public static ITokenAppService _tokenAppService;
        public static string email;
        public static bool check = false;
        private readonly ISessionAppService _sessionAppService;
        public GmailController(
            IGmailAppService gmailAppService,
            ITokenAppService tokenAppService,
             ISessionAppService sessionAppService
            )
        {
            _sessionAppService = sessionAppService;
            _gmailAppService = gmailAppService;
            _tokenAppService = tokenAppService;
        }
        public async Task<ActionResult> Index()
        {
            if (Session["Token"] != null)
            {
                //Session["Email"] = await GetUserDetails();
               // email = await GetUserDetails();
                //get list mail
                var listMail = await GetMail();


                var model = new IndexViewMail(listMail, Session["Email"].ToString(), true);
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





        #endregion
        #region to Create AccessToken by using this Parameters
        // Lay ma truy cap
        public async Task<ActionResult> CreateOauthTokenForGmail(string code)
        {
            var result = await _tokenAppService.CreateOauthTokenForGmailAsync(code);
            //Lay userID de luu vao bang Token
            var userId = GetUserId();
            // kiem tra access Token da co trong Db chua
            // Neu chua co thi them vao, co roi thi thoi
            var isCheck = _tokenAppService.GetToken(userId, 1);
            if (isCheck == null)
            {
                // luu accessToken vao Db
                await SaveToken(result.access_token, result.refresh_token, userId, result.gmail);
                Session["Token"] = result.access_token;
                Session["Email"] = result.gmail;
            }
            else
            {
                Session["Token"] = isCheck.access_token;
                Session["Email"] = isCheck.gmail;
            }

            return RedirectToAction("Index");

        }
        #endregion
        public async Task<List<MailListDto>> GetMail()
        {
            var listMail = await _gmailAppService.GetMailAsync(Session["Token"].ToString());
            //var model = new IndexViewMail(listMail);
            return listMail;
        }
        public async Task<ActionResult> SendMail(string subject, string to, string body, string from)
        {
            var vm = new IndexViewMail();
            try
            {
                 _gmailAppService.SendMailAsync(Session["Token"].ToString(), subject, to, body, Session["Email"].ToString());
                //if (result)
                //    vm.IsSendSuccess = true;
                //else
                //    vm.IsSendSuccess = false;
            }
            catch (Exception ex)
            {
                if (ex.Data == null)
                {
                    throw;

                }
                vm.IsSendSuccess = false;
            }
            return RedirectToAction("Index", new { isSendSuccess = vm.IsSendSuccess });

        }

        public async Task<string> GetUserDetails()
        {
            var email = await _gmailAppService.GetUserDetailsAsync(Session["Token"].ToString());


            return email;
        }
        public async Task<ActionResult> SignOut()
        {

            this.Session.Clear();
            this.Session.Abandon();

            check = false;
            Session["Token"] = null;
            var userId = GetUserId();
            _tokenAppService.DeleteToken(userId, 1);
            return RedirectToAction("Index");

        }

        [ChildActionOnly]
        public int GetUserId()
        {
            var model = new SideBarUserAreaViewModel
            {
                LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations())
            };

            return (int)model.LoginInformations.User.Id;
        }
        // Luu access token vao DB
        public async Task SaveToken(string accessToken, string refreshToken, int userId, string gmail)
        {
            var token = new SaveToken();
            token.access_token = accessToken;
            token.refresh_token = refreshToken;
            token.user_Id = userId;
            token.gmail = gmail;
            token.type = 1;
            await _tokenAppService.SaveTokenAsync(token);


        }
    }
}