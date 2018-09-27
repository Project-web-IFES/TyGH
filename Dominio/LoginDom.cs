using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LoginDom
    {
        private String correo;
        private String password;

        public LoginDom()
        {
        }

        public LoginDom(string correo, string password)
        {
            this.correo = correo;
            this.password = password;
        }

        public string Correo { get => correo; set => correo = value; }
        public string Password { get => password; set => password = value; }
    }
}
