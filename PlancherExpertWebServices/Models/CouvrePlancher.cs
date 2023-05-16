using System.ComponentModel.DataAnnotations;

namespace PlancherExpertWebServices.Models
{
    public class CouvrePlancher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float PrixMa { get; set; }
        [Required]
        public float PrixMo { get; set; }
        [Required]
        public string Type { get; set; } = null!;

    }
}
