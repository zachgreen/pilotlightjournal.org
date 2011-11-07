﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class IssueRepository {
        private PilotLightJournalContext dbContext = new PilotLightJournalContext();

        public Issue GetMostRecent() {
            //return the latest complete issue
            return (from n in dbContext.Issues
                    where n.Completed == true
                    orderby n.ReleaseDate descending
                    select n).FirstOrDefault();
        }

        public Issue GetIssue(int id) {
            //retrieve the specified issue from the database
            return dbContext.Issues.Where(issue => issue.IssueId == id).Include(issue => issue.Works).FirstOrDefault();
        }

        public List<Issue> GetIssues() {
            //get all issues that have been completed and order them by ascending release date
            return (from i in dbContext.Issues
                   where i.Completed == true
                   orderby i.ReleaseDate ascending
                   select i).ToList();
        }

        public List<Contributor> GetContributors() {
            //get all contributers from finished issues (or all if in debug mode) and order them by name
            return (from i in dbContext.Issues
                    join w in dbContext.Works on i.IssueId equals w.Issue.IssueId
                    join c in dbContext.Contributors on w.Contributor.ContributorId equals c.ContributorId
                    where i.Completed == true || AppConfig.InDebug == true
                    orderby c.LastName, c.FirstName ascending
                    select c).ToList();                    
        }

        public List<Contributor> GetContributors(int id) {
            //get all contributors from a particular issue ordered by name
            return (from w in dbContext.Works
                    join c in dbContext.Contributors on w.Contributor.ContributorId equals c.ContributorId
                    where w.Issue.IssueId == id
                    orderby c.LastName, c.FirstName ascending
                    select c).ToList();
        }

        /// <summary>
        /// Public method to determine the number of issues in the database
        /// </summary>
        /// <returns>A integer representing the number of issues in the database</returns>
        public int GetCount() {
            //count the number of issues
            return (from i in dbContext.Issues
                    select i).Count();
        }
    }
}