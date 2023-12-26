using Microsoft.EntityFrameworkCore;
using ProiectASP.Models;

namespace ProiectASP.Data
{
    //6.0.25
    public class ApplicationDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AdreseLivrare)
                .WithOne()
                .HasForeignKey<AdresaLivrare>(a => a.ID);



        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<AdresaLivrare> AdresaLivrare { get; set; }
        public DbSet<Comanda> Comanda {  get; set; }
        public DbSet<AppReview> AppReview { get; set; }
        public DbSet<Produs> Produs {  get; set; }
    }
}
