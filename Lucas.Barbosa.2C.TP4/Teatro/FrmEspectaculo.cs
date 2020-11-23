using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teatro
{
    public partial class FrmEspectaculo : Form
    {        
        public FrmEspectaculo(List<Sala> salas)
        {
            InitializeComponent();
            this.cbSala.DataSource = salas;
            
        }
        public string Nombre
        {
            get
            {
                return this.tbNombre.Text;
            }
        }
        public string Descripcion
        {
            get
            {
                return this.tbDescripcion.Text;
            }
        }
        public DateTime Diaa
        {
            get
            {
                return this.dtpickerHorario.Value;
            }
        }
        public double Costo
        {
            get
            {
                double costoDouble;
                if(double.TryParse(this.textBoxCosto.Text, out costoDouble))
                {
                    return costoDouble;
                }
                else
                {
                    throw new EspectaculoException("Costo invalido");
                }
            }
        }
        public int Sala
        {
            get
            {
                int salaInt;
                int.TryParse(this.cbSala.Text,out salaInt);
                return salaInt;
            }
        }

        private void dtpickerHorario_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
