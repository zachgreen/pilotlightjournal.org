using System.Web.Mvc;

namespace pilotlightjournal.org.Areas.Issue2 {
    public class Issue2AreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Issue2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute("Work View 2", "2/{workId}/{page}", new { controller = "Issue2", action = "Issue" });
            context.MapRoute("Print View 2", "print/{issueId}/{workId}", new { controller = "Issue2", action = "PrintView" });
            context.MapRoute("Issue 2", "2", new { controller = "Issue2", action = "Index" });
        }
    }
}
