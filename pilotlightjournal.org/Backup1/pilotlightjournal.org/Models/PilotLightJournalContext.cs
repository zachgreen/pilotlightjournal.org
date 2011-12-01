using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models
{
    public class PilotLightJournalContext : DbContext
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}