using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Areas.Issue1.Controllers{
    public class Issue1Controller : Controller {
        private PilotLightJournalContext dbContext = new PilotLightJournalContext();
        private IssueRepository issues = new IssueRepository();

        public Issue1Controller() {}
        public ActionResult Index() { return View(issues.GetIssue(1)); }
        public ActionResult Nicole_Cooley(int page){ return View(page); }
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
