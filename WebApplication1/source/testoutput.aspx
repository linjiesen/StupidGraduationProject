<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testoutput.aspx.cs" Inherits="WebApplication1.source.testoutput"   EnableEventValidation = "false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="btn">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>自动组卷系统！</title>


      <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>

    
<%--        <!-- CSS -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="assets/css/form-elements.css"/>
        <link rel="stylesheet" href="assets/css/style.css"/>--%>

        <link rel="shortcut icon" href="assets/ico/favicon.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png"/>



</head>
<body>


     <nav class="navbar navbar-expand-md " style="background-color:blanchedalmond">
        <div class="container">
            <a class="btn " href="home.aspx">
                    自动组卷系统
            </a> 
        </div>
    </nav>

    <div align="center">

    <form id="form1" runat="server"   text-align:center  >
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDataBound="GridView1_RowDataBound" OnRowUpdating="GridView1_RowUpdating" Width="945px" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated" OnRowDeleting="GridView1_RowDeleting" OnDataBound="GridView1_DataBound" OnRowCommand="GridView1_RowCommand" OnCreatingModelDataSource="GridView1_CreatingModelDataSource" OnDataBinding="GridView1_DataBinding" OnInit="GridView1_Init" OnLoad="GridView1_Load1" OnPreRender="GridView1_PreRender" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSorted="GridView1_Sorted" OnSorting="GridView1_Sorting" style="margin-right: 0px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="编号" />
                <%--<asp:BoundField DataField="type" HeaderText="题目类型" />--%>
                <asp:BoundField DataField="content" HeaderText="题目" />
                <asp:BoundField DataField="level" HeaderText="难易度" />
                <asp:BoundField DataField="value" HeaderText="分值" />
                <asp:BoundField DataField="answer" HeaderText="答案" />
                <asp:BoundField DataField="correctanswer" HeaderText="正确答案" />
                <asp:CommandField HeaderText="操作" ShowEditButton="True" ShowDeleteButton="True" EditText="" />

            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />

             <PagerTemplate>
                <table>
                    <tr><td>
                        第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex+1 %>"></asp:Label>页
                        共<asp:Label ID="lblPageCount" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>页
                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="false" CommandArgument="First" CommandName="Page">首页</asp:LinkButton>
                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="false" CommandArgument="Prev" CommandName="Page">上一页</asp:LinkButton>
                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="false" CommandArgument="Next" CommandName="Page">下一页</asp:LinkButton>
                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="false" CommandArgument="Last" CommandName="Page">尾页</asp:LinkButton>
                        到<asp:DropDownList ID="listPageCount" runat="server" AutoPostBack="true" Width="50"></asp:DropDownList>
                        <%--<asp:LinkButton ID="btnGo" runat="server" CausesValidation="false" CommandName="Go">Go</asp:LinkButton></td>--%>
                    </tr>
                </table>
            </PagerTemplate>   
        </asp:GridView>

    <%--    <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>--%>


    </form>

</div>






</body>
</html>
