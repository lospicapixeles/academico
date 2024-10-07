using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CapaNegocio
{
    public class Docente
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        public string CodDocente { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombres { get; set; }
        public string Usuario { get; set; }

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TDocente";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public bool Agregar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                // Abrir la conexión una vez
                conexion.Open();

                // Primer comando de inserción
                string consulta1 = "INSERT INTO TUsuario values(@Usuario, @Contrasena)";
                SqlCommand comando1 = new SqlCommand(consulta1, conexion);
                comando1.Parameters.AddWithValue("@Usuario", Usuario);
                comando1.Parameters.AddWithValue("@Contrasena", "1234");
                byte o = Convert.ToByte(comando1.ExecuteNonQuery());

                // Segundo comando de inserción
                string consulta = "INSERT INTO TDocente values(@CodDocente, @APaterno, @AMaterno, @Nombres, @Usuario)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", CodDocente);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", Nombres);
                comando.Parameters.AddWithValue("@Usuario", Usuario);
                byte i = Convert.ToByte(comando.ExecuteNonQuery());

                // Cerrar la conexión
                conexion.Close();

                // Verificar el resultado
                if (i == 1)
                    return true;
                else
                    return false;
            }
        }


        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM TDocente WHERE CodDocente = @CodDocente";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", CodDocente);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public bool Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "UPDATE TDocente SET APaterno = @APaterno, AMaterno = @AMaterno, Nombres = @Nombres  WHERE CodDocente = @CodDocente";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", CodDocente);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", Nombres);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public DataTable Buscar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TDocente WHERE CodDocente LIKE @CodDocente";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", "%" + CodDocente + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }

        }
    }
}  
