<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="customerreport.aspx.cs" Inherits="Furniture_Ecommerce_site.customerreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
        <h2>Customer Reports</h2>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:Button CssClass="btn btn-success" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
     <div class="panel panel-default">
        <div class="panel-heading">All Rejected Orders</div>
             
             <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Orders</th>
                          <td>
                             
                              Price
                         </td>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("UserID") %></th>
                         <td><%#Eval("PName") %></td>
                         <td><%#Eval("PSelPrice") %></td> 
                          
                     </tr>
                     
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>
             </div>
</asp:Content>
