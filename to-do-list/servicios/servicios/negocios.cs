using atributos;
using conexion;
using System.Globalization;
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
            IQueryable<tabla> llamado = conexion.listaDb;

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
                        llamado = llamado.Where(t => t.tarea.ToLower().Contains(valor.ToLower()));
                    }
                    break;
                case "Prioridad":
                    if (int.TryParse(valor, out parseado))
                    {
                        llamado = llamado.Where(t => t.prioridad == parseado);
                    }

                    break;
                case "Fecha":
                    string[] formatos = { "d/M/yyyy", "dd/MM/yyyy", "d-M-yyyy", "dd-MM-yyyy" };
                    if (DateTime.TryParseExact(valor, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime Fechaparseado))
                    {
                        llamado = llamado.Where(t => t.fecha.Date == Fechaparseado.Date);
                    }

                    break;
            }

            return llamado.ToList();
        }

    }
}
