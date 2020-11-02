using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        #region "Métodos"
        /// <summary>
        /// Guarda los datos de un tipo de objeto T en un archivo Xml.
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="obj">Objeto que deseamos guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T obj)
        {
            string ruta = archivo + "-" + DateTime.Now.ToString("yyyyMdd-Hm") + ".xml";
            XmlTextWriter writer = null;
            XmlSerializer serializador = null;
            try
            {
                writer = new XmlTextWriter(ruta, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(writer, obj);
                return true;
            }catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

            }
        }
        /// <summary>
        /// Lee un archivo Xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Variable de tipo T donde seran guardados los datos leidos.</param>
        /// <returns></returns>
        public T Leer(string archivo, out T datos)
        {
            string ruta = archivo + "-" + DateTime.Now.ToString("yyyyMdd-Hm") + ".xml";
            using (XmlTextReader reader = new XmlTextReader(ruta))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
            }
            return datos;
        }
        #endregion
    }
}
