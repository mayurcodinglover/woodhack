<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Recover Password.aspx.cs" Inherits="Furniture_Ecommerce_site.Recover_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Reset Your Password Recovery
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <div class="container">
            <div class="form-horizontal">
                <br />
                <br />
                <br />

                <h2>Reset Password</h2>
                <hr />
                <h3></h3>
                <div class="form-group">
                    <asp:Label ID="lblmsg" runat="server" CssClass="col-md-2 control-label" Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>

                </div>
                <div class="form-group">
                    <asp:Label ID="lblNewPassword" runat="server" CssClass="col-md-2 control-label" Text="Your New Password" Visible="False"></asp:Label>
                    <div class="col-md-3">
                    <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPass" CssClass="test alert-danger" runat="server" ErrorMessage="Enter Your New password...." ControlToValidate="txtNewPass" ForeColor="Red"></asp:RequiredFieldValidator>


                    </div>
                </div>
                 <div class="form-group">
                    <asp:Label ID="lblConfirmPass" runat="server" CssClass="col-md-2 control-label" Text="Confirm New Password" Visible="False"></asp:Label>
                    <div class="col-md-3">
                    <asp:TextBox ID="txtConfirmPass" TextMode="Password" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPass" CssClass="test alert-danger" runat="server" ErrorMessage="Confirm Your New password...." ControlToValidate="txtConfirmPass" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorPass" runat="server" ErrorMessage="Confirm password not match... Try again" ControlToCompare="txtNewPass" ForeColor="Red" ControlToValidate="txtConfirmPass"></asp:CompareValidator>
                        
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">

                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnResetPass" CssClass="btn btn-default" runat="server" Text="Reset" Visible="False" OnClick="btnResetPass_Click"  />

                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
