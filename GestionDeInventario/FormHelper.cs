using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeInventario
{
    public class FormHelper:Form
    {
        public void ValidarResultado<T>(Result<T> resultado)
        {
            if (!resultado.Ok)
            {
                MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
