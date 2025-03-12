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

        public void Modificar(string nombre, string apellido, string mail,  int id)
        {
            try
            {
                string query = "UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, Mail=@mail WHERE IdUsuario=@idUsuario";
                SqlParameter[] parametro =
                {
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido),
                    new SqlParameter("@mail", mail),
                    new SqlParameter("@idUsuario", id)
                };
                helper.EjecutarComando(query, parametro);
            }
            catch
            {
                throw;
            }
        }

        //NO SE USA TODAV
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

        public DataTable SeleccionarTabla()
        {
            try
            {
                string query = "SELECT IdUsuario as Id, Nombre, Apellido, Mail FROM Usuario";
                return helper.EjecutarConsulta(query, null);
            }
            catch
            {
                throw;
            }
        }
    }
}
