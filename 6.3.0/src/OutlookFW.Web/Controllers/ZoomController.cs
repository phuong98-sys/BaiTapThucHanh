using OutlookFW.Models.Zoom;
using OutlookFW.Sessions;
using OutlookFW.Tokens;
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Schedule()
        {
            return View();
        }
        public async Task<ActionResult> CreateOauthTokenForZoom(string code)
        {
           var a = await _tokenAppService.CreateOauthTokenForZoomAsync(code);
            Session["Token"] = a.access_token;
            Session["UserId"] = await _zoomAppService.GetUserDetailsAsync(Session["Token"].ToString());
            return View();
        }
        public ActionResult CreateMeeting(Meeting meeting)
        {
             _zoomAppService.CreateMeeting(meeting, Session["Token"].ToString(), Session["UserId"].ToString());
            return View();
        }
        public void GetAllMeeting()
        {
            var a = _zoomAppService.AllMeetings(Session["Token"].ToString(), Session["UserId"].ToString());
        }
        
    }
}