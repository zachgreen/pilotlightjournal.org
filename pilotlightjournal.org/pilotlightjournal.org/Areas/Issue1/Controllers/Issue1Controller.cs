using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Areas.Issue1.Controllers{
    public class Issue1Controller : Controller{
        private IssueRepository issues = null;

        public Issue1Controller() {
            issues = new IssueRepository();
        }

        public ActionResult Index() {
            return View(issues.GetIssue(3));
        }

        public ActionResult Nicole_Cooley(int page){
            return View(page);
        }

    }
}
