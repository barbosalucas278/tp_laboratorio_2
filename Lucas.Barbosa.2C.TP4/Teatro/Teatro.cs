using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teatro
{
    public partial class Teatro : Form
    {
        #region "Atributos"

        private const int CantidadDeSalas = 3;
        private List<Espectaculo> espectaculos;
        private List<Sala> salas;
        private Boleteria<EntradaVentanilla> boleteriaVentanilla;
        private FrmBoleteriaVentanilla FormVentanilla;
        private Boleteria<EntradaElectronica> boleteriaElectronica;
        private FrmBoleteriaElectronica formBoleteriaelectronica;
        #endregion
        #region "Constructor"

        public Teatro()
        {
            InitializeComponent();
            this.espectaculos = new List<Espectaculo>();
            this.salas = new List<Sala>();
            this.boleteriaVentanilla = this.GenerarBoleteriaVentanilla();
            this.boleteriaElectronica = this.GenerarBoleteriaElectronica();
        }
        #endregion

        private void FrmTeatro_Load(object sender, EventArgs e)
        {
            this.boleteriaToolStripMenuItem.Enabled = true;
            this.CrearSalas(CantidadDeSalas);
            this.espectaculos.Add(new Espectaculo("dracula", "bla bla", new DateTime(2020, 11, 21, 19, 40, 00), 1,200));
            this.espectaculos.Add(new Espectaculo("pokemon", "bla bla", new DateTime(2020, 11, 21, 20, 40, 00), 2, 250));
            //this.espectaculos.Add(new Espectaculo("motorhead", "bla bla", new DateTime(2020, 11, 21, 21, 40, 00), 3, 300.50));

        }
        private void VentanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentanilla = new FrmBoleteriaVentanilla(this.boleteriaVentanilla);
            
            FormVentanilla.MdiParent = this;
            FormVentanilla.Show();
            this.vEntanillaToolStripMenuItem.Enabled = false;

        }
        private void electronicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBoleteriaelectronica = new FrmBoleteriaElectronica(this.boleteriaElectronica);

            formBoleteriaelectronica.MdiParent = this;
            formBoleteriaelectronica.Show();
            this.electronicaToolStripMenuItem.Enabled = false;
        }
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEspectaculo formEspectaculo = new FrmEspectaculo(this.salas);
            formEspectaculo.ShowDialog();
            try
            {
                this.espectaculos.Add(new Espectaculo(formEspectaculo.Nombre, formEspectaculo.Descripcion, formEspectaculo.Diaa, formEspectaculo.Sala,formEspectaculo.Costo));

            }
            catch (EspectaculoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(this.espectaculos.Count >= 3)
            {
                this.agregarToolStripMenuItem.Enabled = false;
                this.boleteriaToolStripMenuItem.Enabled = true;
            }
        }
        #region "Metodos"
        /// <summary>
        /// Crea las salas del teatro.
        /// </summary>
        /// <param name="cantidad"></param>
        private void CrearSalas(int cantidad)
        {
            for (int sala = 1; sala <= cantidad; sala++)
            {
                this.salas.Add(new Sala(sala));
            }
        }
        /// <summary>
        /// Genera una nueva boleteria ventanilla.
        /// </summary>
        /// <returns></returns>
        private Boleteria<EntradaVentanilla> GenerarBoleteriaVentanilla()
        {
            Boleteria<EntradaVentanilla> boleteria = new Boleteria<EntradaVentanilla>(this.salas, this.espectaculos);

            return boleteria;
        }
        /// <summary>
        /// Genera una boleteria electronica.
        /// </summary>
        /// <returns></returns>
        private Boleteria<EntradaElectronica> GenerarBoleteriaElectronica()
        {
            Boleteria<EntradaElectronica> boleteria = new Boleteria<EntradaElectronica>(this.salas, this.espectaculos);

            return boleteria;
        }
        #endregion

    }
}
