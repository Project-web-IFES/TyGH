using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Descripción breve de WSverturnos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSverturnos : System.Web.Services.WebService
    {
        TurnoNeg turnoNego = new TurnoNeg();
        PacienteNeg pacienteNeg = new PacienteNeg();
        SalaNeg salaNeg = new SalaNeg();
        AgendaNeg agendaNeg = new AgendaNeg();

        [WebMethod]
        public DataTable PacienteDDL()
        {
            DataTable paciente = new DataTable();
            paciente = pacienteNeg.ListarPacientesDDL();

            return paciente;
        }

        [WebMethod]
        public DataTable SalaDDL()
        {
            DataTable sala = new DataTable();
            sala = salaNeg.ListarSalasDDL();

            return sala;
        }

        [WebMethod]
        public DataTable AgendaDDL()
        {
            DataTable agenda = new DataTable();
            agenda = agendaNeg.ListarAgendasDDL();

            return agenda;
        }


        [WebMethod]
        public void UpdateTurno(DateTime diaHoraInicio, DateTime diaHoraFinal, int idSala, int idAgenda, int idPaciente)
        {

        }
    }
}
