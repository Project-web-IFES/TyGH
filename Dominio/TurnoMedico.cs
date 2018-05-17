using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class TurnoMedico : Turno
    {
        private Medico medico;
        private Paciente paciente;    

        public TurnoMedico() :base()
        {
        }

        public TurnoMedico(Medico medico, Paciente paciente):base()
        {
            this.medico = medico;
            this.paciente = paciente;
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

        public Paciente Paciente
        {
            get
            {
                return paciente;
            }

            set
            {
                paciente = value;
            }
        }
    }
}
