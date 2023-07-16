using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Expenses
{
    public partial class AddOrUpdateExpense : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ExpenseId"] != null)
                {
                    Session["breadCrum"] = "Update Expense";
                    populate();
                    ExpenseDrop();
                    dropExpenses.Items.Insert(0, new ListItem("--Select Expenses Type--", "0"));

                }
                else
                {
                    Session["breadCrum"] = " Add Expense";
                    ExpenseDrop();
                    dropExpenses.Items.Insert(0, new ListItem("--Select Expenses Type--", "0"));
                }

            }
        }
        void ExpenseDrop()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand ExpenseDetail = new SqlCommand("GetExpenses_sp", con);
            ExpenseDetail.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(ExpenseDetail);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dropExpenses.DataTextField = "ExpenseName";
            dropExpenses.DataValueField = "ExpenseID";
            dropExpenses.DataSource = dt;
            dropExpenses.DataBind();
        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetExpenseById", con);
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["ExpenseId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.Rows[0];
            dropExpenses.SelectedValue = dr["ExpenseId"].ToString();
            ExpenseType.SelectedItem.Text = dr["ExpensesType"].ToString();
            Amount.Text = dr["Amount"].ToString();
            hdn.Value = dt.Rows[0]["Id"].ToString();
            txtNote.Visible = false;
            BtnAddEdit.Text = "Update";
            BtnAddEdit.CssClass = "btn btn-dark";
        }
        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ExpenseId"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand UpdateExpense = new SqlCommand("UpdateExpenses", con);
                UpdateExpense.CommandType = CommandType.StoredProcedure;
                DateTime Date = DateTime.Now;
                UpdateExpense.Parameters.AddWithValue("@Id", Request.QueryString["ExpenseId"]);
                UpdateExpense.Parameters.AddWithValue("@ExpensesType", ExpenseType.SelectedItem.ToString());
                UpdateExpense.Parameters.AddWithValue("@BankID",0);
                UpdateExpense.Parameters.AddWithValue("@CheckNo", 0);
                UpdateExpense.Parameters.AddWithValue("@Amount", Convert.ToDecimal(Amount.Text));
                UpdateExpense.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName().ToString());
                UpdateExpense.Parameters.AddWithValue("@ModifyDate", Date);
                UpdateExpense.Parameters.AddWithValue("@ExpenseId", dropExpenses.SelectedValue);
                try
                {
                    con.Open();
                    UpdateExpense.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated SuccessFully";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Expense.aspx");
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
                SqlConnection con = new SqlConnection(cs);
                SqlCommand InsertExpenses = new SqlCommand("InsertExpensesDetail", con);
                InsertExpenses.CommandType = CommandType.StoredProcedure;
                DateTime date = DateTime.Now;

                InsertExpenses.Parameters.AddWithValue("@ExpenseDate",ExpensesDate.Text);
                InsertExpenses.Parameters.AddWithValue("@ExpenseType", ExpenseType.SelectedItem.ToString());
                InsertExpenses.Parameters.AddWithValue("@BankID", 0);
                InsertExpenses.Parameters.AddWithValue("@CheckNo", 0);
                InsertExpenses.Parameters.AddWithValue("@Amount", Convert.ToDecimal(Amount.Text));
                InsertExpenses.Parameters.AddWithValue("@Description", txtNotes.Text);
                InsertExpenses.Parameters.AddWithValue("@CreatedDate", date);
                InsertExpenses.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName().ToString());
                InsertExpenses.Parameters.AddWithValue("@ModifyBy", "");
                InsertExpenses.Parameters.AddWithValue("@ModifyDate", "");
                InsertExpenses.Parameters.AddWithValue("@IsDeleted", 0);
                InsertExpenses.Parameters.AddWithValue("@ExpenseName", dropExpenses.SelectedItem.ToString());
                InsertExpenses.Parameters.AddWithValue("@ExpenseId", dropExpenses.SelectedValue);
                try
                {
                    con.Open();
                    InsertExpenses.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted SuccessFully";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Expense.aspx");
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
}