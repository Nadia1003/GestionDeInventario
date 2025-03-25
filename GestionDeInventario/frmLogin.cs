using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICIOS;

namespace GestionDeInventario
{
    public partial class frmLogin : FormHelper
    {
        BLL.Usuario bll_usuario;

        public frmLogin()
        {
            InitializeComponent();
            bll_usuario = new BLL.Usuario();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bll_usuario.VerificarAccesoUsuario(txtUsuario.Text, txtContraseña.Text).Ok)
                {
                    DataTable dt = new DataTable();
                    dt = bll_usuario.SeleccionarUsuario(txtUsuario.Text).Data;

                    BE.Usuario usuario = new BE.Usuario()
                    {
                        NombreUsuario = dt.Rows[0]["Usuario"].ToString(),
                        Nombre = dt.Rows[0]["Nombre"].ToString(),
                        Apellido = dt.Rows[0]["Apellido"].ToString(),
                        Mail = dt.Rows[0]["Mail"].ToString(),
                        Contraseña = dt.Rows[0]["Contraseña"].ToString()
                    };

                    BLL.Singleton singleton = BLL.Singleton.GetInstance();
                    singleton.IniciarSesion(usuario);


                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show("Compruebe los datos e ingrese nuevamente.");
                }
            }
            catch
            {
                MessageBox.Show("Se generó un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblOlvideContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmOlvidoContraseña frm = new frmOlvidoContraseña();
            frm.Show();
            this.Hide();
        }
    }
}
