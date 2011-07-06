using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Controllers{
    public class IssueController : Controller {
        private IssueRepository issues = null;

        public IssueController() {
            issues = new IssueRepository();
        }

        public ActionResult Archive(){
            return View(issues.GetIssues());
        }

    }
}
