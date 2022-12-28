using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

namespace Furniture_Ecommerce_site
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select *from login where Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email",txtEmailID.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count != 0)
                {
                    String myGUID=Guid.NewGuid().ToString();
                    int Uid = Convert.ToInt32(dt.Rows[0][0]);
                    SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass(Id,Uid,RequestDateTime) values('"+myGUID+"','"+Uid+"',GETDATE())", con);
                    cmd1.ExecuteNonQuery();



                    //Send Reset Link via Email

                    String ToEmailAddress = dt.Rows[0][3].ToString();
                    String Username = dt.Rows[0][1].ToString();
                    String EmailBody ="Hii ,"+Username+ ",<br/><br/>Click the link below to Reset Your password<br/><br/>https://localhost:44342/Recover%20Password.aspx?id=" + myGUID +"";

                    MailMessage PassRecMail = new MailMessage("hedaumayur266@gmail.com",ToEmailAddress);
                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "Reset Password";
                    using (SmtpClient client=new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("hedaumayur266@gmail.com", "okymuyjymhdntnpp");
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(PassRecMail);
                        
                    }

                    //------




                    lblResetPassMsg.Text = "Reset Link send ! Check Your Email for reset password";
                    lblResetPassMsg.ForeColor=System.Drawing.Color.Green;
                    txtEmailID.Text = String.Empty;
                }
                else
                {
                    lblResetPassMsg.Text = "OOps ! This Email Does Not Exist... Try again";
                    lblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                    txtEmailID.Text = String.Empty;
                    txtEmailID.Focus();
                }


            }
        }
    }
}