<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadPage.aspx.cs" Inherits="EmailSite.ReadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Read Email</div>
        <p>
            From:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 14px"></asp:TextBox>
        </p>
        <p>
            Subject:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px; margin-bottom: 1px"></asp:TextBox>
        </p>
        <p>
            Body:<asp:Button ID="Button1" runat="server" style="margin-left: 225px" Text="Delete" />
        </p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Height="196px" style="margin-left: 8px" Width="316px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Inbox" />
            <asp:Button ID="Button3" runat="server" style="margin-left: 11px" Text="Reply" />
        </p>
    </form>
</body>
</html>
