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

namespace GestionDeInventario
{
    public partial class frmUsuarios : Form
    {
        public BLL.Usuario usuario;
        public frmUsuarios()
        {
            InitializeComponent();
        }



        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                usuario = new BLL.Usuario();
                //usuario.Crear("prueba1", "prueba1", "prueba1", "prueba1", "prueba1");
                // usuario.Eliminar(28);
                // usuario.Modificar("prueba2", "prueba2", "prueba2", "prueba2", "prueba2",28);
                //usuario.Seleccionar(29);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
