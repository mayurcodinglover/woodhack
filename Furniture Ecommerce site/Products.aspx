<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Furniture_Ecommerce_site.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <h3>All product</h3>


    <div class="row" Style="padding-top:50px">

        <asp:Repeater ID="rptrProducts" runat="server">
            
            <ItemTemplate>
                
        <div class="col-sm-3 col-md-3" style="height:300px; width:300px;">
            <a href="ProductView.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none">
            <div class="thumbnail">
                <img src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval ("Extention") %>" alt="<%# Eval ("ImageName") %>" style="height:200px; width:200px;"/>
                <div class="caption">
                    <div class="probrand"><%# Eval("BrandName") %></div>
                    <div class="proName"><%# Eval("PName") %></div>
                    <div class="proprice"><span class="proOgprice"><%# Eval("PPrice","{00:0,0}") %></span><%# Eval("PSelPrice","{00:0,0}") %><span class="proPriceDiscount">(Rs. <%# Eval("DiscAmount","{00:0,0}") %> off)</span></div>

                </div>
            </div>
                </a>

        </div>

          </ItemTemplate>
                
       </asp:Repeater>
    </div>
</asp:Content>
