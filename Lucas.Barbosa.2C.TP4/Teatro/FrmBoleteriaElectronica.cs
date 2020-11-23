using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teatro
{
    public delegate void InfoError();
    public partial class FrmBoleteriaElectronica : Form
    {
        #region "Atributos"

        private Boleteria<EntradaElectronica> boleteria;
        private Thread ventas;
        #endregion
        #region "Constructor"
        public FrmBoleteriaElectronica(Boleteria<EntradaElectronica> boleteria)
        {
            InitializeComponent();
            this.boleteria = boleteria;
        }
        #endregion
        #region "Propiedades"

        public Thread Ventas
        {
            get
            {
                return this.ventas;
            }
        }
        #endregion
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            this.btnCerrar.Enabled = true;
            this.btnAbrir.Enabled = false;
            this.ventas = new Thread(this.GenerarVentasAleatoriasElectronicas);
            this.ventas.Start();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.btnAbrir.Enabled = true;
            this.btnCerrar.Enabled = false;
            
            if(this.ventas.IsAlive && this.ventas != null)
            {
                this.ventas.Abort();
            }
        }

        private void FrmBoleteriaElectronica_Load_1(object sender, EventArgs e)
        {
            this.boleteria.EventoConfirmacion += this.HandlerEventoConfirmacionElectronica;
            foreach (Sala sala in this.boleteria.Salas)
            {
                sala.ActualizarSalasEvento += this.HandlerActualizarSalasEventoElectronico;
            }
        }
        #region "Metodos"

        /// <summary>
        /// Genera ventas aleatorias.
        /// </summary>
        private void GenerarVentasAleatoriasElectronicas()
        {
            string[] nombre = { "lucas@gmail.com", "nahuel@hotmail.com", "analia@yahoo.com.ar", "roberto@gmail.com.ar" };
            while (true)
            {
                Thread.Sleep(new Random().Next(25, 30));
                try
                {
                    Espectaculo espectaculoRandom = this.boleteria.Espectaculos[new Random().Next(1, this.boleteria.Espectaculos.Count)];
                    EntradaElectronica entrada = new EntradaElectronica(espectaculoRandom.Nombre, espectaculoRandom.Sala, espectaculoRandom.Dia, this.boleteria.BuscarButacaLibre(espectaculoRandom),espectaculoRandom.Costo, nombre[new Random().Next(0, nombre.Length)]);
                    if (this.boleteria.ConfirmarEntrada(entrada))
                    {
                        foreach (Sala s in this.boleteria.Salas)
                        {
                            if (espectaculoRandom == s)
                            {
                                if (s.OcuparButaca(entrada.Butaca))
                                {
                                    this.boleteria.GuardarEntradaEnBD(entrada);
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    this.InformarErrorEletronico();
                }

            }
        }
        /// <summary>
        /// Informa que ha sucedido un error en el richTextBox.
        /// </summary>
        private void InformarErrorEletronico()
        {
            if (this.richTextBoxVentaElectronica.InvokeRequired)
            {
                InfoError infoError = new InfoError(this.InformarErrorEletronico);
                this.Invoke(infoError);
            }
            else
            {
                this.richTextBoxVentaElectronica.Text = "Ha ocurrido un problema, no se efectuó la venta.\n" + this.richTextBoxVentaElectronica.Text;
            }
        }
        /// <summary>
        /// Manejador del evento confirmar entrada, agrega los datos de la entrada a las demas en el richTextBox.
        /// </summary>
        /// <param name="e">entrada</param>
        private void HandlerEventoConfirmacionElectronica(Entrada e)
        {
            if (this.richTextBoxVentaElectronica.InvokeRequired)
            {
                Callback c = new Callback(this.HandlerEventoConfirmacionElectronica);
                this.Invoke(c, e);
            }
            else
            {
                this.richTextBoxVentaElectronica.Text = this.boleteria.ImprimirEntradaBreve((EntradaElectronica)e) + "\n" + this.richTextBoxVentaElectronica.Text;
            }
        }
        /// <summary>
        /// Manejador dle evento ActualizarSalasEvento, lo que hace es asignarle nuevamente la sala que fue modificada, asi se actualizan los Estados de las butacas. 
        /// </summary>
        /// <param name="salaActualizada">sala actualizada</param>
        private void HandlerActualizarSalasEventoElectronico(Sala salaActualizada)
        {
            for (int i = 0; i < this.boleteria.Salas.Count; i++)
            {
                if (salaActualizada == this.boleteria.Salas[i])
                {
                    this.boleteria.Salas[i] = salaActualizada;
                    break;
                }
            }
        }
        #endregion
    }
}
