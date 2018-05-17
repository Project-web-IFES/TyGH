using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sala
    {
        private int numero;
        private string nombre;

        public int Numero
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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public Sala(int numero, string nombre) 
        {
            this.Numero = numero;
            this.Nombre = nombre;
        }

        public Sala()
        {
        }
    }
}
