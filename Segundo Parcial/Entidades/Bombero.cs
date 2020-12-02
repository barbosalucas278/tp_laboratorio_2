using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void FinDeSalida(int bomberoIndex);
    [Serializable]
    public class Bombero : IArchivos<Bombero>, IArchivos<string>
    {
        [field: NonSerialized] public event FinDeSalida MarcarFin;

        private string nombre;
        private List<Salidas> salidas;
        #region "Constructor"
        public Bombero()
        {
            this.salidas = new List<Salidas>();

        }
        public Bombero(string nombre):this()
        {
            this.nombre = nombre;
        }
        #endregion
        #region "Propiedades"
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        #endregion
        #region "Métodos"

        /// <summary>
        /// Serializara un objeto de tipo Bombero a binario
        /// </summary>
        /// <param name="info">Datos del bombero</param>
        public void Guardar(Bombero info)
        {
            Stream fs = null;
            try
            {
                fs = new FileStream("bomberos.dat", FileMode.Create);
                BinaryFormatter serializador = new BinaryFormatter();

                serializador.Serialize(fs, info);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar un archivo binario",ex);
            }
            finally
            {
                fs.Close();

            }

        }
        /// <summary>
        /// Deserializará de binario un objeto de tipo Bombero-
        /// </summary>
        /// <returns></returns>
        public Bombero Leer()
        {
            Stream fs = null;
            Bombero bomberoAux = null;
            try
            {
                if (File.Exists("bomberos.dat"))
                {
                    bomberoAux = null;
                    fs = new FileStream("bomberos.dat", FileMode.Open);
                    BinaryFormatter serializador = new BinaryFormatter();

                    bomberoAux = (Bombero)serializador.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fs.Close();
            }
            return bomberoAux;
        }
        /// <summary>
        /// Guarda las actividades concretadas y no concretadas de los bomberos.
        /// </summary>
        /// <param name="info"></param>
        void IArchivos<string>.Guardar(string info)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=20201119-sp;Trusted_Connection=True;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string command = string.Empty;
                SqlCommand sqlCommand = null;
                command = "INSERT INTO dbo.log(entrada,alumno) VALUES(@entrada,@alumno);";
                sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("entrada", info);
                sqlCommand.Parameters.AddWithValue("alumno", this.Nombre);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

        }
        /// <summary>
        /// Lee el registro de entradas de la base de datos de bomberos.
        /// </summary>
        /// <returns></returns>
        string IArchivos<string>.Leer()
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=20201119-sp;Trusted_Connection=True;";
            StringBuilder datosLeidos = new StringBuilder();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string command = "SELECT * FROM dbo.log;";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    datosLeidos.AppendLine((string)reader["entrada"]);
                    datosLeidos.AppendLine((string)reader["alumno"]);
                }
            }
            return datosLeidos.ToString();
        }
        /// <summary>
        /// Atiende una salida de un bombero y la guarda en un log.
        /// </summary>
        /// <param name="bomberoIndex"></param>
        public void AtenderSalida(object bomberoIndex)
        {
            Salidas salida = new Salidas();
            this.salidas.Add(salida);
            Thread.Sleep(new Random().Next(2000, 4000));
            salida.FinalizarSalida();
            
            ((IArchivos<string>)this).Guardar($"Salida de bombero {bomberoIndex} concretada");
            this.MarcarFin.Invoke((int)bomberoIndex);
        }
        #endregion
    }
}
