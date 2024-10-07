using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCarrera : System.Web.UI.Page
    {
        private void Listar()
        {
            Carrera carrera = new Carrera();
            gvCarrera.DataSource = carrera.Listar();
            gvCarrera.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // solo carga la primera vez
            if(!Page.IsPostBack) {
                Listar();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Carrera carrera = new Carrera();
            carrera.CodCarrera = txtCodCarrera.Text.Trim();
            carrera.NombreCarrera = txtCarrera.Text;
            bool resultado = carrera.Agregar();
            if (resultado) {
                Listar();
                txtCodCarrera.Text = "";
                txtCarrera.Text = "";
            }else{
                Response.Write("Error: No se agrego correctamente");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Carrera carrera = new Carrera();
            carrera.CodCarrera=txtCodCarrera.Text.Trim();
            carrera.NombreCarrera =txtCarrera.Text;
            bool resultado =carrera.Actualizar();
            if (resultado){
                Listar();
                txtCodCarrera.Text = "";
                txtCarrera.Text = "";
            }
            else
            {
                Response.Write("Error: No se actualizo correctamente");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Carrera carrera = new Carrera();
            carrera.CodCarrera = txtBuscar.Text.Trim();
            gvCarrera.DataSource = carrera.Buscar();
            gvCarrera.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Carrera carrera = new Carrera();
                carrera.CodCarrera = txtCodCarrera.Text.Trim();
                bool resultado = carrera.Eliminar();
                if (resultado)
                {
                    Listar();
                    txtCodCarrera.Text = "";
                    txtCarrera.Text = "";
                }
                else
                {
                    Response.Write("Error: No se eliminó correctamente");
                }
            }
            catch (SqlException sqlEx)
            {
                // Verifica el código de error de SQL
                if (sqlEx.Number == 547) // Código de error para violación de clave foránea
                {
                    Response.Write("Error: No se puede eliminar esta carrera porque está relacionada con otros registros.");
                }
                else
                {
                    Response.Write("Error de base de datos: " + sqlEx.Message);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}