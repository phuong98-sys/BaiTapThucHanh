using Abp.Threading;
using OutlookFW.Models.Zoom;
using OutlookFW.Sessions;
using OutlookFW.Tokens;
using OutlookFW.Tokens.Dto;
using OutlookFW.Web.Models.Layout;
using OutlookFW.Web.Models.Zooms;
using OutlookFW.Zoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    public class ZoomController : Controller
    {
        // GET: Zoom
        public static IZoomAppService _zoomAppService;
        public static ITokenAppService _tokenAppService;
        public static string email;
        public static bool check = false;
        private readonly ISessionAppService _sessionAppService;
        public ZoomController(
            IZoomAppService zoomAppService,
            ITokenAppService tokenAppService,
             ISessionAppService sessionAppService
            )
        {
            _sessionAppService = sessionAppService;
            _zoomAppService = zoomAppService;
            _tokenAppService = tokenAppService;
        }
        public async Task<ActionResult> Index()
        {
            if (Session["AccessToken"] != null)
            {
                //Session["Email"] = await GetUserDetails();
                // email = await GetUserDetails();
                //get list mail
                var listMail = await GetAllMeeting();


                var model = new ZoomIndexViewModel(listMail, Session["UserZoomEmail"].ToString());
                model.isAuthenticated = true;
                return View(model);
            }
            else
            {
                var model = new ZoomIndexViewModel();
                return View(model);
            }
        }
        public ActionResult Schedule()
        {
            return View();
        }
        public async Task<ActionResult> CreateOauthTokenForZoom(string code)
        {


            //Lay userID de luu vao bang Token
            var userId = GetUserId();
            // luu accessToken vao Db
            UserMeeting userMeeting ;
            // kiem tra access Token da co trong Db chua
            // Neu chua co thi them vao, co roi thi thoi
            var isCheck = _tokenAppService.GetToken(userId, 2);
            if (isCheck == null)
            {
             
                var a = await _tokenAppService.CreateOauthTokenForZoomAsync(code);
                Session["AccessToken"] = a.access_token;
                Session["RefreshToken"] = a.refresh_token;
                 userMeeting = await _zoomAppService.GetUserDetailsAsync(Session["AccessToken"].ToString());
                Session["UserZoomId"] = userMeeting.userId;

                Session["UserZoomEmail"] = userMeeting.userEmail;
                // luu accessToken vao Db
                await SaveToken(Session["AccessToken"].ToString(), Session["RefreshToken"].ToString(), userId, Session["UserZoomEmail"].ToString());

            }
            else
            {

                Session["AccessToken"] = isCheck.access_token;
                 userMeeting = await _zoomAppService.GetUserDetailsAsync(Session["AccessToken"].ToString());
                Session["UserZoomId"] = userMeeting.userId;
                Session["UserZoomEmail"] = isCheck.gmail;
            }

            return RedirectToAction("Index");
        }
        public ActionResult CreateMeeting(Meeting meeting)
        {
            _zoomAppService.CreateMeeting(meeting, Session["AccessToken"].ToString(), Session["UserZoomId"].ToString());
            return View();
        }
        public async Task<List<Meeting>> GetAllMeeting()
        {
            var listMeeting = await _zoomAppService.AllMeetings(Session["AccessToken"].ToString(), Session["UserZoomId"].ToString());
            return listMeeting;
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
        public async Task SaveToken(string accessToken, string refreshToken, int userId, string gmail)
        {
            var token = new SaveToken();
            token.access_token = accessToken;
            token.refresh_token = refreshToken;
            token.user_Id = userId;
            token.gmail = gmail;
            token.type = 2;
            await _tokenAppService.SaveTokenAsync(token);


        }
        public async Task<ActionResult> SignOut()
        {

            this.Session.Clear();
            this.Session.Abandon();

            check = false;
            Session["AccessToken"] = null;
            var userId = GetUserId();
            _tokenAppService.DeleteToken(userId, 2);
            return RedirectToAction("Index");

        }
    }
}