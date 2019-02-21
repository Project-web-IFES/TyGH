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

            //string sql1 = "INSERT INTO Direccion (calle, numero, piso, localidad) VALUES (@1,@2,@3,@4); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Crear_Paciente_Domicilio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar)).Value = medico.Domicilio.Calle;
                cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value = medico.Domicilio.Numero;
                cmd.Parameters.Add(new SqlParameter("@piso", SqlDbType.VarChar)).Value = medico.Domicilio.Piso;
                cmd.Parameters.Add(new SqlParameter("@localidad", SqlDbType.VarChar)).Value=medico.Domicilio.Localidad;
                int id = Convert.ToInt32(cmd.ExecuteScalar());
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
            //string sql = "INSERT INTO Persona (nombre,apellido,documento,email,celular,idDireccion) VALUES (@5,@6,@7,@8,@9,@10); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Crear_Persona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = medico.Nombre;
                cmd.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar)).Value = medico.Apellido;
                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar)).Value = medico.Documento;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = medico.EMail;
                cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value = medico.Celular;
                cmd.Parameters.Add(new SqlParameter("@idDireccion", SqlDbType.Int)).Value = id;
                int idPersona = int.Parse(cmd.ExecuteScalar().ToString());   
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
            //string sql = "INSERT INTO Empleado (legajo,consulta,idPersona) VALUES (@1,@2,@3); SELECT SCOPE_IDENTITY()";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Guardar_Empleado", conn);     
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@legajo",SqlDbType.VarChar)).Value= medico.Legajo;
                cmd.Parameters.Add(new SqlParameter("@consulta",SqlDbType.Decimal)).Value= medico.Consulta;
                cmd.Parameters.Add(new SqlParameter("@idPersona",SqlDbType.Int)).Value= id;
                int idEmpleado = int.Parse(cmd.ExecuteScalar().ToString());
                //cmd.ExecuteNonQuery();
                GuardarMedicoAux(medico, idEmpleado);
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
            //string sql = "INSERT INTO Medico (especialidad,matricula,idEmpleado) VALUES (@1,@2,@3)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Guardad_Medico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@especialidad", medico.Especialidad);
                cmd.Parameters.AddWithValue("@matricula", medico.Matricula);
                cmd.Parameters.AddWithValue("@idEmpleado", id);
                //int idMedico = int.Parse(cmd.ExecuteScalar().ToString());
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
            //String query = "select m.idMedico, p.nombre + ' ' + p.apellido as nombreApellido, p.celular, p.email, e.legajo, e.consulta from medico as M inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Medicos", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
            //String query = "select m.especialidad, m.matricula, e.legajo, e.consulta, p.nombre, p.apellido, p.documento, p.celular, p.email, e.legajo, e.consulta, d.calle, d.numero, d.piso, d.localidad from medico as M inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona inner join direccion as D on p.idDireccion = d.idDireccion WHERE idMedico=@val1";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Medico_Id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //CAMBIAR LOS PARAMETROS SI ES NECESARIO
            cmd.Parameters.Add(new SqlParameter("@idMedico",SqlDbType.Int)).Value=id;
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable ListarMedicoConIdNomApe(int id)
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "select p.nombre, p.apellido from medico as M inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona inner join direccion as D on p.idDireccion = d.idDireccion WHERE idMedico=@val1";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Medico_NomApId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //CAMBIAR LOS PARAMETROS SI ES NECESARIO
            cmd.Parameters.AddWithValue("@idMedico", id);
            //toma el datatable y mete lo que traigamos de la query
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable ListarMedicoConIdNomApeAgenda(int id)
        {
            DataTable dataTable = new DataTable();

            //Tengo que usar el nombre de la tabla, cambiar la query dependiendo lo que necesitemos
            //CAMBIAR TODOS LOS NOMBRES EN LAS QUERIES BIEN
            //String query = "select p.nombre, p.apellido from agenda as A inner join medico as M on a.idMedico = m.idMedico inner join empleado as E on m.idEmpleado = e.idEmpleado inner join persona as P on e.idPersona = p.idPersona inner join direccion as D on p.idDireccion = d.idDireccion WHERE a.idAgenda=@val1";
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Listar_Medico_NomApIdAgenda", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //CAMBIAR LOS PARAMETROS SI ES NECESARIO
            cmd.Parameters.AddWithValue("@idAgenda", id);
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
            //
            //se uso esta 
            //string sql = "Update medico SET especialidad = @val1, matricula=@val2 Where idMedico = @val3; SELECT idEmpleado FROM medico Where idMedico=@val3 ";
            //se uso esta
            //
            //string sql = "Update medico SET especialidad = @val1, matricula=@val2 Where idMedico = @val3; SELECT SCOPE_IDENTITY() ";
            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Update_Medico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.Add(new SqlParameter("@especialidad",SqlDbType.VarChar)).Value=medico.Especialidad;
                cmd.Parameters.Add(new SqlParameter("@matricula", SqlDbType.Int)).Value = medico.Matricula;
                cmd.Parameters.Add(new SqlParameter("@idMedico", SqlDbType.Int)).Value = id;
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

            //se uso esta
            //string sql = "Update empleado SET legajo = @val1, consulta=@val2 Where idEmpleado = @val3; SELECT idPersona FROM empleado Where idEmpleado=@val3 ";
            //se uso esta
            
            //string sql = "Update empleado SET legajo = @val1, consulta=@val2 Where idEmpleado = @val3; SELECT SCOPE_IDENTITY()";
            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Update_Empleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.Add(new SqlParameter("@legajo",SqlDbType.VarChar)).Value=medico.Legajo;
                cmd.Parameters.Add(new SqlParameter("@consulta",SqlDbType.Decimal)).Value=medico.Consulta;
                cmd.Parameters.Add(new SqlParameter("@idEmpleado",SqlDbType.Int)).Value= id;
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

            //se uso este del medio
            //string sql = "Update persona SET nombre = @val1, apellido=@val2, documento=@val3, email=@val4, celular=@val5 Where idPersona = @val6; SELECT idDireccion FROM persona Where idPersona=@val6 ";
            //se uso el del medio
            
            
            //string sql = "Update persona SET nombre = @val1, apellido=@val2, documento=@val3, email=@val4, celular=@val5 Where idPersona = @val6; SELECT SCOPE_IDENTITY() ";
            try
            {
                //Abrimos la conexion
                con.Open();
                //Para establecer parametros
                SqlCommand cmd = new SqlCommand("Update_Persona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //CAMBIAR LOS PARAMETROS
                cmd.Parameters.Add(new SqlParameter("@nombre",SqlDbType.VarChar)).Value=medico.Nombre;
                cmd.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar)).Value= medico.Apellido;
                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar)).Value = medico.Documento;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = medico.EMail;
                cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value = medico.Celular;
                cmd.Parameters.Add(new SqlParameter("@idPersona", SqlDbType.Int)).Value = id;
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
                direccion = medico.Domicilio;
                cmd.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar)).Value = direccion.Calle;
                cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value = direccion.Numero;
                cmd.Parameters.Add(new SqlParameter("@piso", SqlDbType.VarChar)).Value = direccion.Piso;
                cmd.Parameters.Add(new SqlParameter("@localidad", SqlDbType.VarChar)).Value = direccion.Localidad;
                cmd.Parameters.Add(new SqlParameter("@idDireccion", SqlDbType.Int)).Value = id;
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
