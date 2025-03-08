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
        SqlConnection con;

        public void Conectar()
        {
            using (con = new SqlConnection("Data Source=DESKTOP-DQVMASA\\MSSQLSERVER01;Initial Catalog=GestionInventario;Integrated Security=True;Trust Server Certificate=True"))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
