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
    public partial class ProfitReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select Distinct Products.Pid,Products.PName,Products.PSelPrice, \r\n(select COUNT(PIDSizeID) from tblPurchase where Products.Pid in (select SUBSTRING(PIDSizeID,1,4)from tblPurchase)) as qty, \r\n(Products.PSelPrice*(select COUNT(PIDSizeID) from tblPurchase where Products.Pid in (select SUBSTRING(PIDSizeID,1,4)from tblPurchase)) *20/100) as Profit\r\nfrom Products join tblPurchase on Products.Pid in (select SUBSTRING(PIDSizeID,1,4)from tblPurchase);;", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrprofitreport.DataSource = dt;
                        rptrprofitreport.DataBind();
                    }
                }

            }
        }
    }
}