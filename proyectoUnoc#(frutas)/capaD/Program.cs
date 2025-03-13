using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace CapaDatos
{
    public class coneccionBD
    {
        private SqlConnection SQL_CON;
        private SqlCommand SQL_CMD;
        private SqlDataReader SQL_RS;
        public String Sentencia;

        private string BD_SQL = "frutascolor";
        private string Server = "SAMANTHA";
        public coneccionBD()
        {
            SQL_CON = new SqlConnection();
        }

        public bool AbrirConeccion()
        {
            try
            {
                // Abre la conección solo si esa cerrada
                if (SQL_CON == null) SQL_CON = new SqlConnection();

                if (SQL_CON != null && SQL_CON.State == ConnectionState.Closed)
                {
                    SQL_CON.ConnectionString = "Data Source=" + Server + ";Initial Catalog=" + BD_SQL + ";Integrated Security=SSPI;";

                    //SQL_CON.ConnectionString = "Data Source=" + Server + ";Initial Catalog=" + BD_SQL + ";Integrated Security=false;User ID=sa;Password=3105r;";
                    SQL_CON.Open();
                    SQL_CMD = new SqlCommand();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CerrarConeccion()
        {
            try
            {
                if (SQL_CMD != null)
                    SQL_CMD = null;
                if (SQL_RS != null)
                {
                    SQL_RS.Close();
                    SQL_RS = null;
                }
                if (SQL_CON != null)
                {
                    SQL_CON.Close();
                    SQL_CON = null;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodos para consultas de tipo Texto
        public bool EjecutaConsulta()
        {
            SQL_CMD.Connection = SQL_CON;
            SQL_CMD.CommandText = Sentencia;
            SQL_CMD.CommandType = CommandType.Text;

            try
            {
                SQL_RS = SQL_CMD.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EjecutaConsultaValores()
        {
            SQL_CMD.Connection = SQL_CON;
            SQL_CMD.CommandText = Sentencia;
            SQL_CMD.CommandType = CommandType.Text;

            try
            {
                SQL_RS = SQL_CMD.ExecuteReader();
                if (SQL_RS.Read() == true) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EjecutaSentancia()
        {
            SQL_CMD.Connection = SQL_CON;
            SQL_CMD.CommandText = Sentencia;
            SQL_CMD.CommandType = CommandType.Text;

            try
            {
                SQL_CMD.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodos para consultas de tipo StoreProcedure
        public bool EjecutaStoreProcedure()
        {
            SQL_CMD.Connection = SQL_CON;
            SQL_CMD.CommandText = Sentencia;
            SQL_CMD.CommandType = CommandType.StoredProcedure;
            var rowsAfectadas = 0;

            try
            {
                rowsAfectadas = SQL_CMD.ExecuteNonQuery();
                return rowsAfectadas > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetStoreProcedure()
        {
            SQL_CMD.Connection = SQL_CON;
            SQL_CMD.CommandText = Sentencia;
            SQL_CMD.CommandType = CommandType.StoredProcedure;

            try
            {
                SQL_RS = SQL_CMD.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetuniqueStoreProcedure()
        {
            SQL_CMD.Connection = SQL_CON;
            SQL_CMD.CommandText = Sentencia;
            SQL_CMD.CommandType = CommandType.StoredProcedure;

            try
            {
                SQL_RS = SQL_CMD.ExecuteReader();
                if (SQL_RS.Read() == true) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // agregar parametros
        public void addDateParameter(String nombre, DateTime valor)
        {
            try
            {
                if (SQL_CMD != null)
                {
                    SqlParameter dateParam = new SqlParameter(nombre, SqlDbType.Date);
                    dateParam.Value = valor;
                    SQL_CMD.Parameters.Add(dateParam);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addStringParameter(String nombre, String valor)
        {
            try
            {
                if (SQL_CMD != null)
                {
                    SqlParameter stringParam = new SqlParameter(nombre, SqlDbType.NVarChar);
                    stringParam.Direction = ParameterDirection.Input;
                    stringParam.Value = valor;
                    SQL_CMD.Parameters.Add(stringParam);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addIntParameter(String nombre, Int64 valor)
        {
            try
            {
                if (SQL_CMD != null)
                {
                    SqlParameter intParam = new SqlParameter(nombre, SqlDbType.Int);
                    intParam.Value = valor;
                    SQL_CMD.Parameters.Add(intParam);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addFloatParameter(String nombre, float valor)
        {
            try
            {
                if (SQL_CMD != null)
                {
                    SqlParameter floatParam = new SqlParameter(nombre, SqlDbType.Float);
                    floatParam.Value = valor;
                    SQL_CMD.Parameters.Add(floatParam);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String ObtenerCampo(int indice)
        {
            try
            {
                return SQL_RS[indice].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetSQL_RS()
        {
            return SQL_RS;
        }

    }
}
