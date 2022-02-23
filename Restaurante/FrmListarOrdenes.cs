using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Restaurante
{
    public partial class FrmListarOrdenes : Form
    {
        public FrmListarOrdenes()
        {
            InitializeComponent();
        }
        private void FrmListarOrdenes_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            Add servicioOrdenes = new Add();
            LboxListar.BeginUpdate();
            LboxListar.Items.Clear();
            var ordenes = servicioOrdenes.ObtenerOrdenes();

            foreach (LogicaRestaurante item in ordenes)
            {
                LboxListar.Items.Add(item.ObtenerMensaje());
            }
            LboxListar.EndUpdate();
        }

        private void BtnVolverAtrasListar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Esta seguro que desea Volver Atras?", $"Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmRestaurante.Instancia.Show();
                this.Close();

            }
            else
            {
                LboxListar.Focus();
            }
        }

        private void BtnSalirListar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Esta seguro que desea Salir Del Programa?", $"Atención",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                LboxListar.Focus();
            }
        }

        private void FrmListarOrdenes_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmRestaurante.Instancia.Show();
        }

      
    }
}
