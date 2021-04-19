using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Practice.Controllers;

namespace Practice.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : PracticeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
