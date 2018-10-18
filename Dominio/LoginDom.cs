using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LoginDom
    {
        
        private String nombre;
        private String apellido;
        private String correo;
        private String password;

        public LoginDom()
        {
        }

        public LoginDom(string nombre, string apellido, string correo, string password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.password = password;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Password { get => password; set => password = value; }
    }
}
