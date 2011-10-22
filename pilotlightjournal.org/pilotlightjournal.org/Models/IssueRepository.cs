using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return dbContext.Issues.Where(issue => issue.IssueId == id).Include(issue => issue.Works).FirstOrDefault();
        }

        public List<Issue> GetIssues() {
            return (from i in dbContext.Issues
                   where i.Completed == true
                   orderby i.ReleaseDate ascending
                   select i).ToList();
        }

        public List<Contributor> GetContributors() {
            return (from i in dbContext.Issues
                    join w in dbContext.Works on i.IssueId equals w.Issue.IssueId
                    join c in dbContext.Contributors on w.Contributor.ContributorId equals c.ContributorId
                    where i.Completed == true
                    orderby c.LastName, c.FirstName ascending
                    select c).ToList();                    
        }

        public List<Contributor> GetContributors(int id) {
            return (from w in dbContext.Works
                    join c in dbContext.Contributors on w.Contributor.ContributorId equals c.ContributorId
                    where w.Issue.IssueId == id
                    orderby c.LastName, c.FirstName ascending
                    select c).ToList();
        }
    }
}