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
    public class PacienteRep
    {
        string cnn = ConfigurationManager.ConnectionStrings["capas"].ConnectionString;

        public void GuardarPaciente(Paciente paciente)
        {
            SqlConnection conn = new SqlConnection(cnn);

            //string sql1 = "INSERT INTO Direccion (calle, numero, piso, localidad) VALUES (@1,@2,@3,@4); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Crear_Paciente_Domicilio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar)).Value=paciente.Domicilio.Calle;
                cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value=paciente.Domicilio.Numero;
                cmd.Parameters.Add(new SqlParameter("@piso",SqlDbType.VarChar)).Value=paciente.Domicilio.Piso;
                cmd.Parameters.Add(new SqlParameter("@localidad", SqlDbType.VarChar)).Value=paciente.Domicilio.Localidad;
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                
                //cmd.ExecuteNonQuery();

                GuardarPersonaAux(paciente, id);
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

        private void GuardarPersonaAux(Paciente paciente, int id)
        {
            SqlConnection conn = new SqlConnection(cnn);
          //  string sql = "INSERT INTO Persona (nombre,apellido,documento,email,celular,idDireccion) VALUES (@5,@6,@7,@8,@9,@10); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Crear_Persona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter ("@nombre", SqlDbType.VarChar)).Value=paciente.Nombre;
                cmd.Parameters.Add(new SqlParameter ("@apellido", SqlDbType.VarChar)).Value=paciente.Apellido;
                cmd.Parameters.Add(new SqlParameter ("@documento", SqlDbType.VarChar)).Value=paciente.Documento;
                cmd.Parameters.Add(new SqlParameter ("@email", SqlDbType.VarChar)).Value=paciente.EMail;
                cmd.Parameters.Add(new SqlParameter ("@celular", SqlDbType.VarChar)).Value=paciente.Celular;
                cmd.Parameters.Add(new SqlParameter ("@idDireccion", SqlDbType.Int)).Value=id;
                int idPersona = int.Parse(cmd.ExecuteScalar().ToString());
                //cmd.ExecuteNonQuery();

                GuardarPacienteAux(paciente, idPersona);

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


        private void GuardarPacienteAux(Paciente paciente, int id)
        {
            SqlConnection conn = new SqlConnection(cnn);
            //string sql = "INSERT INTO Paciente (idPersona) VALUES (@1)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Relacion_Persona_Paciente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idPersona", SqlDbType.Int)).Value=id;
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

        public DataTable ListarPacientesDDL()
        {
            DataTable dataTable = new DataTable();
            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "SELECT pa.idPaciente, p.nombre+' '+p.apellido as nombreApellido from paciente as PA inner join persona as P on pa.idPersona=p.idPersona";

            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Pacientes_DDL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            con.Close();

            return dataTable;
        }

        public DataTable ListarPacientes()
        {
            DataTable dataTable = new DataTable();
            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "select pa.idPaciente, p.nombre + ' ' + p.apellido as nombreApellido, p.celular, p.email from paciente as PA inner join persona as p on pa.idPersona = p.idPersona";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Pacientes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }


        public DataTable ListarPacienteConId(int id)
        {
            DataTable dataTable = new DataTable();
            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "select p.nombre, p.apellido, p.documento, p.celular, p.email, d.calle, d.numero, d.piso, d.localidad from paciente as PA inner join persona as P on pa.idPersona = p.idPersona inner join direccion as D on p.idDireccion = d.idDireccion WHERE idPaciente=@val1";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Paciente_Id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //CAMBIAR LOS PARAMETROS SI ES NECESARIO
            cmd.Parameters.Add(new SqlParameter ("@idPaciente", SqlDbType.Int)).Value=id;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable ListarPacienteConIdNomApe(int id)
        {
            DataTable dataTable = new DataTable();
            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "select p.nombre, p.apellido from paciente as PA inner join persona as P on pa.idPersona = p.idPersona WHERE idPaciente=@val1";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Paciente_NomApID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //CAMBIAR LOS PARAMETROS SI ES NECESARIO
            cmd.Parameters.Add(new SqlParameter("@idPaciente", SqlDbType.Int)).Value=id;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();

            return dataTable;
        }


        public void UpdatePaciente(Paciente paciente, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);
            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //string sql = "SELECT idPersona FROM paciente where idPaciente=@val1 ";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Select_Paciente_UP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.Add(new SqlParameter("@idPaciente",SqlDbType.Int)).Value=id;
                cmd.CommandType = CommandType.StoredProcedure;
                //Ejecutamos la query
                //cmd.ExecuteNonQuery();
                int idPersona = int.Parse(cmd.ExecuteScalar().ToString());
                UpdatePersona(paciente, idPersona);
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

        private void UpdatePersona(Paciente paciente, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //string sql = "Update persona SET nombre = @val1, apellido=@val2, documento=@val3, email=@val4, celular=@val5 Where idPersona = @val6; SELECT idDireccion from persona where idPersona=@val6 ";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Update_Persona ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value=paciente.Nombre;
                cmd.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar)).Value=paciente.Apellido;
                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar)).Value=paciente.Documento;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value=paciente.EMail;
                cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value=paciente.Celular;
                cmd.Parameters.Add(new SqlParameter("@idPersona", SqlDbType.Int)).Value=id;
                //Ejecutamos la query
                //cmd.ExecuteNonQuery();
                //me parece que esta mal, que solo funciona porque como se guarda la persona al mismo tiempo que la direccion tienen
                //el mismo id, porque el execute scalar trae el primer campo que seria el id, no trae el id de direccion.
                int idDireccion = int.Parse(cmd.ExecuteScalar().ToString());
                UpdateDireccion(paciente, idDireccion);
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

        private void UpdateDireccion(Paciente paciente, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //string sql = "Update direccion SET calle = @val1, numero=@val2, piso=@val3, localidad=@val4  Where idDireccion = @val5";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Update_Direccion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                Direccion direccion = new Direccion();
                direccion = paciente.Domicilio;
                cmd.Parameters.Add(new SqlParameter("@calle",SqlDbType.VarChar)).Value=direccion.Calle;
                cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value=direccion.Numero;
                cmd.Parameters.Add(new SqlParameter("@piso", SqlDbType.VarChar)).Value=direccion.Piso;
                cmd.Parameters.Add(new SqlParameter("@localidad", SqlDbType.VarChar)).Value=direccion.Localidad;
                cmd.Parameters.Add(new SqlParameter("@idDireccion", SqlDbType.Int)).Value=id;               
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

        //public void DeletePaciente(int id)
        //{
        //    SqlConnection con = new SqlConnection(cnn);
        //    //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
        //    string sql = "Select idPersona from paciente Where idPaciente=@val1; DELETE FROM medico Where idMedico = @val1 ";

        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        //CAMBIAR LOS PARAMETROS SI ES NECESARIO
        //        cmd.Parameters.AddWithValue("@val1", id);

        //        cmd.CommandType = CommandType.Text;
        //        int idPersona = int.Parse(cmd.ExecuteScalar().ToString());

        //        DeletePersona(idPersona);
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        string msg = "Insert Error:";
        //        msg += ex.Message;
        //        throw new Exception(msg);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private void DeletePersona(int id)
        //{
        //    SqlConnection con = new SqlConnection(cnn);
        //    //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
        //    string sql = "Select idDireccion from persona Where idPersona=@val1; DELETE FROM persona Where idPersona = @val1 ";

        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        //CAMBIAR LOS PARAMETROS SI ES NECESARIO
        //        cmd.Parameters.AddWithValue("@val1", id);

        //        cmd.CommandType = CommandType.Text;
        //        int idDireccion = int.Parse(cmd.ExecuteScalar().ToString());

        //        DeleteDireccion(idDireccion);
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        string msg = "Insert Error:";
        //        msg += ex.Message;
        //        throw new Exception(msg);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private void DeleteDireccion(int id)
        //{
        //    SqlConnection con = new SqlConnection(cnn);
        //    //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
        //    string sql = "DELETE FROM direccion Where idDireccion = @val1 ";

        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        //CAMBIAR LOS PARAMETROS SI ES NECESARIO
        //        cmd.Parameters.AddWithValue("@val1", id);

        //        cmd.CommandType = CommandType.Text;
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        string msg = "Insert Error:";
        //        msg += ex.Message;
        //        throw new Exception(msg);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
    }
}
