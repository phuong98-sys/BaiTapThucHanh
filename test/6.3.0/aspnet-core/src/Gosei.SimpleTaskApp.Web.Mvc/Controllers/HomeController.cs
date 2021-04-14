using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Gosei.SimpleTaskApp.Controllers;

namespace Gosei.SimpleTaskApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SimpleTaskAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
