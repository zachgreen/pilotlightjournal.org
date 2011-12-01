using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace pilotlightjournal.org.Models {
    public class Partial {
        [Key]
        public int PartialId { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual Work Work { get; set; }
    }
}