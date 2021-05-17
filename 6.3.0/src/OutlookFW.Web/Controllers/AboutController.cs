using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    public class AboutController : OutlookFWControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}