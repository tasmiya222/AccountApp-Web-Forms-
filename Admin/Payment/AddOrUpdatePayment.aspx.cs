using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Payment
{
    public partial class AddOrUpdatePayment : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        private decimal total_amount;
        private int CustomerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PaymentID"] != null)
                {
                    Session["breadCrum"] = "Update Payment";
                    populate();
                    BankDropDown();
                    dropBank.Items.Insert(0, new ListItem("--Select Bank--", "0"));
                    InvoiceDropDown();
                    InvoiceNo.Items.Insert(0, new ListItem("--Select Invoice No--", "0"));

                }
                else
                {
                    Session["breadCrum"] = " Add Payment";
                    BankDropDown();
                    dropBank.Items.Insert(0, new ListItem("--Select Bank--", "0"));
                    InvoiceDropDown();
                    InvoiceNo.Items.Insert(0, new ListItem("--Select Invoice No--", "0"));

                }

            }
        }
        void BankDropDown()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand BankDetail = new SqlCommand("GetBankDetailByBank", con);
            BankDetail.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(BankDetail);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dropBank.DataTextField = "BankName";
            dropBank.DataValueField = "Id";
            dropBank.DataSource = dt;
            dropBank.DataBind();
        }
        void InvoiceDropDown()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand InvoiceDetail = new SqlCommand("GetInvoiceDetailsByInvoiceHeader", con);
            InvoiceDetail.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(InvoiceDetail);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 1)
            {
                int CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);

                CustomerId = CustomerID;
            }
            InvoiceNo.DataTextField = "InvoiceID";
            InvoiceNo.DataValueField = "InvoiceID";
            InvoiceNo.DataSource = dt;
            InvoiceNo.DataBind();

        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetDetailsByID", con);
            cmd.Parameters.AddWithValue("@PaymentId", Request.QueryString["PaymentID"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.Rows[0];
            InvoiceNo.SelectedValue = dr["InvoiceID"].ToString();
            PaymentType.SelectedItem.Text = dr["PaymentType"].ToString();
            Amount.Text = dr["Amount"].ToString();
            //lblOnlineOrCheck.Text = dr["CheckNo"].ToString();
            //dropBank.SelectedValue = dr["BankID"].ToString();
            hdn.Value = dt.Rows[0]["PaymentID"].ToString();
            txtNote.Visible = false;
            BtnAddEdit.Text = "Update";
            BtnAddEdit.CssClass = "btn btn-dark";
        }
        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["PaymentID"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand UpdatePayment = new SqlCommand("UpdatePaymentDetails", con);
                UpdatePayment.CommandType = CommandType.StoredProcedure;
                DateTime Date = DateTime.Now;
                UpdatePayment.Parameters.AddWithValue("@PaymentID", Request.QueryString["PaymentID"]);
                UpdatePayment.Parameters.AddWithValue("@PaymentType", PaymentType.SelectedItem.ToString());
                UpdatePayment.Parameters.AddWithValue("@BankID", dropBank.SelectedValue != "" ? null : dropBank.SelectedValue);
                UpdatePayment.Parameters.AddWithValue("@CheckNo", lblOnlineOrCheck.Text != "" ? null : lblOnlineOrCheck.Text);
                UpdatePayment.Parameters.AddWithValue("@Amount", Convert.ToDecimal(Amount.Text));
                UpdatePayment.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName().ToString());
                UpdatePayment.Parameters.AddWithValue("@ModifyDate", Date);
                UpdatePayment.Parameters.AddWithValue("@InvoiceId", InvoiceNo.SelectedValue);
                try
                {
                    con.Open();
                    UpdatePayment.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated SuccessFully";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Payment.aspx");
                }

                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error : " + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                decimal txtAmount = Convert.ToDecimal(Amount.Text);
                decimal chkamount = Convert.ToDecimal(total_amount);
                if (txtAmount >= chkamount)
                {
                    lblAmountError.Visible = true;
                }
                else
                {
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand InsertPayment = new SqlCommand("InsertPaymentDetail", con);
                    InsertPayment.CommandType = CommandType.StoredProcedure;
                    DateTime date = DateTime.Now;
                    InsertPayment.Parameters.AddWithValue("@VendorID", 0);
                    InsertPayment.Parameters.AddWithValue("@CustomerID", 0);
                    InsertPayment.Parameters.AddWithValue("@PaymentDate", PaymentDate.Text);
                    InsertPayment.Parameters.AddWithValue("@PaymentType", PaymentType.SelectedItem.ToString());
                    InsertPayment.Parameters.AddWithValue("@BankID", dropBank.SelectedValue != "" ? null : dropBank.SelectedValue);
                    InsertPayment.Parameters.AddWithValue("@CheckNo", lblOnlineOrCheck.Text != "" ? null : lblOnlineOrCheck.Text);
                    InsertPayment.Parameters.AddWithValue("@Amount", Convert.ToDecimal(Amount.Text));
                    InsertPayment.Parameters.AddWithValue("@Description", txtNotes.Text);
                    InsertPayment.Parameters.AddWithValue("@CreatedDate", date);
                    InsertPayment.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                    InsertPayment.Parameters.AddWithValue("@ModifyBy", "");
                    InsertPayment.Parameters.AddWithValue("@ModifyDate", "");
                    InsertPayment.Parameters.AddWithValue("@IsDeleted", 0);
                    InsertPayment.Parameters.AddWithValue("@RecordType", "Customer Payment".ToString());
                    InsertPayment.Parameters.AddWithValue("@CustomerName", " ");
                    InsertPayment.Parameters.AddWithValue("@VendorName", " ");
                    InsertPayment.Parameters.AddWithValue("@InvoiceId", InvoiceNo.SelectedValue);
                    InsertPayment.Parameters.AddWithValue("@PurchaseOrderId", 0);
                    try
                    {
                        con.Open();
                        InsertPayment.ExecuteNonQuery();
                        lblMsg.Visible = true;
                        lblMsg.Text = "Inserted SuccessFully";
                        lblMsg.CssClass = "alert alert-success";
                        Response.Redirect("Payment.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Error : " + ex.Message;
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        protected void PaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentType.SelectedItem.Value == "Cash")
            {
                pnlTextBox.Visible = false;
            }
            else
            {
                pnlTextBox.Visible = true;
            }
        }

        protected void InvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand InvoiceDetail = new SqlCommand("GetInvoiceDetailsByInvoiceHeader", con);
            InvoiceDetail.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(InvoiceDetail);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal total = Convert.ToDecimal(dt.Rows[0]["totalAmount"]);

                total_amount = total;
            }
            if (InvoiceNo.SelectedItem.Value == InvoiceNo.SelectedItem.Value)
            {
                Session["Total_amount"] = total_amount;
            }
            else
            {
                Session["Total_amount"] = 0;
            }
        }
    }
}