using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Bank
{
    public partial class AddEditBank : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Bank";
                    Session["AddOrUpdate"] = "Update";
                    populate();
                }
                else
                {
                    Session["breadCrum"] = "Add Bank";
                    Session["AddOrUpdate"] = "Add";
                }
            }
        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Bank_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtBankName.Text = dt.Rows[0]["BankName"].ToString();
            txtBankTitle.Text = dt.Rows[0]["BankTitle"].ToString();
            txtOpeningBalance.Text = dt.Rows[0]["OpeningBalance"].ToString();
            txtOpeningBalanceDate.Text = dt.Rows[0]["OpeningBalanceDate"].ToString();
            txtBankAccountNumber.Text = dt.Rows[0]["BankAccountNumber"].ToString();
            txtBranchName.Text = dt.Rows[0]["BranchName"].ToString();
            txtBranchName.Text = dt.Rows[0]["BankAddress"].ToString();
            BtnAddEdit.Text = "Update";
            BtnAddEdit.CssClass = "btn btn-dark";

        }
        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Bank_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
                cmd.Parameters.AddWithValue("@BankTitle", txtBankTitle.Text);
                cmd.Parameters.AddWithValue("@OpeningBalance", txtOpeningBalance.Text);
                cmd.Parameters.AddWithValue("@OpeningBalanceDate", txtOpeningBalanceDate.Text);
                cmd.Parameters.AddWithValue("@BankAccountNumber", txtBankAccountNumber.Text);
                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddress.Text);
                cmd.Parameters.AddWithValue("@BranchName", txtBranchName.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Bank.aspx");




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
                SqlCommand cmd = new SqlCommand("Bank_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime Date = DateTime.Now;
                cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
                cmd.Parameters.AddWithValue("@BankTitle", txtBankTitle.Text);
                cmd.Parameters.AddWithValue("@OpeningBalance", txtOpeningBalance.Text);
                cmd.Parameters.AddWithValue("@OpeningBalanceDate", txtOpeningBalanceDate.Text);
                cmd.Parameters.AddWithValue("@BankAccountNumber", txtBankAccountNumber.Text);
                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddress.Text);
                cmd.Parameters.AddWithValue("@BranchName", txtBranchName.Text);
                cmd.Parameters.AddWithValue("@CreatedDate", Date);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Bank.aspx");




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
        }
    }


}


