<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxPage.aspx.cs" Inherits="EmailSite.InboxPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2>Inbox</h2>       
        <asp:Button ID="Button1" runat="server" Text="Compose" OnClick="compose_click" />
        <asp:Button ID="Button2" runat="server" style="margin-left: 11px" Text="Address Book" OnClick="address_click" />
        <asp:Button ID="Button3" runat="server" style="margin-left: 11px" Text="Logout" OnClick="logout_click" />
    
    </div>

        <div id="AddressBox" runat="server">

        </div>

        <div id="inboxDisplay" runat="server">
            
        </div>

    </form>
</body>
</html>
