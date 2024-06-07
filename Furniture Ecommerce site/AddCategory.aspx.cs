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

            if (!IsPostBack)
            {
                BindCategoryReapter();
            }
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
            this.RequiredFieldValidatortxtCategoryName.Visible = false;
            if (!string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();

                    int existingCategoryId = 0;
                    int.TryParse(hdnCategoryID.Value, out existingCategoryId);

                    SqlCommand cmd;
                    string successMessage = string.Empty;
                    if (existingCategoryId > 0)
                    {
                        cmd = new SqlCommand("UPDATE Category SET CatName =  '" + txtCategory.Text + "' WHERE CatID=" + existingCategoryId, con);
                        successMessage = "Category updated successfully";
                    }
                    else
                    {
                        cmd = new SqlCommand("Insert into Category(CatName) Values('" + txtCategory.Text + "')", con);
                        successMessage = "Category added successfully";
                    }

                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('" + successMessage + "'); </script>");
                    txtCategory.Text = String.Empty;
                    hdnCategoryID.Value = "";

                    con.Close();
                    //lblmsg.Text = "Registration successfully done";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;
                    txtCategory.Focus();

                    btnAddtxtCategory.Text = "Add Category";

                    BindCategoryReapter();

                }
            }
            else
            {
                this.RequiredFieldValidatortxtCategoryName.Visible = true;
            }
        }

        protected void rptrCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int categoryId = 0;
            if (e.CommandName == "Edit")
            {
                categoryId = Convert.ToInt32(Convert.ToString(e.CommandArgument));

                if (categoryId > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Category WHERE CatID = " + categoryId, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    txtCategory.Text = Convert.ToString(dt.Rows[0]["CatName"]);
                                    hdnCategoryID.Value = Convert.ToString(categoryId);
                                    btnAddtxtCategory.Text = "Edit Category";
                                    txtCategory.Focus();
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                categoryId = Convert.ToInt32(Convert.ToString(e.CommandArgument));

                if (categoryId > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Category WHERE CatID = " + categoryId, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();

                        Response.Write("<script> alert('Category deleted successfully'); </script>");

                        BindCategoryReapter();
                    }
                }
            }
        }
    }
}