using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.UI.Registro
{
    public partial class rTalleres : Form
    {
        public rTalleres()
        {
            InitializeComponent();
        }

        private Talleres LlenarClase()
        {
            Talleres taller = new Talleres();

            taller.TallerId = Convert.ToInt32(TallerIdnumericUpDown.Value);
            taller.Nombre = NombretextBox.Text;
            return taller;
        }

        private bool Validar(int validar) // VALIDAR
        {

            bool paso = false;
            if (validar == 1 && TallerIdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(TallerIdnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && NombretextBox.Text == string.Empty)
            {
                errorProvider.SetError(NombretextBox, "Ingrese un nombre");
                paso = true;
            }

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(TallerIdnumericUpDown.Value);
            Talleres taller = BLL.TalleresBLL.Buscar(id);

            if (taller != null)
            {
                NombretextBox.Text = taller.Nombre;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            TallerIdnumericUpDown.Value = 0;
            NombretextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            errorProvider.Clear();

            if (TallerIdnumericUpDown.Value == 0)
                paso = BLL.TalleresBLL.Guardar(LlenarClase());
            else
                paso = BLL.TalleresBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(TallerIdnumericUpDown.Value);

            if (BLL.TalleresBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
