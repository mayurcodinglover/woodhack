<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Furniture_Ecommerce_site.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <!--sign up page start-->
        <div class="center-page">
            <label class="col-xs-11">UserName</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
            </div>

            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Password"></asp:TextBox>
            </div>

            <label class="col-xs-11">Confirm password</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtCpass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm password"></asp:TextBox>
            </div>

            <label class="col-xs-11">Your Full Name</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
            </div>
            

            <label class="col-xs-11">Email</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
            </div>

            <label class="col-xs-11"></label>
            <div class="col-xs-11">
            <asp:Button ID="txtsignup" class="btn btn-success" runat="server" Text="SignUP" OnClick="txtsignup_Click" />
                <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
            </div>
        </div>


        <!--sign up page End-->
    </div>
</asp:Content>
