<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="House sshopping.aspx.cs" Inherits="Furniture_Ecommerce_site.WebForm3" %>
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
                    
  <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="images/1.jpeg" alt="First slide">
    </div>
    <div class="item">
      <img src="images/1.jpeg" alt="Second slide">
    </div>
    <div class="item">
      <img src="images/1.jpeg" alt="Third slide">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
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
            
            <div class="divDel1">
                <h1 class="proNameView">Name</h1>
                <span class="proOgpriceView">RS .1000</span><span class="proOgpriceView">200</span><p class="propriceView">RS .800</p>
            </div>
            <div>
                    <h5 class="">Size</h5>
                <div>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                        <asp:ListItem>1 Seater</asp:ListItem>
                        <asp:ListItem>2 Seater</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div> 
            <div class="divDel1">
                <asp:Button ID="btnAddtoCart" runat="server" Text="Add To Cart" CssClass="mainButton" OnClick="btnAddtoCart_Click"/>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            </div>
            <div class="divDel1">
                    <h5 class="h5size">Description</h5>
                <p>THis is the description</p>
                <h5 class="h5size">Product Details</h5>
                <p>This is product details</p>
                    <h5 class="h5size">mat &care </h5>
                <p>This is mat and care :</p>

            </div>
            <div>
                <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":"" %></p>
                <p><%# ((int)Eval("Return30day")==1)? "30 Day Return":"" %></p>
                <p><%# ((int)Eval("COD")==1)? "Cash on Delivery":"" %></p>

            </div>
                    <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("Pcategoryid") %>'/>
                    <asp:HiddenField ID="hfSubCatID" runat="server" Value='<%# Eval("PSubCategoryid") %>'/>
                    <asp:HiddenField ID="hfBrandID" runat="server" Value='<%# Eval("PBrandid") %>'/>
              

        </div>
        
    </div>

</asp:Content>
