<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProfitReport.aspx.cs" Inherits="Furniture_Ecommerce_site.ProfitReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br />
    <h1>Revenue Report</h1>
         <div class="panel panel-default">
             <div class="panel-heading">Revenue Report</div>

             <asp:Repeater ID="rptrprofitreport" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>Product ID</th>
                         <th>Product Name</th>
                          <th>Product Price</th>
                         <th>Sold Quantity</th>
                         <th>Profit</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("pid") %></th>
                         <td><%#Eval("PName") %></td>
                          <td><%#Eval("PSelPrice") %></td>
                          <td><%#Eval("qty") %></td>
                          <td><%#Eval("Profit","{00:0,0}") %></td>
                     </tr>
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>  
         </div>

</asp:Content>
