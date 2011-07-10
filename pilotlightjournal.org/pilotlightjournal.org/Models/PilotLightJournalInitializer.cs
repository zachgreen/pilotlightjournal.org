using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class PilotLightJournalInitializer : DropCreateDatabaseAlways<PilotLightJournalContext> {
        protected override void Seed(PilotLightJournalContext context) {
            var issues = new List<Issue>{
                new Issue(){
                    IssueId = 0,
                    Controller = "Issue1",
                    Name = "Issue 1",
                    ReleaseDate = DateTime.Parse("2011/09/01"),
                    Completed = true,
                    Url = "/1",
                    Works = new List<Work>{
                        new Work(){
                            WorkId = 1,
                            Title = "Writing the Body: Tory Dent’s <i>Black Milk</i>",
                            Order = 0,
                            Url = "Nicole_Cooley",
                            Contributor = new Contributor(){
                                ContributorId = 0,
                                FirstName = "Nicole",
                                LastName = "Cooley",
                                Bio = "Nicole Cooley's Bio",
                                ImagePage = ""
                            }
                        }
                    }
                },
                new Issue(){
                    IssueId = 1,
                    Controller = "Issue2",
                    Name = "Issue 2",
                    ReleaseDate = DateTime.Parse("2011/10/01"),
                    Completed = true,
                    Url = "/2"
                },
                new Issue(){
                    IssueId = 2,
                    Controller = "Issue3",
                    Name = "Issue 3",
                    ReleaseDate = DateTime.Parse("2011/11/01"),
                    Completed = false,
                    Url = "/3"
                }
            };

            issues.ForEach(i => context.Issues.Add(i));
        }
    
    }

}