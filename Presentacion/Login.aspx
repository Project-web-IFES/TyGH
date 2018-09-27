<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/login.css" rel="stylesheet" id="login" />


</head>
<body>
    <form runat="server">
        <div class="grand-parent-container">
            <div class="parent-container">
                <div align="center">
                    <%--<form class="login-form">--%>
                    <h2>LOGIN</h2>
                    <div class="inputs">
                        <div class="form-group row">
                            <label for="email" class="col-sm-3 control-label">Email </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEmail" type="email" runat="server"></asp:TextBox>
                                <%-- <input id="TbxEmail" type="email" placeholder="Email" class="form-control" runat="server"/>--%>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="password" class="col-sm-3 control-label">Password</label>
                            <div class="col-sm-9">
                                <%--<input id="TbxPass" type="password" placeholder="Password" class="form-control" runat="server" />--%>
                                 <asp:TextBox ID="txtPass" type="password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" class="btn btn-primary btn-block" />
                        <!--<button type="submit" class="btn btn-primary btn-block" runat="server">Login</button> -->
                        <span class="help-block"><a href="#">I don't have an account yet! </a></span>
                    </div>
                    <!-- /form -->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
