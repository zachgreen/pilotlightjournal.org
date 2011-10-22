using System.Web.Mvc;

namespace pilotlightjournal.org.Areas.Issue3 {
    public class Issue3AreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Issue3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute("Work View 3", "3/{workId}/{page}", new { controller = "Issue3", action = "Issue" });
            context.MapRoute("Print View 3", "print/{issueId}/{workId}", new { controller = "Issue3", action = "PrintView" });
            context.MapRoute("Issue 3", "3", new { controller = "Issue3", action = "Index" });
        }
    }
}
