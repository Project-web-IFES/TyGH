<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Presentacion.RegistroUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<body>
    <form runat="server">--%>
    <div class="col-sm-4">

    </div>

    <div class="grand-parent-container col-sm-4">
        <div class="parent-container">
            <div align="center">
                <h2>LOGIN</h2>
                <div class="inputs">

                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <label for="email" class="input-group-text">Email </label>
                        </div>
                            <asp:TextBox ID="txtEmail" type="email" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <label for="password" class="input-group-text">Password</label>
                        </div>
                            <asp:TextBox ID="txtPass" type="password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div>
                    <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" class="btn btn-primary btn-block" />
                    <span class="help-block"><a href="AltaUsuario.aspx">I don't have an account yet!</a></span>
                </div>

                <div role="alert">
                    <h2><asp:Label ID="LblError" runat="server" CssClass="alert-danger "></asp:Label></h2>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-4">

    </div>
<%--    </form>
</body>--%>
</asp:Content>
