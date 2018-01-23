using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ALPS.MVC.Helpers
{
    public static class JsonHtmlHelpers
    {
        public static IHtmlContent JsonFor<T>(this HtmlHelper helper, T obj)
        {
            return helper.Raw(obj.ToJson());
        }
    }
}