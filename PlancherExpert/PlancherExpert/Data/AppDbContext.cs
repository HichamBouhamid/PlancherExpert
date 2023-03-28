using Microsoft.EntityFrameworkCore;
using PlancherExpert.Models;

namespace PlancherExpert.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Commande> Commande { get; set; }
		public DbSet<Utilisateur> Utilisateur { get; set; }
		public DbSet<CouvrePlancher> CouvrePlancher { get; set; }

	}
}
