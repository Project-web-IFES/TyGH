using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Turno
    {
        private DateTime diaHoraInicio;
        private DateTime diaHoraFinal;
        private Sala sala;

        public DateTime DiaHoraInicio
        {
            get
            {
                return diaHoraInicio;
            }

            set
            {
                diaHoraInicio = value;
            }
        }

        public DateTime DiaHoraFinal
        {
            get
            {
                return diaHoraFinal;
            }

            set
            {
                diaHoraFinal = value;
            }
        }

        public Sala Sala
        {
            get
            {
                return sala;
            }

            set
            {
                sala = value;
            }
        }

        protected Turno(DateTime diaHoraInicio, DateTime diaHoraFinal, Sala sala)
        {
            this.sala = sala;
            this.diaHoraInicio = diaHoraInicio;
            this.diaHoraFinal = diaHoraFinal;
        }

        protected Turno()
        {
        }


    }
}
