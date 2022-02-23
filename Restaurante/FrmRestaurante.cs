using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class FrmRestaurante : Form
    {
        public static FrmRestaurante Instancia { get; } = new FrmRestaurante();

        public FrmRestaurante()
        {
            InitializeComponent();
        }
        #region EVENTOS

        
        private void PboxMesa1_Click(object sender, EventArgs e)
        {
            FrmCantidadPersonas cantidadPersonas = new FrmCantidadPersonas();
            cantidadPersonas.Show();
            this.Hide();
        }      

        private void PboxMesa2_Click(object sender, EventArgs e)
        {
            FrmCantidadPersonas cantidadPersonas = new FrmCantidadPersonas();
            cantidadPersonas.Show();
            this.Hide();
        }      

        private void PboxMesa3_Click(object sender, EventArgs e)
        {
            FrmCantidadPersonas cantidadPersonas = new FrmCantidadPersonas();
            cantidadPersonas.Show();
            this.Hide();
        }       

        private void PboxMesa4_Click(object sender, EventArgs e)
        {
            FrmCantidadPersonas cantidadPersonas = new FrmCantidadPersonas();
            cantidadPersonas.Show();
            this.Hide();
        }

        private void BtnVerListar_Click(object sender, EventArgs e)
        {
            FrmListarOrdenes listar = new FrmListarOrdenes();
            listar.Show();
            this.Hide();
        }
        #endregion


    }
}
