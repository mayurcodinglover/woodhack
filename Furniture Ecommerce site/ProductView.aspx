<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="Furniture_Ecommerce_site.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div style="padding-top:50px">
        <div class="col-md-5">
            <div style="max-width:480px" class="thumbnail">
                <!--For Proimage slider starting -->
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
    <li data-target="#carousel-example-generic" data-slide-to="3"></li>
    <li data-target="#carousel-example-generic" data-slide-to="4"></li>

  </ol>
                    
  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
      <asp:Repeater ID="rptrImage" runat="server">
          <ItemTemplate>
    <div class="item <%# GetActiveImgClass(Container.ItemIndex) %>">
      <img src="images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval ("Extention") %>" alt="<%# Eval("Name") %>"onerror="this.src='images/noimage.jpg'">
      
    </div>
              </ItemTemplate>
    </asp:Repeater>
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
                <!--For proimage slider ending-->
                
            </div>
        </div>
        
        <div class="col-md-5">
            <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound">
                <ItemTemplate>
            <div class="divDel1">
                <h1 class="proNameView"><%# Eval("PName") %></h1>
                <span class="proOgpriceView">Rs. <%# Eval("PPrice","{0:00,0}")%></span>
                <span class="proPriceDiscount">Rs. <%# string.Format("{0}",Convert.ToInt64(Eval("PPrice"))-Convert.ToInt64(Eval("PSelPrice"))) %> off</span>
                <p class="propriceView">RS.&nbsp;<%# string.Format("{0}",Convert.ToInt64(Eval("PSelPrice"))) %></p>
            </div>
            <div>
                    <b><h5 class="">Sub - Category</h5></b>
                <div>
                    <b><asp:Label ID="lblsize" runat="server"></asp:Label></b>
                </div>
            </div> 

            <div class="divDel1">
                <asp:Button ID="btnAddtoCart" runat="server" Text="Add To Cart" CssClass="mainButton" onclick="btnAddtoCart_Click"/>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            </div>
           
                    <div class="divDel1">
                        <h5 class="">Description</h5>
                        <p><%#Eval("PDescription") %></p>
                    </div>
                    <div class="divDel1">
                        <h5 class="">Details</h5>
                        <p><%#Eval("PDetails") %></p>
                    </div>
                    <div class="divDel1">
                        <h5 class="">Material & Care</h5>
                        <p><%#Eval("PMaterial") %></p>
                    </div>
            <div>
                <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":"" %></p>
                <p><%# ((int)Eval("COD")==1)? "Cash on Delivery":"" %></p>

            </div>
                    <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("Pcategoryid") %>'/>
                    <asp:HiddenField ID="hfSubCatID" runat="server" Value='<%# Eval("PSubCategoryid") %>'/>
                    <asp:HiddenField ID="hfBrandID" runat="server" Value='<%# Eval("PBrandid") %>'/>

                </ItemTemplate>
            </asp:Repeater>
            

        </div>
    </div>
</asp:Content>
