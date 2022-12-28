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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into SubCategory(SubCatName,MainCatID) Values('" + txtSubCategory.Text + "','"+ddlMainCatID.SelectedItem.Value+"')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('SubCategory Added Successfully'); </script>");
                txtSubCategory.Text = String.Empty;
                con.Close();
                ddlMainCatID.ClearSelection();
                ddlMainCatID.Items.FindByValue("0").Selected = true;
                txtSubCategory.Focus();

            }
            BindSubCatRptr();
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
    }
}