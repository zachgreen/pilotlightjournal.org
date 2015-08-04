

using System.ComponentModel.DataAnnotations;

namespace pilotlightjournal.org.Models
{
    public class Partial {
        [Key]
        public int PartialId { get; set; }

        [Required, System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string Type { get; set; }

        [Required, System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string Name { get; set; }

        public virtual Work Work { get; set; }
    }
}