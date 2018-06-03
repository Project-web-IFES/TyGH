using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Empleado
    {
        private int matricula;
        private string especialidad;
        private Agenda agenda;

        public Agenda Agenda
        {
            get
            {
                return agenda;
            }

            set
            {
                agenda = value;
            }
        }

        public int Matricula { get => matricula; set => matricula = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }

        public Medico(int matricula, string especialidad, Agenda agenda) :base()
        {
            this.matricula = matricula;
            this.especialidad = especialidad;
            this.agenda = agenda;
        }

        public Medico()
        {
        }
    
    }
}
