using atributosBanco;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace conexion
{
    public class TablaDbContent : DbContext
    {
        public DbSet<tabla> listaDb { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6NJP2S7\\SQLEXPRESS;Database=SimulacionBanco;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla>().ToTable("BancoTabla");
        }
    }

}