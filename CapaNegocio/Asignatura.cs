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
    public class Asignatura
    {
        public string CodAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public string CodRequisito { get; set; }

        public string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT a.CodAsignatura, a.Asignatura, t.Asignatura as Requisito FROM TAsignatura a left join TAsignatura t on a.CodRequisito = t.CodAsignatura";
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
                string consulta = "INSERT INTO TAsignatura values(@CodAsignatura, @Asignatura, @CodRequisito)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                comando.Parameters.AddWithValue("@Asignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodRequisito", CodRequisito);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }


        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM TAsignatura WHERE CodAsignatura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
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
                string consulta = "UPDATE TAsignatura SET Asignatura = @Asignatura WHERE CodAsignatura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Asignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
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
                string consulta = "SELECT * FROM TAsignatura WHERE CodAsignatura LIKE @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", "%" + CodAsignatura + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }

        }
    }
}
