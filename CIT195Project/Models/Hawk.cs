using System.ComponentModel.DataAnnotations;

namespace CIT195Project.Models
{
    public class Hawk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(25)]
        [Display(Name = "Latin Name")]
        public string LatinName { get; set; }

        [Range(1.5, 5.0)] // Wingspan range in feet
        [Display(Name = "Wingspan (ft)")]
        public float Wingspan { get; set; }

        [Required]
        [Display(Name = "Endangered?")]
        public bool IsEndangered { get; set; }

        [Required]
        [StringLength(50)]
        public string Rarity { get; set; }

    }
}
