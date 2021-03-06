﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegundoParcial.UI.Registro;
using SegundoParcial.UI.Registros;

namespace SegundoParcial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVehiculo registro = new rVehiculo();
            registro.MdiParent = this;
            registro.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rArticulo registro = new rArticulo();
            registro.MdiParent = this;
            registro.Show();

        }

        private void talleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTalleres registro = new rTalleres();
            registro.MdiParent = this;
            registro.Show();

        }

        private void entradaArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradaArticulo registro = new rEntradaArticulo();
            registro.MdiParent = this;
            registro.Show();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rMantenimiento registro = new rMantenimiento();
            registro.MdiParent = this;
            registro.Show();
        }
    }
}
