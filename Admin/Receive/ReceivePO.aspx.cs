using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Receive
{
    public partial class ReceivePO : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["PoId"] != null)
                {
                    Session["breadCrum"] = "PurchaseOrder Recevied";
                    BindData();
                }


            }
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand ShowData = new SqlCommand("browseReceivedDetailsByPO_sp", con);
            ShowData.Parameters.AddWithValue("@PurchaseOrderID", Request.QueryString["PoId"]);
            ShowData.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(ShowData);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rReceivedPo.DataSource = dt;
            rReceivedPo.DataBind();
        }

        protected void BtnShip_Click(object sender, EventArgs  e)
        {
            if (Request.QueryString["PoId"] != null)
            {
                foreach (RepeaterItem item in rReceivedPo.Items)
                {
                    var lblItemId = item.FindControl("lblItemID") as HiddenField;
                    var lblPurchaseOrderLineID = item.FindControl("lblPurchaseOrderLineID") as HiddenField;
                    var lblReceiveQty = item.FindControl("lblReceivQty") as TextBox;
                    var txtReceiveDate = item.FindControl("txtReceiveDate") as TextBox;
                    var lblqty = item.FindControl("lblqty") as Label;
                    DateTime date = DateTime.Now;
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand InsertPoId = new SqlCommand("InsertInventoryPO_sp", con);
                    InsertPoId.Parameters.AddWithValue("@PurchaseOrderID", Request.QueryString["PoId"]);
                    InsertPoId.Parameters.AddWithValue("@PurchaseOrderLineID", lblPurchaseOrderLineID.Value);
                    InsertPoId.Parameters.AddWithValue("@isIgnore", 0);
                    InsertPoId.Parameters.AddWithValue("@ItemID", lblItemId.Value);
                    InsertPoId.Parameters.AddWithValue("@Quantity", lblqty.Text);
                    InsertPoId.Parameters.AddWithValue("@createDate", date);
                    InsertPoId.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                    InsertPoId.Parameters.AddWithValue("@ModifyDate", "");
                    InsertPoId.Parameters.AddWithValue("@ModifyBy", "");
                    InsertPoId.Parameters.AddWithValue("@IsDeleted", "");
                    InsertPoId.Parameters.AddWithValue("@InventoryDate", date);
                    InsertPoId.CommandType = CommandType.StoredProcedure;
                    SqlCommand InsertReceive = new SqlCommand("InsertReceive_sp", con);
                    InsertReceive.Parameters.AddWithValue("@PurchaseOrderID", Request.QueryString["POId"]);
                    InsertReceive.Parameters.AddWithValue("@PurchaseOrderLineID", lblPurchaseOrderLineID.Value);
                    InsertReceive.Parameters.AddWithValue("@ReceivedQty", lblReceiveQty.Text);
                    InsertReceive.Parameters.AddWithValue("@ReceivedDate", txtReceiveDate.Text);
                    InsertReceive.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                    InsertReceive.Parameters.AddWithValue("@ItemID", "");
                    InsertReceive.Parameters.AddWithValue("@ItemName","");
                    InsertReceive.Parameters.AddWithValue("@PurchasePrice","" );
                    InsertReceive.Parameters.AddWithValue("@TotalPurchaseReturn", "");
                    InsertReceive.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        InsertPoId.ExecuteNonQuery();
                        InsertReceive.ExecuteNonQuery();
                       // Response.Redirect("../PurchaseOrder/PurchaseOrder.aspx");
                    }
                    catch (Exception ex)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>alert(" + ex.Message + ")</script>");
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
          
        }
    }
}