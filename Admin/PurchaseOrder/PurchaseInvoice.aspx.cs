using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AccountApp.Admin.PurchaseOrder
{
    public partial class PurchaseInvoice : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        private decimal grandtotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PurchaseID"] != null)
                {
                    BindData();
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand Details = new SqlCommand("GetPOInvoiceDetails", con);
                Details.Parameters.AddWithValue("@purchaseID", Request.QueryString["PurchaseID"]);
                Details.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(Details);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                lblPurchaseID.Text = dr["PurchaseOrderID"].ToString();
                LblPurchaseDate.Text = dr["ReceivedDate"].ToString();
                lblEmail.Text = dr["Email"].ToString();
                lblCustomerName.Text = dr["FullName"].ToString();
                lblContact.Text = dr["PhoneNumber"].ToString();
                lblDate.Text = DateTime.Now.ToString("M/d/yyyy");
                lblAddres1.Text = dr["Address2"].ToString();
                lblAddres2.Text = dr["Address1"].ToString();

            }
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand ShowData = new SqlCommand("PurchaseOrderInvoice_sp", con);
            ShowData.CommandType = CommandType.StoredProcedure;
            ShowData.Parameters.AddWithValue("@PurchaseID", Request.QueryString["PurchaseID"]);
            SqlDataAdapter sda = new SqlDataAdapter(ShowData);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rPurchaseInvoice.DataSource = dt;
            rPurchaseInvoice.DataBind();


        }
        protected void rPurchaseInvoice_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                grandtotal += res;
            }
            Session["Total"] = grandtotal;
        }
    }
}