using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Controllers
{
    public class HomeController : Controller
    {
        private IssueRepository issues = new IssueRepository();

        /// <summary>
        /// GET: /Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() { return View(); }

        /// <summary>
        /// GET: /Home/AboutUs
        /// </summary>
        /// <returns></returns>
        public ActionResult About() { return View(); }

        /// <summary>
        /// GET: /Home/Contact
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact() { return View(); }

        /// <summary>
        /// GET: /Home/Submissions
        /// </summary>
        /// <returns></returns>
        public ActionResult Submissions() { return View(); }

        public ActionResult Contributors() {
            List<ContributorViewModel> models = new List<ContributorViewModel>();
            ContributorViewModel model = null;

            //first get the contributors
            List<Contributor> contributors = issues.GetContributors();

            //for each contributor, find the issues they are in
            foreach(Contributor c in contributors){
                model = new ContributorViewModel();
                model.Contributor = c;
                model.Issues = new List<Issue>();

                foreach (Work w in c.Works) {
                    if (!model.Issues.Contains(w.Issue)) model.Issues.Add(w.Issue);
                }

                models.Add(model);
            }
                        
            return View(models);         
        }
    }
}
