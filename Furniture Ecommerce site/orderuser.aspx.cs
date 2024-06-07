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
    public partial class orderuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //rptrstatus.Visible = false;
            if (Session["Username"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("procjoin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Uid", Session["USERID"]);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptrstatus.DataSource = dt;
                    rptrstatus.DataBind();
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Please login to check the orders!');window.location.href = 'Home.aspx';</script>");
                //Response.Redirect("Home.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script> alert('Please login to check your orders!');window.open('Home.aspx');</script>", true);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //rptrstatus.Visible = true;

        }
    }
}