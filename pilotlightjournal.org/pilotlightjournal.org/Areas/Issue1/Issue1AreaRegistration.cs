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
                "Nicole_Cooley",
                "Issue1/Nicole_Cooley/{page}",
                new { controller = "Issue", action = "Nicole_Cooley", page = 1 }
            );
        }
    }
}
