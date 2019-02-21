using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Repositorio;

namespace Negocio
{
    public class AgendaNeg
    {
        AgendaRep agendaRep = new AgendaRep();

        public void GuardarAgenda(Agenda agenda)
        {
            agendaRep.GuardarAgenda(agenda);
        }

        public DataTable ListarAgendas(int id)
        {
            return agendaRep.ListarAgendas(id);
        }

        public DataTable ListarAgendasDDL()
        {
            return agendaRep.ListarAgendaDDL();
        }

    }
}
