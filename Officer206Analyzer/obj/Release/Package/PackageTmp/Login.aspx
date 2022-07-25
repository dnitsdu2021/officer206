<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Officer206Analyzer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>

    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet"/>
</head>
<body class="bg-dark">

    <div class="container">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">Login</div>
            <div class="card-body">
                <form id="form" runat="server">
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox id="txtEmail" CssClass="form-control" runat="server" placeholder="Email address" required="required" autofocus="autofocus" Width="100%"></asp:TextBox>
                            <label for="txtEmail">User Name</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox id="txtPassword" CssClass="form-control" runat="server" placeholder="Password" required="required" TextMode="Password" Width="100%"></asp:TextBox>
                            <label for="txtPassword">Password</label>
                        </div>
                    </div>
                    <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" Width="100%" />
                    <asp:Label ID="lblMessage" runat="server" Text="" class="alert-link"></asp:Label>
                    <asp:TextBox ID="lblNicTemp" runat="server" Visible="False"></asp:TextBox>
                </form>
                <div class="text-center">
                    <a class="d-block small mt-3" href="Register.aspx">Register an Account</a>
                   
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

</body>
</html>

