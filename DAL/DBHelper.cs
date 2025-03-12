using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        Conexion con;

        public DBHelper()
        {
            con = new Conexion();
        }

        //CONSULTA GENERICA PARA INSERT, DELETE, UPDATE
        public void EjecutarComando(string query, SqlParameter[] parametros)
        {
            try
            {
                if (con.cadena.State == ConnectionState.Closed)             //???//
                {
                    con = new Conexion();
                } 
                using (con.cadena)
                {
                    con.AbrirConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con.cadena;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    cmd.ExecuteNonQuery();
                    con.CerrarConexion();
                }
            }
            catch
            {
                throw;
            }
        }

        //CONSULTA GENERICA PARA SELECT
        public DataTable EjecutarConsulta(string query, SqlParameter parametro)
        {
            try
            {
                if (con.cadena.State == ConnectionState.Closed)      //???//
                {
                    con = new Conexion();
                }
                using (con.cadena)
                {
                    con.AbrirConexion();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(query, con.cadena);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con.cadena;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    if (parametro != null)
                    {
                        cmd.Parameters.Add(parametro);
                    }

                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    con.CerrarConexion();
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
