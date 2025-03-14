using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Crear(string nombreUsuario, string nombre, string apellido, string mail, string contraseña)
        {
            try
            {
                dal_usuario.Crear(nombreUsuario, nombre, apellido, mail, contraseña);
            }
            catch (Exception ex)
            {
                throw new Exception("Se generó un error: " + ex.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                dal_usuario.Eliminar(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Se generó un error: " + ex.Message);
            }
        }

        public void Modificar(string nombre, string apellido, string mail,  int id)
        {
            try
            {
                dal_usuario.Modificar(nombre, apellido, mail,  id);
            }
            catch (Exception ex)
            {
                throw new Exception("Se generó un error: " + ex.Message);
            }
        }

        public DataTable SeleccionarUsuario(string usuario)
        {
            try
            {
                return dal_usuario.SeleccionarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Se generó un error: " + ex.Message);
            }
        }

        public DataTable SeleccionarTabla()
        {
            try
            {
                return dal_usuario.SeleccionarTabla();
            }
            catch (Exception ex)
            {

                throw new Exception("Se generó un error: "+ ex.Message);
            }
        }

        public bool VerificarAccesoUsuario(string usuario, string contraseña)
        {
            DataTable dt = SeleccionarUsuario(usuario); //selecciono usuario y contraseña bd

            //comparo contraseña ingresada con almacenada
            return SERVICIOS.Encriptar.EncriptarCadena(contraseña) == dt.Rows[0][1].ToString();
        }
    }
}
