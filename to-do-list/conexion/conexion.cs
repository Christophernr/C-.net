using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using atributos;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace conexion
{
    public class TablaDbContent : DbContext
    {
        public DbSet<tabla> listaDb { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6NJP2S7\\SQLEXPRESS;Database=porHacer;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla>().ToTable("TAREAS");
        }
    }

}
