<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="manageusers.aspx.cs" Inherits="Furniture_Ecommerce_site.manageusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br /><br /><br /><br /><br />



    <asp:Label ID="Label1" runat="server" Text="User Type"></asp:Label>
    <asp:HiddenField ID="hdnuserID" runat="server" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator visible="false" ID="RequiredFieldValidatorUtype" runat="server" ErrorMessage="Please Enter User Type...." ControlToValidate="TextBox1" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:Button CssClass="btn btn-success" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />




    <h1>Manage Users</h1>
         <div class="panel panel-default">
             <!--<div class="panel-heading">All Collections</div>-->

             <asp:Repeater ID="rptrUsers" runat="server" OnItemCommand="rptrUsers_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>UserName</th>
                         <th>User Type</th>
                          <td>
                             
                              Action
                         </td>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("Uid") %></th>
                         <td><%#Eval("Username") %></td>
                         <td><%#Eval("UserType") %></td>
                         <td><asp:LinkButton ID="lnkEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Uid") %>' runat="server">Edit</asp:LinkButton>
                             &nbsp;&nbsp;&nbsp;
                             </td>
                     </tr>
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>  
         </div>
</asp:Content>
