using Microsoft.EntityFrameworkCore;


namespace PlancherExpertWebServices.Models
{
    public class CouvrePlancherDBContext : DbContext
    {
        public CouvrePlancherDBContext(DbContextOptions<CouvrePlancherDBContext> options) : base(options)
        {
        }
        public DbSet<CouvrePlancher> CouvrePlancher { get; set; }

    }
}
