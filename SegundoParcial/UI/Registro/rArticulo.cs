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
using SegundoParcial.BLL;

namespace SegundoParcial.UI.Registro
{
    public partial class rArticulo : Form
    {
        public rArticulo()
        {
            InitializeComponent();

        }

        private Articulos LlenarClase()
        {
            Articulos articulo = new Articulos();

            articulo.ArticuloId = Convert.ToInt32(ArticuloIdnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Costo = Convert.ToInt32(CostonumericUpDown.Value);
            articulo.Ganancia = Convert.ToInt32(GanancianumericUpDown.Value);
            articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            return articulo;
        }

        private bool Validar(int validar) // VALIDAR
        {

            bool paso = false;
            if (validar == 1 && ArticuloIdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(ArticuloIdnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
                paso = true;
            }
            if (validar == 2 && CostonumericUpDown.Value == 0)
            {
                errorProvider.SetError(CostonumericUpDown, "Ingrese un Costo");
                paso = true;
            }
            if (validar == 2 && GanancianumericUpDown.Value == 0)
            {
                errorProvider.SetError(GanancianumericUpDown, "Ingrese un % de ganancia");
                paso = true;
            }
            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {
                errorProvider.SetError(PrecionumericUpDown, "Ingrese un Precio");
                paso = true;
            }
            return paso;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(ArticuloIdnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ArticuloIdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CostonumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            GanancianumericUpDown.Value = 0;
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

            if (ArticuloIdnumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticulosBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GanancianumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //---------------BUSCAR PRECIO
            if(Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if(Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    PrecionumericUpDown.Value = ArticulosBLL.Precio(Convert.ToDecimal(CostonumericUpDown.Value), Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }

            //--------------- BUSCAR COSTO
            if(Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if(Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
                {
                    CostonumericUpDown.Value = ArticulosBLL.Costo(Convert.ToDecimal(PrecionumericUpDown.Value), Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //--------------- BUSCAR PORCENTAGE
            if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    GanancianumericUpDown.Value = ArticulosBLL.PorcientoGanancia(Convert.ToDecimal(PrecionumericUpDown.Value), Convert.ToDecimal(CostonumericUpDown.Value));
                }
            }
            // --------------- BUSCAR PRECIO
            if (Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    PrecionumericUpDown.Value = ArticulosBLL.Precio(Convert.ToDecimal(CostonumericUpDown.Value), Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }


        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //------------- BUSCAR PROCENTAGE
            if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)// PORCENTTAGE
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    GanancianumericUpDown.Value = ArticulosBLL.PorcientoGanancia(Convert.ToDecimal(PrecionumericUpDown.Value), Convert.ToDecimal(CostonumericUpDown.Value));
                }
            }

            //--------------- BUSCAR COSTO
            if (Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
                {
                    CostonumericUpDown.Value = ArticulosBLL.Costo(Convert.ToDecimal(PrecionumericUpDown.Value), Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(ArticuloIdnumericUpDown.Value);
            Articulos articulo = BLL.ArticulosBLL.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                CostonumericUpDown.Value = articulo.Costo;
                GanancianumericUpDown.Value = articulo.Ganancia;
                PrecionumericUpDown.Value = articulo.Precio;
                InventariotextBox.Text = articulo.Inventario.ToString();

                
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rArticulo_Load(object sender, EventArgs e)
        {

        }
    }
}
