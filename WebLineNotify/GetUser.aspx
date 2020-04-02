<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetUser.aspx.cs" Inherits="WebLineNotify.GetUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">



        <h3 class=" bg-primar">登入line帳號產生連結token</h3>



        <div class="h3"> 
            透過此頁讓line 的通知根群組或者朋友連線，
            <br />
             登入之後會看見一組清單，群組或朋友，如果群組要顯示需要將linenotify加入群組裡面
        </div>
        <asp:Button ID="BtnAgree" runat="server" Text="登入產生連結token"  OnClick="BtnAgree_Click" CssClass="btn btn-primary btn-block"/>
        <asp:Literal ID="lblMessage" runat="server"></asp:Literal>

        <asp:Button ID="Button1" runat="server" Text="Button" />

    </form>
</body>
</html>
