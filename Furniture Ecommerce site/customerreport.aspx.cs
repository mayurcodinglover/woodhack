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
    public partial class customerreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bindcusid();
            }
            


        }
        public void Bindcusid()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT UserID from tblPurchase", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "UserID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(" select tblPurchase.UserID, Products.PName, Products.PSelPrice from tblPurchase join Products on Products.Pid in (select DISTINCT SUBSTRING(PIDSizeID,1,4) from tblPurchase where tblPurchase.UserID='" + DropDownList1.SelectedValue.ToString() + "') where tblPurchase.UserID='" + DropDownList1.SelectedValue.ToString() + "'", con))               
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }

            }
        }
    }

}