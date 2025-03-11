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
        DAL.Usuario usuario;

        public Usuario()
        {
            usuario = new DAL.Usuario();
        }

        public void Crear(string nombre, string apellido, string mail, string contraseña, string encriptado)
        {
            try
            {
                usuario.Crear(nombre, apellido, mail, contraseña, encriptado);
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
                usuario.Eliminar(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Se generó un error: " + ex.Message);
            }
        }


        public void Modificar(string nombre, string apellido, string mail, string contraseña, string encriptado, int id)
        {
            try
            {
                usuario.Modificar(nombre, apellido, mail, contraseña, encriptado, id);
            }
            catch (Exception ex)
            {
                throw new Exception("Se generó un error: " + ex.Message);
            }
        }


        public DataTable Seleccionar(int id)
        {
            try
            {
                return usuario.Seleccionar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Se generó un error: " + ex.Message);
            }
        }
    }
}
