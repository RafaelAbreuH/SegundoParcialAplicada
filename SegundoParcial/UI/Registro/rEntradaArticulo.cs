using SegundoParcial.DAL;
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
    public partial class rEntradaArticulo : Form
    {
        public rEntradaArticulo()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private EntradaArticulos LlenarClase()
        {
            EntradaArticulos entrada = new EntradaArticulos();

            entrada.EntradaId = Convert.ToInt32(EntradaIdnumericUpDown.Value);
            entrada.Fecha = FechaDateTimePicker.Value;
            entrada.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            entrada.ArticuloId = (int)ArticulocomboBox.SelectedValue;

            return entrada;
        }


        private bool Validar(int validar) // VALIDAR
        {

            bool paso = false;
            if (validar == 1 && EntradaIdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(EntradaIdnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && CantidadnumericUpDown.Value == 0)
            {
                errorProvider.SetError(CantidadnumericUpDown, "Ingrese una Cantidad");
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

            int id = Convert.ToInt32(EntradaIdnumericUpDown.Value);
            EntradaArticulos entradaArticulo = BLL.EntradaArticuloBLL.Buscar(id);

            if (entradaArticulo != null)
            {
                CantidadnumericUpDown.Value = entradaArticulo.Cantidad;
                FechaDateTimePicker.Text = entradaArticulo.Fecha.ToString();
                ArticulocomboBox.SelectedValue = entradaArticulo.ArticuloId;
                LlenarComboBox();


            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            ArticulocomboBox.DataSource = repositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            EntradaIdnumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;


        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            EntradaArticulos entArticulos = LlenarClase();
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }
            else
            {
                if(EntradaIdnumericUpDown.Value == null)
                {
                    paso = BLL.EntradaArticuloBLL.Guardar(entArticulos);
                }
                else
                {
                    var x = BLL.EntradaArticuloBLL.Buscar(Convert.ToInt32(EntradaIdnumericUpDown.Value));
                    if (x != null)
                        paso = BLL.EntradaArticuloBLL.Modificar(entArticulos);
                }

            }

            errorProvider.Clear();

            if (EntradaIdnumericUpDown.Value == 0)
                paso = BLL.EntradaArticuloBLL.Guardar(LlenarClase());
            else
                paso = BLL.EntradaArticuloBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
           

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(EntradaIdnumericUpDown.Value);

            if (BLL.EntradaArticuloBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            errorProvider.Clear();
        }
    }
}