<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionCheck.aspx.cs" Inherits="Officer206Analyzer.SessionCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <script>

        {"valid":<%=Session["nic"] != null ? "true" : "false" %>}

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
