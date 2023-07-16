<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SaleOrder.aspx.cs" Inherits="AccountApp.Admin.SaleOrder.SaleOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-add {
            display: inline-block;
            border: none;
            border-radius: 5px;
            padding: 10px 15px;
            text-decoration: none;
            font-size: 11px;
            margin-left: 87%;
            cursor: pointer;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="body_scroll">
            <div class="block-header">
                <div class="row">
                    <div class="col-lg-7 col-md-6 col-sm-12">
                        <h2>Dashboard</h2>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Default.aspx"><i class="zmdi zmdi-home"></i>App</a></li>
                            <li class="breadcrumb-item active"><%Response.Write(Session["breadCrum"]); %> </li>
                        </ul>
                        <button class="btn btn-primary btn-icon mobile_menu" type="button"><i class="zmdi zmdi-sort-amount-desc"></i></button>
                    </div>
                    <div class="col-lg-5 col-md-6 col-sm-12">
                        <button class="btn btn-primary btn-icon float-right right_icon_toggle_btn" type="button"><i class="zmdi zmdi-arrow-right"></i></button>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <!-- Striped Rows -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="card">
                        <div class="header">
                            <h2><strong>Sale</strong>Order </h2>
                        </div>
                        <div class="btn-add">
                            <asp:LinkButton ID="lkninsert" CssClass="btn btn-dark" runat="server" PostBackUrl="~/Admin/SaleOrder/AddEditSaleOrder.aspx">Add New SaleOrder</asp:LinkButton>
                        </div>

                        <div class="body">
                            <div class="table-responsive">
                                <asp:GridView ID="TableSaleOrder" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="SaleOrderID" CellPadding="3" CellSpacing="3">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lknInser" runat="server" PostBackUrl='<%# "~/Admin/SaleOrderDetails/AddEditSaleOrderDetails.aspx?SaleOrderID="+ Eval("SaleOrderID") %>' ForeColor="#6600cc" >Add</asp:LinkButton>
                                                <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "AddEditSaleOrder.aspx?id="+ Eval("SaleOrderID") %>' ForeColor="#6600cc">Edit</asp:LinkButton>
                                                <asp:LinkButton ID="lknDelete" runat="server" OnClick="lknDelete_Click"  ForeColor="#6600cc" >Delete</asp:LinkButton>
                                                <asp:LinkButton ID="lknDeleivered" runat="server" PostBackUrl='<%# "~/Admin/Delivered/DeliveredOrder.aspx?SaleOrderID="+Eval("SaleOrderID") %>' ForeColor="#6600cc">Delivered</asp:LinkButton>
                                                <asp:LinkButton ID="lknReturn" runat="server" PostBackUrl='<%# "~/Admin/Return/SaleOrderReturn.aspx?SaleOrderID="+Eval("SaleOrderID") %>' ForeColor="#6600cc" >Return</asp:LinkButton>
                                                <asp:LinkButton ID="lknInvocie" runat="server" PostBackUrl='<%# "SaleInvoice.aspx?SaleOrderID="+Eval("SaleOrderID") %>' ForeColor="#6600cc" >Invoice</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SaleOrderDate" HeaderText="SaleOrderDate" SortExpression="SaleOrderDate">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="SaleOrderID" HeaderText="SO #" SortExpression="SaleOrderID">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CretaedDate" SortExpression="CreatedDate">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
