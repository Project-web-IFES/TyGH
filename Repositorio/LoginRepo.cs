using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class LoginRepo
    {
        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;
        public DataTable ListUsuarioPass(String correo,String contraseña)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_UsuariosPass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar)).Value = correo;
            cmd.Parameters.Add(new SqlParameter("@contraseña", SqlDbType.VarChar)).Value = contraseña;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }

    }
}
