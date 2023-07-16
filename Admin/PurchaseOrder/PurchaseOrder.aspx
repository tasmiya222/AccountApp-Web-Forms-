<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="AccountApp.Admin.PurchaseOrder.PurchaseOrder" %>

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
                            <h2><strong>Purchase</strong>Order </h2>
                        </div>
                        <div class="btn-add">
                            <asp:LinkButton ID="lkninsert" CssClass="btn btn-dark" runat="server" PostBackUrl="~/Admin/PurchaseOrder/AddEditPurchaseOrder.aspx">Add New PurchaseOrder</asp:LinkButton>
                        </div>
                        <div class="body">
                            <div class="table-responsive">

                                <asp:GridView ID="TablePurchaseOrder" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="PurchaseOrderID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "AddEditPurchaseOrder.aspx?id="+ Eval("PurchaseOrderID") %>'>Edit</asp:LinkButton>
                                                <asp:LinkButton ID="lknDelete" runat="server" OnClick="lknDelete_Click">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Add PurchaseOrderDetails">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lknInser" runat="server" PostBackUrl='<%# "~/Admin/PurchaseOrderDetail/AddEditPurchaseOrderDetail.aspx?PurchaseOrderID="+ Eval("PurchaseOrderID") %>'>Add PODetails</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Received">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "~/Admin/Receive/ReceivePO.aspx?PoId="+Eval("PurchaseOrderID") %>'>Received</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Create Invoice">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "PurchaseInvoice.aspx?PurchaseID="+Eval("PurchaseOrderID") %>'>Invoice</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="VendorName" HeaderText="VendorName" SortExpression="VendorName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="PurchaseOrderID" HeaderText="PO #" SortExpression="PurchaseOrderID">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PurchaseOrderDate" HeaderText="PurchaseOrderDate" SortExpression="PurchaseOrderDate">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate">
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
