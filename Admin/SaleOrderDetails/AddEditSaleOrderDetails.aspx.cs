using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.SaleOrderDetails
{
    public partial class AddEditSaleOrderDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        private string SaleLineiD;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SaleOrderID"] != null)
                {


                    Session["AddOrUpdate"] = "Add";
                    Session["breadCrum"] = "Add SaleOrderDetails";

                    DropItemId();
                    DropItemID.Items.Insert(0, new ListItem("--Select ItemID--", "0"));


                }
                else
                {

                    Session["AddOrUpdate"] = "Update";
                    Session["breadCrum"] = "Update SaleOrderDetails";
                    populate();

                    DropItemId();
                    DropItemID.Items.Insert(0, new ListItem("--Select ItemID--", "0"));

                }
            }
        }
        void DropItemId()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("BrowseItemIDByItems_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropItemID.DataValueField = "ID";
            DropItemID.DataTextField = "Name";
            DropItemID.DataSource = dt;
            DropItemID.DataBind();

        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SaleOrderDetails_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SaleOrderLineID", Request.QueryString["id"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            SaleLineiD = dt.Rows[0]["SaleOrderLineID"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            txtPrice.Text = dt.Rows[0]["Price"].ToString();
            txtLastPurchaseCost.Text = dt.Rows[0]["LastPurchaseCost"].ToString();
            DropItemID.SelectedValue = dt.Rows[0]["ItemID"].ToString();
            txtDiscount.Text = dt.Rows[0]["Discount"].ToString();
            txtDiscountRupee.Text = dt.Rows[0]["DiscountRupee"].ToString();
            hdn.Value = dt.Rows[0]["SaleOrderID"].ToString();
            BtnAddOrEdit.Text = "Update";
            BtnAddOrEdit.CssClass = "btn btn-dark";
        }
        protected void BtnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SaleOrderID"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("select quantity from PurchaseOrderDetail where ItemID ="+ DropItemID.SelectedValue + "", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                    decimal Qty = Convert.ToDecimal(dr["quantity"]);
                    decimal txtQty = Convert.ToDecimal(txtQuantity.Text);
                    if (txtQty > Qty)
                    {
                        lblCkhPurchase.Visible = true;
                    }
                
                else
                {
                    int res = 0;
                    SqlCommand InsertData = new SqlCommand("SaleOrderDetails_Crud", con);
                    InsertData.Parameters.AddWithValue("@Action", "INSERT");
                    InsertData.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["SaleOrderID"]);
                    InsertData.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                    InsertData.Parameters.AddWithValue("@ItemID", DropItemID.SelectedValue);
                    InsertData.Parameters.AddWithValue("@Price", txtPrice.Text);
                    InsertData.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    InsertData.Parameters.AddWithValue("@Description", txtDescription.Text);
                    InsertData.Parameters.AddWithValue("@LastPurchaseCost", txtLastPurchaseCost.Text);
                    InsertData.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                    InsertData.Parameters.AddWithValue("@DiscountRupee", txtDiscountRupee.Text);
                    InsertData.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                    DateTime date = DateTime.Now;
                    InsertData.Parameters.AddWithValue("@CreatedDate", date);
                    InsertData.Parameters.AddWithValue("@ModifyBy", "");
                    InsertData.Parameters.AddWithValue("@ModifyDate", "");
                    InsertData.Parameters.AddWithValue("@IsActive", 1);
                    InsertData.Parameters.AddWithValue("@IsDelivered", 1);
                    InsertData.Parameters.AddWithValue("@IsDeleted", 0);
                    InsertData.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        con.Open();
                        res = Convert.ToInt32(InsertData.ExecuteNonQuery());
                        SqlCommand InsertInventory = new SqlCommand("InsertInventorySO_sp", con);
                        InsertInventory.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["SaleOrderID"]);
                        InsertInventory.Parameters.AddWithValue("@SaleOrderLineID", res);
                        InsertInventory.Parameters.AddWithValue("@ItemID", DropItemID.SelectedValue);
                        InsertInventory.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        InsertInventory.Parameters.AddWithValue("@createDate", date);
                        InsertInventory.Parameters.AddWithValue("@InventoryDate", DateTime.Now);
                        InsertInventory.Parameters.AddWithValue("@IsDeleted", 0);
                        InsertInventory.Parameters.AddWithValue("@IsIgnore", 0);
                        InsertInventory.Parameters.AddWithValue("@createdBy", UtilityFunctions.GetCurrentUserName().ToString());
                        InsertInventory.CommandType = CommandType.StoredProcedure;
                        InsertInventory.ExecuteNonQuery();
                        lblError.Visible = true;
                        lblError.Text = "Inserted SuccessFully";
                        lblError.CssClass = "alert alert-success";
                        Response.Redirect("SaleOrdeDetails.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error - " + ex.Message;
                        lblError.CssClass = "alert alert-danger";
                    }
                    finally
                    {
                        con.Close();
                    }


                }
            }
            else if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand UpdateData = new SqlCommand("SaleOrderDetails_Crud", con);
                UpdateData.Parameters.AddWithValue("@Action", "UPDATE");
                UpdateData.Parameters.AddWithValue("@SaleOrderLineID", Request.QueryString["id"]);
                UpdateData.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                UpdateData.Parameters.AddWithValue("@ItemID", DropItemID.SelectedValue);
                UpdateData.Parameters.AddWithValue("@Price", txtPrice.Text);
                UpdateData.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                UpdateData.Parameters.AddWithValue("@Description", txtDescription.Text);
                UpdateData.Parameters.AddWithValue("@LastPurchaseCost", txtLastPurchaseCost.Text);
                UpdateData.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                UpdateData.Parameters.AddWithValue("@DiscountRupee", txtDiscountRupee.Text);
                DateTime date = DateTime.Now;
                UpdateData.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName().ToString());
                UpdateData.Parameters.AddWithValue("@ModifyDate", date);
                UpdateData.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    UpdateData.ExecuteNonQuery();
                    lblError.Visible = true;
                    lblError.Text = "Updated SuccessFully";
                    lblError.CssClass = "alert alert-success";
                    Response.Redirect("SaleOrdeDetails.aspx");
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Error - " + ex.Message;
                    lblError.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}