using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Return
{
    public partial class SaleOrderReturn : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SaleOrderID"] != null)
                {
                    Session["breadCrum"] = "SaleOrder Return";
                    BindData();
                }

            }
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetInvoiceIdAndCustomerID", con);
            cmd.Parameters.AddWithValue("@SOId", Request.QueryString["SaleOrderID"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.Rows[0];
            lblCustomerID.Text = dr["CustomerId"].ToString();
            lblItemID.Text = dr["ItemID"].ToString();
            lblDate.Text = dr["DeliveredDate"].ToString();
            lblInvoiceID.Text = dr["InvoiceID"].ToString();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand ShowReturnData = new SqlCommand("GetReturnDetail_sp", con);
            ShowReturnData.Parameters.AddWithValue("@SOID", Request.QueryString["SaleOrderID"]);
            SqlDataAdapter Sda = new SqlDataAdapter(ShowReturnData);
            DataTable dt = new DataTable();
            ShowReturnData.CommandType = CommandType.StoredProcedure;
            Sda.Fill(dt);
            rReturn.DataSource = dt;
            rReturn.DataBind();

        }

        protected void BtnRetuen_Click(object sender, EventArgs e)
        {

            foreach (RepeaterItem item in rReturn.Items)
            {
                var lblItemID = item.FindControl("lblItemID") as HiddenField;
                var lblItemName = item.FindControl("lblItemName") as Label;
                var lblSalePrice = item.FindControl("lblQty") as Label;
                var lblShipQty = item.FindControl("lblQty") as Label;
                var txtReturnqty = item.FindControl("txtShipQuantity") as TextBox;
                string txtqty = txtReturnqty.Text;
                if (txtqty == "")
                {
                    lblChkHeader.Visible = true;
                }
               else
                {

                    int res = 0;
                    //Return Header
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand InsertReturnHeader = new SqlCommand("InsertReturnHeader_sp", con);
                    InsertReturnHeader.Parameters.AddWithValue("@InvoiceId", lblInvoiceID.Text);
                    InsertReturnHeader.Parameters.AddWithValue("@SaleOrderId", Request.QueryString["SaleOrderID"]);
                    InsertReturnHeader.Parameters.AddWithValue("@CustomerId", lblCustomerID.Text);
                    DateTime date = DateTime.Now;
                    InsertReturnHeader.Parameters.AddWithValue("@ReturnDate", txtReturnDate.Text);
                    InsertReturnHeader.Parameters.AddWithValue("@CreatedDate", date);
                    InsertReturnHeader.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                    InsertReturnHeader.Parameters.AddWithValue("@IsDeleted", 0);
                    InsertReturnHeader.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        res = InsertReturnHeader.ExecuteNonQuery();
                        lblErorr.Visible = true;
                        lblErorr.Text = "Returen Header Inserted Successfully";
                        lblErorr.CssClass = "alert alert-success";
                    }
                    catch (Exception ex)
                    {
                        lblErorr.Visible = true;
                        lblErorr.Text = "Errorr: " + ex.Message;
                        lblErorr.CssClass = "alert alert-danger";
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            
            foreach (RepeaterItem item in rReturn.Items)
            {
                var lblItemID = item.FindControl("lblItemID") as HiddenField;
                var lblItemName = item.FindControl("lblItemName") as Label;
                var lblSalePrice = item.FindControl("lblQty") as Label;
                var txtReturnqty = item.FindControl("txtShipQuantity") as TextBox;
                var lblShipQty = item.FindControl("lblQty") as Label;
                var lblSoDetail = item.FindControl("lblSaleDetailId") as HiddenField;

                string one = txtReturnqty.Text;
                string two = lblShipQty.Text;


                if (one == "")
                {
                    txtReturnqty.Text = "0";
                }

                if (Convert.ToInt32(txtReturnqty.Text) > Convert.ToInt32(lblShipQty.Text))
                {
                    lblChkQty.Visible = true;
                }

                else
                {
                    if (Convert.ToInt32(txtReturnqty.Text) > 0 && one != "")
                    {
                        SqlConnection con = new SqlConnection(cs);
                        SqlCommand InserRetuernDetails = new SqlCommand("InsertReturnDetail_sp", con);
                        DateTime date = DateTime.Now;
                       // InserRetuernDetails.Parameters.AddWithValue("@ReturnId", res);
                        InserRetuernDetails.Parameters.AddWithValue("@ItemId", lblItemID.Value);
                        InserRetuernDetails.Parameters.AddWithValue("@ItemName", lblItemName.Text);
                        InserRetuernDetails.Parameters.AddWithValue("@SalePrice", lblSalePrice.Text);
                        InserRetuernDetails.Parameters.AddWithValue("@SaleOrderId", Request.QueryString["SaleOrderID"]);
                        InserRetuernDetails.Parameters.AddWithValue("@SaleDetailID", lblSoDetail.Value);
                        InserRetuernDetails.Parameters.AddWithValue("@CreatedDate", date);
                        InserRetuernDetails.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                        InserRetuernDetails.Parameters.AddWithValue("@IsDeleted", 0);
                        InserRetuernDetails.Parameters.AddWithValue("@ReturnQuantity", txtReturnqty.Text);

                        InserRetuernDetails.CommandType = CommandType.StoredProcedure;


                        con.Open();
                        InserRetuernDetails.ExecuteNonQuery();
                        lblErorr.Text = "Returen Details Inserted Successfully";
                        lblErorr.CssClass = "alert alert-success";
                        Response.Redirect("../SaleOrder/SaleOrder.aspx");
                    }

                    //try
                    //{

                    //}
                    //catch (Exception ex)
                    //{
                    //    lblErorr.Visible = true;
                    //    lblErorr.Text = "Errorr: " + ex.Message;
                    //    lblErorr.CssClass = "alert alert-danger";

                    //}
                    //finally
                    //{
                    //    con.Close();
                    //}
                }
                lblchk.Visible = true;
            }

        }
    }
}