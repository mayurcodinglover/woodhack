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
using System.Globalization;
using System.Threading;

namespace Furniture_Ecommerce_site
{
    public partial class Cart : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindProductCart();

            }
        }

        private void BindProductCart()
        {

            if (Request.Cookies["CartPID"] != null)
            {
                
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                Int64 CartTotal = 0;
                Int64 Total = 0;
                if (CookieDataArray.Length > 0)
                {
                    h4Noitems.InnerText = "MY Cart(" + CookieDataArray.Length + "items)";
                    //DataTable dt = new DataTable();
                   
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string SubCatid = CookieDataArray[i].ToString().Split('-')[1];
                        //Convert.ToInt32(SubCatid);
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("select A.* , dbo.getSizeName(" + SubCatid+") as SizeNamee , "+SubCatid+ " as SizeIDD , SizeData.Name , SizeData.Extention from Products A cross apply (select  top 1  B.Name , B.Extention from ProductImages B where B.PID = A.PID) SizeData where A.PID='" + PID + "'",con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                {
                                    
                                    da.Fill(dt);

                                }
                            }

                        }
                        CartTotal += Convert.ToInt64(dt.Rows[i]["PPrice"]);
                        Total += Convert.ToInt64(dt.Rows[i]["PSelPrice"]);
                    }
                }
                rptrCartProducts.DataSource = dt;
                rptrCartProducts.DataBind();
                if (dt.Rows.Count > 0)
                {
                    //string Total = dt.Compute("Sum(PSelPrice)", "").ToString();
                    //string CartTotal = dt.Compute("Sum(PPrice)", "").ToString();
                    //string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                    string CartQuantity = dt.Rows.Count.ToString();
                    h4Noitems.InnerText = "My Cart ( " + CartQuantity + " Item(s) )";
                    //int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                    //int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                    spanTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", Total) + ".00";
                    spanCartTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", CartTotal) + ".00";
                    spanDiscount.InnerText = "- Rs. " + (CartTotal - Total).ToString() + ".00";

                }
                else
                {
                    h4Noitems.InnerText = "Your Shopping Cart is Empty.";
                    divAmountSect.Visible = false;

                }
                
            }
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (Session["USERNAME"]!=null)
            {
                Response.Redirect("~/Payment.aspx");
            }
            else
            {
                Response.Redirect("~/SignIn.aspx?rurl=cart");
            }
        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;
            base.InitializeCulture();
        }

        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            string CookiePid = Request.Cookies["CartPID"].Value.Split('=')[1];
            Button btn = (Button)(sender);
            string PIDSIZE = btn.CommandArgument;
            List<String> cookiePIDList = CookiePid.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            cookiePIDList.Remove(PIDSIZE);
            string CookiePIDUpdated = String.Join(",", cookiePIDList.ToArray());
            if(CookiePIDUpdated=="")
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            Response.Redirect("~/Cart.aspx");
        }
    }
    
}