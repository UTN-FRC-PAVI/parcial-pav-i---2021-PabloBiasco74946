using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialPav.AccesoADatos
{
    public class Acceso
    {
        public static DataTable ObtenerTabla(string nombreTabla)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM " + nombreTabla;

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
        }


        public static DataTable ObtenerDatosJugador(string Numero)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Jugadores WHERE Id like'" + Numero + "'";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


        public static bool AltaNuevoEquipo(int IdEquipo,string NombreEquipo, DateTime FechaCreacion, List<int> ListaIdJugadores)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlTransaction ObjTransaccion = null;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Equipos values(@Nombre, @FechaCreacion)";

                cmd.Parameters.Clear();           
                cmd.Parameters.AddWithValue("@Nombre", NombreEquipo);
                cmd.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                ObjTransaccion = cn.BeginTransaction("AltaDeEquipo");

                cmd.Transaction = ObjTransaccion;

                cmd.Connection = cn;

                cmd.ExecuteNonQuery();

                foreach (var IdJugador in ListaIdJugadores)
                {

                    string consultaEquipoXJugadores = "INSERT INTO JugadoresPorEquipos values (@IdJugador, @IdEquipo, @FechaAsignacion)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdJugador", IdJugador);
                    cmd.Parameters.AddWithValue("@IdEquipo", IdEquipo);
                    cmd.Parameters.AddWithValue("@FechaAsignacion", DateTime.Now);

                    cmd.CommandText = consultaEquipoXJugadores;
                    cmd.ExecuteNonQuery();
                }
                ObjTransaccion.Commit();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ObjTransaccion.Rollback();
                return false;
            }
            finally
            {
                cn.Close();
            }
        }


        public static int ObtenerUltimoIdEquipo()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT MAX(Id) FROM Equipos";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                int resultado = (int)cmd.ExecuteScalar();
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cn.Close();
            }
        }


        public static DataTable ObtenerListaDeJugadores()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Jugadores";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                return tabla;
                if (tabla.Rows.Count == 1)
                {
                    resultado = true;
                }

                else
                {
                    resultado = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

        }

    }
}
