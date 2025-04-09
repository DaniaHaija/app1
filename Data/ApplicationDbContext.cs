using app1.Modle;
using Microsoft.EntityFrameworkCore;

namespace app1.Data
{
    public class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=app708;Trusted_connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);

                entity.Property(p => p.Description)
               .HasColumnType("varchar(max)")
               .HasMaxLength(100);

                entity.Property(p => p.Price)
               .HasColumnType("decimal(6,2)"); 





            });
        }

       
        public DbSet<Categre> Categres { get; set;}
    }
}
