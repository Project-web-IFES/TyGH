using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda
    {
        private DateTime diaHoraInicio;
        private DateTime diaHoraFinal;
        private int idMedico;

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


        public int IdMedico { get => idMedico; set => idMedico = value; }

        public Agenda(DateTime diaHoraInicio, DateTime diaHoraFinal, int idMedico)
        {
            this.diaHoraInicio = diaHoraInicio;
            this.diaHoraFinal = diaHoraFinal;
            this.idMedico = idMedico;
        }

        public Agenda()
        {
        }
    }
}
