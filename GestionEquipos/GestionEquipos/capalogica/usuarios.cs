using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionEquipos.capalogica
{
    public class Usuarios
    {
        public int AgregarEquipo(string nombrePersona, string nombreTecnico, string nombreEquipo)
        {
            int retorno = 0;
            SqlConnection Conn = null;

            try
            {
                Conn = DBConn.obtenerConexion();
                using (SqlCommand cmd = new SqlCommand("sp_InsertarEquipo", Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombrePersona", nombrePersona);
                    cmd.Parameters.AddWithValue("@NombreTecnico", nombreTecnico);
                    cmd.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn?.Close();
            }

            return retorno;
        }

        public int EliminarEquipo(string nombrePersona)
        {
            int retorno = 0;
            SqlConnection Conn = null;

            try
            {
                Conn = DBConn.obtenerConexion();

                using (SqlCommand cmd = new SqlCommand("sp_EliminarEquipo", Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NombrePersona", nombrePersona));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn?.Close();
            }

            return retorno;
        }



        public int ActualizarEquipo(int equipoID, string nombrePersona, string nombreTecnico, string nombreEquipo)
        {
            int retorno = 0;
            SqlConnection Conn = null;

            try
            {
                Conn = DBConn.obtenerConexion(); 
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarEquipo", Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("@EquipoID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@NombrePersona", nombrePersona));
                    cmd.Parameters.Add(new SqlParameter("@NombreTecnico", nombreTecnico));
                    cmd.Parameters.Add(new SqlParameter("@NombreEquipo", nombreEquipo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn?.Close();
            }

            return retorno;
        }
    }
}



