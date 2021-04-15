using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Test1.Web.Views
{
    public abstract class Test1RazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected Test1RazorPage()
        {
            LocalizationSourceName = Test1Consts.LocalizationSourceName;
        }
    }
}
