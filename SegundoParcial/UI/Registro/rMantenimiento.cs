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

            MantenimientoDetalledataGridView.DataSource = null;
        }

        public void RemoverColumnas()
        {

            MantenimientoDetalledataGridView.Columns["ArticuloId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["Articulos"].Visible = false;
            MantenimientoDetalledataGridView.Columns["Talleres"].Visible = false;
            MantenimientoDetalledataGridView.Columns["VehiculoId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["articulo"].DisplayIndex = 1;
            MantenimientoDetalledataGridView.Columns["TallerId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["mantenimientoId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["id"].Visible = false;
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

        private bool Validar(int error)
        {
            bool paso = false;



            if (error == 1 && MantenimientoIdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(MantenimientoIdnumericUpDown,
                   "Llenar campo ID");
                paso = true;
            }
            if (error == 2 && MantenimientoDetalledataGridView.RowCount == 0)
            {
                errorProvider.SetError(MantenimientoDetalledataGridView,
                    "Debes Agregar un articulo ");
                paso = true;
            }

            if (error == 3 && string.IsNullOrEmpty(ImportetextBox.Text))
            {
                errorProvider.SetError(ImportetextBox,
                    "Debes agregar un articulo");
                paso = true;
            }

            return paso;
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

            foreach (DataGridViewRow item in MantenimientoDetalledataGridView.Rows)
            {

                mantenimientos.AgregarDetalle
                (ToInt(item.Cells["id"].Value),
                mantenimientos.MantenimientoId,
                ToInt(item.Cells["tallerId"].Value),
                ToInt(item.Cells["articuloId"].Value),
                Convert.ToString(item.Cells["Articulo"].Value),
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
            TotaltextBox.Text = mantenimiento.Total.ToString();
        
            MantenimientoDetalledataGridView.DataSource = mantenimiento.Detalle;
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

            if (MantenimientoDetalledataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalledataGridView.DataSource;
            }

            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());

            Articulos articulo = (Articulos)ArticulocomboBox.SelectedItem;
            
            if ((int)CantidadnumericUpDown.Value > articulo.Inventario)
            {
                errorProvider.SetError(CantidadnumericUpDown, "Error");
                MessageBox.Show("no hay suficiente Productos para la venta!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(CantidadnumericUpDown.Value == 0)
            {
                errorProvider.SetError(CantidadnumericUpDown, "Error");
                MessageBox.Show("Debes Elegir una cantidad!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                  detalle.Add(
                    new MantenimientoDetalle(id: 0,
                    mantenimientoId: (int)Convert.ToInt32(MantenimientoIdnumericUpDown.Value),
                    tallerId: (int)TallercomboBox.SelectedValue,
                       articuloId: (int)ArticulocomboBox.SelectedValue,
                            articulo: (string)BLL.ArticulosBLL.RetornarDescripcion(ArticulocomboBox.Text),
                        cantidad: (int)Convert.ToInt32(CantidadnumericUpDown.Value),
                        precio: (int)Convert.ToInt32(PreciotextBox.Text),
                        importe: (int)Convert.ToInt32(ImportetextBox.Text)
                         
                    ));

                MantenimientoDetalledataGridView.DataSource = null;
                MantenimientoDetalledataGridView.DataSource = detalle;
                RemoverColumnas();
            }

            int x = Convert.ToInt32(CantidadnumericUpDown.Value);
            articulo.Inventario -= x;
            double Total = 0;
            double itbis = 0;
            double subtotal = 0;

            foreach (var item in detalle) 
            {
                Total += item.Importe;
            }
            itbis = (Total * 18) / 100;
            subtotal = Total - itbis;
            SubTotaltextBox.Text = subtotal.ToString();
           // itbis = BLL.MantenimientoBLL.CalcularItbis(Convert.ToDecimal(SubTotaltextBox.Text));
            itbistextBox.Text = itbis.ToString();
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

        private void RebajarValores()
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (MantenimientoDetalledataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalledataGridView.DataSource;
            }
            double Total = 0;
            double Itbis = 0;
            double SubTotal = 0;
            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }
            Total *= (-1);
            Itbis = (Total * 18) / 100;
            SubTotal = Total - Itbis;
            SubTotaltextBox.Text = SubTotal.ToString();
            itbistextBox.Text = Itbis.ToString();
            TotaltextBox.Text = Total.ToString();
        }


        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("Debe Agregar Algun Producto al Grid", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                Mantenimientos mantenimiento = LlenarClase();
                bool Paso = false;

                if (MantenimientoIdnumericUpDown.Value == 0)
                {
                    Paso = BLL.MantenimientoBLL.Guardar(mantenimiento);
                    errorProvider.Clear();
                }
                else
                {
                    var x = BLL.MantenimientoBLL.Buscar(Convert.ToInt32(MantenimientoIdnumericUpDown.Value));
                    if (x != null)
                        Paso = BLL.MantenimientoBLL.Modificar(mantenimiento);
                }
                if (Paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No se pudo guardar!!", "Fallo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            MantenimientoDetalle mantenimiento = new MantenimientoDetalle();
            if (MantenimientoDetalledataGridView.Rows.Count > 0 && MantenimientoDetalledataGridView.CurrentRow != null)
            {

                List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)MantenimientoDetalledataGridView.DataSource;
                detalle.RemoveAt(MantenimientoDetalledataGridView.CurrentRow.Index);
                Articulos articulo = (Articulos)ArticulocomboBox.SelectedItem;

                int x = Convert.ToInt32(CantidadnumericUpDown.Value);
                articulo.Inventario += x;

                // Cargar el detalle al Grid
                MantenimientoDetalledataGridView.DataSource = null;
                MantenimientoDetalledataGridView.DataSource = detalle;

                RebajarValores();
                RemoverColumnas();
            }
        }




    }
}