using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using entidades;
namespace capaConexion
{
    public class AppDbContext : DbContext
    {

        public DbSet<Contactos> contactosDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6NJP2S7\\SQLEXPRESS;Database=CONTACTOS;Trusted_Connection=True; TrustServerCertificate=True;");
            }
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contactos>().ToTable("contactos");
        }
    }

}
