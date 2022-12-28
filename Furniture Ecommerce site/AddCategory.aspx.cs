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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryReapter();
        }

        private void BindCategoryReapter()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select *from Category", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrCategory.DataSource = dt;
                        rptrCategory.DataBind();
                    }
                }

            }
        }

        protected void btnAddtxtCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Category(CatName) Values('" + txtCategory.Text + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Category Added Successfully'); </script>");
                txtCategory.Text = String.Empty;
                con.Close();
                //lblmsg.Text = "Registration successfully done";
                //lblmsg.ForeColor = System.Drawing.Color.Green;
                txtCategory.Focus();

            }
        }
    }
}