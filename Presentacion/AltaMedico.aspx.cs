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
        MedicoAltaNego MedicoNego = new MedicoAltaNego();
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardarMedicoNuevo();
        }
        public void guardarMedicoNuevo()
        {
            Medico medico = new Medico();
            medico.Nombre = TbxNombre.Text;
            medico.Apellido = TbxApellido.Text;
            medico.Documento = int.Parse(TbxDocumento.Text);
            medico.Matricula = TbxMatricula.Text;
            medico.EMail = TbxEmail.Text;
            Direccion direccion = new Direccion();
            direccion.Calle = TbxCalle.Text;
            direccion.Numero = TbxAltura.Text;
            direccion.Piso = TbxPiso.Text;
            direccion.Localidad = TbxLocalidad.Text;
            medico.Domicilio = direccion;
            medico.Celular = TbxCelular.Text;
            medico.Legajo = int.Parse(TbxLegajo.Text);
            medico.Matricula = TbxMatricula.Text;
            medico.Consulta = double.Parse(TbxConsulta.Text);
            MedicoNego.guardarMedico(medico);
             
            
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpDate();
        }
        public void UpDate ()
        {
            Medico medico = new Medico();
            medico.Nombre = TbxNombre.Text;
            MedicoNego.update(medico);
        }

        protected void BtnListar_Click(object sender, EventArgs e)
        {
            listar();
        }

        public void listar()
        {
            GdvMedicos.DataSource = MedicoNego.listar();
            GdvMedicos.DataBind();


        }
    }
}