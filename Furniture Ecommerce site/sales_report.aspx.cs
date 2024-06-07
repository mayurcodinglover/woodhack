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
    public partial class sales_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select Products.Pid,Products.PName,Products.PSelPrice from Products join tblPurchase on Products.Pid in (select SUBSTRING(PIDSizeID,1,4)from tblPurchase) join Category on Category.CatId=Products.PCategoryId ; ", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrsalesreport.DataSource = dt;
                        rptrsalesreport.DataBind();
                    }
                }

            }
        }
    }
}