using Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void EntradaDelegate(Entrada e);
    public delegate void CallbackSalas(Sala s);
    /// <summary>
    /// Esta clase no puede ser derivada.
    /// </summary>
    /// <typeparam name="U">Tipo Entrada</typeparam>
    public sealed class Boleteria<U> : IBoleteria<U> where U : Entrada
    {
        public event EntradaDelegate EventoConfirmacion;
        #region "Atributos"
        public enum TipoVenta { Ventanilla, Electronica }
        private List<U> entradas;
        private List<Sala> salas;
        private List<Espectaculo> espectaculos;
        #endregion
        #region "Constructor"
        public Boleteria(List<Sala> salas, List<Espectaculo> espectaculos)
        {
            this.salas = salas;
            this.espectaculos = espectaculos;
            this.entradas = new List<U>();
        }
        #endregion
        #region "propiedades"
        /// <summary>
        /// Propiedad que maneja el atributo salas.
        /// </summary>
        public List<Sala> Salas
        {
            get
            {
                return this.salas;
            }
            set
            {
                this.salas = value;
            }
        }
        /// <summary>
        /// Propiedad que maneja el atributo espectaculos.
        /// </summary>
        public List<Espectaculo> Espectaculos
        {
            get
            {
                return this.espectaculos;
            }
        }
        #endregion
        #region "Metodos"
        /// <summary>
        /// Confirma la venta de una entrada.
        /// </summary>
        /// <param name="e">Entrada</param>
        /// <returns>True si se efectuó la venta, false y no se efectuó</returns>
        public bool ConfirmarEntrada(U e)
        {
            this.EventoConfirmacion.Invoke(e);
            Thread.Sleep(new Random().Next(1000, 2000));
            foreach (U entrada in this.entradas)
            {
                if (e == entrada)
                {
                    return false;
                }
            }

            this.entradas.Add(e);

            return true;
        }
        /// <summary>
        /// Imprimie los datos de una entrada
        /// </summary>
        /// <param name="e">Entrada</param>
        /// <returns></returns>
        public string InformeEntradas()
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=tp4-database;Trusted_Connection=True;";
            StringBuilder datosLeidos = new StringBuilder();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string command = "SELECT * FROM entradas;";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    datosLeidos.AppendLine("Id: "+reader["id"].ToString());
                    datosLeidos.AppendLine("Espectaculo: "+(string)reader["nombre"]);
                    datosLeidos.AppendLine("Sala:"+ reader["sala"].ToString());
                    datosLeidos.AppendLine("Fecha: "+(string)reader["dia"]);
                    datosLeidos.AppendLine("Butaca: "+(string)reader["butaca"]);
                    datosLeidos.AppendLine("Precio: "+reader["precio"].ToString());
                    datosLeidos.AppendLine("******************************************\n");
                }
            }
            return datosLeidos.ToString();
        }
        /// <summary>
        /// Imprime los datos de una entrada de una forma breve.
        /// </summary>
        /// <param name="e">Entrada</param>
        /// <returns></returns>
        public string ImprimirEntradaBreve(U e)
        {
            return e.MostrarDatos();
        }
        /// <summary>
        /// Guarda datos en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="obj">Informacion que deseamos guardar</param>
        /// <returns></returns>
        public bool GuardarEntrada(string obj)
        {
            StreamWriter streamWriter = null;
            try
            {
                string ruta = "entradas\\entrada-" + DateTime.Now.ToString("yyyyMdd-Hms") + ".txt";
                streamWriter = new StreamWriter(ruta, false);
                streamWriter.WriteLine(obj);
                
                return true;
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
        /// <summary>
        /// Retorna una butaca libre aleatoria de la sala correspondiente al espectaculo.
        /// </summary>
        /// <param name="e">Espectáculo</param>
        /// <returns></returns>
        public string BuscarButacaLibre(Espectaculo e)
        {
            string butacaLibre = string.Empty;
            Thread.Sleep(300);
            try
            {
                foreach (Sala sala in this.Salas)
                {
                    if (e == sala)
                    {
                        int cantidadButacas = sala.Butacas.Count;
                        int butacaRandomLibre;
                        for (int i = 0; i < cantidadButacas ; i++)
                        {
                            Thread.Sleep(25);
                            butacaRandomLibre = new Random().Next(0,99);                        
                            if (sala.Butacas[butacaRandomLibre].Estado == Butaca.TipoEstado.Libre)
                            {
                                butacaLibre = sala.Butacas[butacaRandomLibre].Ubicacion;

                                break;
                            }
                            else
                            {
                                cantidadButacas--;
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BoleteriaException("Ha ocurrido un error las salas no estaban actualizadas todavia", ex);
            }
            return butacaLibre;
        }
        /// <summary>
        /// Guarda una entrada en una base de datos.
        /// </summary>
        /// <param name="entrada">Entrada</param>
        public void GuardarEntradaEnBD(U entrada)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=tp4-database;Trusted_Connection=True;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string command = string.Empty;
                SqlCommand sqlCommand = null;
                command = "INSERT INTO entradas(nombre,sala,dia,butaca,precio) VALUES(@nombre,@sala,@dia,@butaca,@precio);";
                sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", entrada.Espectaculo);
                sqlCommand.Parameters.AddWithValue("sala", entrada.Sala);
                sqlCommand.Parameters.AddWithValue("dia", entrada.Fecha);
                sqlCommand.Parameters.AddWithValue("butaca", entrada.Butaca);
                sqlCommand.Parameters.AddWithValue("precio", (float)entrada.Precio);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            
        }
        #endregion
    }
}
