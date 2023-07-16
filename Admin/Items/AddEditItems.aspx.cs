using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountApp.Admin.Items
{
    public partial class AddEditItems : System.Web.UI.Page
    {
       
        string cs = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["breadCrum"] = "Update Items";
                    Session["AddOrUpdate"] = "Update";
                    populate();
                    dropDown1();
                    DropDownList1.Items.Insert(0, new ListItem("--Select Brand--", "0"));
                    dropDown2();
                    DropDownList2.Items.Insert(0, new ListItem("--Select Measurement--", "0"));
                
                }

                else
                {
                    Session["breadCrum"] = "Add Items";
                    Session["AddOrUpdate"] = "Add";
                    dropDown1();
                    DropDownList1.Items.Insert(0, new ListItem("--Select Brand--", "0"));
                    dropDown2();
                    DropDownList2.Items.Insert(0, new ListItem("--Select Measurement--", "0"));
                  
                }
                        
            }
        }
        void dropDown1()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("browseCodeByCodeTypeId_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", 1);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "NAME";
            DropDownList1.DataBind();
        }
        void dropDown2()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("browseCodeByCodeTypeId_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", 2);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataTextField = "NAME";
            DropDownList2.DataBind();
        }
        void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Items_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
            txtdescription.Text = dt.Rows[0]["Description"].ToString();
            DropDownList2.SelectedValue = dt.Rows[0]["Measurement"].ToString();
            DropDownList1.SelectedValue = dt.Rows[0]["BrandCodeID"].ToString();
            txtPurchaePrice.Text = dt.Rows[0]["PurchasePrice"].ToString();
            txtSalePrice.Text = dt.Rows[0]["SalePrice"].ToString();
            txtOpeningQuantity.Text = dt.Rows[0]["OpeningQuantity"].ToString();
            txtOpeningStockPrice.Text = dt.Rows[0]["OpeningStockPrice"].ToString();
            hdn.Value = dt.Rows[0]["Id"].ToString();
        }

        protected void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Items_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@Description", txtdescription.Text);
                cmd.Parameters.AddWithValue("@PurchasePrice", txtPurchaePrice.Text);
                cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                cmd.Parameters.AddWithValue("@Measurement", DropDownList2.SelectedValue);
                cmd.Parameters.AddWithValue("@BrandCodeID", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@OpeningQuantity", txtOpeningQuantity.Text == "" ? null : txtOpeningQuantity.Text);
                cmd.Parameters.AddWithValue("@OpeningStockPrice", txtOpeningStockPrice.Text == "" ? null : txtOpeningStockPrice.Text);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Items.aspx");



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
                SqlCommand cmd = new SqlCommand("Items_Crud", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@Description", txtdescription.Text);
                cmd.Parameters.AddWithValue("@PurchasePrice", txtPurchaePrice.Text);
                cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                cmd.Parameters.AddWithValue("@Measurement", DropDownList2.SelectedValue);
                cmd.Parameters.AddWithValue("@BrandCodeID", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.Parameters.AddWithValue("@OpeningQuantity", txtOpeningQuantity.Text == "" ? null : txtOpeningQuantity.Text);
                cmd.Parameters.AddWithValue("@OpeningStockPrice", txtOpeningStockPrice.Text == "" ? null : txtOpeningStockPrice.Text);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    Response.Redirect("Items.aspx");



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