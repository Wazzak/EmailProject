<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="EmailSite.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href=".//Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Name:
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 7px"></asp:TextBox>
        Address:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 16px" Width="122px"></asp:TextBox>
    
    </div>
        <p>
            New Email Address: <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 13px" Width="125px"></asp:TextBox>
        </p>
        <p>
            New Password:<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 26px"></asp:TextBox>
            Re-enter new password:<asp:TextBox ID="TextBox5" runat="server" style="margin-left: 26px"></asp:TextBox>
        </p>
        <p>
            What is your favourite colour?<asp:TextBox ID="TextBox6" runat="server" style="margin-left: 13px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="create_click" Text="Create" />
        <asp:Button ID="Button2" runat="server" OnClick="cancel_click" style="margin-left: 11px" Text="Cancel" />
    </form>

    <span id="errorMessage" runat="server">
            ERROR
        </span>

</body>
</html>
