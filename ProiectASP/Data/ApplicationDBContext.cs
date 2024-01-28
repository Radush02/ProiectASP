using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProiectASP.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Identity;

namespace ProiectASP.Data
{
    //6.0.25
    public class ApplicationDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AdreseLivrare)
                .WithOne()
                .HasForeignKey<AdresaLivrare>(a => a.ID);

  

            modelBuilder.Entity<Comanda>()
                .HasKey(c => new { c.ID, c.UserID, c.ProdusID });

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Users)
                .WithMany(u => u.Comenzi)  
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Produse)
                .WithMany(p => p.Comenzi)
                .HasForeignKey(c => c.ProdusID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produs>().HasKey(p => p.ID);

            modelBuilder.Entity<Produs>()
            .Property(p => p.Pret)
            .HasColumnType("decimal(18, 2)");

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
