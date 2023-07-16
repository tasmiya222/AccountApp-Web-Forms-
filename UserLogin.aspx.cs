using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Users_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", txtUser.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count >= 1 )
            {
                Session["LoggedInUserName"] = dt.Rows[0]["UserName"];
                Session["LoggedInUserEmail"] = dt.Rows[0]["Email"];
                Session["LoggedInUserID"] = dt.Rows[0]["UserID"];
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Visible = false;
                lblError.Text = "InCorrect UserName And Password";
                lblError.CssClass = "alert alert-danger";
            }
                
        }
    }
}