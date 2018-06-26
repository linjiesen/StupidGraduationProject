<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.source.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Login!</title>

        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>

    
        <!-- CSS -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="assets/css/form-elements.css"/>
        <link rel="stylesheet" href="assets/css/style.css"/>

    
        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

      <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assets/ico/favicon.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png"/>


</head>
<body>
     <!-- Top content -->
        <div class="top-content">
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong> 欢迎使用自动组卷系统 </strong>   </h1>
                            <div class="description">
                            	<p>
	                            	This is a automatic test paper system! 
                            	</p>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>Login to our site</h3>
                            		<p>  输入您的用户名和密码：</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-lock"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
                                <form id="form1" role="form"  method="post"  class="login-form" runat="server" >
                                    <div class="form-group">
                                        <p><asp:Label ID="lbusername" runat="server"> </asp:Label>
                                            <asp:TextBox ID="tbusername" placeholder="Username..." class="form-username form-control" runat="server" ></asp:TextBox>

                                        </p>

                                    </div>
                                    <div class="form-group">
                                        <p> <asp:Label ID="lbpsw" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbpsw" runat="server" type="password"   placeholder="Password..." class="form-password form-control"></asp:TextBox>
                                        </p>

                                    </div>              
                                
                                    <asp:Button ID="BtnLogin_Click" runat="server" Text="Sign in!"    onclick="btnLogin_Click" BackColor="#DE615E" ForeColor="White" Height="53px" Width="250px"   />

                                    <asp:Button ID="BtnRegister_Click" runat="server" Height="53px" BackColor="#DE615E" ForeColor="White"  Width="250px" Text="Register!" OnClick="BtnRegister_Click_Click" />
                                
                                </form>
                           </div>
                        </div>
                    </div>
                </div>
             </div>
          </div>
        <%--</div>--%>
     <!-- Javascript -->
        <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->
</body>
</html>
