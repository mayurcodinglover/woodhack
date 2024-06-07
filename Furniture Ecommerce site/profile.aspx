<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Furniture_Ecommerce_site.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <br />
    <br />
    <div align="center">
        <!--<img id="ProfilePic" class="img-circle" src="" alt="profile_pic" width="140px" height="140px" onerror="this.src='userprofile/userpic.png'" />-->
        <asp:Image ID="Image1" class="img-circle" runat="server" ImageUrl='<%# Eval("PPic")%>' alt="profile_pic" width="170px" height="170px"/>
    </div>
    <div align="center">
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
    <br /><br />
    <div>

        <table align="center">
            <tr>
                <td><b>Username :</b></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbluname" runat="server" Text=""></asp:Label>
                    <div><%# Eval("Username") %></div>
                </td>
            </tr>
            <tr>
                <td><b>Name :</b></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                    <div><%# Eval("Name") %></div>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Please Enter Name...." ControlToValidate="txtname" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><b>Email :</b></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                    <div><%# Eval("Email") %></div>
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Please Enter Email...." ControlToValidate="txtemail" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidatorEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><b>Mobile :</b></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblmobile" runat="server" Text=""></asp:Label>
                    <div><%# Eval("Mobile") %></div>
                    <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatormobileno" runat="server" ErrorMessage="Please Enter Mobile no...." ControlToValidate="txtmobile" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatormono" runat="server" ErrorMessage="Please Enter valid mono" ControlToValidate="txtmobile" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><b>Address :</b></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    <div><%# Eval("Address") %></div>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Address..." ControlToValidate="txtAddress" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><b>Zip Code :</b></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblZip" runat="server" Text=""></asp:Label>
                    <div><%# Eval("Zipcode") %></div>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Zipcode" ControlToValidate="txtZip" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>

    </div>
    <div align="center">
        <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass ="btn btn-success" OnClick="btnedit_Click"/>
        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass ="btn btn-success" OnClick="btnupdate_Click"/>
    </div>

</asp:Content>
