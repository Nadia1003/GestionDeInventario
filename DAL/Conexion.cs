using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        public SqlConnection cadena;

        public Conexion()
        {
            cadena = new SqlConnection("Data Source=DESKTOP-DQVMASA\\MSSQLSERVER01;Initial Catalog=GestionInventario;Integrated Security=True;");
        }

        public void AbrirConexion()
        {
            try
            {
                cadena.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                cadena.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
