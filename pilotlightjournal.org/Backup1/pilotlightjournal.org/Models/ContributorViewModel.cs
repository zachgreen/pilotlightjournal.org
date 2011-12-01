using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class ContributorViewModel {
        public Contributor Contributor { get; set; }
        public List<Issue> Issues { get; set; }
    }
}