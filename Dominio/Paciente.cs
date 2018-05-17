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
        private List<Turno> turnos = new List<Turno>();

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

        public Paciente(int idPaciente, List<Turno> turnos) :base()
        {
            this.idPaciente = idPaciente;
            this.turnos = turnos;
        }

        public Paciente() :base()
        {
        }
    }
}
