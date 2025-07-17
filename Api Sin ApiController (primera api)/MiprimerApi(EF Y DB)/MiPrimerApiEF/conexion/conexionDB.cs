using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
using MiPrimerApiEF.Models;



namespace MiPrimerApiEF.conexion
{
    public class conexionDB: DbContext
    {
        public DbSet<tabla_producto> tabla_producto { get; set; }

        public conexionDB (DbContextOptions<conexionDB> options) : base(options) 
        {
        
        }
    }
}
