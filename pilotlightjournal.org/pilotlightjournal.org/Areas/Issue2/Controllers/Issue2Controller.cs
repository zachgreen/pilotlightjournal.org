using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Areas.Issue2.Controllers{
    public class Issue2Controller : Controller {
        private PilotLightJournalContext dbContext = new PilotLightJournalContext();
        private IssueRepository issues = new IssueRepository();

        public Issue2Controller() {}
        public ActionResult Index() {
            Issue i = issues.GetIssue(2);
            if (i.Completed || AppConfig.InDebug) return View(i);
            else return RedirectToRoute(new { action = "Index",  area = "", controller = "Home" });
        }
        public ActionResult Issue(int workId, int page) {
            var mod = new WorkViewModel() {
                Work = dbContext.Works.FirstOrDefault(w => w.WorkId == workId),
                Page = page
            };
            return View(mod);
        }
        public ActionResult PrintView(int issueId, int workId) {
            var mod = new WorkViewModel() {
                Work = dbContext.Works.FirstOrDefault(w => w.WorkId == workId),
                Page = 0
            };
            return View(mod);
        }

    }
}
