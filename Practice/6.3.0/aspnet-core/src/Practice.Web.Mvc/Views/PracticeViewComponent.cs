using Abp.AspNetCore.Mvc.ViewComponents;

namespace Practice.Web.Views
{
    public abstract class PracticeViewComponent : AbpViewComponent
    {
        protected PracticeViewComponent()
        {
            LocalizationSourceName = PracticeConsts.LocalizationSourceName;
        }
    }
}
