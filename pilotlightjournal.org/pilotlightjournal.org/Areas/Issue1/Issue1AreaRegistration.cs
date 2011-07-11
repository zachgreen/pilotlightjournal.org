using System.Web.Mvc;

namespace pilotlightjournal.org.Areas.Issue1 {
    public class Issue1AreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Issue1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Work View",
                "1/{workId}/{page}",
                new { controller = "Issue1", action = "Issue" }
            );

            //context.MapRoute(
            //    "Nicole_Cooley",
            //    "1/{action}/{page}",
            //    new { controller = "Issue1", page = 1 }
            //);
            //context.MapRoute(
            //    "Nicole_Cooley_test",
            //    "Issue1/Nicole_Cooley/{page}",
            //    new { controller = "Issue1", action = "Nicole_Cooley", page = 1 }
            //);

            context.MapRoute(
                "Issue 1",
                "1",
                new { controller = "Issue1", action = "Index"}
            );
        }
    }
}
