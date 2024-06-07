using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Drawing;

namespace Furniture_Ecommerce_site
{
    public partial class ProductView : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*btnAddtoCart.Visible = false;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select Quantity from ProdQuantity where Quantity='"+0+"'", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if(dt.Rows.Count>0)
                        {
                            btnAddtoCart.Visible = false;
                        }
                        else
                        {
                            btnAddtoCart.Visible = true;
                        }
                        
                    }
                }

            }*/


            if (Request.QueryString["PID"]!=null)
            {
                if (!IsPostBack)
                {
                    BindProductImage();
                    BindProductDetails();

                }
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }
        }

        private void BindProductDetails()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select *from Products where Pid='" + PID + "'", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrProductDetails.DataSource = dt;
                        rptrProductDetails.DataBind();
                    }
                }

            }
        }

        private void BindProductImage()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select *from ProductImages where Pid='" + PID+"'", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrImage.DataSource = dt;
                        rptrImage.DataBind();
                    }
                }

            }
        }
        protected string GetActiveImgClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
   
            if (e.Item.ItemType==ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                Label lblsize = e.Item.FindControl("lblsize") as Label;
                //RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("select *from SubCategory where SubCatid='" + SubCatID + "'", con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                           // rblSize.DataSource = dt;
                            //rblSize.DataTextField = "SubCatName";
                            //rblSize.DataValueField = "SubCatID";
                            //rblSize.DataBind();
                            if(dt.Rows.Count > 0)
                            {
                                lblsize.Text = Convert.ToString(dt.Rows[0]["SubCatName"]);
                            }
                        }
                    }

                }
            }
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                if (Session["USERID"] != null)
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    
                    using (SqlCommand cmd1 = new SqlCommand("select *from Cart where UserId='" + Session["USERID"] + "'and ProductID='" + PID + "'", con))
                    {
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                Session["pid"] = PID;
                                SqlCommand cmd = new SqlCommand("Insert into Cart(UserId,ProductID) Values('" + Session["USERID"] + "','" + PID + "')", con);
                                cmd.ExecuteNonQuery();
                            }
                            
                        }
                    }

                    
                    
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
                string SelectedSize = string.Empty;
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var hfSubCatID = item.FindControl("hfSubCatID") as HiddenField;
                    SelectedSize = hfSubCatID.Value;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }
            }

            if (SelectedSize != "")
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                if (Request.Cookies["CartPID"] != null)
                {
                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];

                    //Avoid duplicate product with size.
                    if (!string.IsNullOrWhiteSpace(CookiePID))
                    {
                        string[] products = CookiePID.Split(',');

                        if ((products?.Any() ?? false))
                        {
                            if (!products.Contains($"{PID}-{SelectedSize}"))
                            {
                                CookiePID = CookiePID + "," + PID + "-" + SelectedSize;
                                HttpCookie CartProducts = new HttpCookie("CartPID");
                                CartProducts.Values["CartPID"] = CookiePID;
                                CartProducts.Expires = DateTime.Now.AddDays(30);
                                Response.Cookies.Add(CartProducts);
                                
                            }
                        }
                    }
                }
                else
                {
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                }

                Response.Redirect("~/ProductView.aspx?PID=" + PID);

            }
            else
            {
                foreach (RepeaterItem item in rptrProductDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "Please select a size";
                    }
                }

            }

        }
    }
    
}