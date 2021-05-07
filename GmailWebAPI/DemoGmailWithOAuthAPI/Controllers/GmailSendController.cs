using DemoGmailWithOAuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DemoGmailWithOAuthAPI.Controllers
{
    public class GmailSendController : Controller
    {
        // GET: GmailSend
        public ActionResult Index(EmailContent ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44334/GmailAPI/SendEmail");
            var consumeweapi = hc.PostAsXmlAsync<EmailContent>("Email", ec);
            consumeweapi.Wait();
            var sendmail = consumeweapi.Result;
            if(sendmail.IsSuccessStatusCode)
            {
                ViewBag.message = "Gui mail thanh cong";
            }
            return View();
        }
    }
}