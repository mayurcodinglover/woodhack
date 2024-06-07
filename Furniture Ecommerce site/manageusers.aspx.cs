using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Furniture_Ecommerce_site
{
    public partial class manageusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }
        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select *from Users", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrUsers.DataSource = dt;
                        rptrUsers.DataBind();
                    }
                }

            }
        }
        protected void rptrUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int utypeid = 0;
            if (e.CommandName == "Edit")
            {
                utypeid = Convert.ToInt32(Convert.ToString(e.CommandArgument));

                if (utypeid > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Uid = " + utypeid, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    TextBox1.Text = Convert.ToString(dt.Rows[0]["UserType"]);
                                    hdnuserID.Value = Convert.ToString(utypeid);
                                    TextBox1.Focus();
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.RequiredFieldValidatorUtype.Visible = false;
            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();

                    int existingCategoryId = 0;
                    int.TryParse(hdnuserID.Value, out existingCategoryId);

                    SqlCommand cmd;
                    string successMessage = string.Empty;
                    if (existingCategoryId > 0)
                    {
                        cmd = new SqlCommand("UPDATE Users SET UserType =  '" + TextBox1.Text + "' WHERE Uid=" + existingCategoryId, con);
                        successMessage = "User type updated successfully";
                        cmd.ExecuteNonQuery();
                    }



                    Response.Write("<script> alert('" + successMessage + "'); </script>");
                    TextBox1.Text = String.Empty;
                    hdnuserID.Value = "";

                    con.Close();
                    //lblmsg.Text = "Registration successfully done";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;
                    TextBox1.Focus();
                    BindBrandRepeater();

                }
            }
            else
            {
                this.RequiredFieldValidatorUtype.Visible = true;
            }
        }
    }
}