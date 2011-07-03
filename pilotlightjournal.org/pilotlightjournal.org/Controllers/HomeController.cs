using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pilotlightjournal.org.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(){ return View(); }

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

        /// <summary>
        /// GET: /Home/Submissions
        /// </summary>
        /// <returns></returns>
        public ActionResult Sample1() { return View(); }
    }
}
