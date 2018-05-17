using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        private string calle;
        private string numero;
        private string piso;
        private string localidad;

        public string Calle
        {
            get
            {
                return calle;
            }

            set
            {
                calle = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Piso
        {
            get
            {
                return piso;
            }

            set
            {
                piso = value;
            }
        }

        public string Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value;
            }
        }

  

        public Direccion()
        {
        }

        public Direccion(string calle, string numero, string piso, string localidad)
        {
            this.calle = calle;
            this.numero = numero;
            this.piso = piso;
            this.localidad = localidad;
        }
    }
}
