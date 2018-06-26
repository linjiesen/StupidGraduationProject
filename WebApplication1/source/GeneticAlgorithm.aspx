<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneticAlgorithm.aspx.cs" Inherits="WebApplication1.source.GeneticAlgorithm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" />  
	<script src="https://cdn.bootcss.com/jquery/2.1.1/jquery.min.js"></script>
	<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
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

    <div class="card">
    <form id="form1" runat="server">
        <div class="card-title">
           <asp:Button ID="Button1" runat="server" Text="生成试卷" OnClick="Button1_Click"  CssClass="btn btn-info coll-,d-4"/>
        </div>
        <div class="card-text">
            <asp:TextBox ID="TextBox1" runat="server"  TextMode="MultiLine" Height="142px" Width="257px" Visible="False"    ></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"   TextMode="MultiLine" Height="95px" Width="258px" Visible="False"   ></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"    TextMode="MultiLine"  class="form-control" Height="100px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server"    TextMode="MultiLine"     Height="119px" Width="212px" OnTextChanged="TextBox4_TextChanged" Visible="False"></asp:TextBox>
        </div>
        <div class="panel">
            <asp:TextBox ID="test_output" runat="server" TextMode="MultiLine" class="form-control" Height="300px"></asp:TextBox>
        </div>
        <div class="panel" >
            <asp:TextBox ID="correct_answer" runat="server"  TextMode="MultiLine" class="form-control" Height="200px"></asp:TextBox>
        </div>
    </form>
    </div>  

    </div>
</div>



   <%-- <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>--%>




</body>
</html>
