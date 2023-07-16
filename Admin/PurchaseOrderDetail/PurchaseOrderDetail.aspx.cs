using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.PurchaseOrderDetail
{
    public partial class PurchaseOrderDetail : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "PurchaseOrder Detail";
                BindData();
            }
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand ShowPODetail = new SqlCommand("PurchaseOrderDetail_Crud", con);
            ShowPODetail.Parameters.AddWithValue("@Action", "SELECT");
            ShowPODetail.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter SDA = new SqlDataAdapter(ShowPODetail);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void lknDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            LinkButton lkndelete = sender as LinkButton;
            GridViewRow gridViewRow = lkndelete.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(GridView.DataKeys[gridViewRow.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand("PurchaseOrderDetail_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "DELETE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PurchaseOrderLineID", id);
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
