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

                int id = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();

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
                //cmd.ExecuteNonQuery();

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
                //cmd.ExecuteNonQuery();

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
            string sql = "INSERT INTO Medico (especialidad,matricula,idEmpleado) VALUES (@1,@2,@3)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@1", medico.Especialidad);
                cmd.Parameters.AddWithValue("@2", medico.Matricula);
                cmd.Parameters.AddWithValue("@3", id);

                //int idMedico = int.Parse(cmd.ExecuteScalar().ToString());


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

        public DataTable ListarMedicos()
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            String query = "select m.idMedico, p.nombre + ' ' + p.apellido as nombreApellido, p.celular, p.email, e.legajo, e.consulta from medico as M inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona";


            SqlConnection con = new SqlConnection(cnn);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);


            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            con.Close();

            return dataTable;
        }

        public DataTable ListarMedicoConId(int id)
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            String query = "select m.especialidad, m.matricula, e.legajo, e.consulta, p.nombre, p.apellido, p.documento, p.celular, p.email, e.legajo, e.consulta, d.calle, d.numero, d.piso, d.localidad from medico as M inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona inner join direccion as D on p.idDireccion = d.idDireccion WHERE idMedico=@val1";


            SqlConnection con = new SqlConnection(cnn);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            //CAMBIAR LOS PARAMETROS SI ES NECESARIO
            cmd.Parameters.AddWithValue("@val1", id);


            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dataTable);

            con.Close();

            return dataTable;
        }

        public void UpdateMedico(Medico medico, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            string sql = "Update medico SET especialidad = @val1, matricula=@val2 Where idMedico = @val3; SELECT idEmpleado FROM medico ";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand(sql, con);
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.AddWithValue("@val1", medico.Especialidad);
                cmd.Parameters.AddWithValue("@val2", medico.Matricula);
                cmd.Parameters.AddWithValue("@val3", id);


                cmd.CommandType = CommandType.Text;
                //Ejecutamos la query
                //cmd.ExecuteNonQuery();
                int idEmpleado = int.Parse(cmd.ExecuteScalar().ToString());

                UpdateEmpleado(medico, idEmpleado);

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

        private void UpdateEmpleado(Medico medico, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            string sql = "Update empleado SET legajo = @val1, consulta=@val2 Where idEmpleado = @val3; SELECT idPersona FROM empleado ";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand(sql, con);
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.AddWithValue("@val1", medico.Legajo);
                cmd.Parameters.AddWithValue("@val2", medico.Consulta);
                cmd.Parameters.AddWithValue("@val3", id);


                cmd.CommandType = CommandType.Text;
                //Ejecutamos la query
                //cmd.ExecuteNonQuery();
                int idPersona = int.Parse(cmd.ExecuteScalar().ToString());

                UpdatePersona(medico, idPersona);


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

        private void UpdatePersona(Medico medico, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            string sql = "Update persona SET nombre = @val1, apellido=@val2, documento=@val3, email=@val4, celular=@val5 Where idPersona = @val6; SELECT idDireccion FROM persona ";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand(sql, con);
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.AddWithValue("@val1", medico.Nombre);
                cmd.Parameters.AddWithValue("@val2", medico.Apellido);
                cmd.Parameters.AddWithValue("@val3", medico.Documento);
                cmd.Parameters.AddWithValue("@val4", medico.EMail);
                cmd.Parameters.AddWithValue("@val5", medico.Celular);
                cmd.Parameters.AddWithValue("@val6", id);


                cmd.CommandType = CommandType.Text;
                //Ejecutamos la query
                //cmd.ExecuteNonQuery();
                int idDireccion = int.Parse(cmd.ExecuteScalar().ToString());

                UpdateDireccion(medico, idDireccion);

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

        private void UpdateDireccion(Medico medico, int id)
        {
            //Establecemos la conexion de SQL
            SqlConnection con = new SqlConnection(cnn);

            //Escribimos la query de Update Con el id que quiera modificar
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            string sql = "Update direccion SET calle = @val1, numero=@val2, piso=@val3, localidad=@val4  Where idDireccion = @val5";

            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand(sql, con);
                //CAMBIAR LOS PARAMETROS
                Direccion direccion = new Direccion();
                direccion = medico.Domicilio;
                cmd.Parameters.AddWithValue("@val1", direccion.Calle);
                cmd.Parameters.AddWithValue("@val2", direccion.Numero);
                cmd.Parameters.AddWithValue("@val3", direccion.Piso);
                cmd.Parameters.AddWithValue("@val4", direccion.Localidad);
                cmd.Parameters.AddWithValue("@val5", id);


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




    }
}
