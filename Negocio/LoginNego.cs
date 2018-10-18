using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Dominio;
namespace Negocio
{
    public class LoginNego
    {
    
        LoginRepo loginRepo = new LoginRepo();
        public DataTable compararUsuarioPass(String usuario)
        {
            return loginRepo.ListUsuarioPass(usuario);
        }

        public void GuardarUsuario(LoginDom login)
        {
            loginRepo.GuardarUsuario(login);
        }
    }
}
