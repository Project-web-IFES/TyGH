using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Almacen
    {
        private int id;
        private string descripcion;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public Almacen(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public Almacen()
        {
        }
    }
}
