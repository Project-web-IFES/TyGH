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
    public partial class VerTurno : System.Web.UI.Page
    {
        PacienteNeg pacienteNeg = new PacienteNeg();
        TurnoNeg turnoNeg = new TurnoNeg();

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
            DataTable table = pacienteNeg.ListarPacienteConIdNomApe(id);
            foreach (DataRow row in table.Rows)
            {
                lblNombre.Text = row["nombre"].ToString();
                lblApellido.Text = row["apellido"].ToString();
            }

        }


        protected void ListarTurnos()
        {
            if (Request.QueryString["ID"] != null)
            {
                int idPaciente = int.Parse(Request.QueryString["ID"]);
                gdvListarTurnos.DataSource = turnoNeg.ListarTurnosPaciente(idPaciente);
                gdvListarTurnos.DataBind();
            }


        }


        protected void btnListarTurnos_Click(object sender, EventArgs e)
        {
            ListarTurnos();
        }
    }
}