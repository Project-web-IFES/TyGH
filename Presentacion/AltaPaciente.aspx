<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Presentacion.AltaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblIntro" runat="server" Text="Ingrese los datos del paciente" CssClass="label control-label label-default col-md-3"></asp:Label></h4>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngreseNombre" runat="server" CssClass="label control-label label-default col-md-2" Text="Nombre: "></asp:Label></h1>

                <asp:TextBox ID="txtNombre" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblIngreseApellido" runat="server" CssClass="label control-label label-default col-md-2" Text="Apellido: "></asp:Label></h1>

                <asp:TextBox ID="txtApellido" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngreseDocumento" runat="server" CssClass="label control-label label-default col-md-2" Text="Documento: "></asp:Label></h1>

                <asp:TextBox ID="txtDocumento" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblIngreseEmail" runat="server" CssClass="label control-label label-default col-md-2" Text="E-Mail: "></asp:Label></h1>

                <asp:TextBox ID="txtEmail" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngreseCelular" runat="server" CssClass="label control-label label-default col-md-2" Text="Celular: "></asp:Label></h1>

                <asp:TextBox ID="txtCelular" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblDatosDireccion" runat="server" Text="Ingrese los datos de la Direccion del Paciente" CssClass="label control-label label-default col-md-4"></asp:Label></h4>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngreseCalle" runat="server" CssClass="label control-label label-default col-md-2" Text="Calle: "></asp:Label></h1>

                <asp:TextBox ID="txtCalle" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>

                <h1>
                    <asp:Label ID="lblIngreseAltura" runat="server" CssClass="label control-label label-default col-md-2" Text="Altura: "></asp:Label></h1>

                <asp:TextBox ID="txtAltura" CssClass="input-lg col-md-3" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngresePiso" runat="server" CssClass="label control-label label-default col-md-2" Text="Piso: "></asp:Label></h1>

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
                <asp:Button ID="btnGuardarPaciente" OnClick="btnGuardarPaciente_Click" runat="server" class="btn btn-success col-md-3" Text="Guardar Paciente" />

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnListarPacientes" OnClick="btnListarPacientes_Click" runat="server" class="btn btn-info col-md-3" Text="Listar Pacientes" />

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:GridView ID="gdvListarPacientes" AutoGenerateColumns="false" CssClass="table table-hover table-responsive" runat="server" RowStyle-CssClass="alert-success">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre y Apellido" DataField="nombreApellido" />
                        <asp:BoundField HeaderText="Email" DataField="email" />
                        <asp:BoundField HeaderText="Celular" DataField="celular" />


                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:Button ID="btnEditarPaciente" OnClick="btnEditarPaciente_Click" CommandArgument='<%# Eval("idPaciente") %>' runat="server" Text="Editar Paciente" CssClass="btn-link" />
                                <asp:Button ID="btnVerTurnos" OnClick="btnVerTurnos_Click" CommandArgument='<%# Eval("idPaciente") %>' runat="server" Text="Ver Turnos" CssClass="btn-link" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>


    </div>


</asp:Content>
