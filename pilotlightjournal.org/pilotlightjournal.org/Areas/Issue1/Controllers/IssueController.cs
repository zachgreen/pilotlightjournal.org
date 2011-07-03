using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pilotlightjournal.org.Areas.Issue1.Controllers{
    public class IssueController : Controller{
        //
        // GET: /Issue1/Default1/

        public ActionResult Nicole_Cooley(int page){
            return View(page);
        }

    }
}
