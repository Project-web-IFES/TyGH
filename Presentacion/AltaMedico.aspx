<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaMedico.aspx.cs" Inherits="Presentacion.AltaMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

    <div class="form-group">
        <asp:Label ID="LlbDatos" runat="server" Text="Datos Personales"></asp:Label>
        <asp:TextBox ID="TbxNombre" placeholder="Nombre" runat="server"></asp:TextBox> 
        <asp:TextBox ID="TbxApellido" placeholder="Apellido" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxDocumento" placeholder="Documento" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxEmail" placeholder="ingrese E-Mail" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxCelular" placeholder="Ingrese Celular" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Lbl" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="TbxCalle" placeholder="Calle" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxAltura" placeholder="Altura" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxPiso" placeholder="Piso" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxLocalidad" placeholder="localidad" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:TextBox ID="TbxEspecialidad" runat="server" Text="Especialidad"></asp:TextBox>
        <asp:TextBox ID="TbxLegajo" placeholder="ingrese Numero de Legajo" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxConsulta" placeholder="ingrese valor de consulta sin $" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbxMatricula" placeholder="ingrese matricula" runat="server"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar Datos" />
        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" />
        <asp:Button ID="BtnListar" runat="server" OnClick="BtnListar_Click" Text="Listar" />
       
         <asp:GridView ID="GdvMedicos" runat="server" AutoGenerateColumns="false">
            <Columns>
            <asp:BoundField HeaderText="Id" DataField="idMedico" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Documento" DataField="Documento" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Celular" DataField="celular" />
            <asp:BoundField HeaderText="Calle" DataField="calle" />
            <asp:BoundField HeaderText="Altura" DataField="altura" />
            <asp:BoundField HeaderText="Piso" DataField="piso" />
            <asp:BoundField HeaderText="Localidad" DataField="localidad" />
            <asp:BoundField HeaderText="Legajo" DataField="legajo" />
            <asp:BoundField HeaderText="Valor Consulta" DataField="valorConsulta" />
            <asp:BoundField HeaderText="Matricula" DataField="matricula" />
        </Columns>
        </asp:GridView>
    </div>

</div>

</asp:Content>

