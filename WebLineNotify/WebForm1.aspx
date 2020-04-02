<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebLineNotify.WebForm1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />


    <style>

        .pagination a[disabled]{  color: #777;cursor: not-allowed;background-color: #fff;border-color: #ddd;}
.pagination span.active{z-index: 2;color: #fff;cursor: default;background-color: #337ab7;border-color: #337ab7;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            Token:<asp:TextBox ID="txtToken" runat="server"></asp:TextBox>

        </div>

        <div>
            TO頻道名稱:
            <asp:TextBox ID="txtChannel" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>想傳送的訊息文字:</label>        
        </div>        
        <asp:TextBox ID="txtmsg" runat="server" Height="85px" TextMode="MultiLine" Width="250px" ></asp:TextBox>
        <br />
        <asp:Button ID="btnSend" runat="server" Text="發送訊息" OnClick="btnSend_Click"   CssClass="btn btn-primary"/>
                &nbsp;
                <asp:Button ID="btnAdd" runat="server" Text="新增訊息" OnClick="btnAdd_Click"  CssClass="btn btn-warning"/>
        <br />
        <asp:Literal ID="lblStatus" runat="server"></asp:Literal>
        

        <br />
        <div>
            文字訊息清單
        </div>
        
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered"></asp:GridView>

        <div class='pagin'> 
        <webdiyer:AspNetPager ID="anp" runat="server" AlwaysShow="true"
        CssClass="pagination" CurrentPageButtonClass="active"
        CustomInfoHTML="共%RecordCount%条，第%CurrentPageIndex%页/共%PageCount%页"
        FirstPageText='首页'
        LastPageText='尾页'
        NextPageText="下一页"
        OnPageChanged="anpList_PageChanged"
        PageIndexBoxType="DropDownList"
        PageSize="20"
        PagingButtonSpacing=""
        PrevPageText="上一页"
        ShowCustomInfoSection="Left" ShowMoreButtons="False" ShowPageIndex="true"
        ShowPageIndexBox="Always"
        SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到 ">
    </webdiyer:AspNetPager>
</div

        
    </form>
</body>
</html>
