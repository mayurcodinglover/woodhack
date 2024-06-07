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
    public partial class SubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindMainCat();
                BindSubCatRptr();
            }
        }

        private void BindSubCatRptr()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select A.*,B.* from SubCategory A inner join Category B on B.CatID=A.MainCatID", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrSubcat.DataSource = dt;
                        rptrSubcat.DataBind();
                    }
                }

            }
        }

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            this.RequiredFieldValidatortxtSubCategoryName.Visible = false;
            if (!string.IsNullOrWhiteSpace(txtSubCategory.Text))
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();

                    int existingCategoryId = 0;
                    int.TryParse(hdnSubCategoryID.Value, out existingCategoryId);

                    SqlCommand cmd;
                    string successMessage = string.Empty;
                    if (existingCategoryId > 0)
                    {
                        cmd = new SqlCommand("UPDATE SubCategory SET SubCatName =  '" + txtSubCategory.Text + "' WHERE SubCatid=" + existingCategoryId, con);
                        successMessage = "SubCategory updated successfully";
                    }
                    else
                    {
                        cmd = new SqlCommand("Insert into SubCategory(SubCatName, MainCatId) Values('" + txtSubCategory.Text + "', "+ ddlMainCatID.SelectedValue + ")", con);
                        successMessage = "SubCategory added successfully";
                    }

                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('" + successMessage + "'); </script>");
                    txtSubCategory.Text = String.Empty;
                    hdnSubCategoryID.Value = "";

                    con.Close();
                    //lblmsg.Text = "Registration successfully done";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;
                    txtSubCategory.Focus();

                    btnAddSubCategory.Text = "Add Category";

                    BindSubCatRptr();

                }
            }
            else
            {
                this.RequiredFieldValidatortxtSubCategoryName.Visible = true;
            }
        }
        private void BindMainCat()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Category", con);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count !=0)
                {
                    ddlMainCatID.DataSource = dt;
                    ddlMainCatID.DataTextField = "CatName";
                    ddlMainCatID.DataValueField = "CatID";
                    ddlMainCatID.DataBind();
                    ddlMainCatID.Items.Insert(0, new ListItem("-Select-", "0"));
                }
               

            }
        }
        protected void rptrSubCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM SubCategory WHERE SubCatid = " + categoryId, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    txtSubCategory.Text = Convert.ToString(dt.Rows[0]["SubCatName"]);
                                    hdnSubCategoryID.Value = Convert.ToString(categoryId);
                                    btnAddSubCategory.Text = "Edit Category";
                                    txtSubCategory.Focus();
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
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM SubCategory WHERE SubCatid = " + categoryId, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();

                        Response.Write("<script> alert('Category deleted successfully'); </script>");

                        BindSubCatRptr();
                    }
                }
            }
        }
    }
}