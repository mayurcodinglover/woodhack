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
    public partial class _2seater : System.Web.UI.Page
    {
        public static String cs = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductRepeter();
            }
        }
        private void BindProductRepeter()
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("proc2seater", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptrProducts.DataSource = dt;
                        rptrProducts.DataBind();
                    }
                }
            }
        }
    }
}