using Restaurante.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace Restaurante
{
    public partial class FrmGestionOrdenes : Form
    {
        public DialogResult Result;
        public bool SeCalculo { get; set; } = false;


        #region EVENTOS
        public FrmGestionOrdenes()
        {
            InitializeComponent();
        }
        private void BtnGuardarOrden_Click(object sender, EventArgs e)
        {
            Validar();
        }
        private void FrmGestionOrdenes_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmRestaurante.Instancia.Show();
        }

        private void FrmGestionOrdenes_Load(object sender, EventArgs e)
        {
            CargandoCbx();
        }
       
        private void CbxEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeCalculo)
            {
                Validar();
            }
        }
        private void CbxPlatoFuerte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeCalculo)
            {
                Validar();
            }
        }
        private void CbxBebida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeCalculo)
            {
                Validar();
            }
        }
        private void CbxPostre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeCalculo)
            {
                Validar();
            }
        }

        private void BtnCancelarOrden_Click(object sender, EventArgs e)
        {
            Result = MessageBox.Show($"¿Esta seguro que desea Volver Atras?", $"Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                FrmCantidadPersonas cantidadPersonas = new FrmCantidadPersonas();
                cantidadPersonas.CancelaronUnaOrden = true;
                this.Close();
            }
            else
            {
                TxtNombreOrden.Focus();
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Esta seguro que desea Salir Del Programa?", $"Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                TxtNombreOrden.Focus();
            }
        }
        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Esta seguro que desea Salir Del Programa?", $"Atención",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                TxtNombreOrden.Focus();
            }
        }

        #endregion

        private void CargandoCbx()
        {
            #region LLENANDO COMBOBOX ENTRADA
            LlenandoComboBox opcionDefecto = new LlenandoComboBox
            {
                Texto = "Seleccione",
                Valor = null

            };
            LlenandoComboBox platoEntrada1 = new LlenandoComboBox
            {
                Texto = "CEVICHE CREMOSO",
                Valor = 1

            };
            LlenandoComboBox platoEntrada2 = new LlenandoComboBox
            {
                Texto = "EMPANADAS DE CIERVO",
                Valor = 2

            };
            LlenandoComboBox platoEntrada3 = new LlenandoComboBox
            {
                Texto = "PIZZA FRITA MARGHERITA",
                Valor = 3

            };
            LlenandoComboBox platoEntrada4 = new LlenandoComboBox
            {
                Texto = "CARACÚ CON MANDIOCA",
                Valor = 4

            };
            LlenandoComboBox platoEntrada5 = new LlenandoComboBox
            {
                Texto = "TORTILLA DE PAPA",
                Valor = 5

            };

            #endregion

            #region LLENANDO COMBOBOX PLATO FUERTE
            
            LlenandoComboBox platoFuerte1 = new LlenandoComboBox
            {
                Texto = "ANGUILA TERIYAKI CON SÉSAMO",
                Valor = 1

            };
            LlenandoComboBox platoFuerte2 = new LlenandoComboBox
            {
                Texto = "FRITTATA DE VERDURAS",
                Valor = 2

            };
            LlenandoComboBox platoFuerte3 = new LlenandoComboBox
            {
                Texto = "MERLUZA AL HORNO",
                Valor = 3

            };
            LlenandoComboBox platoFuerte4 = new LlenandoComboBox
            {
                Texto = "MERLUZA EN SALSA",
                Valor = 4

            };
            LlenandoComboBox platoFuerte5 = new LlenandoComboBox
            {
                Texto = "MORCILLO CON PURÉ DE BATATA",
                Valor = 5

            };
            LlenandoComboBox platoFuerte6 = new LlenandoComboBox
            {
                Texto = "MUSLITOS DE POLLO AL SÉSAMO",
                Valor = 6

            };
            LlenandoComboBox platoFuerte7 = new LlenandoComboBox
            {
                Texto = "PAELLA VALENCIANA",
                Valor = 7

            };
            LlenandoComboBox platoFuerte8 = new LlenandoComboBox
            {
                Texto = "PIERNA DE CORDERO",
                Valor = 8

            };
            LlenandoComboBox platoFuerte9 = new LlenandoComboBox
            {
                Texto = "PIZZA DE QUESO AZUL CON SETAS",
                Valor = 9

            };
            LlenandoComboBox platoFuerte10 = new LlenandoComboBox
            {
                Texto = "ROLLITOS DE ROAST BEEF",
                Valor = 10

            };

            #endregion

            #region LLENANDO COMBOBOX POSTRE
            
            LlenandoComboBox postre1 = new LlenandoComboBox
            {
                Texto = "Mousse de frutas del bosque",
                Valor = 1

            };
            LlenandoComboBox postre2 = new LlenandoComboBox
            {
                Texto = "Soufflé de mango y coco",
                Valor = 2

            };
            LlenandoComboBox postre3 = new LlenandoComboBox
            {
                Texto = "Pastel de zanahoria de la casa",
                Valor = 3

            };
            LlenandoComboBox postre4 = new LlenandoComboBox
            {
                Texto = "Pastel de matcha",
                Valor = 4

            };
            LlenandoComboBox postre5 = new LlenandoComboBox
            {
                Texto = " Pastel vegano de chocolate",
                Valor = 5

            };

            #endregion

            #region LLENANDO COMBOBOX BEBIDAS

            LlenandoComboBox bebida1 = new LlenandoComboBox
            {
                Texto = "Limonada",
                Valor = 1

            };
            LlenandoComboBox bebida2 = new LlenandoComboBox
            {
                Texto = "Té helado.",
                Valor = 2

            };
            LlenandoComboBox bebida3 = new LlenandoComboBox
            {
                Texto = "Café frappé",
                Valor = 3

            };
            LlenandoComboBox bebida4 = new LlenandoComboBox
            {
                Texto = "Granizados de frutas.",
                Valor = 4

            };
            LlenandoComboBox bebida5 = new LlenandoComboBox
            {
                Texto = "Vinos veraniegos.",
                Valor = 5

            };

            #endregion

            /////////////////////////////////////////////////////////////////////
            #region ASIGNANDOLE VALOR AL COMBOBOX ENTRADA
            CbxEntrada.Items.Add(opcionDefecto);
            CbxEntrada.Items.Add(platoEntrada1);
            CbxEntrada.Items.Add(platoEntrada2);
            CbxEntrada.Items.Add(platoEntrada3);
            CbxEntrada.Items.Add(platoEntrada4);
            CbxEntrada.Items.Add(platoEntrada5);
            CbxEntrada.SelectedItem = opcionDefecto;
            #endregion

            #region ASIGNANDOLE VALOR AL COMBOBOX PLATO FUERTE
            CbxPlatoFuerte.Items.Add(opcionDefecto);
            CbxPlatoFuerte.Items.Add(platoFuerte1);
            CbxPlatoFuerte.Items.Add(platoFuerte2);
            CbxPlatoFuerte.Items.Add(platoFuerte3);
            CbxPlatoFuerte.Items.Add(platoFuerte4);
            CbxPlatoFuerte.Items.Add(platoFuerte5);
            CbxPlatoFuerte.Items.Add(platoFuerte6);
            CbxPlatoFuerte.Items.Add(platoFuerte7);
            CbxPlatoFuerte.Items.Add(platoFuerte8);
            CbxPlatoFuerte.Items.Add(platoFuerte9);
            CbxPlatoFuerte.Items.Add(platoFuerte10);
            CbxPlatoFuerte.SelectedItem = opcionDefecto;
            #endregion

            #region ASIGNANDOLE VALOR AL COMBOBOX POSTRE
            CbxPostre.Items.Add(opcionDefecto);
            CbxPostre.Items.Add(postre1);
            CbxPostre.Items.Add(postre2);
            CbxPostre.Items.Add(postre3);
            CbxPostre.Items.Add(postre4);
            CbxPostre.Items.Add(postre5);
            CbxPostre.SelectedItem = opcionDefecto;

            #endregion

            #region ASIGNANDOLE VALOR AL COMBOBOX BEBIDA
            CbxBebida.Items.Add(opcionDefecto);
            CbxBebida.Items.Add(bebida1);
            CbxBebida.Items.Add(bebida2);
            CbxBebida.Items.Add(bebida3);
            CbxBebida.Items.Add(bebida4);
            CbxBebida.Items.Add(bebida5);
            CbxBebida.SelectedItem = opcionDefecto;
            #endregion

        }

        private void Validar()
        {
            #region VALIDANDO LOS CAMPOS

            try
            {
                LlenandoComboBox SeleccionPlatoEntrada = CbxEntrada.SelectedItem as LlenandoComboBox;
                LlenandoComboBox SeleccionPlatoFuerte = CbxPlatoFuerte.SelectedItem as LlenandoComboBox;
                LlenandoComboBox SeleccionBebida = CbxBebida.SelectedItem as LlenandoComboBox;
                LlenandoComboBox SeleccionPostre = CbxPostre.SelectedItem as LlenandoComboBox;

                if (String.IsNullOrEmpty(TxtNombreOrden.Text))
                {
                    MessageBox.Show("Usted Debe Facilitarme Un Nombre ", "Informacion");

                }
                else if(SeleccionPlatoEntrada.Valor == null)
                {
                    MessageBox.Show("Usted Debe Seleccionar Un Plato De Entrada", "Informacion");

                }
                else if (SeleccionPlatoFuerte.Valor == null)
                {
                    MessageBox.Show("Usted Debe Seleccionar Un Plato Fuerte", "Informacion");

                }
                else if (SeleccionBebida.Valor == null)
                {
                    MessageBox.Show("Usted Debe Seleccionar Una Bebida", "Informacion");

                }
                else if (SeleccionPostre.Valor == null)
                {
                    MessageBox.Show("Usted Debe Seleccionar Un Postre", "Informacion");

                }
                else 
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Usted Debe Facilitarme Un Monto Numerico ", "ERROR", (MessageBoxButtons)MessageBoxIcon.Exclamation);
            }


            #endregion

        }

    }
}
