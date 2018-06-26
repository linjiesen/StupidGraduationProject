<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="import.aspx.cs" Inherits="WebApplication1.source.import" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导入试题</title>
    <style type="text/css">
        #Text1 {
            height: 58px;
            width: 214px;
        }
    </style>
         
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" />  
	<script src="https://cdn.bootcss.com/jquery/2.1.1/jquery.min.js"></script>
	<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body style="height: 148px">
    <nav class="navbar navbar-expand-md " style="background-color:blanchedalmond">
        <div class="container">
            <a class="navbar-brand" href="home.aspx">
                    自动组卷系统
            </a> 
        </div>
    </nav>
    <div class="container">
           <div class="panel panel-primary col-md-2" style="float:right;">
                <table class="table text-center table-hover" style="margin:0px;">
                    <tr >
                        <td>
                            <a href="GeneticAlgorithm.aspx" >
                                自动组卷
                            </a>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <a href="import.aspx" >
                                导入题库
                            </a>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <a href="testoutput.aspx" >
                                查看题库
                            </a>
                        </td>
                    </tr>
                </table>
            </div>
        <!-- 这里添加页面的显示代码-->
        <div class="col-md-10">
        <form id="form1" runat="server" role="form">
             <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="题目内容" CssClass="col-md-3 control-label"></asp:Label>
                <asp:TextBox ID="TextBox_content" runat="server"   TextMode="MultiLine"   CssClass="form-control col-md-8"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="题目难易度"  CssClass="col-md-3"></asp:Label>
                <asp:DropDownList ID="DropDownList_level" runat="server"   CssClass="form-control col-md-4">
                    <asp:ListItem Value="1">简单</asp:ListItem>
                    <asp:ListItem Value="2">中等</asp:ListItem>
                    <asp:ListItem Value="3">困难</asp:ListItem>
                </asp:DropDownList>
            </div>
    
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="分值" CssClass="col-md-3"></asp:Label>
                <asp:TextBox ID="TextBox_value" runat="server"  CssClass="form-control col-md-4"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="题目类型"  CssClass="col-md-3"></asp:Label>
                <asp:DropDownList ID="DropDownList_type" runat="server"  CssClass="form-control col-md-4">
                    <asp:ListItem Value="0">选择题</asp:ListItem>
                    <asp:ListItem Value="1">填空题</asp:ListItem>
                    <asp:ListItem Value="2">综合题</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="答案"  CssClass="col-md-3"></asp:Label>
                <asp:TextBox ID="TextBox_answer" runat="server" Height="107px"  TextMode="MultiLine"  CssClass="form-control col-md-9"  ></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="正确答案" CssClass="col-md-4"></asp:Label>
                <asp:TextBox ID="TextBox_correctanswer" runat="server"   TextMode="MultiLine"   CssClass="form-control col-md-9"></asp:TextBox>
            </div>
            <div class="form-group ">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="取消"  CssClass="btn  btn-danger col-md-4" />
                <asp:Button ID="Button2" runat="server" Text="确定" OnClick="Button2_Click" CssClass="btn btn-info col-md-4" />
            </div>
       </form>
    </div>
</div>



    




 <%--   <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>--%>



</body>
</html>
