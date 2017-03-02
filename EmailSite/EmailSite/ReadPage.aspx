<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadPage.aspx.cs" Inherits="EmailSite.ReadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Read Email</div>
        <p>
            From:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 14px" ReadOnly="True"></asp:TextBox>
        </p>
        <p>
            Subject:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px; margin-bottom: 1px" ReadOnly="True"></asp:TextBox>
        </p>
        <p>
            Body:<asp:Button ID="deleteButton" runat="server" style="margin-left: 225px" Text="Delete" OnClick="delete_click" />
        </p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Height="196px" style="margin-left: 8px" Width="316px" ReadOnly="True"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Inbox" OnClick="inbox_click" />
            <asp:Button ID="Button3" runat="server" style="margin-left: 11px" Text="Reply" OnClick="reply_click" />
        </p>
    </form>
</body>
</html>
