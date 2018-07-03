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

          
        }
    }
}
