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
    public class TurnoNeg
    {
        TurnoRep turnoRep = new TurnoRep();

        public void GuardarTurno(Turno turno)
        {
            turnoRep.GuardarTurno(turno);
        }

        public DataTable ListarTurnos(int id)
        {
            return turnoRep.ListarTurnos(id);
        }

        public DataTable ListarTurnosPaciente(int id)
        {
            return turnoRep.ListarTurnosPaciente(id);
        }

    }
}
