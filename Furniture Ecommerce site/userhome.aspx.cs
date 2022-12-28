using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Furniture_Ecommerce_site
{
    public partial class userhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            if (Session["Username"]!=null)
            {
                btnlogout.Visible = true;
                btnlogin.Visible = false;
                lblSuccess.Text = "Login Success Welcome " + Session["Username"].ToString();
            }
            else
            {
                btnlogout.Visible = false;
                btnlogin.Visible = true;
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Username"] = null;
            Response.Redirect("~/Signin.aspx");
        }
        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
                pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Signin.aspx");

        }
    }
}