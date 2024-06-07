using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Furniture_Ecommerce_site
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //when page first time run this code will execute
                BindBrand();
                BindCategory();
                // Bindsize();
                ddlSubCategory.Enabled = false;
            }
        }

        private void BindCategory()
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

        /*private void Bindsize()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Sizes", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlsize.DataSource = dt;
                    ddlsize.DataTextField = "SizeName";
                    ddlsize.DataValueField = "SizeID";
                    ddlsize.DataBind();
                    ddlsize.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }*/

        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(CS))
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
                cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);
                cmd.Parameters.AddWithValue("@PBrandid", ddlBrand.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PCategoryid", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PSubCategoryId", ddlSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
                cmd.Parameters.AddWithValue("@PDetails", txtPDetail.Text);
                cmd.Parameters.AddWithValue("@PMaterial", txtMatCare.Text);

                if (chFD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());

                }
                /*if (ch30Ret.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Return30day", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Return30day", 0.ToString());

                }*/
                if (chCOD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());

                }

                con.Open();
                Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());


                //Insert quentity

                SqlCommand cmd2 = new SqlCommand("insert into ProdQuantity values('" + PID + "','" + txtQuantity.Text + "')", con);
                cmd2.ExecuteNonQuery();

                //Insert and upload images
                if (fuImg01.HasFile)
                {
                    string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                    fuImg01.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);
                    SqlCommand cmd3 = new SqlCommand("insert into ProductImages values('" + PID + "','" + txtProductName.Text.Trim()+"01"+"','"+Extention+"')", con);
                    cmd3.ExecuteNonQuery();

                }
                //2nd file upload
                if (fuImg02.HasFile)
                {
                    string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
                    fuImg02.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);
                    SqlCommand cmd4 = new SqlCommand("insert into ProductImages values('" + PID + "','" + txtProductName.Text.Trim() + "02" + "','" + Extention + "')", con);
                    cmd4.ExecuteNonQuery();

                }
                //3rd file upload
                if (fuImg03.HasFile)
                {
                    string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
                    fuImg03.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);
                    SqlCommand cmd5 = new SqlCommand("insert into ProductImages values('" + PID + "','" + txtProductName.Text.Trim() + "03" + "','" + Extention + "')", con);
                    cmd5.ExecuteNonQuery();

                }
                //4th file upload
                if (fuImg04.HasFile)
                {
                    string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
                    fuImg04.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);
                    SqlCommand cmd6 = new SqlCommand("insert into ProductImages values('" + PID + "','" + txtProductName.Text.Trim() + "04" + "','" + Extention + "')", con);
                    cmd6.ExecuteNonQuery();

                }
                //5th file upload
                if (fuImg05.HasFile)
                {
                    string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
                    fuImg05.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);
                    SqlCommand cmd7 = new SqlCommand("insert into ProductImages values('" + PID + "','" + txtProductName.Text.Trim() + "05" + "','" + Extention + "')", con);
                    cmd7.ExecuteNonQuery();

                }


            }
            
        }


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from SubCategory where MainCatID='"+ddlCategory.SelectedItem.Value+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = dt;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
    }
}