using AccountApp.Admin.Payment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp
{
    public partial class Default : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        private string payment;
        private string sale;
        private string purchase;
        private string expense;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "DashBoard";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("TotalAmount_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.Rows[0];
                if(dt.Rows.Count >0)
                {
                    string TotalPayment = dr["PaymentAmount"].ToString();
                    string TotalSale = dr["SaleAmount"].ToString();
                    string TotalPurchase = dr["PurchaseAmount"].ToString();
                    string TotalExpense = dr["ExpensesAmount"].ToString();
                    payment = TotalPayment;
                    sale = TotalSale;
                    purchase = TotalPurchase;
                    expense = TotalExpense;


                }
                Session["TotalPayment"] = payment;
                Session["TotalSale"] = sale;
                Session["TotalPurchase"] = purchase;
                Session["TotalExpense"] = expense;
            }
        }

      
    }
}