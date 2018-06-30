using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Repositorio
{
    public class AgendaRep
    {

        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;


        public void GuardarAgenda(Agenda agenda)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Insert en este caso persona es el nombre de la tabla
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            string sql = "Insert into agenda (diaHoraInicio, diaHoraFinal, idMedico) VALUES (@val1,@val2,@val3)";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand(sql, con);
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.AddWithValue("@val1", agenda.DiaHoraInicio);
                cmd.Parameters.AddWithValue("@val2", agenda.DiaHoraFinal);
                cmd.Parameters.AddWithValue("@val3", agenda.IdMedico);

                cmd.CommandType = CommandType.Text;
                //Ejecutamos la query
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                //Cerramos la conexion
                con.Close();
            }

        }

        public DataTable ListarAgendas(int id)
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            String query = "SELECT a.idAgenda,a.diaHoraInicio, p.nombre+' '+p.apellido as nombreCompleto, a.diaHoraFinal from agenda as A inner join medico as M on a.idMedico = m.idMedico inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona where a.idMedico = @val1";

            SqlConnection con = new SqlConnection(cnn);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@val1", id);


            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            con.Close();

            return dataTable;
        }

    }
}
