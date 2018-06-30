using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente : Persona
    {
        private int idPaciente;

        public int IdPaciente
        {
            get
            {
                return idPaciente;
            }

            set
            {
                idPaciente = value;
            }
        }


        public Paciente(int idPaciente) :base()
        {
            this.idPaciente = idPaciente;
        }

        public Paciente() :base()
        {
        }
    }
}
