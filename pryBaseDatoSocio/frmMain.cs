﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryBaseDatoSocio
{
    public partial class frmMain : Form
    {

        clsAccesoDatos objBaseDatos;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsAccesoDatos();
            objBaseDatos.ConectarBD();
            lblEstadoConexion.Text = objBaseDatos.estadoConexion;
            lblEstadoConexion.BackColor = Color.Green;
            objBaseDatos.TraerDatos(dgvGrilla);

            lblDatos.Text = objBaseDatos.datosTabla;
        }
        private void dtvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            objBaseDatos.BuscarPorID(int.Parse(txtBuscar.Text));
        }

    }
}
