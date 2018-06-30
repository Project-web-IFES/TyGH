<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAgenda.aspx.cs" Inherits="Presentacion.AltaAgenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="form-group">
            <div class="row">
                <h4>
                    <asp:Label ID="lblIntro" runat="server" Text="Agenda del Medico: " CssClass="label control-label label-default col-md-3"></asp:Label></h4>

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
                <h1>
                    <asp:Label ID="lblFechaHoraInicio" runat="server" CssClass="label control-label label-default col-md-5" Text="Fecha y Hora Inicial de Agenda: "></asp:Label></h1>


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
                    <asp:Label ID="lblFechaHoraFin" runat="server" CssClass="label control-label label-default col-md-5" Text="Fecha y Hora Final de Agenda: "></asp:Label></h1>

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
                <asp:Button ID="btnGuardarAgenda" OnClick="btnGuardarAgenda_Click" runat="server" class="btn btn-success col-md-3" Text="Guardar Agenda" />

            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <asp:GridView ID="gdvListarAgendas" AutoGenerateColumns="false" CssClass="table table-hover table-responsive" runat="server" RowStyle-CssClass="alert-success">
                    <Columns>
                        <asp:BoundField HeaderText="Inicio de Agenda" DataField="diaHoraInicio" />
                        <asp:BoundField HeaderText="Fin de Agenda" DataField="diaHoraFinal" />
                        <asp:BoundField HeaderText="Medico" DataField="nombreCompleto" />

                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:Button ID="btnCargarOVerTurnos" OnClick="btnCargarOVerTurnos_Click" CommandArgument='<%# Eval("idAgenda") %>' runat="server" Text="Cargar o Ver Turnos" CssClass="btn-link" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <asp:Button ID="btnListarAgendas" OnClick="btnListarAgendas_Click" runat="server" class="btn btn-info col-md-3" Text="Listar Agendas" />

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
