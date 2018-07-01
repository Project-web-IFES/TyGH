<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="Presentacion.VerTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblIntro" runat="server" Text="Turnos del Paciente: " CssClass="label control-label label-default col-md-3"></asp:Label></h4>

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblMostrarNombre" runat="server" CssClass="label control-label label-default col-md-1" Text="Nombre: "></asp:Label>
                    <asp:Label ID="lblNombre" runat="server" CssClass="label label-info col-md-2"></asp:Label>

                </h4>

                <h4>
                    <asp:Label ID="lblMostrarApellido" runat="server" CssClass="label control-label label-default col-md-1" Text="Apellido: "></asp:Label>
                    <asp:Label ID="lblApellido" runat="server" CssClass="label label-info col-md-2"></asp:Label>

                </h4>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:GridView ID="gdvListarTurnos" AutoGenerateColumns="false" CssClass="table table-hover table-responsive" RowStyle-CssClass="alert-success" runat="server">
                    <Columns>
                        <%--En el DataField hay que poner el nombre que tiene en la BASE DE DATOS--%>
                        <asp:BoundField HeaderText="Dia y Hora Inicio Turno" DataField="diaHoraInicio" />
                        <asp:BoundField HeaderText="Dia y Hora Fin Turno" DataField="diaHoraFinal" />
<%--                        <asp:BoundField HeaderText="Paciente" DataField="nombreCompleto" />--%>
                        <asp:BoundField HeaderText="Sala" DataField="nombre" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnListarTurnos" OnClick="btnListarTurnos_Click" runat="server" class="btn btn-info col-md-3" Text="Listar Turnos" />

            </div>
        </div>

    </div>



</asp:Content>
