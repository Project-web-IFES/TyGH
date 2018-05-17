using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Psicologo : Empleado
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

        public Psicologo() :base()
        {
        }

        public Psicologo(string matricula, Agenda agenda):base()
        {
            this.matricula = matricula;
            this.agenda = agenda;
        }
    }
}
