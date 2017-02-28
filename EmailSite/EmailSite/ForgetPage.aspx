<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPage.aspx.cs" Inherits="EmailSite.ForgetPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Email:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 13px"></asp:TextBox>
    
    </div>
        <p>
            What is your favourite colour?<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Height="25px" Text="Get Password" />
        </p>
        <p>
            Your password is:<asp:TextBox ID="TextBox3" runat="server" Height="16px" style="margin-left: 16px" Width="113px"></asp:TextBox>
        </p>
        <asp:Button ID="Button2" runat="server" Text="Home" />
    </form>
</body>
</html>
