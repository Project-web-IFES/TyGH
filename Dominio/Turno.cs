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
        private Paciente paciente;
        private Agenda agenda;

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

        public Agenda Agenda { get => agenda; set => agenda = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }

        protected Turno(DateTime diaHoraInicio, DateTime diaHoraFinal, Sala sala, Agenda agenda, Paciente paciente)
        {
            this.sala = sala;
            this.diaHoraInicio = diaHoraInicio;
            this.diaHoraFinal = diaHoraFinal;
            this.agenda = agenda;
            this.paciente = paciente;
        }

        protected Turno()
        {
        }


    }
}
