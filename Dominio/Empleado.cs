using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Empleado : Persona
    {
        //este seria nuestro id de empleado
        private int legajo;
        private double consulta;

        public int Legajo
        {
            get
            {
                return legajo;
            }

            set
            {
                legajo = value;
            }
        }

        public double Consulta
        {
            get
            {
                return consulta;
            }

            set
            {
                consulta = value;
            }
        }

        protected Empleado(int legajo, double consulta) : base()
        {
            this.legajo = legajo;
            this.consulta = consulta;
        }

        protected Empleado() :base()
        {
        }
    }
}
