using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using atributos;
using Microsoft.EntityFrameworkCore;

namespace conexion
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
