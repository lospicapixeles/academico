<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento.aspx.cs" Inherits="CapaPresentacion.Privado.Mantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento 🌴</h3>
    <!-- Pestañas de navegación -->
    <ul class="nav nav-tabs" id="myTab" role="tablist">
      <li class="nav-item" role="presentation">
        <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">Asignatura</button>
      </li>
      <li class="nav-item" role="presentation">
        <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false">Docentes</button>
      </li>
      <li class="nav-item" role="presentation">
        <button class="nav-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#contact" type="button" role="tab" aria-controls="contact" aria-selected="false">Alumnos</button>
      </li>
    </ul>

    <!-- Contenido de las pestañas -->
    <div class="tab-content" id="myTabContent">
      <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
        <h3>Asignatura</h3>
          <p>
            CodAsiganatura: <asp:TextBox
                CssClass="form-control"
                runat="server"
                Id="txtCodAsignatura" />
        </p>
         <p>
            Asignatura: <asp:TextBox  CssClass="form-control" runat="server" Id="txtAsignatura" />
        </p>
        <p>
            CodRequisito:
            <asp:DropDownList CssClass="form-select" runat="server" ID="ddRequisito"></asp:DropDownList>
        </p>
        <p>
            <asp:Button Text="Agregar" CssClass="btn btn-primary" runat="server" ID="btnAgregarAsignatura" OnClick="btnAgregarAsignatura_Click" />
            <asp:Button Text="Eliminar" CssClass="btn btn-danger" runat="server" ID="btnEliminarAsignatura" OnClick="btnEliminarAsignatura_Click" />
            <asp:Button Text="Actualizar" CssClass="btn btn-warning" runat="server" ID="btnActualizarAsignatura" OnClick="btnActualizarAsignatura_Click" />
        </p>
        <p>
            Buscar: <asp:TextBox runat="server" CssClass="form-control" Id="txtBuscar" />
            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-info" ID="btnBuscar" OnClick="btnBuscar_Click" />
        </p>
        <p>
            <asp:GridView runat="server" cssClass="table table-hover" ID="gvAsignatura"></asp:GridView>
        </p>
      </div>
      <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
        <h3>Mantenimiento de la tabla Docente</h3>
        <p>
            CodDocente: <asp:TextBox runat="server" CssClass="form-control" Id="txtCodDocente" />
        </p>
         <p>
            APaterno: <asp:TextBox runat="server" CssClass="form-control" Id="txtAPaterno" />
        </p>
         <p>
            AMaterno: <asp:TextBox runat="server" CssClass="form-control" Id="txtAMaterno" />
         </p>
         <p>
            Nombres: <asp:TextBox runat="server" CssClass="form-control" Id="txtNombres" />
        </p>
         <p>
            Usuario: <asp:TextBox runat="server" CssClass="form-control" Id="txtUsuario" />
        </p>

        <p>
            <asp:Button Text="Agregar" runat="server" CssClass="btn btn-primary" Id="btnAgregarDocente" OnClick="btnAgregarDocente_Click"/>
            <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" Id="btnEliminarDocente" OnClick="btnEliminarDocente_Click"/>
            <asp:Button Text="Actualizar" runat="server" CssClass="btn btn-warning" Id="btnActualizarDocente" OnClick="btnActualizarDocente_Click"/>
        </p>
        <p>
            Buscar: <asp:TextBox runat="server" CssClass="form-control" Id="txtBuscarDocente" />
            <asp:Button Text="Buscar" runat="server" Id="btnBuscarDocente" CssClass="btn btn-info" OnClick="btnBuscarDocente_Click" />
        </p>
        <p>
            <asp:GridView runat="server" CssClass="table table-hover" ID="gvDocente"></asp:GridView>
        </p>
      </div>
      <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
        <h3>Mantenimiento de la tabla Alumno</h3>
        <p>
            CodAlumno: <asp:TextBox CssClass="form-control" runat="server" Id="txtCodAlumno" />
        </p>
         <p>
            APaterno: <asp:TextBox CssClass="form-control" runat="server" Id="txtAPaternoAlumno" />
        </p>
         <p>
            AMaterno: <asp:TextBox CssClass="form-control" runat="server" Id="txtAMaternoAlumno" />
        </p>
         <p>
            Nombres: <asp:TextBox CssClass="form-control" runat="server" Id="txtNombresAlumno" />
        </p>
         <p>
            Usuario: <asp:TextBox CssClass="form-control" runat="server" Id="txtUsuarioAlumno" />
          </p>
         <p>
            CodCarrera:
             <asp:DropDownList runat="server"  CssClass="form-select" Id="ddCarrera">
             </asp:DropDownList>
         </p>
        <p>
            <asp:Button Text="Agregar" runat="server" Id="btnAgregar" CssClass="btn btn-primary"  OnClick="btnAgregarAlumno_Click" />
            <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminarAlumno_Click" />
            <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" CssClass="btn btn-warning" OnClick="btnActualizarAlumno_Click" />
        </p>
        <p>
            Buscar: <asp:TextBox runat="server"  CssClass="form-control" Id="txtBuscarAlumno" />
            <asp:Button Text="Buscar"  runat="server" Id="btnBuscarAlumno" CssClass="btn btn-info" OnClick="btnBuscarAlumno_Click" />
        </p>
        <p>
            <asp:GridView runat="server" cssClass="table table-hover" ID="gvAlumno"></asp:GridView>
        </p>
      </div>
    </div>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            // Restaurar la pestaña activa desde localStorage o sessionStorage
            var activeTabId = localStorage.getItem('activeTab');
            if (activeTabId) {
                var activeTab = new bootstrap.Tab(document.querySelector(activeTabId));
                activeTab.show();
            }

            // Guardar la pestaña seleccionada cuando se hace clic en una
            var tabButtons = document.querySelectorAll('button[data-bs-toggle="tab"]');
            tabButtons.forEach(function (tab) {
                tab.addEventListener('shown.bs.tab', function (event) {
                    localStorage.setItem('activeTab', `#${event.target.id}`);
                });
            });
        });
    </script>

</asp:Content>
