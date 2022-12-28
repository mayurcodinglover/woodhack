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
    public partial class AddSize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindMainCategory();
                BindGender();

            }
        }
        private void BindMainCategory()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Category", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Brands", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "Name";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        private void BindGender()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Gender", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlGender.DataSource = dt;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));
                    BindrptrSize();
                }
            }
        }

        private void BindrptrSize()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.*,E.* from Sizes A inner join Category B On B.CatID=A.CategoryID inner join Brands C on c.BrandID=A.BrandID inner join SubCategory D on D.SubCatID=A.SubCategoryID inner join Gender E on E.GenderID=A.GenderID", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrSize.DataSource = dt;
                        rptrSize.DataBind();
                    }
                }

            }
        }

        protected void btnAddSize_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Sizes(SizeName,BrandID,CategoryID,SubCategoryID,GenderID) Values('" + txtSize.Text + "','" + ddlBrand.SelectedItem.Value + "','" + ddlCategory.SelectedItem.Value + "','" + ddlSubCat.SelectedItem.Value + "','" + ddlGender.SelectedItem.Value + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Size Added Successfully'); </script>");
                txtSize.Text = String.Empty;
                con.Close();
                ddlBrand.ClearSelection();
                ddlBrand.Items.FindByValue("0").Selected = true;

                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;

                ddlSubCat.ClearSelection();
                ddlSubCat.Items.FindByValue("0").Selected = true;

                ddlGender.ClearSelection();
                ddlGender.Items.FindByValue("0").Selected = true;

            }
            BindrptrSize();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from SubCategory where MainCatID='"+ddlCategory.SelectedItem.Value+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlSubCat.DataSource = dt;
                    ddlSubCat.DataTextField = "SubCatName";
                    ddlSubCat.DataValueField = "SubCatID";
                    ddlSubCat.DataBind();
                    ddlSubCat.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
    }
}