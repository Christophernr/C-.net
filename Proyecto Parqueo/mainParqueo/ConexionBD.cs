using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace mainParqueo
{
    public class ConexionBD: DbContext
    {
        public DbSet<Roles> roles { get; set; }
        public DbSet<Parqueo> parqueos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Vehiculos> vehiculos { get; set; }
        public DbSet<RolesUsuario> rolesUsuarios { get; set; }
        public DbSet<Spots> spots { get; set; }
        public DbSet<Ocupacion> ocupacions { get; set; }
        public DbSet<Logs> logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6NJP2S7\\SQLEXPRESS;Database=Parqueo;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().ToTable("ROLES");

            modelBuilder.Entity<Parqueo>().ToTable("PARQUEO");

            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.Entity<Vehiculos>().ToTable("VEHICULOS");

            modelBuilder.Entity<RolesUsuario>().ToTable("ROLESUSUARIO");

            modelBuilder.Entity<Spots>().ToTable("SPOTS");

            modelBuilder.Entity<Ocupacion>().ToTable("OCUPACION");

            modelBuilder.Entity<Logs>().ToTable("LOGS");

            //configurcion para hacer unico el valor de estas tablas: "unique"
            modelBuilder.Entity<Vehiculos>()
                .HasIndex(v => v.placa)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.usuario)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.email)
                .IsUnique();
        }


        public ConexionBD (DbContextOptions<ConexionBD> options) :  base (options)
        {

        }
        //Add-Migration Inicial -Project conectar -StartupProject mainProyecto

    }
}
