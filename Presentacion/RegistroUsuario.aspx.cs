using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Data;
using System.Security.Cryptography;

namespace Presentacion
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        private string hashpass;
        private string usuario;    

        LoginNego loginNego = new LoginNego();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Registro();
        }

        public void Registro()
        {
            
            byte[] pass;
            pass = System.Text.Encoding.UTF8.GetBytes(txtPass.Text.ToString());
            hashpass = Hash(pass);
            usuario = txtEmail.Text;
            CompararUsuaruio(usuario, hashpass);

        }

        public String Hash(byte[] val)
        {
            using (SHA1Managed sha1=new SHA1Managed()) {
                var hash = sha1.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
         }

        private void CompararUsuaruio(string correo, string hashpass)
        {
            DataTable data=loginNego.compararUsuarioPass(correo);
            string correobase = data.Rows[0]["correo"].ToString();
            string contraseñabase = data.Rows[0]["password"].ToString();
            if(contraseñabase == hashpass)
            {
                Session["log"] = correo;
                Response.Redirect("/Default.aspx");
            }
            
        }
    }
}