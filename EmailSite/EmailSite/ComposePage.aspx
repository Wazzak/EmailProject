<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComposePage.aspx.cs" Inherits="EmailSite.ComposePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Compose new mail<br />
        <br />
        To:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 17px"></asp:TextBox>
    
    </div>
        <p>
            Subject:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 18px" MaxLength="12"></asp:TextBox>
        </p>
        <p>
            Body:</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Height="153px" style="margin-left: 0px" Width="246px" MaxLength="255"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Send" OnClick="send_click" />
            <asp:Button ID="Button2" runat="server" OnClick="cancel_click" style="margin-left: 18px" Text="Cancel" />
        </p>

        <span id="errorMessage" runat="server">
            ERROR
        </span>
    </form>
</body>
</html>
