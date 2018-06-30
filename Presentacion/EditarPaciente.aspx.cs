using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Negocio;

namespace Presentacion
{
    public partial class EditarPaciente : System.Web.UI.Page
    {
        private PacienteNeg pacienteNeg = new PacienteNeg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["ID"] != null)
                {
                    int idPaciente = int.Parse(Request.QueryString["ID"]);
                    ListarPacienteConId(idPaciente);
                }
            }
        }


        private void ListarPacienteConId(int id)
        {
            DataTable table = pacienteNeg.ListarPacienteConId(id);
            foreach (DataRow row in table.Rows)
            {
                txtNombre.Text = row["nombre"].ToString();
                txtApellido.Text = row["apellido"].ToString();
                txtDocumento.Text = row["documento"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtCelular.Text = row["celular"].ToString();
                txtCalle.Text = row["calle"].ToString();
                txtPiso.Text = row["piso"].ToString();
                txtAltura.Text = row["numero"].ToString();
                ddlListarLocalidad.Text = row["localidad"].ToString();


            }

        }

        private void UpdatePaciente()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idPaciente = int.Parse(Request.QueryString["ID"]);
                Paciente paciente = new Paciente();
                paciente.Nombre = txtNombre.Text;
                paciente.Apellido = txtApellido.Text;
                paciente.Documento = int.Parse(txtDocumento.Text);
                paciente.EMail = txtEmail.Text;
                paciente.Celular = txtCelular.Text;
                Direccion direccion = new Direccion();
                direccion.Calle = txtCalle.Text;
                direccion.Numero = txtAltura.Text;
                direccion.Piso = txtPiso.Text;
                direccion.Localidad = ddlListarLocalidad.SelectedValue;
                paciente.Domicilio = direccion;

                pacienteNeg.UpdatePaciente(paciente, idPaciente);
            }
        }

        protected void btnUpdatePaciente_Click(object sender, EventArgs e)
        {
            UpdatePaciente();
        }

        //private void DeletePaciente()
        //{
        //    if (Request.QueryString["ID"] != null)
        //    {
        //        int idPaciente = int.Parse(Request.QueryString["ID"]);
        //        pacienteNeg.DeletePaciente(idPaciente);
        //    }
        //    //Response.Redirect("PersonaCapa.aspx");
        //}

        //protected void btnEliminarPaciente_Click(object sender, EventArgs e)
        //{
        //    DeletePaciente();
        //}
    }
}