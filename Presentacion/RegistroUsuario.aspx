<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Presentacion.RegistroUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<body>
    <form runat="server">--%>
        <div class="grand-parent-container">
            <div class="parent-container">
                <div align="center">
                    <h2>LOGIN</h2>
                    <div class="inputs">
                        <div class="form-group row">
                            <label for="email" class="col-sm-3 control-label">Email </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEmail" type="email" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="password" class="col-sm-3 control-label">Password</label>
                            <div class="col-sm-9">
                                 <asp:TextBox ID="txtPass" type="password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" class="btn btn-primary btn-block" />
                        <span class="help-block"><a href="AltaUsuario.aspx">I don't have an account yet!</a></span>
                    </div>
                </div>
            </div>
        </div>
<%--    </form>
</body>--%>
</asp:Content>
