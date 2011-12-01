using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pilotlightjournal.org.Models {
    public class Contributor {
        [Key]
        public int ContributorId { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [Required, MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string ImagePage { get; set; }

        [MaxLength(50)]
        public string ImageCredit { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}