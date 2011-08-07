using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org {
    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                "About",
                "About",
                new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Contact",
                "Contact", 
                new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Submissions",
                "Submissions",
                new { controller = "Home", action = "Submissions", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Archive",
                "Archive",
                new { controller = "Issue", action = "Archive", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "TestingIndex",
                "TestingIndex",
                new { controller = "Home", action = "TestingIndex", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Contributors",
                "Contributors",
                new { controller = "Home", action = "Contributors", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            //Database.SetInitializer<PilotLightJournalContext>(new PilotLightJournalInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error() {
            Exception ex = Server.GetLastError();
            ex.ToString();
        }
    }
}