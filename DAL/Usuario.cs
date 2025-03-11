using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Usuario
    {
        DBHelper helper;

        public Usuario()
        {
            helper = new DBHelper();
        }

        public void Crear(string nombre, string apellido, string mail, string contraseña, string encriptado)
        {
            try
            {
                string query = "INSERT INTO Usuario VALUES(@nombre,@apellido, @mail ,@contraseña, @encriptado)";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido),
                    new SqlParameter("@mail", mail),
                    new SqlParameter("@contraseña", contraseña),
                    new SqlParameter("@encriptado", encriptado)
                };

                helper.EjecutarComando(query, parametros);
            }
            catch
            {
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                string query = "DELETE Usuario WHERE IdUsuario=@Id";
                SqlParameter[] parametro =
                {
                    new SqlParameter("@Id",id)
                };
                helper.EjecutarComando(query, parametro);
            }
            catch
            {
                throw;
            }
        }

        public void Modificar(string nombre, string apellido, string mail, string contraseña, string encriptado, int id)
        {
            try
            {
                string query = "UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, Mail=@mail, Contraseña=@contraseña, Encriptado=@encriptado WHERE IdUsuario=@IdUsuario";
                SqlParameter[] parametro =
                {
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido),
                    new SqlParameter("@mail", mail),
                    new SqlParameter("@contraseña", contraseña),
                    new SqlParameter("@encriptado", encriptado),
                    new SqlParameter("@IdUsuario", id)
                };
                helper.EjecutarComando(query, parametro);
            }
            catch
            {
                throw;
            }
        }

        public DataTable Seleccionar(int id)
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE IdUsuario=@Id";
                SqlParameter parametro = new SqlParameter("@Id", id);

                return helper.EjecutarConsulta(query, parametro);
            }
            catch
            {
                throw;
            }
        }
    }
}
