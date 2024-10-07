using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;

namespace CapaPresentacion.Privado
{
    public partial class Mantenimiento : System.Web.UI.Page
    {
        private void ListarAsignatura()
        {
            Asignatura asignatura = new Asignatura();
            gvAsignatura.DataSource = asignatura.Listar();
            gvAsignatura.DataBind();

            // Obtener la lista de asignaturas
            var listaAsignaturas = asignatura.Listar();

            // Vincular los datos al DropDownList
            ddRequisito.DataSource = listaAsignaturas;
            ddRequisito.DataTextField = "Asignatura"; // Campo que se muestra
            ddRequisito.DataValueField = "CodAsignatura";   // Campo de valor
            ddRequisito.DataBind();

            // Opcional: Agregar un elemento por defecto
            ddRequisito.Items.Insert(0, new ListItem("-- Seleccione una asignatura --", "0"));

        }

        private void ListarDocente()
        {
            Docente docente = new Docente();
            gvDocente.DataSource = docente.Listar();
            gvDocente.DataBind();
        }

        private void ListarAlumno()
        {
            Alumno alumno = new Alumno();
            gvAlumno.DataSource = alumno.Listar();
            gvAlumno.DataBind();

            // Obtener la lista de asignaturas
            Carrera carrera = new Carrera();
            var listaCarrera = carrera.Listar();

            // Vincular los datos al DropDownList
            ddCarrera.DataSource = listaCarrera;
            ddCarrera.DataTextField = "Carrera"; // Campo que se muestra
            ddCarrera.DataValueField = "CodCarrera";   // Campo de valor
            ddCarrera.DataBind();

            // Opcional: Agregar un elemento por defecto
            ddCarrera.Items.Insert(0, new ListItem("-- Seleccione una asignatura --", "0"));

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo cargar la primera vez
            if (!Page.IsPostBack)
            {
                ListarAsignatura();
                ListarDocente();
                ListarAlumno();
            }
        }

        private void ClearForm()
        {
            txtCodAsignatura.Text = "";
            txtAsignatura.Text = "";
            txtCodDocente.Text.Trim();
            txtAPaterno.Text = "";
            txtAMaterno.Text = "";
            txtNombres.Text = "";
            txtUsuario.Text = "";
            txtCodAlumno.Text = "";
            txtAPaternoAlumno.Text = "";
            txtAMaternoAlumno.Text = "";
            txtNombresAlumno.Text = "";
        }

        protected void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            try
            {
                Asignatura asignatura = new Asignatura();
                asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
                asignatura.NombreAsignatura = txtAsignatura.Text;
                asignatura.CodRequisito = ddRequisito.SelectedValue;
                bool i = asignatura.Agregar();
                if (i)
                {
                    ListarAsignatura();
                    ClearForm();
                }
                else {
                    Response.Write("Error: Al guardar Asignatura :(");
                }
                
            }
            catch (Exception ex) {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminarAsignatura_Click(object sender, EventArgs e)
        {
            try
            {
                Asignatura asignatura = new Asignatura();
                asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
                bool i = asignatura.Eliminar();
                if (i)
                {
                    ListarAsignatura();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: Al eliminar Asignatura :(");
                }

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizarAsignatura_Click(object sender, EventArgs e)
        {
            try
            {
                Asignatura asignatura = new Asignatura();
                asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
                asignatura.NombreAsignatura = txtAsignatura.Text.Trim();
                asignatura.CodRequisito = txtAsignatura.Text;
                bool i = asignatura.Actualizar();
                if (i)
                {
                    ListarAsignatura();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: Al actualizar Asignatura :(");
                }

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignatura asignatura = new Asignatura();
                asignatura.CodAsignatura = txtBuscar.Text; 
                gvAsignatura.DataSource = asignatura.Buscar();
                gvAsignatura.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        // Docentes
        protected void btnAgregarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                Docente docente = new Docente();
                docente.CodDocente = txtCodDocente.Text.Trim();
                docente.APaterno = txtAPaterno.Text;
                docente.AMaterno = txtAMaterno.Text;
                docente.Nombres = txtNombres.Text;
                docente.Usuario = txtUsuario.Text;

                bool i = docente.Agregar();
                if (i)
                {
                    ListarDocente();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: Al guardar Docente :(");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                Docente Docente = new Docente();
                Docente.CodDocente = txtCodDocente.Text.Trim();
                bool resultado = Docente.Eliminar();
                if (resultado)
                {
                    ListarDocente();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: No se eliminó correctamente");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                Docente Docente = new Docente();
                Docente.CodDocente = txtCodDocente.Text.Trim();
                Docente.APaterno = txtAPaterno.Text;
                Docente.AMaterno = txtAMaterno.Text;
                Docente.Nombres = txtNombres.Text;
                Docente.Usuario = txtUsuario.Text;
                bool resultado = Docente.Actualizar();
                if (resultado)
                {
                    ListarDocente();
                    ClearForm();

                }
                else
                {
                    Response.Write("Error: No se actualizo correctamente");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnBuscarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                Docente Docente = new Docente();
                Docente.CodDocente = txtBuscarDocente.Text.Trim();
                gvDocente.DataSource = Docente.Buscar();
                gvDocente.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        // Alumnos
        protected void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.CodAlumno = txtCodAlumno.Text.Trim();
                alumno.APaterno = txtAPaternoAlumno.Text;
                alumno.AMaterno = txtAMaternoAlumno.Text;
                alumno.Nombres = txtNombresAlumno.Text;
                alumno.Usuario = txtUsuarioAlumno.Text;
                alumno.CodCarrera = ddCarrera.SelectedValue;
                bool resultado = alumno.Agregar();
                if (resultado)
                {
                    ListarAlumno();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: No se agrego correctamente");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
    
        }

        protected void btnActualizarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.CodAlumno = txtCodAlumno.Text.Trim();
                alumno.APaterno = txtAPaternoAlumno.Text;
                alumno.AMaterno = txtAMaternoAlumno.Text;
                alumno.Nombres = txtNombresAlumno.Text;
                alumno.CodCarrera = ddCarrera.SelectedValue;
                bool resultado = alumno.Actualizar();
                if (resultado)
                {
                    ListarAlumno();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: No se actualizo correctamente");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.CodAlumno = txtBuscarAlumno.Text.Trim();
                gvAlumno.DataSource = alumno.Buscar();
                gvAlumno.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.CodAlumno = txtCodAlumno.Text.Trim();
                bool resultado = alumno.Eliminar();
                if (resultado)
                {
                    ListarAlumno();
                    ClearForm();
                }
                else
                {
                    Response.Write("Error: No se eliminó correctamente");
                }
            }
            catch (SqlException sqlEx)
            {

                Response.Write("Error de base de datos: " + sqlEx.Message);

            }
        }
    }
}