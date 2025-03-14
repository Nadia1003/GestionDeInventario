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
    public partial class frmUsuarios : Form
    {
        BLL.Usuario bll_usuario;
        BE.Usuario be_usuario;
        public frmUsuarios()
        {
            InitializeComponent();
            bll_usuario = new BLL.Usuario();
            be_usuario = new BE.Usuario();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = bll_usuario.SeleccionarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BE.Usuario be_usuario = new BE.Usuario
                {
                    NombreUsuario = txtUsuario.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Mail = txtMail.Text,
                    Contraseña = SERVICIOS.Encriptar.EncriptarCadena("Contraseña") //"Contraseña"
                };
                bll_usuario.Crear(be_usuario.NombreUsuario, be_usuario.Nombre, be_usuario.Apellido, be_usuario.Mail, be_usuario.Contraseña);
                MessageBox.Show("Se guardó correctamente", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.None);
                LimpiarCasillas();
                dgv.DataSource = bll_usuario.SeleccionarTabla();
            }
            catch
            {
                MessageBox.Show("No se guardó el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiarCasillas()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtMail.Clear();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Text= dgv.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
            txtNombre.Text = dgv.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgv.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            txtMail.Text = dgv.Rows[e.RowIndex].Cells["Mail"].Value.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCasillas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                BE.Usuario be_usuario = new BE.Usuario
                {
                    Id = int.Parse(dgv.CurrentRow.Cells["Id"].Value.ToString()),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Mail = txtMail.Text
                };
                bll_usuario.Modificar(be_usuario.Nombre, be_usuario.Apellido, be_usuario.Mail,  be_usuario.Id);
                dgv.DataSource = bll_usuario.SeleccionarTabla();
                LimpiarCasillas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se generó un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                be_usuario.Id = int.Parse(dgv.CurrentRow.Cells["Id"].Value.ToString());
                bll_usuario.Eliminar(be_usuario.Id);
                dgv.DataSource = bll_usuario.SeleccionarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se generó un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
