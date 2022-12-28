<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="Furniture_Ecommerce_site.Sign_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div>
        <!--sign in page start-->
        <div class="container">
            <div class="form-horizontal">
                <h2>Login Form</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Username"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="Please Enter User Name...." ControlToValidate="txtUsername" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtpass" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ErrorMessage="Please Enter valid password...." ControlToValidate="txtpass" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label3" CssClass=" control-label" runat="server" Text="Remember me"></asp:Label>

                    </div>
                </div>
                 <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnLogin" CssClass ="btn btn-success" runat="server" Text="Login &raquo;" OnClick="btnLogin_Click" />
                       <asp:HyperLink ID="HySignupred" runat="server" NavigateUrl="~/Signup.aspx">Sign Up</asp:HyperLink>

                        <br />
                        <asp:HyperLink ID="HyForgotPass" runat="server" NavigateUrl="~/ForgotPassword.aspx">Forgot Password</asp:HyperLink>

                    </div>
                </div>
                 <!--Forgot password-->
                 <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                       
                    </div>
                </div>
                
                
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                       
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>

            </div>
        </div>
        <!--sign in page end-->
    </div>
</asp:Content>
