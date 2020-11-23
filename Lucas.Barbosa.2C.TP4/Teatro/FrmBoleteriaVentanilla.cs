using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Teatro
{
    public delegate void Callback(Entrada e);

    public partial class FrmBoleteriaVentanilla : Form
    {
        private Boleteria<EntradaVentanilla> boleteria;
        private Thread ventas;
        public FrmBoleteriaVentanilla(Boleteria<EntradaVentanilla> boleteria)
        {
            InitializeComponent();
            this.boleteria = boleteria;

        }
        public List<Sala> ActualizarSala
        {
            get
            {
                return this.boleteria.Salas;
            }
            set
            {
                this.boleteria.Salas = value;
            }
        }
        private void brnAbrir_Click(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = this.boleteria.Espectaculos;
            this.btnGenerarVenta.Enabled = true;
            this.comboBox1.Visible = true;
            this.textBox1.Visible = true;
            this.labelButaca.Visible = true;
            this.ventas = new Thread(this.GenerarVentasAleatorias);

            if (this.ventas != null && this.ventas.ThreadState == ThreadState.Unstarted)
            {
                this.ventas.Start();
            }
            this.btnAbrir.Enabled = false;
            this.btnCerrar.Enabled = true;
        }

        public void ActualizarButaca(string butaca)
        {
            this.labelButaca.Text = butaca;
        }

        private void labelButaca_Click(object sender, EventArgs e)
        {
            if (this.boleteria != null)
            {
                this.ActualizarButaca(this.boleteria.BuscarButacaLibre((Espectaculo)this.comboBox1.SelectedItem));
            }
        }

        /// <summary>
        /// Genera ventas aleatorias.
        /// </summary>
        private void GenerarVentasAleatorias()
        {
            string[] nombre = { "lucas", "nahuel", "analia", "roberto" };
            while (true)
            {
                try
                {
                    Thread.Sleep(new Random().Next(25, 30));
                    Espectaculo espectaculoRandom = (Espectaculo)this.comboBox1.Items[new Random().Next(1, this.boleteria.Espectaculos.Count)];
                    EntradaVentanilla entrada = new EntradaVentanilla(espectaculoRandom.Nombre, espectaculoRandom.Sala, espectaculoRandom.Dia, this.boleteria.BuscarButacaLibre(espectaculoRandom), nombre[new Random().Next(0, nombre.Length)], espectaculoRandom.Costo);
                    if (this.boleteria.ConfirmarEntrada(entrada))
                    {
                        foreach (Sala s in this.boleteria.Salas)
                        {
                            if (espectaculoRandom == s)
                            {
                                if (s.OcuparButaca(entrada.Butaca))
                                {
                                    this.boleteria.GuardarEntrada(entrada.MostrarDatos());
                                    Thread.Sleep(50);
                                    this.boleteria.GuardarEntradaEnBD(entrada);
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    this.InformarErrorVentanilla();
                }

            }
        }
        private void InformarErrorVentanilla()
        {
            if (this.richTextBox1.InvokeRequired)
            {
                InfoError infoError = new InfoError(this.InformarErrorVentanilla);
                this.Invoke(infoError);
            }
            else
            {
                this.richTextBox1.Text = "Ha ocurrido un problema, no se efectuó la venta.\n" + this.richTextBox1.Text;
            }
        }
        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            this.GenerarUnaVenta();
        }

        private void FrmBoleteriaVentanilla_Load(object sender, EventArgs e)
        {
            this.btnGenerarVenta.Enabled = false;
            this.btnCerrar.Enabled = false;
            this.boleteria.EventoConfirmacion += this.HandlerEventoConfirmacionVentanilla;
            foreach (Sala sala in this.boleteria.Salas)
            {
                sala.ActualizarSalasEvento += Sala_ActualizarSalasEvento;
            }
        }

        private void Sala_ActualizarSalasEvento(Sala salaActualizada)
        {
            for(int i = 0; i< this.boleteria.Salas.Count; i++)
            {
                if(salaActualizada == this.boleteria.Salas[i])
                {
                    this.boleteria.Salas[i] = salaActualizada;
                    break;
                }
            }
        }

        private void HandlerEventoConfirmacionVentanilla(Entrada e)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                Callback c = new Callback(this.HandlerEventoConfirmacionVentanilla);
                this.Invoke(c, e);
            }
            else
            {
                this.richTextBox1.Text = this.boleteria.ImprimirEntradaBreve((EntradaVentanilla)e) + "\n" + this.richTextBox1.Text;
            }
        }
        /// <summary>
        /// Oculta los input para generar una venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.btnAbrir.Enabled = true;
            this.btnGenerarVenta.Enabled = false;
            this.comboBox1.Visible = false;
            this.textBox1.Visible = false;
            this.labelButaca.Visible = false;

            if (this.ventas.IsAlive && this.ventas != null)
            {
                this.ventas.Abort();
            }

        }
        /// <summary>
        /// Genera una venta manual.
        /// </summary>
        public void GenerarUnaVenta()
        {
            Espectaculo espectaculoSeleccionado = (Espectaculo)this.comboBox1.SelectedItem;
            try
            {
                EntradaVentanilla entrada = new EntradaVentanilla(espectaculoSeleccionado.Nombre, espectaculoSeleccionado.Sala, espectaculoSeleccionado.Dia, this.labelButaca.Text, this.textBox1.Text, espectaculoSeleccionado.Costo);
                if (this.boleteria.ConfirmarEntrada(entrada))
                {
                    foreach (Sala s in this.boleteria.Salas)
                    {
                        if (espectaculoSeleccionado == s)
                        {
                            if (s.OcuparButaca(this.labelButaca.Text))
                            {
                                this.richTextBox1.Text += this.boleteria.ImprimirEntradaBreve(entrada) + "\n";
                                this.boleteria.GuardarEntrada(entrada.MostrarDatos());
                                Thread.Sleep(50);
                                this.boleteria.GuardarEntradaEnBD(entrada);
                                MessageBox.Show("Se ha vendido una entrada");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se ha cancelado la venta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            FrmInformes formInformes = new FrmInformes();
            formInformes.ActualizarInforme(this.boleteria.InformeEntradas());
            formInformes.ShowDialog();
        }
    }
}
