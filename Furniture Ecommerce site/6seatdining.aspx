<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="6seatdining.aspx.cs" Inherits="Furniture_Ecommerce_site._6seatdining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>6 Seater Dining Table</h3>


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
                    <div class="proprice"><span class="proOgprice"><%# Eval("PPrice") %></span><%# Eval("PSelPrice") %><span class="proPriceDiscount">(<%# Eval("DiscAmount") %> off)</span></div>

                </div>
            </div>
                </a>

        </div>

          </ItemTemplate>
       </asp:Repeater>
    </div>
</asp:Content>
