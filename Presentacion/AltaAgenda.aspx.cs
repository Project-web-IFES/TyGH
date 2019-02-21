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
    public partial class AltaAgenda : System.Web.UI.Page
    {
        MedicoAltaNego medicoNeg = new MedicoAltaNego();
        AgendaNeg agendaNeg = new AgendaNeg();

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
            DataTable table = medicoNeg.ListarMedicoConIdNomApe(id);
            foreach (DataRow row in table.Rows)
            {
                lblNombre.Text = row["nombre"].ToString();
                lblApellido.Text = row["apellido"].ToString();
            }

        }

        private void GuardarAgenda()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idMedico = int.Parse(Request.QueryString["ID"]);
                Agenda agenda = new Agenda();
                agenda.IdMedico = idMedico;
                agenda.DiaHoraFinal = DateTime.Parse(txtFechaHoraFin.Text);
                agenda.DiaHoraInicio = DateTime.Parse(txtFechaHoraInicio.Text);
                agendaNeg.GuardarAgenda(agenda);

            }
        }

        protected void btnGuardarAgenda_Click(object sender, EventArgs e)
        {
            GuardarAgenda();
        }

        protected void ListarAgendas()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idMedico = int.Parse(Request.QueryString["ID"]);
                gdvListarAgendas.DataSource = agendaNeg.ListarAgendas(idMedico);
                gdvListarAgendas.DataBind();
            }


        }

        protected void btnListarAgendas_Click(object sender, EventArgs e)
        {
            ListarAgendas();
        }


        protected void btnCargarOVerTurnos_Click(object sender, EventArgs e)
        {
            Button btnCargarVer = (sender as Button);

            string commandArgument = btnCargarVer.CommandArgument;

            GridViewRow row = (btnCargarVer.NamingContainer as GridViewRow);

            int rowIndex = row.RowIndex;

            Response.Redirect("~/AltaVistaTurno?ID=" + commandArgument);
        }
    }
}