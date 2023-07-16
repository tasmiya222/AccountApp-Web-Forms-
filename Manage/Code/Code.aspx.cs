using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Manage.Code
{
    public partial class Code : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["breadCrum"] = "Code";
                bindData();
            }
        }

        protected void lknDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            LinkButton lkndelete = sender as LinkButton;
            GridViewRow gridViewRow = lkndelete.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(Table.DataKeys[gridViewRow.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand("Code_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "DELETE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "script", "<script>alert('deleted!')</script>", true);
                bindData();
            }
            con.Close();

        }
        void bindData()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Code_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Table.DataSource = dt;
            Table.DataBind();
        }
    }
}