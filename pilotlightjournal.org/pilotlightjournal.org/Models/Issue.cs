using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class Issue {
        [Key]
        public int IssueId { get; set; }

        [Required, MaxLength(50)]
        public string Controller { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public bool Completed { get; set; }

        [Required, MaxLength(100)]
        public string Url { get; set; }

        public ICollection<Work> Works { get; set; }
    }
}