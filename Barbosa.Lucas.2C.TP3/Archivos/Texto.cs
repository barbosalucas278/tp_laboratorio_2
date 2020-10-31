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
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }           
        }

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
