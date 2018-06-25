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
        private Medico medico;
        List<Turno> turnos = new List<Turno>();

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

        public Medico Medico
        {
            get
            {
                return medico;
            }

            set
            {
                medico = value;
            }
        }

        public List<Turno> Turnos
        {
            get
            {
                return turnos;
            }

            set
            {
                turnos = value;
            }
        }

        public Agenda(DateTime diaHoraInicio, DateTime diaHoraFinal, Medico medico, List<Turno> turnos)
        {
            this.diaHoraInicio = diaHoraInicio;
            this.diaHoraFinal = diaHoraFinal;
            this.medico = medico;
            this.turnos = turnos;
        }

        public Agenda()
        {
        }
    }
}
