using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// No podrá ser instanciada.
    /// </summary>
    public abstract class Persona
    {
        #region "Atributos"

        public enum ENacionalidad { Argentino, Extranjero };
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region "Constructores"

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.nombre = nombre;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// Obtiene el apellido de la persona.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if(value.Length > 0)
                {
                    this.apellido = value;
                }
            }
        }
        /// <summary>
        /// Obtiene el nombre de la persona.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.nombre = value;
                }
            }
        }
        /// <summary>
        /// Obtiene la nacionalidad de la persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Obtiene el Dni de la persona como int.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Obtiene el Dni de la persona como string.
        /// </summary>
        public string StringToDNI
        {
            get
            {
                return this.dni.ToString();
            }
            set
            {

                this.dni = ValidarDni(this.nacionalidad, value);

            }
        }
        #endregion
        #region "Métodos de Validación"
        /// <summary>
        /// Valida que el DNI sea el correcto segun la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a validar</param>
        /// <param name="dato">Valor del dni ingresado como int</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        return dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        return dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                default:
                    throw new NacionalidadInvalidaException("Nacionalidad Inválida");
            }
        }
        /// <summary>
        /// Valida que el DNI sea el correcto segun la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a validar</param>
        /// <param name="dato">Valor del dni ingresado como string</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni))
            {

                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dni >= 1 && dni <= 89999999)
                        {
                            return dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                        }
                    case ENacionalidad.Extranjero:
                        if (dni >= 90000000 && dni <= 99999999)
                        {
                            return dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                        }
                    default:
                        throw new NacionalidadInvalidaException("NacionalidadInvalida");
                }
            }
            else
            {
                throw new DniInvalidoException();
            }


        }
        #endregion
        #region "Métodos"

        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();

            datosPersona.AppendLine($"{this.Apellido}");
            return datosPersona.ToString();
        }
        #endregion
    }
}

