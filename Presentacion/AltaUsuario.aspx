<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Presentacion.AltaUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="grand-parent-container">
        <div class="parent-container">
            <div align="center">
                <h2>LOGIN</h2>


                <div class="form-group">
                    <div class="row">

                        <asp:Label ID="LblNombreUsuario" runat="server" Text="Nombre Usuario"></asp:Label>
                        <asp:TextBox ID="TxtNombreUsuario" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <asp:Label ID="LblApellido" runat="server" Text="Apellido usuario"></asp:Label>
                        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <div class="row">

                        <asp:Label ID="lblEmail" for="email" runat="server" Text="Email"> </asp:Label>
                        <asp:TextBox ID="txtEmail" type="email" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">

                        <asp:Label ID="lblPassword" for="password" runat="server" Text="Password"></asp:Label>

                        <asp:TextBox ID="txtPass" type="password" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <div class="row">
                        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Crear Usuario" class="btn-primary" />
                    </div>
                </div>
            </div>




        </div>
    </div>



</asp:Content>
