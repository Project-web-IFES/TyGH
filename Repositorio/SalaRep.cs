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
    public class SalaRep
    {
        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;

        public DataTable ListarSalasDDL()
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            String query = "SELECT s.idSala, s.nombre from sala as S";


            SqlConnection con = new SqlConnection(cnn);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);


            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            con.Close();

            return dataTable;
        }



    }
}
