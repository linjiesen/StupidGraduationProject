<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.source.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>主页</title>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" />  
	<script src="https://cdn.bootcss.com/jquery/2.1.1/jquery.min.js"></script>
	<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>




</head>
<body >


<nav class="navbar navbar-expand-md " style="background-color:blanchedalmond; margin-bottom:0px;">
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



    </div>
</div>


</body>
</html>
