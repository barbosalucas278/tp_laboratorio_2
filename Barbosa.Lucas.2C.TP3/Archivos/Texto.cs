using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    
    public class Texto : IArchivos<string>
    {
        #region "Métodos"
        /// <summary>
        /// Guarda datos en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="obj">Informacion que deseamos guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string obj)
        {
            StreamWriter streamWriter = null;
            try
            {
                string ruta = archivo + "-" + DateTime.Now.ToString("yyyyMdd-Hm") + ".txt";
                streamWriter = new StreamWriter(ruta, true);
                streamWriter.WriteLine(obj);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
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
        /// Lee datos en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Referencia al tipo de dato string donde se guardaran los datos leidos.</param>
        /// <returns></returns>
        public string Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            try
            {
                string ruta = archivo + "-" + DateTime.Now.ToString("yyyyMdd-Hm") + ".txt";
                streamReader = new StreamReader(ruta);

                string text = string.Empty;
                string newLine = streamReader.ReadLine();
                while (newLine != null)
                {
                    text += newLine + "\n";
                    newLine = streamReader.ReadLine();
                }

                datos = text;
                return datos;
            }catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }
        #endregion
    }
}
