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

namespace SegundoParcial.UI.Registros
{
    public partial class rMantenimiento : Form
    {
        public rMantenimiento()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public void Limpiar()
        {
            MantenimientoIdnumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            TotaltextBox.Text = 0.ToString();
            ImportetextBox.Text = 0.ToString();
            SubTotaltextBox.Text = 0.ToString();
            itbistextBox.Text = 0.ToString();

            DetalledataGridView.DataSource = null;
        }
        decimal itbis = 0;
        decimal importe = 0;
        decimal Total = 0;
        decimal subtotal = 0;

        public void RemoverColumnas()
        {
            DetalledataGridView.Columns["MantenimientoId"].Visible = false;
            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["MantenimientoId"].Visible = false;
            DetalledataGridView.Columns["TallerId"].Visible = false;
            DetalledataGridView.Columns["ArticuloId"].Visible = false;
            DetalledataGridView.Columns["Articulos"].Visible = false;
        }

        private void LlenarComboBox()
        {
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            VehiculocomboBox.DataSource = repositorio.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoId";
            VehiculocomboBox.DisplayMember = "Descripcion";

            Repositorio<Articulos> repositorioArt = new Repositorio<Articulos>(new Contexto());
            ArticulocomboBox.DataSource = repositorioArt.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";

            Repositorio<Talleres> repositorioTal = new Repositorio<Talleres>(new Contexto());
            TallercomboBox.DataSource = repositorioTal.GetList(c => true);
            TallercomboBox.ValueMember = "TallerId";
            TallercomboBox.DisplayMember = "Nombre";
        }

        private Mantenimientos LlenarClase()
        {
            Mantenimientos mantenimientos = new Mantenimientos();

            mantenimientos.MantenimientoId = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);
            mantenimientos.VehiculoId = Convert.ToInt32(VehiculocomboBox.SelectedValue);
            mantenimientos.Subtotal = Convert.ToDecimal(SubTotaltextBox.Text);
            mantenimientos.Total = Convert.ToDecimal(TotaltextBox.Text);
            mantenimientos.itbis = Convert.ToDecimal(itbistextBox.Text);
            mantenimientos.Fecha = FechaDateTimePicker.Value;

            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {

                mantenimientos.AgregarDetalle
                (ToInt(item.Cells["id"].Value),
                mantenimientos.MantenimientoId,
                ToInt(item.Cells["tallerId"].Value),
                ToInt(item.Cells["articulosId"].Value),
                ToInt(item.Cells["Articulos"].Value),
                ToInt(item.Cells["cantidad"].Value),
                ToInt(item.Cells["precio"].Value),
                ToInt(item.Cells["importe"].Value)

            


                  );
            }
            return mantenimientos;
        }





        private void LlenarCampos(Mantenimientos mantenimiento)
        {
            MantenimientoIdnumericUpDown.Value = mantenimiento.MantenimientoId;
            FechaDateTimePicker.Value = mantenimiento.Fecha;
            SubTotaltextBox.Text = mantenimiento.Subtotal.ToString();
            itbistextBox.Text = mantenimiento.itbis.ToString();
            TotaltextBox.Text = mantenimiento.itbis.ToString();


            foreach (var item in mantenimiento.Detalle)
            {
                subtotal += item.Importe;

            }
            SubTotaltextBox.Text = subtotal.ToString();

            DetalledataGridView.DataSource = mantenimiento.Detalle;
            RemoverColumnas();
        }

        private void rMantenimiento_Load(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(ProximodateTimePicker.Text);
            fecha = fecha.AddDays(90);

            ProximodateTimePicker.Text = fecha.ToString();
        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in BLL.ArticulosBLL.GetList(x => x.Descripcion == ArticulocomboBox.Text))
            {
                PreciotextBox.Text = item.Precio.ToString();

            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();
            Mantenimientos mantenimientos = new Mantenimientos();

            if (DetalledataGridView.DataSource != null)
            {
                mantenimientos.Detalle = (List<MantenimientoDetalle>)DetalledataGridView.DataSource;
            }

            foreach (var item in BLL.ArticulosBLL.GetList(x => x.Inventario < CantidadnumericUpDown.Value))
            {

                MessageBox.Show("No hay suficiente Articulos para la venta ", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ImportetextBox.Text))
            {
                MessageBox.Show("Importe esta vacio , Llene cantidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mantenimientos.Detalle.Add(
                    new MantenimientoDetalle(id: 0,
                    mantenimientoId: (int)Convert.ToInt32(MantenimientoIdnumericUpDown.Value),
                    tallerId: (int)TallercomboBox.SelectedValue,
                       articuloId: (int)ArticulocomboBox.SelectedValue,
                            articulo: (string)BLL.ArticulosBLL.RetornarDescripcion(ArticulocomboBox.Text),
                        cantidad: (int)Convert.ToInt32(CantidadnumericUpDown.Value),
                        precio: (int)Convert.ToInt32(PreciotextBox.Text),
                        importe: (int)Convert.ToInt32(ImportetextBox.Text)

                    ));

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = mantenimientos.Detalle;

                RemoverColumnas();
            }

            importe += BLL.MantenimientoBLL.CalcularImporte(Convert.ToDecimal(PreciotextBox.Text), Convert.ToInt32(CantidadnumericUpDown.Value));
            if (MantenimientoIdnumericUpDown.Value != 0)
            {

                subtotal += importe;
                SubTotaltextBox.Text = subtotal.ToString();
            }
            else
            {

                subtotal = importe;

                SubTotaltextBox.Text = subtotal.ToString();
            }

            itbis = BLL.MantenimientoBLL.CalcularItbis(Convert.ToDecimal(SubTotaltextBox.Text));

            itbistextBox.Text = itbis.ToString();

            Total = BLL.MantenimientoBLL.Total(Convert.ToDecimal(SubTotaltextBox.Text), Convert.ToDecimal(itbistextBox.Text));

            TotaltextBox.Text = Total.ToString();


        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ImportetextBox.Text = BLL.MantenimientoBLL.CalcularImporte(Convert.ToInt32(PreciotextBox.Text), Convert.ToInt32(CantidadnumericUpDown.Value)).ToString(); ;
        }

        private void FechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            ProximodateTimePicker.Value = FechaDateTimePicker.Value;


            DateTime fecha = Convert.ToDateTime(ProximodateTimePicker.Text);
            fecha = fecha.AddDays(90);

            ProximodateTimePicker.Text = fecha.ToString();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);
            Mantenimientos mantenimientos = BLL.MantenimientoBLL.Buscar(id);

            if (mantenimientos != null)
            {
                LlenarCampos(mantenimientos);

            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Completar las Casillas vacias!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int id = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);
                if (BLL.MantenimientoBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {

        }//termianr
    }
}