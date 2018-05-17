using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class TurnoPsicologo : Turno
    {
        private Psicologo psicologo;
        private Paciente paciente;

        public Psicologo Psicologo
        {
            get
            {
                return psicologo;
            }

            set
            {
                psicologo = value;
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

        public TurnoPsicologo(Psicologo psicologo, Paciente paciente) :base()
        {
            this.psicologo = psicologo;
            this.paciente = paciente;
        }

        public TurnoPsicologo() :base()
        {
        }
    }
}
