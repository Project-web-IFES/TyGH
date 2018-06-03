using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Especialidad
    {
        string doctorado;
        string matricula;

        public Especialidad(string doctorado, string matricula)
        {
            this.doctorado = doctorado;
            this.matricula = matricula;
        }
        public Especialidad()
        {
        }

        public string Doctorado
        {
            get
            {
                return doctorado;
            }

            set
            {
                doctorado = value;
            }
        }

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
    }
}
