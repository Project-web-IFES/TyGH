using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Negocio
{
    public class LoginNego
    {
        LoginRepo loginRepo = new LoginRepo();
        public DataTable compararUsuarioPass(String usuario, String contraseña)
        {
            return loginRepo.ListUsuarioPass(usuario, contraseña);
        }
    }
}
