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
    public partial class AltaVistaTurno : System.Web.UI.Page
    {
        MedicoAltaNego medicoNeg = new MedicoAltaNego();
        PacienteNeg pacienteNeg = new PacienteNeg();
        TurnoNeg turnoNeg = new Negocio.TurnoNeg();
        SalaNeg salaNeg = new SalaNeg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["ID"] != null)
                {
                    int idAgenda = int.Parse(Request.QueryString["ID"]);
                    ListarMedicoConId(idAgenda);
                }
            }
        }

        private void ListarMedicoConId(int id)
        {
            DataTable table = medicoNeg.ListarMedicoConIdNomApeAgenda(id);
            foreach (DataRow row in table.Rows)
            {
                lblNombre.Text = row["nombre"].ToString();
                lblApellido.Text = row["apellido"].ToString();
            }

        }



        protected void ddlListarPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPaciente = int.Parse(ddlListarPacientes.SelectedValue);

            hfIdPaciente.Value = idPaciente.ToString();
        }

        private void GuardarTurno()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idAgenda = int.Parse(Request.QueryString["ID"]);
                Turno turno = new Turno();
                turno.IdPaciente = int.Parse(hfIdPaciente.Value.ToString());
                turno.DiaHoraFinal = DateTime.Parse(txtFechaHoraFin.Text);
                turno.DiaHoraInicio = DateTime.Parse(txtFechaHoraInicio.Text);
                turno.IdAgenda = idAgenda;
                turno.IdSala = int.Parse(hfIdSala.Value.ToString());

                turnoNeg.GuardarTurno(turno);

            }


        }

        protected void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            GuardarTurno();
        }

        private void ListarCheck()
        {


            ddlListarPacientes.DataSource = pacienteNeg.ListarPacientesDDL();
            ddlListarPacientes.DataValueField = "idPaciente";
            ddlListarPacientes.DataTextField = "nombreApellido";
            ddlListarPacientes.DataBind();

            ddlListarPacientes.Items.Insert(0, new ListItem("---Select Paciente---", "0"));
        }



        protected void btnListarPacientes_Click(object sender, EventArgs e)
        {
            ListarCheck();
        }

        protected void ListarTurnos()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idAgenda = int.Parse(Request.QueryString["ID"]);
                gdvListarTurnos.DataSource = turnoNeg.ListarTurnos(idAgenda);
                gdvListarTurnos.DataBind();
            }


        }

        protected void btnListarTurnos_Click(object sender, EventArgs e)
        {
            ListarTurnos();
        }

        protected void ddlListarSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSala = int.Parse(ddlListarSalas.SelectedValue);

            hfIdSala.Value = idSala.ToString();
        }

        private void ListarCheckSalas()
        {
            ddlListarSalas.DataSource = salaNeg.ListarSalasDDL();
            ddlListarSalas.DataValueField = "idSala";
            ddlListarSalas.DataTextField = "nombre";
            ddlListarSalas.DataBind();

            ddlListarSalas.Items.Insert(0, new ListItem("---Select Sala---", "0"));
        }

        protected void btnListarSalas_Click(object sender, EventArgs e)
        {
            ListarCheckSalas();
        }
    }
}