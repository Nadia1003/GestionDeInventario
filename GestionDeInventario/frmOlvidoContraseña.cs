using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace GestionDeInventario
{
    public partial class frmOlvidoContraseña : FormHelper
    {
        BLL.Usuario bllusuario;
        BE.Usuario usuario;
        public frmOlvidoContraseña()
        {
            InitializeComponent();
            bllusuario = new BLL.Usuario();
            usuario = new BE.Usuario();
        }

        public void LimpiarCasillas()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nueva_contraseña, confirmacion_contraseña;

            if (bllusuario.SeleccionarUsuario(txtUsuario.Text).Data.Rows.Count > 0)
            {
                usuario.NombreUsuario = txtUsuario.Text;
                //BLL.Singleton _singleton = BLL.Singleton.GetInstance();
                //_singleton.usuario = usuario;
            }

            nueva_contraseña = bllusuario.EncriptarCadena(txtContraseña.Text).Data;
            confirmacion_contraseña = bllusuario.EncriptarCadena(txtConfirmarContraseña.Text).Data;

            if (nueva_contraseña == confirmacion_contraseña)
            {
                usuario.Contraseña = nueva_contraseña;
                //BLL.Singleton.GetInstance().usuario;
                ValidarResultado(bllusuario.Modificar(usuario));
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
            LimpiarCasillas();
        }
    }
}
