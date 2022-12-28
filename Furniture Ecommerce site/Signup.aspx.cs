using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.EnterpriseServices.Internal;

namespace Furniture_Ecommerce_site
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {

            if (isformvalid())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Users(Username,Password,Email,Name,Usertype) Values('" + txtUname.Text + "','" + txtPass.Text + "','" + txtEmail.Text + "','" + txtName.Text + "','User')", con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('Registration successfully done'); </script>");
                    clr();
                    con.Close();
                    lblmsg.Text = "Registration successfully done";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    
                }
                Response.Redirect("~/Signin.aspx");
            }
            else
            {
                Response.Write("<script> alert('Registration Failed'); </script>");
                lblmsg.Text = "Registration Failed";
                lblmsg.ForeColor = System.Drawing.Color.Red;

            }
        }
        private bool isformvalid()
        {
            if (txtUname.Text == "")
            {
                Response.Write("<script> alert('username is Empty'); </script>");
                txtUname.Focus();
                return false;
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script> alert('password is Empty'); </script>");
                txtPass.Focus();

                return false;
            }
            else if (txtPass.Text != txtCpass.Text)
            {
                Response.Write("<script> alert('Password dosent match'); </script>");
                txtCpass.Focus();
                return false;
            }
            else if (txtEmail.Text == "")
            {
                Response.Write("<script> alert('Email is Empty'); </script>");
                txtEmail.Focus();
                return false;
            }
            else if (txtName.Text == "")
            {
                Response.Write("<script> alert('name is Empty'); </script>");
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void clr()
        {
            txtUname.Text = String.Empty;
            txtPass.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtName.Text = String.Empty;
        }
    }
}