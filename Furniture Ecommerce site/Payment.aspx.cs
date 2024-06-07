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
using System.Reflection.Emit;

namespace Furniture_Ecommerce_site
{
    public partial class Payment : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String str;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString);
            con.Open();
            str = "select* from Users where Uid = '" + Session["USERID"] + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtName1.Text = dr[4].ToString();
                txtAddress1.Text = dr[8].ToString();
                txtPostalCode1.Text = dr[9].ToString();
                txtMobile1.Text = dr[7].ToString();
            }
            con.Close();
            //Bindaddress();
            if (Session["USERNAME"] != null)
            {
                if (!IsPostBack)
                {
                    BindPriceData();
                }
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }
        /*public void Bindaddress()
        {
            if (Session["USERID"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    string e = string.Empty;
                    using (SqlCommand cmd = new SqlCommand("select *from Users where Address1!='"+null+"'", con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                txtName1.Text = dt.Rows[0][4].ToString();
                                txtAddress1.Text = dt.Rows[0][6].ToString();
                                txtPostalCode1.Text = dt.Rows[0][11].ToString();
                                txtMobileNumber.Text = dt.Rows[0][12].ToString();
                            }
                            else
                            {
                                
                                    con.Open();
                                    SqlCommand cmd1;
                                    cmd1 = new SqlCommand("insert into Users (Name,Address1,City,State,Country,ZipCode,mono) values('"+ txtName.Text + "','"+txtAddress.Text+"','"+drpcity.SelectedValue.ToString()+"','"+drpstate.SelectedValue.ToString()+"','"+drpcountry.SelectedValue.ToString()+"')", con);
                                    cmd.ExecuteNonQuery();
                                
                            }
                        }
                    }
                }
            }
        }
        */
        private void BindPriceData()
        {
            DataTable dtBrands = new DataTable();
            Int64 CartTotal = 0;
            Int64 Total = 0;
            string PID = "";
            string SizeID = "";
            if (Session["UserID"] != null)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    DataTable dtcartProducts = new DataTable();
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select C.*,P.PSubCategoryId from Cart C INNER JOIN Products P ON C.ProductID = P.Pid where C.UserId='" + Session["USERID"] + "'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtcartProducts);
                        }
                    }

                    if (dtcartProducts != null && dtcartProducts.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtcartProducts.Rows.Count; i++)
                        {
                            PID = Convert.ToString(dtcartProducts.Rows[i]["ProductID"]);
                            SizeID = Convert.ToString(dtcartProducts.Rows[i]["PSubCategoryId"]);

                            if (hdPidSizeID.Value != null && hdPidSizeID.Value != "")
                            {
                                hdPidSizeID.Value += "," + PID + "-" + SizeID;
                            }
                            else
                            {
                                hdPidSizeID.Value = PID + "-" + SizeID;
                            }

                            using (SqlCommand cmd = new SqlCommand("select A.*,dbo.getSizeName(" + SizeID + ") as SizeNamee,"
                                    + SizeID + " as SizeIDD,SizeData.Name,SizeData.Extention from Products A cross apply( select top 1 B.Name,Extention from ProductImages B where B.PID=A.PID ) SizeData where A.PID="
                                    + PID + "", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    sda.Fill(dtBrands);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (Request.Cookies["CartPID"] != null)
                {
                    string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                    string[] CookieDataArray = CookieData.Split(',');
                    if (CookieDataArray.Length > 0)
                    {
                        for (int i = 0; i < CookieDataArray.Length; i++)
                        {
                            PID = CookieDataArray[i].ToString().Split('-')[0];
                            SizeID = CookieDataArray[i].ToString().Split('-')[1];

                            if (hdPidSizeID.Value != null && hdPidSizeID.Value != "")
                            {
                                hdPidSizeID.Value += "," + PID + "-" + SizeID;
                            }
                            else
                            {
                                hdPidSizeID.Value = PID + "-" + SizeID;
                            }

                            using (SqlConnection con = new SqlConnection(CS))
                            {
                                using (SqlCommand cmd = new SqlCommand("select A.*,dbo.getSizeName(" + SizeID + ") as SizeNamee,"
                                    + SizeID + " as SizeIDD,SizeData.Name,SizeData.Extention from Products A cross apply( select top 1 B.Name,Extention from ProductImages B where B.PID=A.PID ) SizeData where A.PID="
                                    + PID + "", con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                    {
                                        sda.Fill(dtBrands);
                                    }
                                }
                            }
                        }

                    }
                }
            }

            if (dtBrands.Rows.Count > 0)
            {
                foreach (DataRow dr in dtBrands.Rows)
                {
                    CartTotal += Convert.ToInt64(dr["PPrice"]);
                    Total += Convert.ToInt64(dr["PSelPrice"]);
                }

                divPriceDetails1.Visible = true;

                spanCartTotal1.InnerText = CartTotal.ToString();
                spanTotal1.InnerText = "Rs. " + Total.ToString();
                spanDiscount1.InnerText = "- " + (CartTotal - Total).ToString();

                hdCartAmount.Value = CartTotal.ToString();
                hdCartDiscount.Value = (CartTotal - Total).ToString();
                hdTotalPayed.Value = Total.ToString();
            }
            else
            {
                //TODO Show Empty Cart
                Response.Redirect("~/Products.aspx");
            }
        }

        

        protected void addresssubmit_Click(object sender, EventArgs e)
        {
            /*using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("UPDATE Users SET Name =  '" + txtName.Text + "',Address1='" + txtAddress.Text + "',ZipCode='" + txtPinCode.Text + "',mono='" + txtMobileNumber.Text + "',City='" + drpcity.SelectedValue.ToString() + "',State='" + drpstate.SelectedValue.ToString() + "',Country='" + drpcountry.SelectedValue.ToString() + "' WHERE Uid=" + Session["USERID"], con);
                cmd.ExecuteNonQuery();
            }*/
        }


        /*protected void btnPaytm_Click1(object sender, EventArgs e)
        {
            
            if (Session["USERNAME"] != null)
            {
                string USERID = Session["USERID"].ToString();
                string PaymentType = "Paytm";
                string PaymentStatus = "Paid";
                string EMAILID = Session["USEREMAIL"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into tblPurchase values('" + USERID + "','"
                        + hdPidSizeID.Value + "','" + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','"
                        + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "',getdate(),'"
                        + txtName1.Text + "','" + txtAddress1.Text + "','" + txtPostalCode1.Text + "','" + txtMobile1.Text + "') select SCOPE_IDENTITY()", con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());
                    Session["purid"] = PurchaseID;
                    string status = "pending";
                    SqlCommand cmd1;
                    cmd1 = new SqlCommand("insert into Ordermaster values('"+PurchaseID+"','"+status+"','" + Session["UserID"] +"')", con);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("testinvoice.aspx");
                }
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }*/

        protected void btncard_Click(object sender, EventArgs e)
        {
            if (Session["USERNAME"] != null)
            {
                string USERID = Session["USERID"].ToString();
                string PaymentType = "CARD";
                string PaymentStatus = "PAID";
                string EMAILID = Session["USEREMAIL"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into tblPurchase values('" + USERID + "','"
                        + hdPidSizeID.Value + "','" + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','"
                        + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "',getdate(),'"
                        + txtName1.Text + "','" + txtAddress1.Text + "','" + txtPostalCode1.Text + "','" + txtMobile1.Text + "') select SCOPE_IDENTITY()", con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());
                    Session["purid"] = PurchaseID;
                    string status = "pending";
                    SqlCommand cmd1;
                    cmd1 = new SqlCommand("insert into Ordermaster values('" + PurchaseID + "','" + status + "','" + Session["UserID"] +"')", con);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("testinvoice.aspx");
                }
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }

        protected void btncod_Click(object sender, EventArgs e)
        {
            if (Session["USERNAME"] != null)
            {
                string USERID = Session["USERID"].ToString();
                string PaymentType = "COD";
                string PaymentStatus = "pending";
                string EMAILID = Session["USEREMAIL"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into tblPurchase values('" + USERID + "','"
                        + hdPidSizeID.Value + "','" + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','"
                        + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "',getdate(),'"
                        + txtName1.Text + "','" + txtAddress1.Text + "','" + txtPostalCode1.Text + "','" + txtMobile1.Text + "') select SCOPE_IDENTITY()", con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());
                    Session["purid"] = PurchaseID;
                    string status = "pending";
                    SqlCommand cmd1;
                    cmd1 = new SqlCommand("insert into Ordermaster values('" + PurchaseID + "','" + status + "','" + Session["UserID"] + "')", con);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("testinvoice.aspx");
                }
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }



     

        

        //protected void Button2_Click1(object sender, EventArgs e)
        //{
        //    Label1.Visible = false;
        //    Label2.Visible = false;
        //    Label3.Visible = false;
        //    Label4.Visible = false;
        //    Button2.Visible = false;

        //    txtName1.Visible = true;
        //    txtAddress1.Visible = true;
        //    txtPostalCode1.Visible = true;
        //    txtMobile1.Visible = true;
        //    Button3.Visible = true;
        //}

        //protected void Button3_Click1(object sender, EventArgs e)
        //{
        //    using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
        //    {
        //        //FileUpload1.SaveAs(Server.MapPath("~/images/") + Path.GetFileName(FileUpload1.FileName));
        //        //string img = "images/" + Path.GetFileName(FileUpload1.FileName);
        //        con1.Open();
        //        SqlCommand cmd1;
        //        cmd1 = new SqlCommand("insert into tblPurchase(Address,PinCode,MobileNumber,Name) values('" + txtAddress1.Text + "','" + txtPostalCode1.Text + "','" + txtMobile1.Text + "','" + txtName1.Text + "')", con1);
        //        cmd1.ExecuteNonQuery();
        //    }
        //    String str;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString);
        //    con.Open();
        //    str = "select* from tblPurchase where UserID = '" + Session["USERID"] + "'";
        //    SqlCommand cmd = new SqlCommand(str, con);
        //    SqlDataReader dr;
        //    dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        Label1.Text = dr[4].ToString();
        //        Label2.Text = dr[8].ToString();
        //        Label3.Text = dr[9].ToString();
        //        Label4.Text = dr[7].ToString();
        //    }
        //    con.Close();

        //    txtName1.Visible = false;
        //    txtAddress1.Visible = false;
        //    txtPostalCode1.Visible = false;
        //    txtMobile1.Visible = false;
        //    Button3.Visible = false;

        //    Label1.Visible = true;
        //    Label2.Visible = true;
        //    Label3.Visible = true;
        //    Label4.Visible = true;
        //    Button2.Visible = true;
        //}
    }
}