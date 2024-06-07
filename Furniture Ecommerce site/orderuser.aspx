<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="orderuser.aspx.cs" Inherits="Furniture_Ecommerce_site.orderuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br /><br /><br /><br />
    <!--<asp:Button ID="Button1" runat="server" Text="CheckOrderstatus" OnClick="Button1_Click"/>-->

    

    <h1>Orders</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Orders</div>

             <asp:Repeater ID="rptrstatus" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>Oid</th>
                         <th>Order Status</th>
                         <th>Product</th>
                         <th>Product Name</th>
                         <th>Product price</th>
                         
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <td><%#Eval("OrderID") %></td>
                         <td><%#Eval("OrderStatus") %></td>
                         <td><img src="images/ProductImages/<%# Eval("PID") %>/<%#Eval("proimg") %>" class="imguserorder"/></td>
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
