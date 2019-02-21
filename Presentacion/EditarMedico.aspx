<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarMedico.aspx.cs" Inherits="Presentacion.EditarMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblIntro" runat="server" Text="Edite los datos personales del medico" CssClass="label control-label label-default col-md-3"></asp:Label></h4>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditeNombre" runat="server" CssClass="label control-label label-default col-md-2" Text="Nombre: "></asp:Label></h1>

                <asp:TextBox ID="txtNombre" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblEditeApellido" runat="server" CssClass="label control-label label-default col-md-2" Text="Apellido: "></asp:Label></h1>

                <asp:TextBox ID="txtApellido" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditeDocumento" runat="server" CssClass="label control-label label-default col-md-2" Text="Documento: "></asp:Label></h1>

                <asp:TextBox ID="txtDocumento" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblEditeEmail" runat="server" CssClass="label control-label label-default col-md-2" Text="E-Mail: "></asp:Label></h1>

                <asp:TextBox ID="txtEmail" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditeCelular" runat="server" CssClass="label control-label label-default col-md-2" Text="Celular: "></asp:Label></h1>

                <asp:TextBox ID="txtCelular" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblDatosDireccion" runat="server" Text="Edite los datos de la Direccion del Medico" CssClass="label control-label label-default col-md-3"></asp:Label></h4>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditeCalle" runat="server" CssClass="label control-label label-default col-md-2" Text="Calle: "></asp:Label></h1>

                <asp:TextBox ID="txtCalle" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblEditeAltura" runat="server" CssClass="label control-label label-default col-md-2" Text="Altura: "></asp:Label></h1>

                <asp:TextBox ID="txtAltura" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditePiso" runat="server" CssClass="label control-label label-default col-md-2" Text="Piso: "></asp:Label></h1>

                <asp:TextBox ID="txtPiso" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <asp:DropDownList ID="ddlListarLocalidad" AutoPostBack="true" runat="server" class="btn btn-info dropdown-toggle dropdown-toggle-split col-md-3">
                    <asp:ListItem Text="---Seleccione Localidad---" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Neuquen" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Cipolleti" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Plottier" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Cinco Saltos" Value="4"></asp:ListItem>

                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblDatosMedico" runat="server" Text="Edite los datos propios del Medico" CssClass="label control-label label-default col-md-3"></asp:Label></h4>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditeLegajo" runat="server" CssClass="label control-label label-default col-md-2" Text="Legajo: "></asp:Label></h1>

                <asp:TextBox ID="txtLegajo" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblEditeConsulta" runat="server" CssClass="label control-label label-default col-md-3" Text="Precio Consulta: "></asp:Label></h1>

                <asp:TextBox ID="txtConsulta" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditeMatricula" runat="server" CssClass="label control-label label-default col-md-2" Text="Matricula: "></asp:Label></h1>

                <asp:TextBox ID="txtMatricula" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>


                <asp:DropDownList ID="ddlListarEspecialidades" AutoPostBack="true" runat="server" class="btn btn-info dropdown-toggle dropdown-toggle-split col-md-3">
                    <asp:ListItem Text="---Seleccione Especialidad---" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Gastroenterologo" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Psiquiatra" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Clinico" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Pediatra" Value="4"></asp:ListItem>

                </asp:DropDownList>


            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" class="btn btn-link col-md-3" Text="Update Medico" />

            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" runat="server" class="btn btn-danger col-md-5" Text="Volver A Alta Medico" />


            </div>
        </div>
        <%--        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnEliminarMedico" OnClick="btnEliminarMedico_Click" runat="server" class="btn btn-danger col-md-3" Text="Borrar Medico" />

            </div>
        </div>--%>
    </div>
</asp:Content>
