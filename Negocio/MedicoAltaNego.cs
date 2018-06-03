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
        
        public void guardarMedico(Medico medico)
        {
            medicoRepo.GuardarMedico(medico);
        }
        public void update(Medico medico)
        {
            medicoRepo.Update(medico);
        }

        public DataTable listar()
        {
            return medicoRepo.listarMedicos();
        }

    }
}
