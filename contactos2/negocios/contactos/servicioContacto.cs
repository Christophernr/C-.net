using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using negocios.contactos;
using entidades;
using capaConexion;
using Microsoft.EntityFrameworkCore;

namespace negocios.contactos
{
    public class servicioContacto
    {
        public AppDbContext conexion;

        public servicioContacto() 
        { 
            conexion= new AppDbContext();
        }

        public bool insertar(Contactos contacto)
        {
            try
            {
                conexion.contactosDb.Add(contacto);
                conexion.SaveChanges();
                return true;

            }
            catch (Exception ex) { throw ex; }
        }

        public bool Eliminar(Contactos contactos)
        {
            try
            { 
            
                conexion.contactosDb.Remove(contactos);
                conexion.SaveChanges();

                bool vacia = !conexion.contactosDb.Any(); 

                if (vacia)
                {

                    var reseteo = "DBCC CHECKIDENT('Contactos',RESEED,0);";
                    conexion.Database.ExecuteSqlRaw(reseteo);
                }
                return true;


            }catch (Exception ex) { throw ex; }
        }

        public bool modificar(Contactos contactos)
        {
            try
            { 
                conexion.contactosDb.Update(contactos);
                conexion.SaveChanges();
                return true;




            }catch (Exception ex) { throw ex; }

        }

        public List<Contactos> Obtener()
        { 
            return conexion.contactosDb.ToList();
        }
    }
}
