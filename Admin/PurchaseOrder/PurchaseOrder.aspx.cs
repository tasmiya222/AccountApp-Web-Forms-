using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.PurchaseOrder
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "Purchase Order Header";
                BindData();
            }
        }
        void BindData()
        {
            SqlConnection Con = new SqlConnection(cs);
            SqlCommand ShowData = new SqlCommand("PurchaseOrder_Crud", Con);
            ShowData.Parameters.AddWithValue("@Action", "SELECT");
            ShowData.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(ShowData);
            DataTable st = new DataTable();
            sda.Fill(st);
            TablePurchaseOrder.DataSource = st;
            TablePurchaseOrder.DataBind();
        }
        protected void lknDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            LinkButton lkndelete = sender as LinkButton;
            GridViewRow gridViewRow = lkndelete.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(TablePurchaseOrder.DataKeys[gridViewRow.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand("PurchaseOrder_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "DELETE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PurchaseOrderID", id);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "script", "<script>alert('deleted!')</script>", true);
                BindData();
            }
            con.Close();
        }
    }
}