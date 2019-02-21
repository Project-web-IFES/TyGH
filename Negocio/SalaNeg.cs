using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Dominio;
using System.Data;

namespace Negocio
{
    public class SalaNeg
    {
        SalaRep salaRep = new SalaRep();

        public DataTable ListarSalasDDL()
        {
            return salaRep.ListarSalasDDL();
        }
    }
}
