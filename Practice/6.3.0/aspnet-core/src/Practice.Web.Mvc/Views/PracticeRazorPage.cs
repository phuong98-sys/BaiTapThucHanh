using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Practice.Web.Views
{
    public abstract class PracticeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PracticeRazorPage()
        {
            LocalizationSourceName = PracticeConsts.LocalizationSourceName;
        }
    }
}
