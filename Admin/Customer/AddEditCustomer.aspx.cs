using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Customer
{
    public partial class AddEditCustomer : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        public new int ID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Customer";
                    Session["AddOrUpdate"] = "Update";
                    popluate();
                }
                else
                {
                    Session["breadCrum"] = "Add Customer";
                    Session["AddOrUpdate"] = "Add";

                }
            }
        }
        void popluate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Customer_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            txtFullName.Text = dt.Rows[0]["FullName"].ToString();
            txtPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtProvince.Text = dt.Rows[0]["Province"].ToString();
            txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString();
            txtAddre1.Text = dt.Rows[0]["Address1"].ToString();
            txtAddre2.Text = dt.Rows[0]["Address2"].ToString();
            txtOpeningBalance.Text = dt.Rows[0]["OpeningBalance"].ToString();
            hdn.Value = dt.Rows[0]["Id"].ToString();
            BtnAddEdit.Text = "Update";
            BtnAddEdit.CssClass = "btn btn-dark";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Customer_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address1", txtAddre1.Text);
                cmd.Parameters.AddWithValue("@Address2", txtAddre2.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                cmd.Parameters.AddWithValue("@openingBalance", txtOpeningBalance.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Customer.aspx");
           



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
                SqlCommand cmd = new SqlCommand("Customer_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address1", txtAddre1.Text);
                cmd.Parameters.AddWithValue("@Address2", txtAddre2.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                cmd.Parameters.AddWithValue("@openingBalance", txtOpeningBalance.Text);
                SqlCommand cmd1 = new SqlCommand("CustomerCodeByLastID_sp", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["Id"]) + 1;
                    
                    cmd.Parameters.AddWithValue("@CustomerCode", id);
                }

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Customer.aspx");



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