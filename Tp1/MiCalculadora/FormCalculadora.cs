using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(this.textNumero1.Text, this.textNumero2.Text, this.cmbOperador.SelectedItem.ToString());
            this.lblResultado.Text = resultado.ToString();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1),new Numero(numero2), operador);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.textNumero1.Text = string.Empty;
            this.textNumero2.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }

        private void buttonConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lblResultado.Text))
            {
                Numero numeroEntero = new Numero();
                this.lblResultado.Text = numeroEntero.BinarioDecimal(this.lblResultado.Text);
            }
        }

        private void buttonConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lblResultado.Text))
            {
                Numero numeroEntero = new Numero();
                this.lblResultado.Text = numeroEntero.DecimalBinario(this.lblResultado.Text);
            }
        }
    }
}
