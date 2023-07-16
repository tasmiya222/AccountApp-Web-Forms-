using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.PurchaseOrderDetail
{
    public partial class AddEditPurchaseOrderDetail : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["PurchaseOrderID"] != null)
                {
                    Session["breadCrum"] = "Add PurchaseOrder Detail";
                    Session["AddOrUpdate"] = "Add ";
                    ItemID();
                    DropItemID.Items.Insert(0, new ListItem("---Select Items", "0"));

                }
                else
                {
                    Session["breadCrum"] = "Update PurchaseOrder Detail";
                    Session["AddOrUpdate"] = "Update ";
                    ItemID();
                    Populate();
                    DropItemID.Items.Insert(0, new ListItem("---Select Items", "0"));
                }
            }
        }
        void ItemID()
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
        void Populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand GetData = new SqlCommand("PurchaseOrderDetail_Crud", con);
            GetData.Parameters.AddWithValue("@Action", "GETBYID");
            GetData.Parameters.AddWithValue("@PurchaseOrderLineID", Request.QueryString["id"]);
            GetData.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(GetData);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            DropItemID.SelectedValue = dt.Rows[0]["ItemID"].ToString();
            hdn.Value = dt.Rows[0]["PurchaseOrderLineID"].ToString();
            BtnAddOrEdit.Text = "Update";
            BtnAddOrEdit.CssClass = "btn btn-dark";
        }
        protected void BtnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["PurchaseOrderID"] != null)
            {
                DateTime Date = DateTime.Now;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand InsertPO = new SqlCommand("PurchaseOrderDetail_Crud", con);
                InsertPO.Parameters.AddWithValue("@Action", "INSERT");
                InsertPO.CommandType = CommandType.StoredProcedure;
                InsertPO.Parameters.AddWithValue("@PurchaseOrderID", Request.QueryString["PurchaseOrderID"]);
                InsertPO.Parameters.AddWithValue("@ItemID", DropItemID.SelectedValue);
                InsertPO.Parameters.AddWithValue("@ItemName", DropItemID.SelectedItem.Text);
                InsertPO.Parameters.AddWithValue("@Description", txtDescription.Text);
                InsertPO.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                InsertPO.Parameters.AddWithValue("@PurchaseCost", txtPurchaseCost.Text);
                InsertPO.Parameters.AddWithValue("@CreatedDate", Date);
                InsertPO.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                InsertPO.Parameters.AddWithValue("@IsDeleted", 0);
                InsertPO.Parameters.AddWithValue("@IsReceived", 1);
                InsertPO.Parameters.AddWithValue("@ModifyBy", "");
                InsertPO.Parameters.AddWithValue("@ModifyDate", "");
                try
                {
                    con.Open();
                    InsertPO.ExecuteNonQuery();
                    lblError.Visible = false;
                    lblError.Text = "PurchaseOrder Details Inserted";
                    lblError.CssClass = "alert alert-success";
                    Response.Redirect("PurchaseOrderDetail.aspx");

                }
                catch (Exception ex)
                {
                    lblError.Visible = false;
                    lblError.Text = "Error- "+ ex.Message;
                    lblError.CssClass = "alert alert-danger";

                }
                finally
                {
                    con.Close();
                }
            }
            else if (Request.QueryString["id"] != null)
            {
                DateTime Date = DateTime.Now;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand UpdatetPO = new SqlCommand("PurchaseOrderDetail_Crud", con);
                UpdatetPO.Parameters.AddWithValue("@Action", "UPDATE");
                UpdatetPO.Parameters.AddWithValue("@PurchaseOrderLineID", Request.QueryString["id"]);
                UpdatetPO.CommandType = CommandType.StoredProcedure;
                UpdatetPO.Parameters.AddWithValue("@ItemID", DropItemID.SelectedValue);
                UpdatetPO.Parameters.AddWithValue("@ItemName", DropItemID.SelectedItem.Text);
                UpdatetPO.Parameters.AddWithValue("@Description", txtDescription.Text);
                UpdatetPO.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                UpdatetPO.Parameters.AddWithValue("@PurchaseCost", txtPurchaseCost.Text);
                UpdatetPO.Parameters.AddWithValue("@ModifyDate", Date);
                UpdatetPO.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName().ToString());
                
                
                try
                {
                    con.Open();
                    UpdatetPO.ExecuteNonQuery();
                    lblError.Visible = false;
                    lblError.Text = "PurchaseOrder Details Updated";
                    lblError.CssClass = "alert alert-success";
                    Response.Redirect("PurchaseOrderDetail.aspx");
                }
                catch (Exception ex)
                {
                    lblError.Visible = false;
                    lblError.Text = "Error- " + ex.Message;
                    lblError.CssClass = "alert alert-danger";

                }
                finally
                {
                    con.Close();
                }
            }
        }

    
        protected void DropItemID_SelectedIndexChanged1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand GetData = new SqlCommand("GetItemDetailByItemID_sp", con);
            GetData.Parameters.AddWithValue("@Id", DropItemID.SelectedItem.Value);
            GetData.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(GetData);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.Rows[0];
            txtPurchaseCost.Text = dr["PurchasePrice"].ToString();
        }
    }
}