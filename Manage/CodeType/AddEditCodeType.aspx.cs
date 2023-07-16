using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Manage.CodeType
{
    public partial class AddEditCodeType : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Code Type";
                    populate();
                }
                else
                {
                    Session["breadCrum"] = "Add Code Type";
                }


            }
        }
            void populate()
            {

                SqlConnection con = new SqlConnection(cs);
                //string query = " select * from CodeType where CodeTypeID=@Id";
                SqlCommand cmd = new SqlCommand("CodeType_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "GETBYID");
                cmd.Parameters.AddWithValue("@CodeTypeID", Request.QueryString["id"]);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                txtCodetype.Text = dt.Rows[0]["CodeType"].ToString();

                hdn.Value = dt.Rows[0]["CodeTypeId"].ToString();
            }

            protected void btnAdd_Click(object sender, EventArgs e)
            {
                if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
               // string query = " Update dbo.CodeType SET CodeType= @CodeType where CodeTypeID=@ID";
                SqlCommand cmd = new SqlCommand("CodeType_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@CodeType", txtCodetype.Text);
                cmd.Parameters.AddWithValue("@CodeTypeID", Request.QueryString["id"]);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("CodeType.aspx");



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
                string query = "Insert into CodeType (CodeType) values(@CodeType)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CodeType", txtCodetype.Text);



                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("CodeType.aspx");



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