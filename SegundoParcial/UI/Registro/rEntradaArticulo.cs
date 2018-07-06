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

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
          
        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            ArticulocomboBox.DataSource = repositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }
    }
}
