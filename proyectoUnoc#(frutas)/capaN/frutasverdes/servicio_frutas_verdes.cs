using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace capaN.frutasverdes
{
    public class servicio_frutas_verdes
    {   /*AQUI EMPIEZA*/
        private coneccionBD conexion;

        public servicio_frutas_verdes()
        {
            conexion = new coneccionBD();
        }

        //AQUI EMPIEZAN LOS SP

        public bool InsertarVerdes(clase_frutas_verdes verdes)
        {
            try
            {

                var entra = conexion.AbrirConeccion();
                if (entra)
                {
                    conexion.Sentencia = "spInsertarFrutasVerdes";
                    conexion.addStringParameter("@nombre", verdes.NameFrutasVerdes);
                    conexion.addFloatParameter("@precio", verdes.Precio);
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







        //AQUI TERMINA
    }
}
