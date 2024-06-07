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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="It is mandatory!" ControlToValidate="txtUname" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="It is mandatory!" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <label class="col-xs-11">Confirm password</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtCpass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password did not match the above password!" ControlToCompare="txtPass" ControlToValidate="txtCpass" ForeColor="Red"></asp:CompareValidator>
            </div>

            <label class="col-xs-11">Your Full Name</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="It is mandatory!" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>            
            </div>

            <label class="col-xs-11">Address</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtAddress" runat="server" Class="form-control" placeholder="Enter Your Address"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="It is mandatory!" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <label class="col-xs-11">Zip Code</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtZip" runat="server" Class="form-control" placeholder="Enter Your Zip/Postal Code"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid zipcode!" ControlToValidate="txtZip" ValidationExpression="\d{6}" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>

            <label class="col-xs-11">Email</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid email id!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
<label class="col-xs-11">MobileNo</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtmono" runat="server" Class="form-control" placeholder="Enter Your Mobile no"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter valid mobile no!" ControlToValidate="txtmono" ValidationExpression="\d{10}" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>

            <label class="col-xs-11">Profile Pic</label>
            <div class="col-xs-11">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="It is mandatory!" ForeColor="Red" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
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
