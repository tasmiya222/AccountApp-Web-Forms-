<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main Content -->
    <section class="content">
        <div class="">
            <div class="block-header">
                <div class="row">
                    <div class="col-lg-7 col-md-6 col-sm-12">
                        <h2>Dashboard</h2>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Default.aspx"><i class="zmdi zmdi-home"></i>App</a></li>
                            <li class="breadcrumb-item active"><%Response.Write(Session["breadCrum"]);%> </li>
                        </ul>
                        <button class="btn btn-primary btn-icon mobile_menu" type="button"><i class="zmdi zmdi-sort-amount-desc"></i></button>
                    </div>
                    <div class="col-lg-5 col-md-6 col-sm-12">
                        <button class="btn btn-primary btn-icon float-right right_icon_toggle_btn" type="button"><i class="zmdi zmdi-arrow-right"></i></button>
                    </div>
                </div>
            </div>
            <div class="container-fluid">
                <div class="row clearfix">
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="card widget_2 big_icon">
                            <div class="body">
                                <h6>Total Sale </h6>
                                <h2>Rs <%Response.Write(Session["TotalSale"]); %>/-</h2>
                                <h6>(Amount: Rs <%Response.Write(Session["TotalSale"]); %>/-)</h6>
                                <div class="progress">
                                    <div></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="card widget_2 big_icon ">
                            <div class="body">
                                <h6>Total Payment </h6>
                                 <h2>Rs <%Response.Write(Session["TotalPayment"]); %>/-</h2>
                                <h6>(Amount: Rs <%Response.Write(Session["TotalPayment"]); %>/-)</h6>
                                <div class="progress">
                                    <div></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="card widget_2 big_icon ">
                            <div class="body">
                                <h6>Total Expense </h6>
                                <h2>Rs <%Response.Write(Session["TotalExpense"]); %>/-</h2>
                                <h6>(Amount: Rs <%Response.Write(Session["TotalExpense"]); %>/-)</h6>
                                <div class="progress">
                                    <div></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="card widget_2 b">
                            <div class="body">
                                <h6>Total Purchase </h6>
                                  <h2>Rs <%Response.Write(Session["TotalPurchase"]); %>/-</h2>
                                <h6>(Amount: Rs <%Response.Write(Session["TotalPurchase"]); %>/-)</h6>
                                <div class="progress">
                                    <div></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

              

            </div>
        </div>
    </section>

</asp:Content>
