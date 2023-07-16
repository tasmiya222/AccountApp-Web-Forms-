using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.SaleOrder
{
    public partial class SaleInvoice : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        public decimal grandtotal;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["SaleOrderID"] != null)
                {
                    BindData();
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand Details = new SqlCommand("GetInvoiceDetails", con);
                Details.Parameters.AddWithValue("@SOID", Request.QueryString["SaleOrderID"]);
                Details.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(Details);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                lblInvoiceID.Text = dr["InvoiceID"].ToString();
                lblInvoiceDate.Text = dr["InvoiceDate"].ToString();
                lblEmail.Text = dr["Email"].ToString();
                lblCustomerName.Text = dr["FullName"].ToString();
                lblContact.Text = dr["PhoneNumber"].ToString();
                lblDate.Text = DateTime.Now.ToString("M/d/yyyy");
                lblAddres1.Text = dr["Address2"].ToString();
                lblAddres2.Text = dr["Address1"].ToString();
              
            }
        }
       void  BindData()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand ShowData = new SqlCommand("SaleInvoice_SP", con);
            ShowData.CommandType = CommandType.StoredProcedure;
            ShowData.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["SaleOrderID"]);
            SqlDataAdapter sda = new SqlDataAdapter(ShowData);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Invoice.DataSource = dt;
            Invoice.DataBind();
            
            
        }

        protected void Invoice_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
    
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label subTotal = e.Item.FindControl("lblSubTotal") as Label;
                Label lblQuantity = e.Item.FindControl("qty") as Label;
                Label lblPrice = e.Item.FindControl("lblPrice") as Label;
                decimal Price = Convert.ToDecimal(lblPrice.Text);
                decimal qty = Convert.ToDecimal(lblQuantity.Text);
                decimal res = Price * qty;
                subTotal.Text += res.ToString();
                grandtotal  += res;
            }
            Session["Total"] = grandtotal;
        }

           

        
    }
}