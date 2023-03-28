using System.ComponentModel.DataAnnotations;

namespace PlancherExpert.Models
{
	public class CouvrePlancher
	{
		[Required]
		public float prixMa { get; set; }
		[Required]
		public float prixMo { get; set; }
		[Required]
		public string type { get; set; } = null!;
		[Key]
		public int id { get; set; }
	}
}
