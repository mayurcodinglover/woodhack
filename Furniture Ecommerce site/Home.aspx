<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Furniture_Ecommerce_site.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <!--Image slider-->
            <div class="container">
  <h2>Carousel Example</h2>  
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
        <img src="Image slider/pr1.jpg" alt="Los Angeles" style="width:100%;height:500px;">
          <div class="carousel-caption">
        <h3>House shopping</h3>
        <p>20% Off</p>
        <p><a class="btn btn-lg btn-primary" href="#" role="button">Buy Now</a></p>
      </div>
      </div>

      <div class="item">
        <img src="Image slider/pr2.jpg" alt="Chicago" style="width:100%;height:500px;">
          <div class="carousel-caption">
        <h3>Furniture Design</h3>
        <p>30% Off</p>
        <p><a class="btn btn-lg btn-primary" href="#" role="button">Buy Now</a></p>

      </div>
      </div>
    
      <div class="item">
        <img src="Image slider/pr3.jpg" alt="New york" style="width:100%;height:500px;">
          <div class="carousel-caption">
        <h3>Shop in best Price</h3>
        <p>40% Off</p>
        <p><a class="btn btn-lg btn-primary" href="#" role="button">Buy Now</a></p>

      </div>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>
            <!--Image slider End-->
</div>
        <hr />
        <!--Middle content Start-->
        <div class="container center" >
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="card image/chair.jpg" alt="furniture image" width="140px" height="140px"/>
                    <h2>Furniture</h2>
                    <p>details of furniture
                        a seat, especially for one person, usually having four legs for support and a rest for the back and often having rests for the arms.
                    </p>
                    <p><a class="btn btn default" href="#" role="button">View More &raquo;</a></p>

                </div>
                 <div class="col-lg-4">
                    <img class="img-circle" src="card image/Table1.jpg" alt="furniture image" width="140px" height="140px"/>
                    <h2>Furniture</h2>
                    <p>details of furniture
                       A table is an item of furniture with a raised flat top and is supported most commonly by 1 or 4 legs (although some can have more), used as a surface for working at, eating from or on which to place things.
                    </p>
                    <p><a class="btn btn default" href="#" role="button">View More &raquo;</a></p>

                </div>
                 <div class="col-lg-4">
                    <img class="img-circle" src="card image/Table2.jpg" alt="furniture image" width="140px" height="140px"/>
                    <h2>Furniture</h2>
                    <p>details of furniture
                        A table is an item of furniture with a raised flat top and is supported most commonly by 1 or 4 legs (although some can have more), used as a surface for working at, eating from or on which to place things.
                    </p>
                    <p><a class="btn btn default" href="#" role="button">View More &raquo;</a></p>

                </div>

            </div>

        </div>
        <!--Middle content End-->
    </div>
</asp:Content>
