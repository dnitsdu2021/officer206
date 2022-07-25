<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Officer206Analyzer.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Register</title>

    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet" />

    <script type="text/javascript">
        function numeric(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode;
            if (unicode == 8 || unicode == 9 || (unicode >= 48 && unicode <= 57)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">

        <div class="container">
            <div class="card card-login mx-auto mt-5">
                <div class="card-header">Register an Account</div>
                <div class="card-body">
                    <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="TextNic" CssClass="form-control" runat="server" placeholder="NIC"></asp:TextBox>
                            <label for="TextNic">NIC</label>
                        </div>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-block" Text="Search" OnClick="btnSearch_Click" />
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtBranch" CssClass="form-control" runat="server" placeholder="Branch"></asp:TextBox>
                            <label for="txtBranch">Branch</label>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtOffno" CssClass="form-control" runat="server" placeholder="Official No"></asp:TextBox>
                            <label for="txtOffno">Official Number</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtRank" CssClass="form-control" runat="server" placeholder="Rank"></asp:TextBox>
                            <label for="txtRank">Rank</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name with Initial"></asp:TextBox>
                            <label for="txtName">Initial with Name</label>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-label-group">
                                    <asp:TextBox ID="txtMn" CssClass="form-control" runat="server" placeholder="Mobile No"></asp:TextBox>
                                    <label for="txtMn">Mobile No</label>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>
                            <label for="txtEmail">User Name</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <label for="txtPassword">Password</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtPasswordConf" CssClass="form-control" runat="server" placeholder="Password Confirm" TextMode="Password"></asp:TextBox>
                            <label for="txtPasswordConf">Password</label>
                        </div>
                    </div>
                    <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary btn-block" Text="Register" OnClick="btnRegister_Click" />
                    <asp:Label ID="lblMessage" runat="server" Text="" class="alert-link"></asp:Label>

                    <div class="text-center">
                        <a class="d-block small mt-3" href="Login.aspx">Login Page</a>

                    </div>
                </div>
            </div>
        </div>

    </form>
</body>

</html>
