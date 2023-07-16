using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountApp;
using AccountApp.Admin.Items;

namespace AccountApp.Admin.Delivered
{
    public partial class DeliveredOrder : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SaleOrderID"] != null)
                {
                    BindRepeater();
                }
            }

            SqlConnection sql = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetCustomerIDAndSODate", sql);
            cmd.Parameters.AddWithValue("@SOId", Request.QueryString["SaleOrderID"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.Rows[0];
                
            lblSODate.Text = dr["SaleOrderDate"].ToString();
            lblCustomerID.Text = dr["CustomerID"].ToString();
        }
        void BindRepeater()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("browseDeliveredDetailsBySO_sp", con);
            cmd.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["SaleOrderID"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rDelivered.DataSource = dt;
            rDelivered.DataBind();
            
        }


        protected void BtnShip_Click(object sender, EventArgs e)
        {
            
            foreach (RepeaterItem item in rDelivered.Items)
            {
                var txtShipQty = item.FindControl("txtShipQty") as TextBox;
               string  Ship = txtShipQty.Text;
           
                if (Ship == "")
                {
                    lblChkHeader.Visible = true;
                }

                else
                {
                    int res = 0;
                    //Invoice Header Data Insert
                    SqlConnection con = new SqlConnection(cs);
                    DateTime Date = DateTime.Now;
                    SqlCommand InsertInvoice = new SqlCommand("InsertInvoiceHeader", con);
                    InsertInvoice.CommandType = CommandType.StoredProcedure;
                    InsertInvoice.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["SaleOrderID"]);
                    InsertInvoice.Parameters.AddWithValue("@CustomerID", lblCustomerID.Text);
                    InsertInvoice.Parameters.AddWithValue("@SaleOrderDate", lblSODate.Text);
                    InsertInvoice.Parameters.AddWithValue("@Status", "");
                    InsertInvoice.Parameters.AddWithValue("@Rent", Convert.ToDecimal(0));
                    InsertInvoice.Parameters.AddWithValue("@Labour", Convert.ToDecimal(0));
                    InsertInvoice.Parameters.AddWithValue("@Discount", Convert.ToDecimal(0));
                    InsertInvoice.Parameters.AddWithValue("@InvoiceDate", Date);
                    InsertInvoice.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                    InsertInvoice.Parameters.AddWithValue("@CreatedDate", Date);
                    InsertInvoice.Parameters.AddWithValue("@ModifyBy", "");
                    InsertInvoice.Parameters.AddWithValue("@ModifyDate", "");
                    InsertInvoice.Parameters.AddWithValue("@IsDeleted", 0);
                    SqlCommand command = new SqlCommand("InvoiceHeaderByLastID_sp", con);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //if (dt.Rows.Count >= 1)
                    //{
                    //    int id = Convert.ToInt32(dt.Rows[0]["InvoiceID"]);
                    //    decimal PurchaseCost = Convert.ToDecimal(dt.Rows[0]["PurchaseCost"]);
                    //    decimal quantity = Convert.ToDecimal(dt.Rows[0]["Quantity"]);
                    //    decimal totalamount = PurchaseCost * quantity;
                    //    InsertInvoice.Parameters.AddWithValue("@totalamount", totalamount);

                    //}

                    try
                    {
                        con.Open();
                        res = InsertInvoice.ExecuteNonQuery();
                       // Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>alert('inserted')</script>");


                    }
                    catch (Exception ex)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>alert('" + ex.Message + "')</script>");

                    }

                    finally
                    {
                        con.Close();
                    }
                }
            }
            


            foreach (RepeaterItem item in rDelivered.Items)
            {
                var ItemID = item.FindControl("HdnItemID") as HiddenField;
                var Description = item.FindControl("HdnDescription") as HiddenField;
                var Price = item.FindControl("HdnPrice") as HiddenField;
                var SaleOrderLineID = item.FindControl("HdnSoDetailsID") as HiddenField;
                var txtShipQty = item.FindControl("txtShipQty") as TextBox;
                var ItemName = item.FindControl("lblItem") as Label;
                var LastPurchaseCost = item.FindControl("HdnLastPurchaseCost") as HiddenField;
                var DiscountRupee = item.FindControl("HdnDiscountRupee") as HiddenField;
                var Qty = item.FindControl("lblQty") as Label;
                var SaleOrderDate = item.FindControl("lblSODate") as Label;
                var SaleOrderId = item.FindControl("lblSOId") as Label;
                string shipqty = txtShipQty.Text;
                string lblQty = Qty.Text;

                if (shipqty == "")
                {
                    txtShipQty.Text = "0";
                }

                if (Convert.ToDecimal(txtShipQty.Text) > Convert.ToDecimal(Qty.Text))
                {
                    lblqty.Visible = true;
                }

                else
                {
                    if (Convert.ToDecimal(txtShipQty.Text) > 0 && shipqty != "")
                    {
                        SqlConnection con1 = new SqlConnection(cs);
                        DateTime date = DateTime.Now;
                        SqlCommand cmd = new SqlCommand("InsertSOShipDetailsFromDelivered", con1);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOId", Request.QueryString["SaleOrderID"]);
                        cmd.Parameters.AddWithValue("@SOdetailId", SaleOrderLineID.Value);
                        cmd.Parameters.AddWithValue("@ShipQuantity", txtShipQty.Text);
                        cmd.Parameters.AddWithValue("@IsActive", 1);
                        cmd.Parameters.AddWithValue("@IsInvoiceCreated", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName());
                        cmd.Parameters.AddWithValue("@ModifyBy", "");
                        cmd.Parameters.AddWithValue("@OrderDate", date);
                        cmd.Parameters.AddWithValue("@CreatedDate", date);
                        cmd.Parameters.AddWithValue("@DeliveredDate", date);
                        cmd.Parameters.AddWithValue("@ModifyDate", "");
                        SqlCommand InsertInvoiceDetails = new SqlCommand("InsertInvoiceDetails", con1);
                        InsertInvoiceDetails.CommandType = CommandType.StoredProcedure;
                        InsertInvoiceDetails.Parameters.AddWithValue("@ItemID", ItemID.Value);
                        InsertInvoiceDetails.Parameters.AddWithValue("@ItemName", ItemName.Text);
                        InsertInvoiceDetails.Parameters.AddWithValue("@Description", Description.Value);
                        InsertInvoiceDetails.Parameters.AddWithValue("@Status", "");
                        InsertInvoiceDetails.Parameters.AddWithValue("@Quantity", Qty.Text);
                        InsertInvoiceDetails.Parameters.AddWithValue("@Price", Price.Value);
                        InsertInvoiceDetails.Parameters.AddWithValue("@PurchaseCost", LastPurchaseCost.Value);
                        InsertInvoiceDetails.Parameters.AddWithValue("@SalePrice", Price.Value);
                        InsertInvoiceDetails.Parameters.AddWithValue("@Rent", Convert.ToDecimal(0));
                        InsertInvoiceDetails.Parameters.AddWithValue("@DeliveredDate", date);
                        InsertInvoiceDetails.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                        InsertInvoiceDetails.Parameters.AddWithValue("@CreatedDate", date);
                        InsertInvoiceDetails.Parameters.AddWithValue("@ModifyBy", "");
                        InsertInvoiceDetails.Parameters.AddWithValue("@ModifyDate", "");
                        InsertInvoiceDetails.Parameters.AddWithValue("@IsDeleted", 0);
                        InsertInvoiceDetails.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["SaleOrderID"]);
                        SqlCommand cmd1 = new SqlCommand("InvoiceHeaderByLastID_sp", con1);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            int id = Convert.ToInt32(dt.Rows[0]["InvoiceID"]);

                            InsertInvoiceDetails.Parameters.AddWithValue("@InvoiceID", id);
                        }

                        try
                        {
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            InsertInvoiceDetails.ExecuteNonQuery();
                            cmd1.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>alert('inserted')</script>");
                            Response.Redirect("../SaleOrder/SaleOrder.aspx");

                        }
                        catch (Exception ex)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>alert('" + ex.Message + "')</script>");

                        }

                        finally
                        {
                            con1.Close();
                        }
                    }
                }
            }
        }
    }
}