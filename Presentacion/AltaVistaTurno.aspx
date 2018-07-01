<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaVistaTurno.aspx.cs" Inherits="Presentacion.AltaVistaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblIntro" runat="server" Text="Turnos del Medico: " CssClass="label control-label label-default col-md-3"></asp:Label></h4>

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

        <asp:HiddenField ID="hfIdPaciente" runat="server" />

        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngresarFechaHoraInicio" runat="server" CssClass="label control-label label-default col-md-5" Text="Fecha y Hora Incial de Turno: "></asp:Label></h1>


            </div>
        </div>

        <div class="row">
            <div class='col-md-3'>
                <div class="form-group">
                    <div class='input-group date' id='date'>
                        <%--ACA ES DONDE VAMOS A PONER EL TXT DONDE SE GUARDA LA FECHA QUE SELECCIONAMOS--%>
                        <asp:TextBox ID="txtFechaHoraInicio" CssClass="input-lg" runat="server"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <h1>
                    <asp:Label ID="lblIngresarFechaHoraFin" runat="server" CssClass="label control-label label-default col-md-5" Text="Fecha y Hora Final de Turno: "></asp:Label></h1>

            </div>
        </div>


        <div class="row">
            <div class='col-md-3'>
                <div class="form-group">
                    <div class='input-group date' id='date1'>
                        <%--ACA ES DONDE VAMOS A PONER EL TXT DONDE SE GUARDA LA FECHA QUE SELECCIONAMOS--%>
                        <asp:TextBox ID="txtFechaHoraFin" CssClass="input-lg" runat="server"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnListarPacientes" OnClick="btnListarPacientes_Click" runat="server" class="btn btn-info col-md-3" Text="Listar Pacientes" />

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:DropDownList ID="ddlListarPacientes" OnSelectedIndexChanged="ddlListarPacientes_SelectedIndexChanged" AutoPostBack="true" runat="server" class="btn btn-info dropdown-toggle dropdown-toggle-split col-md-3"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnListarSalas" OnClick="btnListarSalas_Click" runat="server" class="btn btn-info col-md-3" Text="Listar Salas" />

            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <asp:DropDownList ID="ddlListarSalas" OnSelectedIndexChanged="ddlListarSalas_SelectedIndexChanged" AutoPostBack="true" runat="server" class="btn btn-info dropdown-toggle dropdown-toggle-split col-md-3"></asp:DropDownList>
            </div>
        </div>

        <asp:HiddenField ID="hfIdSala" runat="server" />

        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnGuardarTurno" OnClick="btnGuardarTurno_Click" runat="server" class="btn btn-success col-md-3" Text="Guardar Turno" />

            </div>
        </div>



        <div class="form-group">
            <div class="row">
                <asp:GridView ID="gdvListarTurnos" AutoGenerateColumns="false" CssClass="table table-hover table-responsive" RowStyle-CssClass="alert-success" runat="server">
                    <Columns>
                        <%--En el DataField hay que poner el nombre que tiene en la BASE DE DATOS--%>
                        <asp:BoundField HeaderText="Dia y Hora Inicio Turno" DataField="diaHoraInicio" />
                        <asp:BoundField HeaderText="Dia y Hora Fin Turno" DataField="diaHoraFinal" />
                        <asp:BoundField HeaderText="Paciente" DataField="nombreCompleto" />
                        <asp:BoundField HeaderText="Sala" DataField="nombre" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnListarTurnos" OnClick="btnListarTurnos_Click" runat="server" class="btn btn-info col-md-3" Text="Listar Turnos de Agenda" />

            </div>
        </div>







    </div>

    <script type="text/javascript">
        $(function () {

            //$('#myDate').datetimepicker();

            $('#date').datetimepicker({
                format: 'DD-MM-YYYY HH:mm:ss'
            }).on('dp.change', function (e) {
                if (!e.oldDate || !e.date.isSame(e.oldDate, 'day')) {
                    $(this).data('DateTimePicker').hide();
                }
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {

            //$('#myDate').datetimepicker();

            $('#date1').datetimepicker({
                format: 'DD-MM-YYYY HH:mm:ss'
            }).on('dp.change', function (e) {
                if (!e.oldDate || !e.date.isSame(e.oldDate, 'day')) {
                    $(this).data('DateTimePicker').hide();
                }
            });
        });
    </script>

</asp:Content>
