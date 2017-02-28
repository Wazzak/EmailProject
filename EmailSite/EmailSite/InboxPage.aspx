<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxPage.aspx.cs" Inherits="EmailSite.InboxPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Inbox<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Compose" OnClick="compose_click" />
        <asp:Button ID="Button2" runat="server" style="margin-left: 11px" Text="Address Book" />
        <asp:Button ID="Button3" runat="server" style="margin-left: 11px" Text="Logout" />
    
    </div>
    </form>
</body>
</html>
