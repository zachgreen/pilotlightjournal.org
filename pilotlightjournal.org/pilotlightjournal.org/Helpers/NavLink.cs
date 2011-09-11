using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc{
    public static class NavExtensions{
        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName) {
            return NavLink(htmlHelper, linkText, actionName, new RouteValueDictionary(), null);
        }

        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues) {
            return NavLink(htmlHelper, linkText, actionName, new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }

        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes) {
            return NavLink(htmlHelper, linkText, actionName, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues) {
            return NavLink(htmlHelper, linkText, actionName, routeValues, new RouteValueDictionary());
        }

        //public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) {
        //    return NavLink(htmlHelper, linkText, actionName, routeValues, htmlAttributes);
        //}

        //public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName) {
        //    return NavLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        //}

        //public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes) {
        //return NavLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        //}

        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) {
            if (String.IsNullOrEmpty(linkText)) {
                throw new ArgumentException("linkText");
            }
            if (IsCurrentUrl(htmlHelper,actionName, routeValues)) htmlAttributes = BuildAttributes(htmlAttributes);
            
            return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext,
                htmlHelper.RouteCollection, linkText, null, actionName, (string)routeValues["controller"], routeValues, htmlAttributes));
        }

        //public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) {
        //return NavLink(htmlHelper, linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        //}

        //public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) {
        //    if (String.IsNullOrEmpty(linkText)) {
        //        throw new ArgumentException("linkText");
        //    }
        //    if (IsCurrentUrl(htmlHelper, actionName, controllerName, routeValues)) htmlAttributes = BuildAttributes(htmlAttributes);
        
        //    return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null /* routeName */, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes));
        //}

        private static bool IsCurrentUrl(this HtmlHelper htmlHelper, string action, RouteValueDictionary routeValues) {
            var currentController = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            var currentPage = htmlHelper.ViewContext.RouteData.Values["page"];
            var currentArea = String.Empty;
            var area = (string)routeValues["area"];
            var controller = (string)routeValues["controller"];

            //determine current area
            if (htmlHelper.ViewContext.RouteData.Values.ContainsKey("area")) currentArea = (string)htmlHelper.ViewContext.RouteData.Values["area"];
            else currentArea = htmlHelper.ViewContext.RouteData.DataTokens.ContainsKey("area") ? (string)htmlHelper.ViewContext.RouteData.DataTokens["area"] : String.Empty;

            //check if current page
            if (currentPage != null && routeValues["page"] != null) {
                if (Convert.ToInt32(currentPage) != (int)routeValues["page"]) return false;
            }

            if (!String.IsNullOrEmpty(controller) && !String.IsNullOrEmpty(area)) return action.ToLower() == currentAction.ToLower() && controller.ToLower() == currentController.ToLower() && area.ToLower() == currentArea.ToLower();
            if (controller != null) return action.ToLower() == currentAction.ToLower() && controller.ToLower() == currentController.ToLower();
            return action.ToLower() == currentAction.ToLower();
        }

        private static IDictionary<string, object> BuildAttributes(IDictionary<string, object> htmlAttributes) {
            if (htmlAttributes["class"] == null) htmlAttributes["class"] = "current";
            else htmlAttributes["class"] = "current " + htmlAttributes["class"];
        
            return htmlAttributes;
        }
    }
}