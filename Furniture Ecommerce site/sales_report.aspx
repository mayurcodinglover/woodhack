<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="sales_report.aspx.cs" Inherits="Furniture_Ecommerce_site.sales_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br /><br /><br />
    <div class="container">
        <div class="form-horizontal">
</div>
          </div>
     <h1>Sales Report</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Sales Report</div>

             <asp:Repeater ID="rptrsalesreport" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>Product ID</th>
                         <th>Product Name</th>
                          <th>Product price</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("pid") %></th>
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
