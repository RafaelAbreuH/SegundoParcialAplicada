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


        private void LlenarComboBox()
        {
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            VehiculocomboBox.DataSource = repositorio.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoId";
            VehiculocomboBox.DisplayMember = "Descripcion";
        }

        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(IdnumericUpDown.Value);
            mantenimiento.Fecha = FechaDateTimePicker.Value;

            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["id"].Value),
                    ToInt(item.Cells["MantenimientoId"].Value),
                    ToInt(item.Cells["VehiculoId"].Value),
                    item.Cells["Servicio"].ToString(),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value)
                  );
            }
            return mantenimiento;
        }
        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(ServicioTextBox.Text))
            {
                MyerrorProvider.SetError(ServicioTextBox,
                    "No debes dejar el servicio vacio");
                HayErrores = true;
            }

            return HayErrores;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            IdnumericUpDown.Value = mantenimiento.MantenimientoId;
            FechaDateTimePicker.Value = mantenimiento.Fecha;

            DetalledataGridView.DataSource = mantenimiento.Detalle;

            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["MantenimientoId"].Visible = false;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

        }

    }
}
