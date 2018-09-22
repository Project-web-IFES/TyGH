<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    
<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="Content/login.css" rel="stylesheet" id="login" />


    <title></title>


</head>
<body>
    <div class="grand-parent-container">
    <div class="parent-container">
        <div align="center" >
            <form class="login-form">
                <h2>LOGIN</h2>
                <div class="inputs">
                    <div class="form-group row">
                        <label for="email" class="col-sm-3 control-label">Email </label>
                        <div class="col-sm-9">
                            <input type="email" id="email" placeholder="Email" class="form-control" runat="server"/>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="password" class="col-sm-3 control-label">Password</label>
                        <div class="col-sm-9">
                            <input type="password" id="password" placeholder="Password" class="form-control" runat="server"/>
                        </div>
                    </div>
                </div>                
                <button type="submit" class="btn btn-primary btn-block">Login</button>
                <span class="help-block"><a href="#">I don't have an account yet! </a></span>
            </form> <!-- /form -->
        </div>
    </div>
</div>
</body>
</html>
