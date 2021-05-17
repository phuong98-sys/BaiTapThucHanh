using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Test1.Controllers;

namespace Test1.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : Test1ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
