<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Furniture_Ecommerce_site.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />

    <div style="padding-top:50px">
        <div class="col-md-9">
            <h4 class="proNameViewCart" runat="server" id="h4Noitems"></h4>
            <asp:Repeater ID="rptrCartProducts" runat="server">
                <ItemTemplate>
            <%--show cart detail start --%>
            <div class="media" style= "border:1px solid black;">
                <div class="media-left">
                    <a href="ProductView.aspx?PID=<%# Eval("PID") %>" target="_blank">
                        <img class="media-object" src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval ("Extention") %>" alt="<%# Eval("Name") %>" width="100px"onerror="this.src='images/noimage.jpg'"/>
                    </a>
                </div>
                <div class="media-body">
                    <h4 class="media-heading proNameViewCart"><%# Eval("PName") %> </h4>
                    <p class="proPriceDiscountView"><%# Eval("SizeNamee") %></p>
                    <span class="propriceView"><%# Eval("PSelPrice","{0:c}") %></span>
                    <span class="proOgpriceView"><%# Eval("PPrice","{0:00,0}") %></span>
                    <span>Product Size: <%# Eval("PID") %>-<%# Eval("SizeIDD") %></span>
                    <p>
                        <asp:Button ID="btnRemoveCart" CommandArgument='<%# Eval("PID").ToString() + "-" + Eval("SizeIDD").ToString() %>' runat="server" Text="Remove" CssClass="RemoveButton" OnClick="btnRemoveCart_Click" />
                    </p>    
                </div>
            </div>
                    </ItemTemplate>
            </asp:Repeater>
            <%--show cart detail end --%>

        </div>
        <div class="col-md-3" runat="server" id="divAmountSect">
           <div>
            <%-----------------------%>
            <h5>Price Details</h5>
            <div>
                <label>Cart Total</label>
                <span class="pull-right priceGray" runat="server" id="spanCartTotal">0</span>
            </div>
            <div>
                <label>Cart Discount</label>
                <span class="pull-right priceGreen" id="spanDiscount" runat="server">0</span>

            </div>
        </div>
            <%-----------------------%>
            <div>
                <div class="proPriceView">
                <label>Cart Total</label>
                <span class="pull-right" runat="server" id="spanTotal">0</span>
                    <div>
                        <asp:Button ID="btnBuyNow" CssClass="buyNowbtn" runat="server" OnClick="btnBuyNow_Click" Text="BUY NOW" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
