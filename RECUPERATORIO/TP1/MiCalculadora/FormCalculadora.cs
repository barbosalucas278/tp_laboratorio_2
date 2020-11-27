﻿using System;
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
        /// <summary>
        /// Al precionar el boton operar realiza la operacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.textNumero1.Text;
            string numero2 = this.textNumero2.Text;
            string operador = string.Empty;
            if (this.cmbOperador.SelectedItem != null)
            {
                operador = this.cmbOperador.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(numero1) || !string.IsNullOrWhiteSpace(numero2) || !string.IsNullOrWhiteSpace(operador))
                {
                    double resultado = Operar(numero1, numero2, operador);
                    this.lblResultado.Text = resultado.ToString();
                }
            }
        }
        /// <summary>
        /// Realiza una operacion matematica entre dos numeros.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operación.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            char operadorAux = operador[0];
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operadorAux);
        }
        /// <summary>
        /// Al precionar el boton buttonCerrar cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Al precionar el boton limpia el formulario de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Realiza la acción de limpiar los campos de texto del formulario.
        /// </summary>
        private void Limpiar()
        {
            this.textNumero1.Text = string.Empty;
            this.textNumero2.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }
        /// <summary>
        /// Al precionar el boton convierte el numero binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lblResultado.Text))
            {
                Numero numeroEntero = new Numero();
                this.lblResultado.Text = numeroEntero.BinarioDecimal(this.lblResultado.Text);
            }
        }
        /// <summary>
        /// Al precioanr el boton convierte solamente la parte entera del numero decimal en binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lblResultado.Text))
            {
                Numero numeroEntero = new Numero();
                this.lblResultado.Text = numeroEntero.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Estás seguro que queres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
