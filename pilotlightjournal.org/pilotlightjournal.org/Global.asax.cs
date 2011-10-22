using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using pilotlightjournal.org.Controllers;
using pilotlightjournal.org.Models;

namespace pilotlightjournal.org {
    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("About", "About", new { controller = "Home", action = "About", id = UrlParameter.Optional });
            routes.MapRoute("Contact", "Contact", new { controller = "Home", action = "About", id = UrlParameter.Optional });
            routes.MapRoute("Submissions", "Submissions", new { controller = "Home", action = "About", id = UrlParameter.Optional });
            routes.MapRoute("Archive", "Archive", new { controller = "Issue", action = "Archive", id = UrlParameter.Optional });
            routes.MapRoute("Contributors", "Contributors", new { controller = "Home", action = "Contributors", id = UrlParameter.Optional });
            routes.MapRoute("RssFeed", "RssFeed", new { controller = "Home", action = "RssFeed", id = UrlParameter.Optional });
            routes.MapRoute("Blank", "Blank", new { controller = "Home", action = "Blank", id = UrlParameter.Optional });
            routes.MapRoute("Default", 
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = @"[^\.]*" });
        }
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error() {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;
            Response.Clear();
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values["area"] = "";
            routeData.Values["controller"] = "Errors";
            routeData.Values["action"] = "General";
            routeData.Values["exception"] = exception;
            Response.StatusCode = 500;
            if (httpException != null) {
                Response.StatusCode = httpException.GetHttpCode();
                switch (Response.StatusCode) {
                    case 403:
                        routeData.Values["action"] = "Http403";
                        break;
                    case 404:
                        routeData.Values["action"] = "Http404";
                        break;
                }
            }
            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;
            IController errorsController = new ErrorsController();
            HttpContextWrapper wrapper = new HttpContextWrapper(Context);
            var rc = new RequestContext(wrapper, routeData);
            errorsController.Execute(rc);
        }
    }
}