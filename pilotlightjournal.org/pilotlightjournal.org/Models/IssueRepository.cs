using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class IssueRepository {
        private PilotLightJournalContext dbContext = new PilotLightJournalContext();

        public Issue GetMostRecent() {
            //return the latest complete issue
            IQueryable<Issue> issues =  from n in dbContext.Issues
                                        where n.Completed == true
                                        orderby n.ReleaseDate descending
                                        select n;
            return issues.FirstOrDefault();
        }

        public Issue GetIssue(int id) {
            return dbContext.Issues.FirstOrDefault(issue => issue.IssueId == id);
        }

        public List<Issue> GetIssues() {
            return (from i in dbContext.Issues
                   where i.Completed == true
                   orderby i.ReleaseDate ascending
                   select i).ToList();
        }
    }
}