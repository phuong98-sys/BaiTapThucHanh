using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace OutlookFW.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : OutlookFWControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error(string message, string debug)
        {
            Flash(message, debug);
            return RedirectToAction("Index");
        }
    }
}