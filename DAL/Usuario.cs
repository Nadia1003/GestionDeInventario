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

        public void Crear(string nombreUsuario, string nombre, string apellido, string mail, string contraseña)
        {
            string query = "INSERT INTO Usuario VALUES(@nombreUsuario,@nombre,@apellido, @mail ,@contraseña)";
            SqlParameter[] parametros = {
                    new SqlParameter("@nombreUsuario", nombreUsuario),
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido),
                    new SqlParameter("@mail", mail),
                    new SqlParameter("@contraseña", contraseña)
            };

            helper.EjecutarComando(query, parametros);
        }

        public void Eliminar(int id)
        {
            string query = "DELETE Usuario WHERE IdUsuario=@Id";
            SqlParameter[] parametro =
            {
                new SqlParameter("@Id",id)
            };
            helper.EjecutarComando(query, parametro);
        }

        public void Modificar(string usuario, string nombre = null, string apellido = null, string mail = null, string contraseña = null)
        {
            string query = "UPDATE Usuario SET ";
            string query_parametros = "";

            List<SqlParameter> lista_parametros = new List<SqlParameter>();
            SqlParameter[] vector_parametro;

            lista_parametros.Add(new SqlParameter("@usuario", usuario));

            if (!string.IsNullOrEmpty(nombre))
            {
                lista_parametros.Add(new SqlParameter("@nombre", nombre));
                query_parametros += "Nombre = @nombre";
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                lista_parametros.Add(new SqlParameter("@apellido", apellido));
                query_parametros += "Apellido=@apellido";
            }

            if (!string.IsNullOrEmpty(mail))
            {
                lista_parametros.Add(new SqlParameter("@mail", mail));
                query_parametros += "Mail=@mail";
            }

            if (!string.IsNullOrEmpty(contraseña))
            {
                lista_parametros.Add(new SqlParameter("@contraseña", contraseña));
                query_parametros += "Contraseña=@contraseña";
            }

            query += string.Join(",", query_parametros);
            query += " WHERE Usuario=@usuario";
            vector_parametro = lista_parametros.ToArray();
            helper.EjecutarComando(query, vector_parametro);
        }

        public DataTable SeleccionarUsuario(string usuario)
        {
            string query = "SELECT Usuario, Nombre, Apellido, Mail, Contraseña FROM Usuario WHERE Usuario=@Usuario";
            SqlParameter parametro = new SqlParameter("@Usuario", usuario);

            return helper.EjecutarConsulta(query, parametro);
        }

        public DataTable SeleccionarTabla()
        {
            string query = "SELECT IdUsuario as Id, Usuario, Nombre, Apellido, Mail FROM Usuario";
            return helper.EjecutarConsulta(query, null);
        }
    }
}
