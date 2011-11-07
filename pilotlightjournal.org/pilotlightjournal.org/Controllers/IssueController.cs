using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Controllers{
    public class IssueController : Controller {
        private IssueRepository issues = null;
        private PilotLightJournalContext dbContext = null;

        #region Constructor
        public IssueController() {
            dbContext = new PilotLightJournalContext();
            issues = new IssueRepository();
        }
        #endregion

        #region Action Methods
        public ActionResult Archive(){ return View(issues.GetIssues()); }
        public ActionResult Index(int issueId) {
            //verfiy that either the issue is completed or that we are in debug mode to prevent showing a future issue to users.
            Issue i = issues.GetIssue(issueId);
            if (i.Completed || AppConfig.InDebug) return View(i);
            else return RedirectToRoute(new { action = "Index", area = "", controller = "Home" });
        }
        public ActionResult Work(int workId, int page) {
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
        #endregion
    }
}
