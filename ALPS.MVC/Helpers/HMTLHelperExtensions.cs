using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq.Expressions;

namespace ALPS.MVC.Helpers
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

		//public static HtmlString EnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> modelExpression, string firstElement)
		//{
		//	var typeOfProperty = modelExpression.ReturnType;
		//	if (!typeOfProperty.IsEnum)
		//		throw new ArgumentException(string.Format("Type {0} is not an enum", typeOfProperty));
		//	var enumValues = new SelectList(Enum.GetValues(typeOfProperty));
		//	return (HtmlString)htmlHelper.DropDownListFor(modelExpression, enumValues, firstElement);
		//}

		//public static MvcHtmlString DisplayNameFor<TModel, TProperty>(this HtmlHelper<IEnumerable<TModel>> helper, Expression<Func<TModel, TProperty>> expression)
		//{
		//    var name = ExpressionHelper.GetExpressionText(expression);
		//    name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
		//    var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<TModel>(), typeof(TModel), name);
		//    return new MvcHtmlString(metadata.DisplayName);
		//}
	}
}
