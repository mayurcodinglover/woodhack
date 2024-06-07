using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Furniture_Ecommerce_site
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtname.Visible = false;
            txtmobile.Visible = false;
            txtemail.Visible = false;
            txtZip.Visible = false;
            txtAddress.Visible = false;
            FileUpload1.Visible = false;
            btnupdate.Visible = false;

            String str;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString);
            con.Open();
            str = "select* from Users where Uid = '" + Session["USERID"] + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Image1.ImageUrl = dr[6].ToString();
                lbluname.Text = dr[1].ToString();
                lblname.Text = dr[4].ToString();
                lblmobile.Text = dr[7].ToString();
                lblemail.Text = dr[3].ToString();
                lblAddress.Text = dr[8].ToString();
                lblZip.Text = dr[9].ToString();
            }

            con.Close();
        }
        protected void btnedit_Click(object sender, EventArgs e)
        {
            lbluname.Visible = false;
            lblname.Visible = false;
            lblmobile.Visible = false;
            lblemail.Visible = false;
            lblZip.Visible = false;
            lblAddress.Visible = false;
            btnedit.Visible = false;

            txtname.Visible = true;
            txtmobile.Visible = true;
            txtemail.Visible = true;
            txtAddress.Visible = true;
            txtZip.Visible = true;
            FileUpload1.Visible = true;
            btnupdate.Visible = true;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {

            using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                FileUpload1.SaveAs(Server.MapPath("~/images/") + Path.GetFileName(FileUpload1.FileName));
                string img = "images/" + Path.GetFileName(FileUpload1.FileName);
                con1.Open();
                SqlCommand cmd1;
                cmd1 = new SqlCommand("update Users set Name = '" + txtname.Text + "',Mobile = '" + txtmobile.Text + "',Email = '" + txtemail.Text + "',Address = '" + txtAddress.Text + "',Zipcode = '" + txtZip.Text + "' ,PPic = '" + img + "' where Uid='" + Session["USERID"] + "'", con1);
                cmd1.ExecuteNonQuery();


            }
            String str;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString);
            con.Open();
            str = "select* from Users where Uid = '" + Session["USERID"] + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Image1.ImageUrl = dr[6].ToString();
                lbluname.Text = dr[1].ToString();
                lblname.Text = dr[4].ToString();
                lblmobile.Text = dr[7].ToString();
                lblemail.Text = dr[3].ToString();
                lblAddress.Text = dr[8].ToString();
                lblZip.Text = dr[9].ToString();
            }
            con.Close();
            txtname.Visible = false;
            txtmobile.Visible = false;
            txtemail.Visible = false;
            txtAddress.Visible = false;
            txtZip.Visible = false;
            FileUpload1.Visible = false;
            btnupdate.Visible = false;

            lblname.Visible = true;
            lbluname.Visible = true;
            lblmobile.Visible = true;
            lblemail.Visible = true;
            lblZip.Visible = true;
            lblAddress.Visible = true;
            btnedit.Visible = true;
        }

    }
}