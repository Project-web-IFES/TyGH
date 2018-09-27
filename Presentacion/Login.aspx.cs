using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Data;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        LoginNego loginNego = new LoginNego();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginDom loginDom = new LoginDom();
            loginDom.Correo = txtEmail.ToString();
            //txtEmail.Text = "hola";
            //loginDom.Password = TbxPass.ToString();
            DataTable dataTable = new DataTable();
            //dataTable = loginNego.compararUsuarioPass(loginDom.Correo, loginDom.Password);
            dataTable = loginNego.compararUsuarioPass(txtEmail.Text, txtPass.Text);
            if (txtEmail.Text == dataTable.Rows[0]["correo"].ToString() & txtPass.Text == dataTable.Rows[0]["contraseña"].ToString())
            {
                Session["correo"] = loginDom.Correo;
                Session["password"] = loginDom.Password;
                Response.Redirect("/Default.aspx");
            }


        }
    }
}