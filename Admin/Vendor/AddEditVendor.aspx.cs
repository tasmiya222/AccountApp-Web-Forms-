using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Vendor
{
    public partial class AddEditVendor : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Vendor";
                    populate();
                }
                else
                {
                    Session["breadCrum"] = "Add Vendor";
                }
            }
        }

        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Vendor_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtcompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLName.Text = dt.Rows[0]["LastName"].ToString();
            txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtProvince.Text = dt.Rows[0]["Province"].ToString();
            txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString();
            txtAddre1.Text = dt.Rows[0]["Address1"].ToString();
            txtAddre2.Text = dt.Rows[0]["Address2"].ToString();
            txtOpeningBalance.Text = dt.Rows[0]["OpeningBalance"].ToString();
            hdn.Value = dt.Rows[0]["Id"].ToString();
        }
        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Vendor_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@CompanyName", txtcompanyName.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLName.Text);
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
                    Response.Redirect("Vendor.aspx");



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
                int res = 0;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Vendor_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", txtcompanyName.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLName.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address1", txtAddre1.Text);
                cmd.Parameters.AddWithValue("@Address2", txtAddre2.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                cmd.Parameters.AddWithValue("@openingBalance", txtOpeningBalance.Text);
                SqlCommand cmd1 = new SqlCommand("VendorCodeByLastID_sp", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["Id"]) + 1;

                    cmd.Parameters.AddWithValue("@VendorCode", id);
                }

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    lblVendor.Text = res.ToString();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Vendor.aspx");



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