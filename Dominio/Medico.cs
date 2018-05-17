using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Empleado
    {
        private string matricula;
        private Agenda agenda;

        public string Matricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
            }
        }

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

        public Medico(string matricula, Agenda agenda) : base()
        {
            this.matricula = matricula;
            this.agenda = agenda;
        }

        public Medico() : base()
        {
        }
    }
}
