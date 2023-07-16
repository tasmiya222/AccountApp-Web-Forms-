using AccountApp.Admin.Customer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Runtime.InteropServices;

namespace AccountApp.Admin.PurchaseOrder
{
    public partial class AddEditPurchaseOrder : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        string POType;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Purchase Order";
                    Session["AddOrUpdate"] = "Update";
                    Populate();
                    DropVendorId();
                    VendorId.Items.Insert(0, new ListItem("--Select Vendor---",""));
                }
                else
                {
                    Session["breadCrum"] = "Add Purchase Order";
                    Session["AddOrUpdate"] = "Add";
                    DropVendorId();
                    VendorId.Items.Insert(0, new ListItem("--Select Vendor---","0"));

                }
            }
        }
        void Populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("PurchaseOrder_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["id"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           txtCounterVendorName.Text = dt.Rows[0]["CounterVendorName"].ToString();
            VendorId.SelectedValue = dt.Rows[0]["VendorID"].ToString();
            txtCounterVendorPhone.Text = dt.Rows[0]["CounterVendorPhone"].ToString();
            POType = dt.Rows[0]["POType"].ToString();
            hdn.Value = dt.Rows[0]["PurchaseOrderID"].ToString();
            BtnAddEdit.Text = "Update";
            BtnAddEdit.CssClass = "btn btn-dark";
        }
        void DropVendorId()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand VendorID = new SqlCommand("BrowseVendorIdByVendor", con);
            SqlDataAdapter sda = new SqlDataAdapter(VendorID);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VendorId.DataValueField = "Id";
            VendorId.DataTextField = "Name";
            VendorId.DataSource = dt;
            VendorId.DataBind();

        }
        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (RadioCash.Checked)
                {
                    POType = "Cash";
                }
                else if (RadioCredit.Checked)
                {
                    POType = "Credit";
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand UpdatePurchase = new SqlCommand("PurchaseOrder_Crud", con);
                UpdatePurchase.Parameters.AddWithValue("@Action", "UPDATE");
                DateTime Date = DateTime.Now;
                UpdatePurchase.CommandType = CommandType.StoredProcedure;
                UpdatePurchase.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName().ToString());
                UpdatePurchase.Parameters.AddWithValue("@ModifyDate", Date);
                UpdatePurchase.Parameters.AddWithValue("@Status", "");
                UpdatePurchase.Parameters.AddWithValue("@VendorID", VendorId.SelectedValue);
                UpdatePurchase.Parameters.AddWithValue("@CounterVendorName", "");
                UpdatePurchase.Parameters.AddWithValue("@CounterVendorPhone", "");
                UpdatePurchase.Parameters.AddWithValue("@POType", POType);
                UpdatePurchase.Parameters.AddWithValue("@PurchaseOrderID", Request.QueryString["id"]);
                try
                {
                    con.Open();
                    UpdatePurchase.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Update Successfully";
                    lblMsg.CssClass= "alert alert-success";
                }
                catch(Exception ex)
                {
                   
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error: "+ ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }


            }
            else
            {
                if (RadioCash.Checked)
                {
                    POType = "Cash";
                }
                else if (RadioCredit.Checked)
                {
                    POType = "Credit";
                }
                DateTime Date = DateTime.Now;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand InsertPurchase = new SqlCommand("PurchaseOrder_Crud", con);
                InsertPurchase.Parameters.AddWithValue("@Action", "INSERT");
                InsertPurchase.CommandType = CommandType.StoredProcedure;
                InsertPurchase.Parameters.AddWithValue("@Status", "");
                InsertPurchase.Parameters.AddWithValue("@CounterVendorName", "");
                InsertPurchase.Parameters.AddWithValue("@CounterVendorPhone", "");
                InsertPurchase.Parameters.AddWithValue("@VendorID", VendorId.SelectedValue);
                InsertPurchase.Parameters.AddWithValue("@POType",POType);
                InsertPurchase.Parameters.AddWithValue("@PurchaseOrderDate",Date);
                InsertPurchase.Parameters.AddWithValue("@IsDeleted",0);
                InsertPurchase.Parameters.AddWithValue("@CreatedDate",Date);
                InsertPurchase.Parameters.AddWithValue("@CreatedBy",UtilityFunctions.GetCurrentUserName().ToString());
                InsertPurchase.Parameters.AddWithValue("@ModifyBy","");
                InsertPurchase.Parameters.AddWithValue("@ModifyDate","");
                try
                {
                    con.Open();
                    InsertPurchase.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted Successfully";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("PurchaseOrder.aspx");
                }
                catch(Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error- "+ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }

            }

        }
    }
}