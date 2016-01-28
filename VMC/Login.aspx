<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VMC.Login" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Đăng nhập hệ thống</title>
   

    <link href="/Content/themes/css/font-awesome.css" rel="stylesheet">
    <link href="/Content/themes/css/font-awesome.min.css" rel="stylesheet">
    <link href="/Content/themes/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap core CSS -->    
    
     <link href="/Content/themes/css/login.css" rel="stylesheet">
    <link href="/Content/themes/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet">
   
  </head>
  <body>
      <div class="loginfrm">
          <% if (failded == 1)
             { %>
            <div class="alert alert-danger alert-dismissible fade in" role="alert">
              <button class="close" aria-label="Close" data-dismiss="alert" type="button">
                <span aria-hidden="true">×</span>
              </button>
              Mật khẩu không đúng
            </div>
          <% } %>
		    <div class="loginmodal-container">
			    <h1>Đăng nhập hệ thống</h1><br>
                <form runat="server" id="frmlogin">
                    <asp:TextBox ID="txtuser" runat="server" ></asp:TextBox>
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" ></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="login loginmodal-submit" OnClick="btnLogin_Click" />
                </form>
			    <%--<div class="login-help">
			    <a href="#">Register</a> - <a href="#">Forgot Password</a>
			    </div>--%>
		    </div>
      </div>
            <script src="<%: ResolveUrl("/Content/themes/bootstrap-switch/docs/js/jquery.min.js") %>"></script>
            <script src="<%: ResolveUrl("/Content/themes/bootstrap-switch/docs/js/bootstrap.min.js") %>"></script>
            <script src="<%: ResolveUrl("/Content/themes/bootstrap-switch/docs/js/highlight.js") %>"></script>
            <script src="<%: ResolveUrl("/Content/themes/bootstrap-switch/dist/js/bootstrap-switch.js") %>"></script>
            <script src="<%: ResolveUrl("/Content/themes/bootstrap-switch/docs/js/main.js") %>"></script>   
  </body>
</html>
