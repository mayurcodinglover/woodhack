using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace Furniture_Ecommerce_site
{
    public partial class Sign_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.Cookies["UNAME"] !=null && Request.Cookies["UPWD"] != null)
                {
                    txtUsername.Text= Request.Cookies["UNAME"].Value;
                    txtpass.Text = Request.Cookies["UPWD"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Users where Username=@username and Password=@pwd", con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pwd", txtpass.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count != 0)
                {
                    Session["USERID"] = dt.Rows[0]["Uid"].ToString();
                    Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = txtUsername.Text;
                        Response.Cookies["UPWD"].Value = txtpass.Text;
                        Response.Cookies["UNAME"].Expires=DateTime.Now.AddDays(10);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);

                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);

                    }
                    string Utype;
                    Utype = dt.Rows[0][5].ToString().Trim();
                    if(Utype=="User")
                    {
                        Session["Username"] = txtUsername.Text;
                        if (Request.QueryString["rurl"]!=null)
                        {
                            if (Request.QueryString["rurl"]=="cart")
                            {
                                Response.Redirect("~/Cart.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Home.aspx");
                        }
                        
                    }
                    if(Utype=="Admin")
                    {
                        Session["Username"] = txtUsername.Text;
                        Response.Redirect("~/AdminHomePage.aspx");
                    }
                }
                else
                {
                    lblError.Text = "Invalid username or password";
                }
                //Response.Write("<script> alert('Login successfully done'); </script>");
                clr();
                con.Close();
                //lblmsg.Text = "Registration successfully done";
                //lblmsg.ForeColor = System.Drawing.Color.Green;

            }
        }

        private void clr()
        {
            txtUsername.Text = "";
            txtpass.Text = "";
            txtUsername.Focus();
        }
    }
}