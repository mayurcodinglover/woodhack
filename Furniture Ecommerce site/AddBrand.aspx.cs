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
        protected void btnBrand_Click1(object sender, EventArgs e)
        {
            this.RequiredFieldValidatorBrandName.Visible = false;
            if (!string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();

                    int existingCategoryId = 0;
                    int.TryParse(hdnBrandID.Value, out existingCategoryId);

                    SqlCommand cmd;
                    string successMessage = string.Empty;
                    if (existingCategoryId > 0)
                    {
                        cmd = new SqlCommand("UPDATE Brands SET Name =  '" + txtBrand.Text + "' WHERE Brandid=" + existingCategoryId, con);
                        successMessage = "Brand updated successfully";
                    }
                    else
                    {
                        cmd = new SqlCommand("Insert into Brands(Name) Values('" + txtBrand.Text + "')", con);
                        successMessage = "Brand added successfully";
                    }

                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('" + successMessage + "'); </script>");
                    txtBrand.Text = String.Empty;
                    hdnBrandID.Value = "";

                    con.Close();
                    //lblmsg.Text = "Registration successfully done";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;
                    txtBrand.Focus();

                    btnBrand.Text = "Add Category";

                    BindBrandRepeater();

                }
            }
            else
            {
                this.RequiredFieldValidatorBrandName.Visible = true;
            }
        }
        protected void rptrBrand_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int brandyid = 0;
            if (e.CommandName == "Edit")
            {
                brandyid = Convert.ToInt32(Convert.ToString(e.CommandArgument));

                if (brandyid > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Brands WHERE Brandid = " + brandyid, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    txtBrand.Text = Convert.ToString(dt.Rows[0]["Name"]);
                                    hdnBrandID.Value = Convert.ToString(brandyid);
                                    btnBrand.Text = "Edit Brand";
                                    txtBrand.Focus();
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                brandyid = Convert.ToInt32(Convert.ToString(e.CommandArgument));

                if (brandyid > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Brands WHERE Brandid = " + brandyid, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();

                        Response.Write("<script> alert('Brand deleted successfully'); </script>");

                        BindBrandRepeater();
                    }
                }
            }
        }

       
    }
}