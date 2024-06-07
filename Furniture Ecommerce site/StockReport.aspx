<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="StockReport.aspx.cs" Inherits="Furniture_Ecommerce_site.StockReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <h1>Stock Report</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Stock Report</div>

             <asp:Repeater ID="rptrstockreport" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>Product ID</th>
                         <th>Product Name</th>
                          <th>Product Quantity</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("pid") %></th>
                         <td><%#Eval("PName") %></td>
                          <td><%#Eval("Quantity") %></td>
                     </tr>
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>  
         </div>

</asp:Content>
