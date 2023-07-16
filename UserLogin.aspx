<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="AccountApp.UserLogin" %>

<%@ Import Namespace="AccountApp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <meta name="description" content="Responsive Bootstrap 4 and web Application ui kit." />

    <title></title>
    <!-- Favicon-->
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <!-- Custom Css -->
    <link rel="stylesheet" href="assets/plugins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/style.min.css" />
    <style>
        .align-center {
            margin-left: 70%;
            margin-right: 70%;
            width: 60%;
            margin-bottom:40%;
            /*margin-top:40%;*/
        }
    </style>
</head>
<body class="theme-blush">
    <div class="authentication">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-sm-12">
                    <form id="form1" runat="server" class="align-center">
                        <div class="header">
                         
                            <h3>Log in</h3>
                        </div>

                        <div class="body">
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtUser" CssClass="form-control" placeholder="UserName" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="zmdi zmdi-account-circle"></i></span>
                                </div>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="zmdi zmdi-lock"></i></span>
                                </div>
                            </div>
                            <asp:Button ID="BtnLogin" runat="server" Text="SIGN IN" CssClass="btn btn-secondary btn-lg btn-block" OnClick="BtnLogin_Click" />
                            <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                        </div>
                    </form>
                    <div class="copyright text-center">
                        <%-- &copy;
                    <script>document.write(new Date().getFullYear())</script>--%>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Jquery Core Js -->
    <script src="assets/bundles/libscripts.bundle.js"></script>
    <script src="assets/bundles/vendorscripts.bundle.js"></script>
    <!-- Lib Scripts Plugin Js -->




</body>
</html>
