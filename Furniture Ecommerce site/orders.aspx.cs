using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Furniture_Ecommerce_site
{
    public partial class orders : System.Web.UI.Page
    {
        
        //Int64 presentorderid = 0;
        
       // public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bindcusid();

            if (!IsPostBack)
            {
                //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                //{
                //    Int64 test = Int64.Parse(TextBox1.Text);
                //    SqlCommand cmd2 = new SqlCommand("select *from Ordermaster where OrderID=(select Max(OrderID) from Ordermaster)", con);
                //    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    presentorderid = Convert.ToInt64(dt.Rows[0][0].ToString());
                //    if ( test < presentorderid)
                //    {
                //        Response.Write("<script> alert('You have New orders'); </script>");
                //    }
                //}
            }

            ddlorderpenchange.Visible = false;
            ddlorderprocchange.Visible = false;
            if (!IsPostBack)
            {
                
                Bindorderpenid1();
                Bindorderprocid1();
                rptrOrders.Visible = false;
                rptrOrders2.Visible = false;
                rptrOrders3.Visible = false;
                rptrOrders4.Visible = false;
            }
            
        }
        
        public void Bindorderprocid1()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Ordermaster where OrderStatus='process'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlorderprocid.DataSource = dt;
                    ddlorderprocid.DataTextField = "PurId";
                    ddlorderprocid.DataBind();
                    ddlorderprocid.Items.Insert(0, new ListItem("-Select-", "0"));
                }


            }
        }
        public void Bindorderpenid1()
        {
            
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select *from Ordermaster where OrderStatus='pending'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        ddlorderpenid.DataSource = dt;
                        ddlorderpenid.DataTextField = "PurId";
                        ddlorderpenid.DataBind();
                        ddlorderpenid.Items.Insert(0, new ListItem("-Select-", "0"));
                    }


                }

        }

        public void Bindorders()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select *from Ordermaster where OrderStatus='Delivered'", con);
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptrOrders.DataSource = dt;
                    rptrOrders.DataBind();
                }
            }
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
        //    {

        //        con.Open();
        //        SqlCommand cmd;

        //        cmd = new SqlCommand("update Ordermaster set OrderStatus='" + DropDownList1.SelectedValue.ToString() + "' from Ordermaster inner join tblPurchase On Ordermaster.PurId=tblPurchase.PurchaseID where OrderId=(select MAX(OrderId) from Ordermaster)", con);
        //        cmd.ExecuteNonQuery();
        //        Bindorders();
        //        SqlCommand cmd1;
        //        cmd1 = new SqlCommand("update tblPurchase set PaymentStatus='PAID' where PaymentStatus='NOTPAID'", con);
        //    }
        //}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {

                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select *from Ordermaster where OrderStatus='pending'", con);
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptrOrders.DataSource = dt;
                    rptrOrders.DataBind();
                }

            }
            rptrOrders.Visible = true;
            rptrOrders2.Visible = false;
            rptrOrders3.Visible = false;
            rptrOrders4.Visible = false;
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {

                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select *from Ordermaster where OrderStatus='process'", con);
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptrOrders2.DataSource = dt;
                    rptrOrders2.DataBind();
                }
                rptrOrders2.Visible = true;
                rptrOrders.Visible = false;
                rptrOrders3.Visible = false;
                rptrOrders4.Visible = false;

            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {

                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select *from Ordermaster where OrderStatus='Delivered'", con);
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptrOrders3.DataSource = dt;
                    rptrOrders3.DataBind();
                }
                rptrOrders3.Visible = true;
                rptrOrders.Visible = false;
                rptrOrders2.Visible = false;
                rptrOrders4.Visible = false;
            }
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Ordermaster set OrderStatus='" + ddlorderpenchange.SelectedValue.ToString() + "'where PurId='" + ddlorderpenid.SelectedValue.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("select *from Ordermaster where OrderID=(select Max(OrderID) from Ordermaster)", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TextBox1.Text = dt.Rows[0][0].ToString();
                Bindorderpenid1();
                

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Ordermaster set OrderStatus='" + ddlorderprocchange.SelectedValue.ToString() + "'where PurId='" + ddlorderprocid.SelectedValue.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("select *from Ordermaster where OrderID=(select Max(OrderID) from Ordermaster)", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TextBox1.Text = dt.Rows[0][0].ToString();

            }
        }

        protected void ddlorderpenid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlorderpenchange.Visible = true;
          
        }

        protected void ddlorderprocid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlorderprocchange.Visible = true;
        }

        /*protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("customerreport.aspx");
        }*/
    }
    
}