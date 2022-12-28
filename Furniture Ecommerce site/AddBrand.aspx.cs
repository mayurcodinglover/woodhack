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
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBrandRepeater();
            }
        }

        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select *from Brands", con))
                {
                    using(SqlDataAdapter da=new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrBrands.DataSource = dt;
                        rptrBrands.DataBind();
                    }
                }

            }
        }

        protected void btnBrand_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Brands(Name) Values('"+txtBrand.Text+"')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Brand Added Successfully'); </script>");
                txtBrand.Text = String.Empty;
                con.Close();
                //lblmsg.Text = "Registration successfully done";
                //lblmsg.ForeColor = System.Drawing.Color.Green;
                txtBrand.Focus();

            }
        }
    }
}