using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Furniture_Ecommerce_site
{
    public partial class testinvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            lblorder.Text = Session["purid"].ToString();
            if(!Page.IsPostBack)
            {
                bindgrid();
            }
            
            Bindlablelandgrid();
            
        }
        public void Bindlablelandgrid()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select Products.pid,Products.PName,Products.PSelPrice,tblPurchase.PurchaseID,tblPurchase.DateOfPurchase,tblPurchase.Address from tblPurchase join Products on Products.Pid in (select SUBSTRING(PIDSizeID,1,4) from tblPurchase where tblPurchase.PurchaseID='" + Session["purid"].ToString() + "') where tblPurchase.PurchaseID='" + Session["purid"].ToString() + "'", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        orderdate.Text = dt.Rows[0][4].ToString();
                        buyadd.Text = dt.Rows[0][5].ToString();
                        total.Text = dt.Rows[0][2].ToString();
                        pid.Text=dt.Rows[0][0].ToString();
                        pname.Text = dt.Rows[0][1].ToString();
                        pprice.Text = dt.Rows[0][2].ToString();

                    }
                }
            }

        }
        public void bindgrid()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("srno");
            dt.Columns.Add("productid");
            dt.Columns.Add("productname");
            dt.Columns.Add("productprice");
            dt.Columns.Add("dop");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyEshoppingDB"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select tblPurchase.PurchaseID,Products.pid,Products.PName,Products.PSelPrice,tblPurchase.DateOfPurchase from tblPurchase join Products on Products.Pid in (select SUBSTRING(PIDSizeID,1,4) from tblPurchase where tblPurchase.UserID='" + Session["USERID"] + "') where tblPurchase.UserID='" + Session["USERID"] + "'", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        StringBuilder htmlTable = new StringBuilder();
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        htmlTable.Append("<table border='5' align='center'width:'60%'>");
                        htmlTable.Append("<tr style='background-color:green; color: black;'><th>sr.no.</th><th>product id</th><th>product name</th><th>product price</th><th>Date of purchase </th></tr>");

                        if (!object.Equals(ds.Tables[0], null))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    htmlTable.Append("<tr style='color: Black;'>");
                                    htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["PurchaseID"] + "</td>");
                                    htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["pid"] + "</td>");
                                    htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["PName"] + "</td>");
                                    htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["PSelPrice"] + "</td>");
                                    htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["DateOfPurchase"] + "</td>");
                                    htmlTable.Append("</tr>");
                                }
                                htmlTable.Append("</table>");
                                DBDataPlaceHolder.Controls.Add(new Literal
                                {
                                    Text = htmlTable.ToString()
                                });
                            }
                            else
                            {
                                htmlTable.Append("<tr>");
                                htmlTable.Append("<td align='center' colspan='4'>There is no Record.</td>");
                                htmlTable.Append("</tr>");
                            }
                        }

                    }
                }
            }
        }





        //int totalrows = ds.Tables[0].Rows.Count;
        //int i = 0;
        //int grandtotal = 0;
        //                while (i<totalrows)
        //                {
        //                    dr = dt.NewRow();
        //                    dr["srno"] = ds.Tables[0].Rows[i]["PurchaseID"].ToString();
        //dr["productid"] = ds.Tables[0].Rows[i]["pid"].ToString();
        //dr["productname"] = ds.Tables[0].Rows[i]["PName"].ToString();
        //dr["productprice"] = ds.Tables[0].Rows[i]["PSelPrice"].ToString();
        //dr["dop"] = ds.Tables[0].Rows[i]["DateOfPurchase"].ToString();
        //i = i + 1;
        //                }


    






        
        private void exportpdf()
        {
            Response.ContentType = "Application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=orderInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            exportpdf();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}