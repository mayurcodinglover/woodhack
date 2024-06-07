using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Furniture_Ecommerce_site
{
    public partial class Recover_Password : System.Web.UI.Page
    {
        String GUIDvalue;
        DataTable dt = new DataTable();
        int Uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                GUIDvalue = Request.QueryString["id"];
                if(GUIDvalue != null)
                {
                    
                    SqlCommand cmd = new SqlCommand("select *from ForgetPass where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", GUIDvalue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    
                    da.Fill(dt);
                    if (dt.Rows.Count!=0)
                    {
                        Uid = Convert.ToInt32(dt.Rows[0][1]);
                    }
                    else
                    {
                        lblmsg.Text = "Your Password Reset Link is Expired or Invalid... Try again";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                    
                }
                else
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
            if(!IsPostBack)
            {
                if(dt.Rows.Count!=0)
                {
                    txtConfirmPass.Visible = true;
                    txtNewPass.Visible = true;
                    lblNewPassword.Visible = true;
                    lblConfirmPass.Visible = true;
                    btnResetPass.Visible = true;

                }
                else
                {
                    lblmsg.Text = "Your Password Reset Link is Expired or Invalid... Try again";
                    lblmsg.ForeColor=System.Drawing.Color.Red;
                }
            }

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text !="" && txtConfirmPass.Text !="" && txtNewPass.Text==txtConfirmPass.Text)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Users set Password=@p where Uid=@Uid", con);
                    cmd.Parameters.AddWithValue("@p", txtNewPass.Text);
                    cmd.Parameters.AddWithValue("@Uid", Uid);
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("delete from ForgetPass where Uid='" + Uid + "'", con);
                    cmd2.ExecuteNonQuery();
                    Response.Write("<script> alert('Passowrd Reset Successfully done'); </script>");
                    Response.Redirect("~/Signin.aspx");

                }
            }
        }
    }
}