<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Furniture_Ecommerce_site.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta / charset="utf-8">
    <meta name="viewport" content="width-device-width,initial-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="chrome"/>
    <link href="css/Custom.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <div>
            <div class="navbar navbar-default navbar-fixed-top"role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button class="navbar-toggle"type="button"data-toggle="collapse"data-target=".navbar-collapse">
                            <span class="sr-only">Toggle Navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>


                        </button>
                        <a class="navbar-brand" href="WebForm1.aspx"><span><img  src="images/logo.png" alt="Logo" height="30px"/></span>WoodHack</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <a href="Home.aspx">Home</a>
                            </li>
                            <li>
                                <a href="#">About</a>
                            </li>
                            <li>
                                <a href="#">Contact</a>
                            </li>
                            <li>
                                <a href="#">Blog</a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                            </li>
                            

                        </ul>

                    </div>
                </div>
            </div>
                <br />
                
                <br />
        </div>
        <div class="container">
            <div class="form-horizontal">
                <h2>Recover Password</h2>
                <hr />
                <h3>Please Enter Your Email Address, we will send you the recovery link for your passoword!</h3>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" CssClass="col-md-2 control-label" Text="Your  Email Address"></asp:Label>
                    <div class="col-md-3">
                    <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClass="test alert-danger" runat="server" ErrorMessage="Enter Your Email...." ControlToValidate="txtEmailID" ForeColor="Red"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">

                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnResetPass" CssClass="btn btn-default" runat="server" Text="Send" OnClick="btnResetPass_Click" />
                        <asp:Label ID="lblResetPassMsg" CssClass="text-success" runat="server"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
         
    </form>
    <footer>
            <div class="container">
                <p class="pull-right"><a href="#">Back to Top</a></p>
                <p>&copy;2022Woodhack.in &middot;<a href="WebForm1.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
            </div>
                </footer>
</body>
</html>
