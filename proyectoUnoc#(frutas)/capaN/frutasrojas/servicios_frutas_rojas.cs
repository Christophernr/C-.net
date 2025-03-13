using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace capaN.frutasrojas
{
    public class servicios_frutas_rojas
    { /*AQUI EMPIEZA*/

        private coneccionBD conexion;
        public servicios_frutas_rojas() 
        {
            conexion = new coneccionBD();
        }

        //AQUI EMPIEZAN LOS SP

        public bool InsertarRojas(clase_frutas_rojas rojas)
        {
            try
            {

                var entra = conexion.AbrirConeccion();
                if (entra)
                {
                    conexion.Sentencia = "spInsertarFrutasRojas";
                    conexion.addStringParameter("@nombreRojo", rojas.NameFrutasRojas);
                    conexion.EjecutaStoreProcedure();
                }
                else
                    return false;

                conexion.CerrarConeccion();
                return true;
            }
            catch (Exception ex)
            {
                    throw ex;
            }

            
        }



    }//AQUI TERMINA
    
}
