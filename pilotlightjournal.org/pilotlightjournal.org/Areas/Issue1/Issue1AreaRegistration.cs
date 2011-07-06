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
                "Nicole_Cooley_test",
                "Issue1/Nicole_Cooley/{page}",
                new { controller = "Issue1", action = "Nicole_Cooley", page = 1 }
            );
            context.MapRoute(
                "Nicole_Cooley",
                "1/Nicole_Cooley/{page}",
                new { controller = "Issue1", action = "Nicole_Cooley", page = 1 }
            );

            context.MapRoute(
                "Issue 1",
                "1",
                new { controller = "Issue1", action = "Index"}
            );
        }
    }
}
