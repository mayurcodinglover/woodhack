using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Furniture_Ecommerce_site
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SubCategory.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddBrand.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("orders.aspx");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("manageusers.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("customerreport.aspx");
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("sales_report.aspx");
        }
    }
}