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
    public class MedicoAltaNego
    {
        MedicoAltaRepo medicoRepo = new MedicoAltaRepo();
        
        public void GuardarMedico(Medico medico)
        {
            medicoRepo.GuardarMedico(medico);
        }
        public void UpdateMedico(Medico medico, int id)
        {
            medicoRepo.UpdateMedico(medico, id);
        }

        public DataTable ListarMedicos()
        {
            return medicoRepo.ListarMedicos();
        }

        public DataTable ListarMedicoConId(int id)
        {
            return medicoRepo.ListarMedicoConId(id);
        }

    }
}
