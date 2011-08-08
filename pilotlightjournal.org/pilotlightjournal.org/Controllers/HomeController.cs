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

        public ActionResult Contributors() { return View(issues.GetContributors()); }
    }
}
