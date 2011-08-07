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
                    Name = "September 2011",
                    ReleaseDate = DateTime.Parse("2011/09/01"),
                    Completed = true,
                    Url = "1",
                    Works = new List<Work>{
                        new Work(){
                            Title = "The Art of Poetry",
                            Order = 2,
                            Url = "Marianne_Boruch",
                            Contributor = new Contributor(){
                                FirstName = "Marianne",
                                LastName = "Boruch",
                                Bio = "Bio",
                                ImagePage = ""
                            },
                            Pages = new List<Page>(){}
                        },
                        new Work(){
                            Title = "Instable Grammar",
                            Order = 3,
                            Url = "Bill_Olsen",
                            Contributor = new Contributor(){
                                FirstName = "Bill",
                                LastName = "Olsen",
                                Bio = "Third Contributor's Bio",
                                ImagePage = ""
                            },                            
                            Pages = new List<Page>(){
                                new Page{
                                    Order = 1,
                                    Url = "Bill_Olsen_1"
                                },
                                new Page{
                                    Order = 2,
                                    Url = "Bill_Olsen_2"
                                },
                                new Page{
                                    Order = 3,
                                    Url = "Bill_Olsen_3"
                                },
                                new Page{
                                    Order = 4,
                                    Url = "Bill_Olsen_4"
                                },
                                new Page{
                                    Order = 5,
                                    Url = "Bill_Olsen_5"
                                },
                                new Page{
                                    Order = 6,
                                    Url = "Bill_Olsen_6"
                                }
                            }
                        },
                        new Work(){
                            Title = "Poetry and the Difficulty of Documentation",
                            Order = 0,
                            Url = "Nancy_Eimers",
                            Contributor = new Contributor(){
                                FirstName = "Nancy",
                                LastName = "Eimers",
                                Bio = "Second Contributor's Bio",
                                ImagePage = ""
                            },
                            Pages = new List<Page>(){
                                new Page{
                                    Order = 1,
                                    Url = "Nancy_Eimers_1"
                                },
                                new Page{
                                    Order = 2,
                                    Url = "Nancy_Eimers_2"
                                },
                                new Page{
                                    Order = 3,
                                    Url = "Nancy_Eimers_3"
                                },
                                new Page{
                                    Order = 4,
                                    Url = "Nancy_Eimers_4"
                                }
                            }
                        }
                    }
                }
            };

            issues.ForEach(i => context.Issues.Add(i));
        }
    
    }

}