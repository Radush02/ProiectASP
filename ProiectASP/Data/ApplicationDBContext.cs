using Microsoft.EntityFrameworkCore;
using TemaASP.Models;

namespace TemaASP.Data
{
    //6.0.25
    public class ApplicationDBContext : DbContext
    {
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
