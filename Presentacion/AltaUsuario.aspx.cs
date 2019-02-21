using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        LoginNego loginNego = new LoginNego();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String Hash(byte[] val)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            CrearUsuario();
        }

        public void CrearUsuario()
        {
            byte[] pass;
            LoginDom login = new LoginDom();
            login.Apellido = TxtApellido.Text;
            login.Nombre = TxtNombreUsuario.Text;
            login.Correo = txtEmail.Text;
            pass = System.Text.Encoding.UTF8.GetBytes(txtPass.Text.ToString());
            login.Password=Hash(pass);
            loginNego.GuardarUsuario(login);
            Response.Redirect("~/RegistroUsuario");
        }


    }
}