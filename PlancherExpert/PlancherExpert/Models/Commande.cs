using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlancherExpert.Models
{
	public class Commande
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int longueur { get; set; }
		[Required]
		public int largeur { get; set; }

		[ForeignKey("Utilisateur")]
		public int? User_Id { get; set; }	
		public Utilisateur? User { get; set; }

		[ForeignKey("CouvrePlancher")]
		public int CP_Id { get; set; }
		public CouvrePlancher? CouvreP { get; set; }



	}
}
