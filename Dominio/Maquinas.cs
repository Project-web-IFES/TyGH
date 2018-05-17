using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Maquinas : Almacen
    {
        private string observacion;

        public string Observacion
        {
            get
            {
                return observacion;
            }

            set
            {
                observacion = value;
            }
        }

        public Maquinas(string observacion) :base()
        {
            this.Observacion = observacion;
        }

        public Maquinas() :base()
        {
        }
    }
}
