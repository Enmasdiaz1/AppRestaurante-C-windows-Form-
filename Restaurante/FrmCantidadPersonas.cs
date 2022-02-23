using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using Restaurante.Control;


namespace Restaurante
{
    public partial class FrmCantidadPersonas : Form
    {
        public bool CancelaronUnaOrden { get; set; } = false;
        public bool SeCalculo { get; set; } = false;
        public FrmCantidadPersonas()
        {
            InitializeComponent();
        }
        #region EVENTOS
        private void FrmCantidadPersonas_Load(object sender, EventArgs e)
        {
            CargandoCbx();            
        }
        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            Validar();
            TomarOrdenes();
        }
        private void CargandoCbx()
        {
            #region LLENANDO COMBOBOX CANTIDAD DE PERSONAS

            LlenandoComboBox cantidadDefault = new LlenandoComboBox
            {
                Texto = "Seleccione Por Favor",
                Valor = null

            };
            LlenandoComboBox cantidad1 = new LlenandoComboBox
            {
                Texto = "Reservar Para 1 Persona",
                Valor = 1

            };
            LlenandoComboBox cantidad2 = new LlenandoComboBox
            {
                Texto = "Reservar Para 2 Personas",
                Valor = 2

            };
            LlenandoComboBox cantidad3 = new LlenandoComboBox
            {
                Texto = "Reservar Para 3 Personas",
                Valor = 3

            };
            LlenandoComboBox cantidad4 = new LlenandoComboBox
            {
                Texto = "Reservar Para 4 Personas",
                Valor = 4

            };


            #endregion

            /////////////////////////////////////////////////////////////////////

            #region ASIGNANDOLE VALOR AL COMBOBOX CANTIDAD DE PERSONAS
            CbxCantidadDePersonas.Items.Add(cantidadDefault);
            CbxCantidadDePersonas.Items.Add(cantidad1);
            CbxCantidadDePersonas.Items.Add(cantidad2);
            CbxCantidadDePersonas.Items.Add(cantidad3);
            CbxCantidadDePersonas.Items.Add(cantidad4);
            CbxCantidadDePersonas.SelectedItem = cantidadDefault;
            #endregion
        }
        private void FrmCantidadPersonas_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmRestaurante.Instancia.Show();
        }
        
        private void TomarOrdenes()
        {
            LlenandoComboBox cantidadPersonas = CbxCantidadDePersonas.SelectedItem as LlenandoComboBox;
            if (cantidadPersonas.Valor==null)
            {
                MessageBox.Show("Debe Seleccionar una Opcion", "Informacion");
            }
            else
            {
                FrmGestionOrdenes[] GestionarOrden = new FrmGestionOrdenes[4];
                Repositorio.Instancia.CantidadDePersonas = (int)cantidadPersonas.Valor;

                for (int i = 0; i < Repositorio.Instancia.CantidadDePersonas; i++)
                {
                    GestionarOrden[i] = new FrmGestionOrdenes();
                    this.Hide();
                    GestionarOrden[i].ShowDialog();
                    this.Show();

                    if (GestionarOrden[i].Result == DialogResult.Yes || CancelaronUnaOrden == true)
                    {
                        CancelaronUnaOrden = true;
                        break;
                    }
                }
                if (CancelaronUnaOrden != true)
                {
                    DialogResult Resultado = MessageBox.Show("¿Te interesa Guardar Los Cambios?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (Resultado == DialogResult.Yes)
                    {
                        Add[] servicioOrdenes = new Add[4];
                        LogicaRestaurante[] ordenes = new LogicaRestaurante[4];

                        for (int i = 0; i < Repositorio.Instancia.CantidadDePersonas; i++)
                        {
                            ordenes[i] = new LogicaRestaurante()
                            {
                                Nombre = GestionarOrden[i].TxtNombreOrden.Text,
                                Entrada = GestionarOrden[i].CbxEntrada.Text,
                                PlatoFuerte = GestionarOrden[i].CbxPlatoFuerte.Text,
                                Liquido = GestionarOrden[i].CbxBebida.Text,
                                Postre = GestionarOrden[i].CbxPostre.Text
                            };

                            ordenes[i] = new LogicaRestaurante();

                            servicioOrdenes[i] = new Add();

                            servicioOrdenes[i].agregando(ordenes[i]);
                        }
                        MessageBox.Show("Se agregaron todas las ordenes", "Notificacion");
                    }
                    else
                    {
                        MessageBox.Show("Se han cancelado todas las ordenes", "Notificacion");
                    }
                }
                else
                {
                    MessageBox.Show("No hay orden para cancelar", "Notificacion");
                }
            }

        }



        #endregion


       


        private void Validar()
        {
            #region VALIDANDO LOS CAMPOS

            try
            {
                LlenandoComboBox seleccionCantidadPersonas = CbxCantidadDePersonas.SelectedItem as LlenandoComboBox;

                 if (seleccionCantidadPersonas.Valor == null)
                {
                    MessageBox.Show("Usted Debe Seleccionar Una Cantidad de Personas", "Informacion");

                }
                else
                {                  
                    SeCalculo = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Usted Debe Facilitarme Un Monto Numerico ", "ERROR");
            }


            #endregion

        }

        
    }
}
