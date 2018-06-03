using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Empleado
    {
        private Especialidad especialidad;
        private Agenda agenda;

        public Especialidad Especialidad
        {
            get
            {
                return especialidad;
            }

            set
            {
                especialidad = value;
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

        public Medico(Especialidad especialidad, Agenda agenda)
        {
            this.especialidad = especialidad;
            this.agenda = agenda;
        }
        public Medico()
        {
        }
    
    }
}
