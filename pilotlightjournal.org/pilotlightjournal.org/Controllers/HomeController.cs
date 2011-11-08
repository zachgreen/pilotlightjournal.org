using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using pilotlightjournal.org.Models;

namespace pilotlightjournal.org.Controllers{
    public class HomeController : Controller{
        private PilotLightJournalContext dbContext = new PilotLightJournalContext();
        private IssueRepository issues = new IssueRepository();

        public ActionResult Index() { return View(); }
        public ActionResult About() { return View(); }
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
        public ActionResult RssFeed() {
            var synFeed = new SyndicationFeed();
            var items = new List<SyndicationItem>();
            foreach (Issue i in issues.GetIssues()) {
                var summary = String.Empty;
                foreach (Work w in i.Works) {
                    summary += "<a href=\"" + Url.Action("Issue", i.Controller, new { area = i.Controller, workId = w.WorkId, page = 1 }, "http")
                        + "\">" + w.Title + "</a> - " + w.Contributor.FirstName + " " + w.Contributor.LastName + "<br /><br />";
                }
                var item = new SyndicationItem(i.Name, null, new Uri(Url.Action("Index", "Issue", new { issueId = i.IssueId }, "http")));
                item.Summary = SyndicationContent.CreateHtmlContent(summary);
                //item.PublishDate = i.ReleaseDate;
                items.Add(item);
            }

            synFeed.Title = SyndicationContent.CreateHtmlContent("Pilot Light");
            synFeed.Description = SyndicationContent.CreateHtmlContent("\"We just wanted the heart's pilot light to keep on burning. / I remember how there, at the edge of the world, was / another world.\" ~Richard Jackson");
            synFeed.Copyright = SyndicationContent.CreateHtmlContent("&copy; Pilot Light");
            synFeed.LastUpdatedTime = DateTime.Now;
            synFeed.Items = items;

            return new FeedResult(new Rss20FeedFormatter(synFeed));
        }
        public ActionResult Blank() { return View(); }
    }
}
