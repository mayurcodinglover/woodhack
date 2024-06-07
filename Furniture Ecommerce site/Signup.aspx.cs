using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Tsp;
using System.Web.Services.Description;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Furniture_Ecommerce_site
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {
               using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select *from Users", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (txtEmail.Text == dt.Rows[i][3].ToString() || txtmono.Text == dt.Rows[i][7].ToString() || txtUname.Text == dt.Rows[i][1].ToString())
                            {
                                Response.Write("<script language='javascript'>alert('Please login to check the orders!');window.location.href = 'Signup.aspx';</script>");
                                clr();
                                
                            }
                        }
                        using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/userprofile/") + Path.GetFileName(FileUpload1.FileName));
                            string img = "userprofile/" + Path.GetFileName(FileUpload1.FileName);
                            con1.Open();
                            SqlCommand cmd1 = new SqlCommand("Insert into Users(Username,Password,Email,Name,Usertype,PPic,Mobile,Address,Zipcode) Values('" + txtUname.Text + "','" + txtPass.Text + "','" + txtEmail.Text + "','" + txtName.Text + "','User','" + img + "','" + txtmono.Text + "','" + txtAddress.Text + "','" + txtZip.Text + "')", con);
                            cmd1.ExecuteNonQuery();
                            Response.Write("<script> alert('Registration successfully done'); </script>");
                            clr();
                            con1.Close();
                            lblmsg.Text = "Registration successfully done";
                            lblmsg.ForeColor = System.Drawing.Color.Green;

                        }
                        Response.Redirect("~/Signin.aspx");



                    }
                }

            }
            

        }
        private void clr()
        {
            txtUname.Text = String.Empty;
            txtPass.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtName.Text = String.Empty;
            txtmono.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtZip.Text = String.Empty;
        }

    }
}
