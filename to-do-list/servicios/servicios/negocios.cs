
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atributos;
using conexion;
using static Azure.Core.HttpHeader;
namespace servicios.procesos
{
    public class servicios
    {
        public TablaDbContent conexion;

        public servicios()
        {
            conexion = new TablaDbContent();
        }

        public bool insertar(tabla insertar)
        {
            try
            {
                conexion.Add(insertar);
                conexion.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw ex; }

        }

        public List<tabla> listar() 
        {
            return conexion.listaDb.ToList();
        }

        public List<tabla> llamar(string campo, string valor) 
        {
            IQueryable<tabla> llamado= conexion.listaDb;

            switch (campo)
            {
                case "ID":
                        
                    if (int.TryParse(valor, out int parseado))
                    {
                        llamado = llamado.Where(t => t.id == parseado);
                    }
                    
                    break;

                case "Tarea":
                    if (!int.TryParse(valor, out parseado))
                    { 
                        llamado= llamado.Where(t=> t.tarea == valor);
                    }
                    break;
                case "Prioridad":
                    if (int.TryParse(valor, out parseado))
                    {
                        llamado = llamado.Where(t => t.prioridad == parseado);
                    }

                    break;
            }

            return llamado.ToList();
        }

    }
}
