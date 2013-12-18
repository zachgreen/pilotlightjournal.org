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
        public ActionResult Archive(){ return View(issues.GetIssues().OrderByDescending(x => x.ReleaseDate).ToList()); }
        public ActionResult Index(int issueId) {
            //adding in special clause to redirect issueid 42 to the next issue
            if (issueId != 42) {
                //verfiy that either the issue is completed or that we are in debug mode to prevent showing a future issue to users.
                Issue i = issues.GetIssue(issueId);
                if (i != null && (i.Completed || AppConfig.InDebug))
                {
                    if (issueId == 5)
                    {
                        return View("YorkIndex", i);
                    }
                    return View(i);
                }
            } else {
                var i = issues.GetAllIssues().FindAll(x => !x.Completed).OrderBy(x => x.ReleaseDate);
                if (i.Count() > 0) return View("YorkIndex", i.ElementAt(0));
            }
            
            //the issue wasn't found, send the user a 404
            return RedirectToRoute(new { action = "Http404", controller = "Errors" });
        }
        public ActionResult Work(int issueId, int workId, int page) {
            bool workFound = false;

            //adding in special clause to redirect issueid 42 to the next issue
            if (issueId != 42) {
                //make sure the issue is active
                Issue i = issues.GetIssue(issueId);

                //verify an issue exists with that id, it is completed (or we are in debug), and it contains the work id parameter
                if (i != null && (i.Completed || AppConfig.InDebug) && i.Works.Count(x => x.WorkId == workId) > 0) {
                    workFound = true;
                }
            } else {
                //special testing mode
                if(issues.GetAllIssues().FindAll(x => !x.Completed).OrderBy(x => x.ReleaseDate).Count() > 0) workFound = true;
            }

            if (workFound) {
                var model = new WorkViewModel() {
                    Work = dbContext.Works.FirstOrDefault(w => w.WorkId == workId),
                    Page = page
                };

                //manaully reassign the issue id in case the special debug code of 42 was used. this will ensure links use the proper address
                model.Work.Issue.IssueId = issueId;
                return View(model);
            } else
                //the work wasn't found, send the user a 404
                return RedirectToRoute(new { action = "Http404", controller = "Errors" });
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
