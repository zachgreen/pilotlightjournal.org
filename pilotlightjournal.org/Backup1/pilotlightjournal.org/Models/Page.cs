using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace pilotlightjournal.org.Models {
    public class Page {
        [Key]
        public int PageId { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public string Url { get; set; }
    }
}