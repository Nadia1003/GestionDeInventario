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
    public partial class frmLogin : Form
    {
        BE.Usuario be_usuario;
        BLL.Usuario bll_usuario;
        public frmLogin()
        {
            InitializeComponent();
            be_usuario = new BE.Usuario();
            bll_usuario = new BLL.Usuario();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                be_usuario.NombreUsuario = txtUsuario.Text;
                if (bll_usuario.VerificarAccesoUsuario(be_usuario.NombreUsuario, txtContraseña.Text))
                    MessageBox.Show("OK");
            }
            catch
            {
                MessageBox.Show("Se generó un error, compuebe los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
