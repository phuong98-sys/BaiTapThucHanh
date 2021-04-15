using Abp.AspNetCore.Mvc.ViewComponents;

namespace Test1.Web.Views
{
    public abstract class Test1ViewComponent : AbpViewComponent
    {
        protected Test1ViewComponent()
        {
            LocalizationSourceName = Test1Consts.LocalizationSourceName;
        }
    }
}
