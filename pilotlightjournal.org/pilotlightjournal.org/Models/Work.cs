using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class Work {
        [Key]
        public int WorkId { get; set; }

        //[ForeignKey("Issue"), Required]
        //public int IssueId { get; set; }

        //[ForeignKey("Contributor"), Required]
        //public int ContributorId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public int Order { get; set; }

        [Required, MaxLength(100)]
        public string Url { get; set; }

        public virtual Issue Issue { get; set; }
        public virtual Contributor Contributor { get; set; }
    }
}