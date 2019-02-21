using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Repositorio
{
    public class TurnoRep
    {
        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;

        public void GuardarTurno(Turno turno)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);
            //Escribimos la query de Insert en este caso persona es el nombre de la tabla
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //string sql = "Insert into turno (diaHoraInicio, diaHoraFinal, idPaciente, idAgenda, idSala) VALUES (@val1,@val2,@val3, @val4, @val5)";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Guardar_Turno", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.Add(new SqlParameter("@diaHoraInicio", SqlDbType.DateTime)).Value=turno.DiaHoraInicio;
                cmd.Parameters.Add(new SqlParameter("@diaHoraFinal", SqlDbType.DateTime)).Value = turno.DiaHoraFinal;
                cmd.Parameters.Add(new SqlParameter("@idPaciente", SqlDbType.Int)).Value = turno.IdPaciente;
                cmd.Parameters.Add(new SqlParameter("@idAgenda", SqlDbType.Int)).Value = turno.IdAgenda;
                cmd.Parameters.Add(new SqlParameter("@idSala", SqlDbType.Int)).Value = turno.IdSala;
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

        public DataTable ListarTurnos(int id)
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "SELECT t.idTurno, t.diaHoraInicio, p.nombre+' '+p.apellido as nombreCompleto, t.diaHoraFinal, s.nombre from turno as T inner join paciente as PA on t.idPaciente = pa.idPaciente inner join persona as P on pa.idPersona = p.idPersona inner join sala as S on t.idSala=s.idSala where t.idAgenda = @val1";

            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Turnos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idAgenda", SqlDbType.Int)).Value = id;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }


        public DataTable ListarTurnosPaciente(int id)
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "SELECT t.idTurno, t.diaHoraInicio, t.diaHoraFinal, s.nombre from turno as T inner join paciente as PA on t.idPaciente = pa.idPaciente inner join persona as P on pa.idPersona = p.idPersona inner join sala as S on t.idSala=s.idSala where t.idPaciente = @val1";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Turnos_Paciente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPaciente",SqlDbType.Int)).Value=id;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            dataTable.TableName = "datatable";
            return dataTable;
        }

    }
}
