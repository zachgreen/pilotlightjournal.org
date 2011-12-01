using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pilotlightjournal.org.Controllers{
    public class ErrorsController : Controller{
        public ActionResult General(Exception exception) { return View("Exception", exception); }
        public ActionResult Http404() { return View("Http404"); }
        public ActionResult Http403() { return View("Http403"); }
    }
}
