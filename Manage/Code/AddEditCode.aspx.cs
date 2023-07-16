using AccountApp.Manage.CodeType;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountApp;

namespace AccountApp.Manage.Code
{
    public partial class AddEditCode : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Code";
                    Session["AddOrUpdate"] = "Update";
                    CodeType();
                    populate();
                    DropDownList1.Items.Insert(0, new ListItem("--Select CodeType--", "0"));

                }
                else
                {
                    Session["breadCrum"] = "Add Code";
                    Session["AddOrUpdate"] = "Add";
                    CodeType();
                    DropDownList1.Items.Insert(0, new ListItem("--Select CodeType--", "0"));


                }
            }

        }
        void CodeType()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("browseCodeTypeByCodeType_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
          
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "NAME";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Code_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtCodeValue.Text = dt.Rows[0]["CodeValue"].ToString();
            txtCodeShortValue.Text = dt.Rows[0]["CodeShortValue"].ToString();
            DropDownList1.SelectedValue = dt.Rows[0]["CodeTypeID"].ToString();
            hdn.Value = dt.Rows[0]["Id"].ToString();
            btnAddEdit.Text = "Update";
            btnAddEdit.CssClass = "btn btn-dark";
        }
        protected void btnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Code_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime Date = DateTime.Now;
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@CodeTypeID", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@CodeShortValue", txtCodeShortValue.Text);
                cmd.Parameters.AddWithValue("@CodeValue", txtCodeValue.Text);
                cmd.Parameters.AddWithValue("@ModifyBy", UtilityFunctions.GetCurrentUserName());
                cmd.Parameters.AddWithValue("@ModifyDate", Date);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Code.aspx");




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
                DateTime Date = DateTime.Now;
                SqlCommand cmd = new SqlCommand("Code_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodeTypeID", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@CodeShortValue", txtCodeShortValue.Text);
                cmd.Parameters.AddWithValue("@CodeValue", txtCodeValue.Text);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cmd.Parameters.AddWithValue("@createdDate", Date);
               cmd.Parameters.AddWithValue("@CreatedBy", UtilityFunctions.GetCurrentUserName());
               cmd.Parameters.AddWithValue("@ModifyDate", "");
               cmd.Parameters.AddWithValue("@ModifyBy", "");
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted SuccessFully";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Code.aspx");
                }
                catch(Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error - "+ ex.Message;
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