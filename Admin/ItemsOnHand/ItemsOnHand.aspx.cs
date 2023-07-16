using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.ItemsOnHand
{
    public partial class ItemsOnHand : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["breadCrum"] = "ItemsOnHand";
                ShowDetails();
            }

        }
        void ShowDetails()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("BrowseInventoryOnHand_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ItemsonHand.DataSource = dt;
            ItemsonHand.DataBind();
        }
    }
}