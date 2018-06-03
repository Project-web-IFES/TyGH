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
    public class MedicoAltaRepo
    {
        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;
        public void GuardarMedico(Medico medico)
        {
            SqlConnection conn = new SqlConnection(cnn);

            string sql1 = "INSERT INTO Direccion (calle, numero, piso, localidad) VALUES (@1,@2,@3,@4); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@1", medico.Domicilio.Calle);
                cmd.Parameters.AddWithValue("@2", medico.Domicilio.Numero);
                cmd.Parameters.AddWithValue("@3", medico.Domicilio.Piso);
                cmd.Parameters.AddWithValue("@4", medico.Domicilio.Localidad);

                int id = int.Parse(cmd.ExecuteScalar().ToString());

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                GuardarPersonaAux(medico, id);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "error";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();

            }
        }

        private void GuardarPersonaAux(Medico medico, int id) {
            SqlConnection conn = new SqlConnection(cnn);
            string sql = "INSERT INTO Persona (nombre,apellido,documento,email,celular,idDireccion) VALUES (@5,@6,@7,@8,@9,@10); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@5", medico.Nombre);
                cmd.Parameters.AddWithValue("@6", medico.Apellido);
                cmd.Parameters.AddWithValue("@7", medico.Documento);
                cmd.Parameters.AddWithValue("@8", medico.EMail);
                cmd.Parameters.AddWithValue("@9", medico.Celular);
                cmd.Parameters.AddWithValue("@10", id);

                int idPersona = int.Parse(cmd.ExecuteScalar().ToString());


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                GuardarEmpleadoAux(medico, idPersona);

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "error";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();

            }
        }


        private void GuardarEmpleadoAux(Medico medico, int id)
        {
            SqlConnection conn = new SqlConnection(cnn);
            string sql = "INSERT INTO Empleado (legajo,consulta,idPersona) VALUES (@1,@2,@3); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@1", medico.Legajo);
                cmd.Parameters.AddWithValue("@2", medico.Consulta);
                cmd.Parameters.AddWithValue("@3", id);

                int idEspecialidad = int.Parse(cmd.ExecuteScalar().ToString());


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                GuardarMedicoAux(medico, id);


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "error";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();

            }
        }

        private void GuardarMedicoAux(Medico medico, int id)
        {
            SqlConnection conn = new SqlConnection(cnn);
            string sql = "INSERT INTO Medico (especialidad,matricula,idEmpleado) VALUES (@1,@2,@3); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@1", medico.Especialidad);
                cmd.Parameters.AddWithValue("@2", medico.Matricula);
                cmd.Parameters.AddWithValue("@3", id);

                int idMedico = int.Parse(cmd.ExecuteScalar().ToString());


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "error";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();

            }
        }

        public void Update(Medico medico)
        {
            SqlConnection conn = new SqlConnection(cnn);
            string sql = "UPDATE Medico (nombre) values (@val) where id=3";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@val", medico.Nombre);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                string msg = "error";
                msg += ex.Message;
                throw new Exception (msg);
            }
            finally
            {
                conn.Close();
            }
        }
    
        public DataTable listarMedicos ()
        {
            DataTable dataTable = new DataTable();
            string sql = "select * from Medico";
            SqlConnection conn = new SqlConnection(cnn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            dAdapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }
        
    }
}
