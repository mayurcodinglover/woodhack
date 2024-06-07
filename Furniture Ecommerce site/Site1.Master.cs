using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Furniture_Ecommerce_site
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            if (Session["Username"]!=null)
            {
                btnprofile.Visible = true;
                btnlogout.Visible = true;
                btnLogin.Visible = false;
            }
            else
            {
                btnprofile.Visible = false;
                btnlogout.Visible = false;
                btnLogin.Visible = true;

            }
        }
        public void BindCartNumber()
        {
            pCount.InnerText = 0.ToString();

            if (Session["UserID"] != null)
            {
                DataTable dtcartProducts = new DataTable();
                using (SqlConnection con = new SqlConnection(CS))
                {   
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select C.* from Cart C where C.UserId='" + Session["USERID"] + "'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtcartProducts);
                        }
                    }
                }

                if (dtcartProducts.Rows.Count > 0)
                {
                    pCount.InnerText = dtcartProducts.Rows.Count.ToString();
                }
            }
            else
            {
                if (Request.Cookies["CartPID"] != null)
                {
                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    string[] ProductArray = CookiePID.Split(',');
                    int ProductCount = ProductArray.Length;
                    pCount.InnerText = ProductCount.ToString();
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string search = txtsearch.Text.ToLower().ToString();
            if (search.ToString() == "sofa")
            {
                Response.Redirect("Sofa.aspx");
            }
            else if (search.ToString() == "3 seater sofa")
            {
                Response.Redirect("3seater.aspx");
            }
            else if (search.ToString() == "2 seater sofa")
            {
                Response.Redirect("2seater.aspx");
            }
            else if (search.ToString() == "1 seater sofa")
            {
                Response.Redirect("1seater.aspx");
            }
            else if (search.ToString() == "sofa set")
            {
                Response.Redirect("sofaset.aspx");
            }
            else if (search.ToString() == "recliner")
            {
                Response.Redirect("Recliner.aspx");
            }
            else if (search.ToString() == "3 Seater recliner")
            {
                Response.Redirect("3seatrecliner.aspx");
            }
            else if (search.ToString() == "2 Seater recliner")
            {
                Response.Redirect("2seatrecliner.aspx");
            }
            else if (search.ToString() == "1 Seater recliner")
            {
                Response.Redirect("1seatrecliner.aspx");
            }
            else if (search.ToString() == "bed")
            {
                Response.Redirect("Bed.aspx");
            }
            else if (search.ToString() == "king size bed")
            {
                Response.Redirect("kingsize.aspx");
            }
            else if (search.ToString() == "queen size bed")
            {
                Response.Redirect("queensize.aspx");
            }
            else if (search.ToString() == "single bed")
            {
                Response.Redirect("single.aspx");
            }
            else if (search.ToString() == "chair")
            {
                Response.Redirect("Chair.aspx");
            }

            else if (search.ToString() == "officechair" || search.ToString() == "office chair")
            {
                Response.Redirect("OfficeChair.aspx");
            }
            else if (search.ToString() == "dinningtable" || search.ToString() == "dinning table")
            {
                Response.Redirect("DiningTable.aspx");
            }
            else if (search.ToString() == "4 seater dinning table")
            {
                Response.Redirect("4seatdining.aspx");
            }
            else if (search.ToString() == "6 seater dinning table")
            {
                Response.Redirect("6seatdining.aspx");
            }
            else if (search.ToString() == "8 seater dinning table")
            {
                Response.Redirect("8seatdining.aspx");
            }
            else if (search.ToString() == "dressing table" || search.ToString() == "dressingtable")
            {
                Response.Redirect("DressingTable.aspx");
            }
            else if (search.ToString() == "mattress" || search.ToString() == "bed sheet")
            {
                Response.Redirect("Mattresses.aspx");
            }
            else if (search.ToString() == "shoerack" || search.ToString() == "shoe rack" || search.ToString() == "shoe stand")
            {
                Response.Redirect("ShoeRack.aspx");
            }
            else if (search.ToString() == "study table" || search.ToString() == "studytable")
            {
                Response.Redirect("StudyTable.aspx");
            }
            else if (search.ToString() == "table" || search.ToString() == "centroid" || search.ToString() == "teapoy")
            {
                Response.Redirect("Table.aspx");
            }
            else if (search.ToString() == "wardrobe" || search.ToString() == "cupboard")
            {
                Response.Redirect("Wardrobes.aspx");
            }
            else if (search.ToString() == "4 door wardrobe" || search.ToString() == "4 door cupboard")
            {
                Response.Redirect("4doorwardrobe.aspx");
            }
            else if (search.ToString() == "3 door wardrobe" || search.ToString() == "3 door cupboard")
            {
                Response.Redirect("3doorwardrobe.aspx");
            }
            else if (search.ToString() == "2 door wardrobe" || search.ToString() == "2 door cupboard")
            {
                Response.Redirect("2doorwardrobe.aspx");
            }
            else if (search.ToString() == "tvunit" || search.ToString() == "t.v.unit" || search.ToString() == "tv unit" || search.ToString() == "t.v. unit" || search.ToString() == "tv showcase" || search.ToString() == "tvshowcase")
            {
                Response.Redirect("TVUnit.aspx");
            }
            else if (search.ToString() == "ottoman" || search.ToString() == "stool")
            {
                Response.Redirect("Ottoman.aspx");
            }
            else
            {
                Response.Redirect("Products.aspx");
            }
        }

        

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Signin.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Session.Clear();


            //Request.Cookies.Clear(); //Remove Cookies
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
            Response.Redirect("~/Home.aspx");
        }

        protected void btnprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile.aspx");
        }
    }
}