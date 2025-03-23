using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class Singleton
    {
        //constructor privado para evitar creaciones de instancias y usar metodo estatico para acceder
        private Singleton()
        {

        }

        private static Singleton instancia;

        public BE.Usuario usuario { get; set; }

        public static Singleton GetInstance()
        {
            if (instancia == null)
            {
                instancia = new Singleton();
            }
            return instancia;
        }

        public void IniciarSesion(BE.Usuario _usuario)
        {
            usuario = _usuario;
        }

        public void CerrarSesion()
        {
            usuario = null;
        }
    }
}
