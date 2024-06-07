using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Furniture_Ecommerce_site
{
    public partial class BookShelve : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("procBookshelve", cn))
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