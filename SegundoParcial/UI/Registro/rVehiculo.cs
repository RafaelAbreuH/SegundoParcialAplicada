using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegundoParcial.Entidades;

namespace SegundoParcial.UI.Registro
{
    public partial class rVehiculo : Form
    {
        public rVehiculo()
        {
            InitializeComponent();
        }

        private Vehiculos LlenarClase()
        {
            Vehiculos vehiculo = new Vehiculos();

            vehiculo.VehiculoId = Convert.ToInt32(VehiculoIdnumericUpDown.Value);
            vehiculo.Descripcion = DescripciontextBox.Text;
            return vehiculo;
        }

        private bool Validar(int validar) // VALIDAR
        {

            bool paso = false;
            if (validar == 1 && VehiculoIdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(VehiculoIdnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
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

            int id = Convert.ToInt32(VehiculoIdnumericUpDown.Value);
            Vehiculos vehiculo = BLL.VehiculoBLL.Buscar(id);

            if (vehiculo != null)
            {

                DescripciontextBox.Text = vehiculo.Descripcion;
                MantenimientotextBox.Text = vehiculo.Mantenimiento.ToString();
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }






        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Vehiculos vehiculo = LlenarClase();
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            errorProvider.Clear();

               if(VehiculoIdnumericUpDown.Value == 0)
                {
                paso = BLL.VehiculoBLL.Guardar(vehiculo);
                }
                else
                {
                    var x = BLL.VehiculoBLL.Buscar(Convert.ToInt32(VehiculoIdnumericUpDown.Value));
                if (x != null)
                    paso = BLL.VehiculoBLL.Modificar(vehiculo);
                }

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

            int id = Convert.ToInt32(VehiculoIdnumericUpDown.Value);

            if (BLL.VehiculoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void rVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            VehiculoIdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
        }
    }
}
