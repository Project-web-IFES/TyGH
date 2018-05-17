using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Farmacologia : Almacen
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

        public Farmacologia(string observacion) :base()
        {
            this.Observacion = observacion;
        }

        public Farmacologia() :base()
        {
        }
    }
}
