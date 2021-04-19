using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Practice.Controllers;

namespace Practice.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PracticeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
