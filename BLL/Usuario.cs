using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Usuario
    {
        DAL.Usuario dal_usuario;

        public Usuario()
        {
            dal_usuario = new DAL.Usuario();
        }

        public Result<bool> Crear(BE.Usuario usuario)
        {
            try
            {
                dal_usuario.Crear(usuario);
                return Result<bool>.Success(true, "Se creó al usuario correctamente");
            }
            catch (Exception)
            {
                return Result<bool>.Error("Ocurrio un error al crear el usuario. Intente nuevamente.", false);
            }
        }
        public Result<bool> Eliminar(int id)
        {
            try
            {
                dal_usuario.Eliminar(id);
                return Result<bool>.Success(true, "Usuario eliminado exitosamente");
            }
            catch (Exception)
            {
                return Result<bool>.Error("Ocurrió un error al eliminar al usuario. Intente nuevamente.", false);
            }
        }
        public Result<bool> Modificar(BE.Usuario usuario)
        {
            try
            {
                dal_usuario.Modificar(usuario);
                return Result<bool>.Success(true, "Se realizaron las modificaciones correctamente");
            }
            catch (Exception)
            {
                return Result<bool>.Error("Error al modificar al usuario. Intente nuevamente", false);
            }
        }
        public Result<DataTable> SeleccionarUsuario(string usuario)
        {
            try
            {
                return Result<DataTable>.Success(dal_usuario.SeleccionarUsuario(usuario));
            }
            catch (Exception)
            {
                return Result<DataTable>.Error("Se generó un error al seleccionar al usuario. Intente nuevamente.", dal_usuario.SeleccionarUsuario(usuario));
            }
        }
        public Result<DataTable> SeleccionarTabla()
        {
            try
            {
                return Result<DataTable>.Success(dal_usuario.SeleccionarTabla());
            }
            catch (Exception)
            {
                return Result<DataTable>.Error("Se generó un error al traer los datos.", dal_usuario.SeleccionarTabla());
            }
        }
        public Result<bool> VerificarAccesoUsuario(string usuario, string contraseña)
        {
            try
            {
                DataTable dt = SeleccionarUsuario(usuario).Data; //selecciono usuario y contraseña bd

                //comparo contraseña ingresada con almacenada
                return Result<bool>.Success(SERVICIOS.Encriptar.EncriptarCadena(contraseña) == dt.Rows[0][4].ToString());
            }

            catch (Exception)
            {
                return Result<bool>.Error("Se generó un error. Intente nuevamente.", false);
            }

        }
        public Result<string> EncriptarCadena(string cadena)
        {
            try
            {
                return Result<string>.Success(SERVICIOS.Encriptar.EncriptarCadena(cadena));
            }
            catch (Exception)
            {
                return Result<string>.Error("Se generó un error. Intente nuevamente.", SERVICIOS.Encriptar.EncriptarCadena(cadena));
            }
        }
    }
}
