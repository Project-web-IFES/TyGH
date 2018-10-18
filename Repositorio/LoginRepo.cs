using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class LoginRepo
    {
        
        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;
        public DataTable ListUsuarioPass(String correo)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_UsuariosPass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar)).Value = correo;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public void GuardarUsuario(LoginDom login)
        {
            SqlConnection conn = new SqlConnection(cnn);

            //string sql1 = "INSERT INTO Direccion (calle, numero, piso, localidad) VALUES (@1,@2,@3,@4); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Crear_Usuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = login.Nombre;
                cmd.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar)).Value = login.Apellido;
                cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar)).Value = login.Correo;
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = login.Password;
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

    }
}
