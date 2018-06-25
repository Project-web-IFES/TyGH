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
    public partial class EditarMedico : System.Web.UI.Page
    {
        MedicoAltaNego medicoNeg = new MedicoAltaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["ID"] != null)
                {
                    int idMedico = int.Parse(Request.QueryString["ID"]);
                    ListarMedicoConId(idMedico);
                }
            }
        }

        private void ListarMedicoConId(int id)
        {
            DataTable table = medicoNeg.ListarMedicoConId(id);
            foreach (DataRow row in table.Rows)
            {
                txtNombre.Text = row["nombre"].ToString();
                txtApellido.Text = row["apellido"].ToString();
                txtDocumento.Text = row["documento"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtCelular.Text = row["celular"].ToString();
                ddlListarEspecialidades.Text = row["especialidad"].ToString();
                txtMatricula.Text = row["matricula"].ToString();
                txtLegajo.Text = row["legajo"].ToString();
                txtConsulta.Text = row["consulta"].ToString();
                txtCalle.Text = row["calle"].ToString();
                txtPiso.Text = row["piso"].ToString();
                txtAltura.Text = row["numero"].ToString();
                ddlListarLocalidad.Text = row["localidad"].ToString();

            }

        }

        private void UpdateMedico()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idMedico = int.Parse(Request.QueryString["ID"]);
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


                medicoNeg.UpdateMedico(medico, idMedico);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMedico();
        }
    }
}