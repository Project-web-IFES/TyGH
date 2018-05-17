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
        string cnn = ConfigurationManager.ConnectionStrings["ConeccionASQL"].ConnectionString;
        public void guardarMedicoBD(Medico medico)
        {
            SqlConnection conn = new SqlConnection(cnn);
            
            string sql = "INSERT INTO Medico (nombre,apellido,documento,email,celular,legajo,valorConsulta,matricula,calle,altura,piso,localidad) VALUES (@val1,@val2,@val3,@val4,@val5,@val6,@val7,@val8,@val9,@val10,@val11,@val12)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@val1", medico.Nombre);
                cmd.Parameters.AddWithValue("@val2", medico.Apellido);
                cmd.Parameters.AddWithValue("@val3", medico.Documento);
                cmd.Parameters.AddWithValue("@val4", medico.EMail);
                cmd.Parameters.AddWithValue("@val5", medico.Celular);
                cmd.Parameters.AddWithValue("@val6", medico.Legajo);
                cmd.Parameters.AddWithValue("@val7", medico.Consulta);
                cmd.Parameters.AddWithValue("@val8", medico.Matricula);
                cmd.Parameters.AddWithValue("@val9", medico.Domicilio.Calle);
                cmd.Parameters.AddWithValue("@val10", medico.Domicilio.Numero);
                cmd.Parameters.AddWithValue("@val11", medico.Domicilio.Piso);
                cmd.Parameters.AddWithValue("@val12", medico.Domicilio.Localidad);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch(System.Data.SqlClient.SqlException ex)
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
