using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace Furniture_Ecommerce_site
{
    public partial class AddGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenderReapter();
        }
        private void GenderReapter()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select *from Gender", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrGender.DataSource = dt;
                        rptrGender.DataBind();
                    }
                }

            }
        }


        protected void btnGender_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Gender(GenderName) Values('" + txtGender.Text + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Gender Added Successfully'); </script>");
                txtGender.Text = String.Empty;
                con.Close();
                //lblmsg.Text = "Registration successfully done";
                //lblmsg.ForeColor = System.Drawing.Color.Green;
                txtGender.Focus();

            }
            GenderReapter();
        }
    }
}
