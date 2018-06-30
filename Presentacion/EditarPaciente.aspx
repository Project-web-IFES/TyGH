<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPaciente.aspx.cs" Inherits="Presentacion.EditarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblIntro" runat="server" Text="Editar los datos del paciente" CssClass="label control-label label-default col-md-3"></asp:Label></h4>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditarNombre" runat="server" CssClass="label control-label label-default col-md-2" Text="Nombre: "></asp:Label></h1>

                <asp:TextBox ID="txtNombre" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblEditarApellido" runat="server" CssClass="label control-label label-default col-md-2" Text="Apellido: "></asp:Label></h1>

                <asp:TextBox ID="txtApellido" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditarDocumento" runat="server" CssClass="label control-label label-default col-md-2" Text="Documento: "></asp:Label></h1>

                <asp:TextBox ID="txtDocumento" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblEditarEmail" runat="server" CssClass="label control-label label-default col-md-2" Text="E-Mail: "></asp:Label></h1>

                <asp:TextBox ID="txtEmail" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblEditarCelular" runat="server" CssClass="label control-label label-default col-md-2" Text="Celular: "></asp:Label></h1>

                <asp:TextBox ID="txtCelular" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblDatosDireccion" runat="server" Text="Edite los datos de la Direccion del Paciente" CssClass="label control-label label-default col-md-3"></asp:Label></h4>
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
                <asp:Button ID="btnUpdatePaciente" OnClick="btnUpdatePaciente_Click" runat="server" class="btn btn-link col-md-3" Text="Editar Paciente" />

            </div>
        </div>

<%--        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnEliminarPaciente" OnClick="btnEliminarPaciente_Click" runat="server" class="btn btn-danger col-md-3" Text="Borrar Paciente" />

            </div>
        </div>--%>

    </div>


</asp:Content>
