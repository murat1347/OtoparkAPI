using Microsoft.EntityFrameworkCore;
using Otopark.WebAPI.Core.Domain;
using Otopark.WebAPI.Persistance.Configrations;

namespace Otopark.WebAPI.Persistance.Context
{
    public class OtoparkJwtContext : DbContext
    {
        public OtoparkJwtContext(DbContextOptions<OtoparkJwtContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
