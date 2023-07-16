<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ItemsOnHand.aspx.cs" Inherits="AccountApp.Admin.ItemsOnHand.ItemsOnHand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="body_scroll">
            <div class="block-header">
                <div class="row">
                    <div class="col-lg-7 col-md-6 col-sm-12">
                        <h2>aDashboard</h2>
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

            <div class="container-fluid">

                <div class="row clearfix">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="card">
                            <div class="header">
                                <h2 style="text-transform: capitalize">Items On Hand</h2>
                            </div>
                            <div class="body">
                                <div class="table-responsive">
                                    <asp:Repeater ID="ItemsonHand" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>Items Name</th>
                                                        <th>Description</th>
                                                        <th>Purchase Quantity</th>
                                                        <th>Alloc Qty</th>
                                                        <th>Sale Qty</th>
                                                        <th>Qty On Hand</th>
                                                        <th>SaleReturn Qty</th>
                                                        <th>PurchaseReturn Qty</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("ItemName") %></td>
                                                <td><%# Eval("Description") %></td>
                                                <td><%# Eval("PoQty") %></td>
                                                <td><%# Eval("AllocQty") %></td>
                                                <td><%# Eval("SoQty") %></td>
                                                <td><%# Eval("QtyOnHand") %></td>
                                                <td><%# Eval("SoRtnQty") %></td>
                                                <td><%# Eval("PORQty") %></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                         </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
