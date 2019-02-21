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
    public class PacienteNeg
    {
        PacienteRep pacienteRep = new PacienteRep();

        public void GuardarPaciente(Paciente paciente)
        {
            pacienteRep.GuardarPaciente(paciente);
        }

        public void UpdatePaciente(Paciente paciente, int id)
        {
            pacienteRep.UpdatePaciente(paciente, id);
        }

        public DataTable ListarMedicos()
        {
            return pacienteRep.ListarPacientes();
        }

        public DataTable ListarPacienteConId(int id)
        {
            return pacienteRep.ListarPacienteConId(id);
        }

        public DataTable ListarPacientesDDL()
        {
            return pacienteRep.ListarPacientesDDL();
        }

        public DataTable ListarPacienteConIdNomApe(int id)
        {
            return pacienteRep.ListarPacienteConIdNomApe(id);
        }

        //public void DeletePaciente(int id)
        //{
        //    pacienteRep.DeletePaciente(id);
        //}
    }
}
