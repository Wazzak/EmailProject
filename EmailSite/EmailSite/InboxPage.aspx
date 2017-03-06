<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxPage.aspx.cs" Inherits="EmailSite.InboxPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href=".///Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2>Inbox</h2>       
        <asp:Button ID="Button1" runat="server" Text="Compose" OnClick="compose_click" />
        <asp:Button ID="Button2" runat="server" style="margin-left: 11px" Text="Address Book" OnClick="address_click" />
        <asp:Button ID="Button3" runat="server" style="margin-left: 11px" Text="Logout" OnClick="logout_click" />
    
        <asp:Button ID="Button4" runat="server" OnClick="delete_click" style="margin-left: 11px" Text="Deleted" Width="85px" />
        <asp:Button ID="Button5" runat="server" OnClick="sent_click" style="margin-left: 14px" Text="Sent" Width="70px" />
    
        <asp:Button ID="Button6" runat="server" OnClick="deleteAllClick" style="margin-left: 20px" Text="Delete Selected" />
    
    </div>
        
        <div id="AddressBox" runat="server">

        </div>

        <div id="inboxDisplay" runat="server">
            
        </div>

        <div id="deletedDisplay" runat="server">
            
        </div>

        <div id="sentDisplay" runat="server">
            
        </div>

    </form>
</body>
</html>
