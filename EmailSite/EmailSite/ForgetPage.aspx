﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPage.aspx.cs" Inherits="EmailSite.ForgetPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href=".//Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        Email Address:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 13px"></asp:TextBox>
    
    </div>
        <p>
            What is your favourite colour?<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Height="25px" Text="Get Password" OnClick="get_click" />
        </p>
        <p>
            Your password is:<asp:TextBox ID="TextBox3" runat="server" Height="16px" style="margin-left: 16px" Width="113px"></asp:TextBox>
        </p>
        <asp:Button ID="Button2" runat="server" Text="Home" OnClick="home_click" />
    </form>

    <span id="errorMessage" runat="server">
            ERROR
    </span>
</body>
</html>
