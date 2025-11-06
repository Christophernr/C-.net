using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atributosBanco;
using conexion;
namespace servicios.serviciosBanco
{
    public class serviciosBancoSimulador
    {
        public TablaDbContent conectar;

        public serviciosBancoSimulador()
        {
            conectar = new TablaDbContent();
        }


        public bool insertar(tabla ingresar)
        {
            try
            {
                conectar.Add(ingresar);
                conectar.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}