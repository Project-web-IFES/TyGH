using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        private DateTime diaHoraInicio;
        private DateTime diaHoraFinal;
        private int idSala;
        private int idPaciente;
        private int idAgenda;

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


        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public int IdAgenda { get => idAgenda; set => idAgenda = value; }
        public int IdSala { get => this.idSala; set => this.idSala = value; }

        public Turno(DateTime diaHoraInicio, DateTime diaHoraFinal, int idSala, int idAgenda, int idPaciente)
        {
            this.idSala = idSala;
            this.diaHoraInicio = diaHoraInicio;
            this.diaHoraFinal = diaHoraFinal;
            this.idAgenda = idAgenda;
            this.idPaciente = idPaciente;
        }

        public Turno()
        {
        }


    }
}
