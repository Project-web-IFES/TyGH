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
    public partial class AltaMedico : System.Web.UI.Page
    {
        MedicoAltaNego medicoNeg = new MedicoAltaNego();
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GuardarMedico()
        {
            Medico medico = new Medico();
            medico.Nombre = txtNombre.Text;
            medico.Apellido = txtApellido.Text;
            medico.Documento = int.Parse(txtDocumento.Text);
            medico.EMail = txtEmail.Text;
            medico.Celular = txtCelular.Text;
            Direccion direccion = new Direccion();
            direccion.Calle = txtCalle.Text;
            direccion.Numero = txtAltura.Text;
            direccion.Piso = txtPiso.Text;
            direccion.Localidad = ddlListarLocalidad.SelectedValue;
            medico.Domicilio = direccion;
            medico.Legajo = int.Parse(txtLegajo.Text);
            medico.Consulta = double.Parse(txtConsulta.Text);
            medico.Especialidad = ddlListarEspecialidades.SelectedValue;
            medico.Matricula = int.Parse(txtMatricula.Text);
            medicoNeg.GuardarMedico(medico);
             
            
        }

        protected void btnEditarMedico_Click(object sender, EventArgs e)
        {
            Button btnEditar = (sender as Button);

            string commandArgument = btnEditar.CommandArgument;

            GridViewRow row = (btnEditar.NamingContainer as GridViewRow);

            int rowIndex = row.RowIndex;

            Response.Redirect("~/EditarMedico?ID=" + commandArgument);
        }

        protected void btnCargarAgenda_Click(object sender, EventArgs e)
        {
            Button btnCargar = (sender as Button);

            string commandArgument = btnCargar.CommandArgument;

            GridViewRow row = (btnCargar.NamingContainer as GridViewRow);

            int rowIndex = row.RowIndex;

            Response.Redirect("~/CargarAgenda?ID=" + commandArgument);
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            GuardarMedico();
        }


        protected void ListarMedicos()
        {
            //SI NO QUIERO QUE APAREZCA EL ID PUEDO SACAR EL BOUNDFIELD DE ID PERO IGUAL PEDIRLO EN LA BASE DE DATOS SOBRE TODO SI TENEMOS BOTONES CON EVENTOS
            gdvListarMedicos.DataSource = medicoNeg.ListarMedicos();
            gdvListarMedicos.DataBind();

        }

        protected void btnListarMedicos_Click(object sender, EventArgs e)
        {
            ListarMedicos();
        }
    }
}