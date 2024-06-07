<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Furniture_Ecommerce_site.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <!--Image slider-->
            <div class="container">
  <h2>`</h2>  
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
        <p><a class="btn btn-lg btn-primary" href="Products.aspx" role="button">Buy Now</a></p>
      </div>
      </div>

      <div class="item">
        <img src="Image slider/pr2.jpg" alt="Chicago" style="width:100%;height:500px;">
          <div class="carousel-caption">
        <h3>Furniture Design</h3>
        <p><a class="btn btn-lg btn-primary" href="Products.aspx" role="button">Buy Now</a></p>

      </div>
      </div>
    
      <div class="item">
        <img src="Image slider/pr3.jpg" alt="New york" style="width:100%;height:500px;">
          <div class="carousel-caption">
        <h3>Shop in best Price</h3>
        <p><a class="btn btn-lg btn-primary" href="Products.aspx" role="button">Buy Now</a></p>

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
     <div class="container center">
            <br /><br />
            <h2>Categories</h2>
            <br/>
            <div class="row">
                <div class="col-lg-4">
                    <a href="Sofa.aspx"><img class="img-circle" src="sofa/sofa1.png" alt="Sofa" height="140" width="140"/></a>
                    <a href="Sofa.aspx"><h2>Sofa</h2></a>
                </div>

                <div class="col-lg-4">
                    <a href="Table.aspx"><img class="img-circle" src="Table/table1.png" alt="Table" height="140" width="140"/></a>
                    <a href="Table.aspx"><h2>Tables</h2></a>
                </div>

                <div class="col-lg-4">
                    <a href="DressingTable.aspx"><img class="img-circle" src="DressingTable/dressingtable.jpg" alt="Dressing Tables" height="140" width="140"/></a>
                    <a href="DressingTable.aspx"><h2>Dressing Tables</h2></a>  
                </div>
                <br /><br />
                <div class="col-lg-4">
                    <a href="StudyTable.aspx"><img class="img-circle" src="StudyTable/studytable.jpg" alt="Study Table" height="140" width="140"/></a>
                    <a href="StudyTable.aspx"><h2>Study Table</h2></a> 
                </div>

                <div class="col-lg-4">
                    <a href="DiningTable.aspx"><img class="img-circle" src="DiningTable/diningTable.jpg" alt="Dining Table" height="140" width="140"/></a>
                    <a href="DiningTable.aspx"><h2>Dining Table</h2></a>  
                </div>

                <div class="col-lg-4">
                    <a href="Bed.aspx"><img class="img-circle" src="bed/bed1.png" alt="Bed" height="140" width="140"/></a>
                    <a href="Bed.aspx"><h2>Beds</h2></a>
                </div>
                <br /><br />

                <div class="col-lg-4">
                    <a href="Mattresses.aspx"><img class="img-circle" src="Mattress/mattress.jpg" alt="Mattresses" height="140" width="140"/></a>
                    <a href="Mattresses.aspx"><h2>Mattresses</h2></a> 
                </div>

                <div class="col-lg-4">
                    <a href="Chair.aspx"><img class="img-circle" src="Chairs/chair.jpg" alt="Chairs" height="140" width="140"/></a>
                    <a href="Chair.aspx"><h2>Chairs</h2></a>  
                </div>

                <div class="col-lg-4">
                    <a href="OfficeChair.aspx"><img class="img-circle" src="Office Chairs/officechair.jpg" alt="Office Chair" height="140" width="140"/></a>
                    <a href="OfficeChair.aspx"><h2>Office Chairs</h2></a> 
                </div>
                <br /><br />

                <div class="col-lg-4">
                    <a href="Recliner.aspx"><img class="img-circle" src="recliner/rec1.png" alt="Recliners" height="140" width="140"/></a>
                    <a href="Recliner.aspx"><h2>Recliners</h2></a>
                </div>

                <div class="col-lg-4">
                    <a href="Wardrobes.aspx"><img class="img-circle" src="Wardrobes/wardrobe.jpeg" alt="Wardrobes" height="140" width="140"/></a>
                    <a href="Wardrobes.aspx"><h2>Wardrobes</h2></a>  
                </div>

                <div class="col-lg-4">
                    <a href="BookShelve.aspx"><img class="img-circle" src="BookShelves/bookshelve.jpeg" alt="Book Shelves" height="140" width="140"/></a>
                    <a href="BookShelve.aspx"><h2>Book Shelves</h2></a>  
                </div>
                <br /><br />

                <div class="col-lg-4">
                    <a href="Ottoman.aspx"><img class="img-circle" src="Ottoman/ottoman.png" alt="Cupboards" height="140" width="140"/></a>
                    <a href="Ottoman.aspx"><h2>Ottoman</h2></a> 
                </div>
                <div class="col-lg-4">
                    <a href="TVUnit.aspx"><img class="img-circle" src="tvunit/tvunit.jpeg" alt="T V Units" height="140" width="140"/></a>
                    <a href="TVUnit.aspx"><h2>T.V. Units</h2></a>  
                </div>

                <div class="col-lg-4">
                    <a href="ShoeRack.aspx"><img class="img-circle" src="ShoeRack/shoerack.jpeg" alt="Shoe Rack" height="140" width="140"/></a>
                    <a href="ShoeRack.aspx"><h2>Shoe Rack</h2></a>  
                </div>

            </div>
        </div>
        <!--Middle content End-->

</asp:Content>
