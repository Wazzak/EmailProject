<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EmailSite.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href=".//Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="words" runat="server">
    
        Email Address:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 11px"></asp:TextBox>
    
    </div>
        <p style="margin-left: 28px">
            Password:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button7" runat="server" OnClick="remember_click" Text="Remember Me" />
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
            <asp:Button class="homeButton"  ID="Button4" runat="server" OnClick="red_click" Text="Red" />
            <asp:Button class="homeButton" ID="Button5" runat="server" OnClick="blue_click" style="margin-left: 13px" Text="Blue" />
            <asp:Button class="homeButton" ID="Button6" runat="server" OnClick="yellow_click" style="margin-left: 9px" Text="Yellow" />
        </p>
    </form>

    <span id="errorMessage" runat="server">
            ERROR
        </span>

</body>
</html>
