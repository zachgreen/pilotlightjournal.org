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

            routes.MapRoute("About", "About", new { controller = "Home", action = "About" });
            routes.MapRoute("Contact", "Contact", new { controller = "Home", action = "About" });
            routes.MapRoute("Submissions", "Submissions", new { controller = "Home", action = "About" });
            routes.MapRoute("Archive", "Archive", new { controller = "Issue", action = "Archive" });
            routes.MapRoute("Contributors", "Contributors", new { controller = "Home", action = "Contributors" });
            routes.MapRoute("RssFeed", "RssFeed", new { controller = "Home", action = "RssFeed"});
            routes.MapRoute("Blank", "Blank", new { controller = "Home", action = "Blank" });
            routes.MapRoute("Http404", "Http404", new { controller = "Errors", action = "Http404" });
            routes.MapRoute("Http403", "Http403", new { controller = "Errors", action = "Http403" });
            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("Issue",
                "{issueId}",
                new { controller = "Issue", action = "Index"},
                new { controller = @"[^\.]*" });
            routes.MapRoute("Work", 
                "{issueId}/{workId}/{page}", 
                new { controller = "Issue", action = "Work", page = UrlParameter.Optional },
                new { controller = @"[^\.]*" });
        }
        protected void Application_Start() {
            //AreaRegistration.RegisterAllAreas();

            IssueRepository issues = new IssueRepository();
            int count = issues.GetCount();

            //change to my custom view engines
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new pilotlightjournal.org.Models.ViewEngines.PilotLightRazorViewEngine(count));
            ViewEngines.Engines.Add(new pilotlightjournal.org.Models.ViewEngines.PilotLightWebFormViewEngine(count));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //check if we are in debug mode. if so, we want to have access to future issues.
            AppConfig.InDebug = HttpContext.Current.IsDebuggingEnabled;
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