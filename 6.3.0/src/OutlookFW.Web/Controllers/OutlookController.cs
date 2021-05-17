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
    }
}