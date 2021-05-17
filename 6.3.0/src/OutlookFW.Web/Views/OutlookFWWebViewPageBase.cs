using Abp.Web.Mvc.Views;

namespace OutlookFW.Web.Views
{
    public abstract class OutlookFWWebViewPageBase : OutlookFWWebViewPageBase<dynamic>
    {

    }

    public abstract class OutlookFWWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected OutlookFWWebViewPageBase()
        {
            LocalizationSourceName = OutlookFWConsts.LocalizationSourceName;
        }
    }
}