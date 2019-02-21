using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        PacienteNeg pacienteNeg = new PacienteNeg();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListarPacientes()
        {
            //SI NO QUIERO QUE APAREZCA EL ID PUEDO SACAR EL BOUNDFIELD DE ID PERO IGUAL PEDIRLO EN LA BASE DE DATOS SOBRE TODO SI TENEMOS BOTONES CON EVENTOS
            gdvListarPacientes.DataSource = pacienteNeg.ListarMedicos();
            gdvListarPacientes.DataBind();

        }

        protected void btnListarPacientes_Click(object sender, EventArgs e)
        {
            ListarPacientes();
        }


        public void GuardarPaciente()
        {
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

            pacienteNeg.GuardarPaciente(paciente);


        }

        protected void btnGuardarPaciente_Click(object sender, EventArgs e)
        {
            GuardarPaciente();
        }

        protected void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            Button btnEditar = (sender as Button);

            string commandArgument = btnEditar.CommandArgument;

            GridViewRow row = (btnEditar.NamingContainer as GridViewRow);

            int rowIndex = row.RowIndex;

            Response.Redirect("~/EditarPaciente?ID=" + commandArgument);
        }

        protected void btnVerTurnos_Click(object sender, EventArgs e)
        {
            Button btnVer = (sender as Button);

            string commandArgument = btnVer.CommandArgument;

            GridViewRow row = (btnVer.NamingContainer as GridViewRow);

            int rowIndex = row.RowIndex;

            Response.Redirect("~/VerTurno?ID=" + commandArgument);
        }
    }
}