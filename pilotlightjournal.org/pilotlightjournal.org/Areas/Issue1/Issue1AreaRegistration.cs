using System.Web.Mvc;

namespace pilotlightjournal.org.Areas.Issue1 {
    public class Issue1AreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Issue1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute("Work View", "1/{workId}/{page}", new { controller = "Issue1", action = "Issue" });
            context.MapRoute("Print View", "print/{issueId}/{workId}", new { controller = "Issue1", action = "PrintView" });
            context.MapRoute("Issue 1", "1", new { controller = "Issue1", action = "Index"});
        }
    }
}
