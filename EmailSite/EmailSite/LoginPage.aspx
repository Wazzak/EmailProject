<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EmailSite.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Email:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 11px"></asp:TextBox>
    
    </div>
        <p>
            Password:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px"></asp:TextBox>
        </p>
        <p>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="login_click" Text="Login" Width="51px" />
            <asp:Button ID="Button2" runat="server" OnClick="register_click" style="margin-left: 8px" Text="Register" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="forget_click" Text="Forgot Password?" />
        </p>
        <p>
            Color:</p>
        <p>
            <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="red_check" Text="Red" />
            <asp:RadioButton ID="RadioButton2" runat="server" OnCheckedChanged="blue_check" Text="Blue" />
            <asp:RadioButton ID="RadioButton3" runat="server" OnCheckedChanged="yellow_check" Text="Yellow" />
        </p>
    </form>
</body>
</html>
