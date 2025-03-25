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

        public void Crear(BE.Usuario usuario)
        {
            string query = "INSERT INTO Usuario VALUES(@nombreUsuario,@nombre,@apellido, @mail ,@contraseña, @contraseñaModificada)";
            SqlParameter[] parametros = {
                    new SqlParameter("@nombreUsuario", usuario.NombreUsuario),
                    new SqlParameter("@nombre", usuario.Nombre),
                    new SqlParameter("@apellido", usuario.Apellido),
                    new SqlParameter("@mail", usuario.Mail),
                    new SqlParameter("@contraseña", usuario.Contraseña),
                    new SqlParameter("@contraseñaModificada", usuario.ContraseñaModificada)
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

        public void Modificar(BE.Usuario usuario)
        {
            string query = "UPDATE Usuario SET ";
            List<string> query_parametros = new List<string>();
            List<SqlParameter> lista_parametros = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(usuario.Nombre))
            {
                lista_parametros.Add(new SqlParameter("@nombre", usuario.Nombre));
                query_parametros.Add("Nombre = @nombre");
            }

            if (!string.IsNullOrEmpty(usuario.Apellido))
            {
                lista_parametros.Add(new SqlParameter("@apellido", usuario.Apellido));
                query_parametros.Add("Apellido=@apellido");
            }

            if (!string.IsNullOrEmpty(usuario.Mail))
            {
                lista_parametros.Add(new SqlParameter("@mail", usuario.Mail));
                query_parametros.Add("Mail=@mail");
            }

            if (!string.IsNullOrEmpty(usuario.Contraseña))
            {
                lista_parametros.Add(new SqlParameter("@contraseña", usuario.Contraseña));
                query_parametros.Add("Contraseña=@contraseña");
            }

            if (!string.IsNullOrEmpty(usuario.ContraseñaModificada.ToString()))
            {
                lista_parametros.Add(new SqlParameter("@contraseñaModificada", usuario.ContraseñaModificada));
                query_parametros.Add("ContraseñaModificada=@contraseñaModificada");
            }

            query += string.Join(",", query_parametros);
            lista_parametros.Add(new SqlParameter("@usuario", usuario.NombreUsuario));
            query += " WHERE Usuario=@usuario";
            helper.EjecutarComando(query, lista_parametros.ToArray());
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
