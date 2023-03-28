using System.ComponentModel.DataAnnotations;

namespace PlancherExpert.Models
{
	public class Utilisateur
	{

		public string UserType { get; set; } = "Supervisor";
		[Required]
		public string Name { get; set; } = null!;
		[Required]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
		public string Email { get; set; } = null!;
		[Required]
		public string Password { get; set; } = null!;
		[Key]
		public int Id { get; set; }
	}
}
