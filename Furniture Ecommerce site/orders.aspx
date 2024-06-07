<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="Furniture_Ecommerce_site.orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /> 
    <h1>Manage Orders</h1>
    <!--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>-->
         
             <!--<div class="panel-heading">All Orders</div>-->
             <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Pending</asp:LinkButton><br />
     <asp:DropDownList ID="ddlorderpenid" runat="server" OnSelectedIndexChanged="ddlorderpenid_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <asp:DropDownList ID="ddlorderpenchange" runat="server" AutoPostBack="true">
        <asp:ListItem>process</asp:ListItem>
       <%--<asp:ListItem>Delivered</asp:ListItem>
        <asp:ListItem>reject</asp:ListItem>--%>
     </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass ="btn btn-success" OnClick="Button1_Click"/>
    <div class="panel panel-default">
        <div class="panel-heading">All Pending Orders</div>
    <asp:Repeater ID="rptrOrders" runat="server">
                <HeaderTemplate>
                    
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Orders</th>
                          <td>
                             
                              Status
                         </td>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("OrderID") %></th>
                         <td><%#Eval("PurId") %></td>
                         <td><%#Eval("OrderStatus") %></td> 
                          
                     </tr>
                     
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>
        </div>
   

             <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Process</asp:LinkButton><br />
    <%--<asp:DropDownList ID="ddlorderprocid" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlorderprocid_SelectedIndexChanged"></asp:DropDownList>--%>
    <asp:DropDownList ID="ddlorderprocid" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlorderprocid_SelectedIndexChanged"></asp:DropDownList>
    <asp:DropDownList ID="ddlorderprocchange" runat="server" AutoPostBack="true">
        <asp:ListItem>Delivered</asp:ListItem>

     </asp:DropDownList>
    <asp:Button ID="Button2" runat="server" Text="Submit" CssClass ="btn btn-success" OnClick="Button2_Click"/>
     <div class="panel panel-default">
        <div class="panel-heading">All Process Orders</div>
     <asp:Repeater ID="rptrOrders2" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Orders</th>
                          <td>
                             
                              Status
                         </td>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("OrderID") %></th>
                         <td><%#Eval("PurId") %></td>
                         <td><%#Eval("OrderStatus") %></td> 
                         
                     </tr>
                     
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>
         </div>
    
             <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Delivered</asp:LinkButton><br />
     <div class="panel panel-default">
        <div class="panel-heading">All Delivered Orders</div>
    <asp:Repeater ID="rptrOrders3" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Orders</th>
                          <td>
                             
                              Status
                         </td>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("OrderID") %></th>
                         <td><%#Eval("PurId") %></td>
                         <td><%#Eval("OrderStatus") %></td> 
                         
                     </tr>
                     
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>
         </div>

             <!--<asp:LinkButton ID="LinkButton4" runat="server">Reject</asp:LinkButton><br />
            
             
             <div class="panel panel-default">
        <div class="panel-heading">All Rejected Orders</div>
             
             <asp:Repeater ID="rptrOrders4" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Orders</th>
                          <td>
                             
                              Action
                         </td>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("OrderID") %></th>
                         <td><%#Eval("PurId") %></td>
                         <td><%#Eval("OrderStatus") %></td> 
                          
                     </tr>
                     
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>
             </div>-->
        
    
    <%--<asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click"/>--%>
    
    <br /><br />
</asp:Content>