using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.SaleOrder
{
    public partial class AddEditSaleOrder : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        string SoType;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update SaleOrder";
                    Session["AddOrUpdate"] = "Update";
                    populate();
                    CustomerID();
                    CustomerId.Items.Insert(0, new ListItem("--Select Customer--", "0"));
                }
                else
                {
                    Session["breadCrum"] = "Add SaleOrder";
                    Session["AddOrUpdate"] = "Add";
                    CustomerID();
                    CustomerId.Items.Insert(0, new ListItem("--Select Customer--", "0"));


                }
            }
        }
        void CustomerID()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("BrowseCustomeIDByCustomer", con);
           cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustomerId.DataValueField = "Id";
            CustomerId.DataTextField = "Name";
            CustomerId.DataSource = dt;
            CustomerId.DataBind();
        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SaleOrderHeader_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["id"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtCounterCustomerName.Text = dt.Rows[0]["CounterCustomerName"].ToString();
            CustomerId.SelectedValue = dt.Rows[0]["CustomerId"].ToString();
            txtCounterCustomerPhoneNumber.Text = dt.Rows[0]["CounterCustomerPhoneNumber"].ToString();
            SoType = dt.Rows[0]["SOType"].ToString();
            hdn.Value = dt.Rows[0]["SaleOrderID"].ToString();
            BtnAddEdit.Text = "Update";
            BtnAddEdit.CssClass = "btn btn-dark";
        }

        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (RadioCash.Checked)
                {
                    SoType = "Cash";
                }
                else if (RadioCredit.Checked)
                {
                    SoType = "Credit";
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("SaleOrderHeader_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime Date = DateTime.Now;
                cmd.Parameters.AddWithValue("@SaleOrderID", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId.SelectedValue);
                cmd.Parameters.AddWithValue("@CounterCustomerName", txtCounterCustomerName.Text);
                cmd.Parameters.AddWithValue("@CounterCustomerPhone", txtCounterCustomerPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@SoType", SoType);
                cmd.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName().ToString());
                cmd.Parameters.AddWithValue("@ModifyDate", Date);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("SaleOrder.aspx");




                }
                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error -" + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("SaleOrderHeader_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime Date = DateTime.Now;
                if(RadioCash.Checked)
                {
                    SoType = "Cash";

                }
                else if(RadioCredit.Checked)
                {
                    SoType = "Credit";
                }
                cmd.Parameters.AddWithValue("@SaleOrderDate", Date);
                cmd.Parameters.AddWithValue("@SOType", SoType);
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId.SelectedValue);
                cmd.Parameters.AddWithValue("@CounterCustomerName", txtCounterCustomerName.Text);
                cmd.Parameters.AddWithValue("@CounterCustomerPhone", txtCounterCustomerPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                cmd.Parameters.AddWithValue("@CreatedDate", Date);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("SaleOrder.aspx");
                }
                catch(Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error - " + ex.Message;
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