<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DeliveredOrder.aspx.cs" Inherits="AccountApp.Admin.Delivered.DeliveredOrder" %>

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
                                <h2><strong>Delivered</strong> Order</h2>
                            </div>
                            <asp:Label ID="lblSODate" runat="server" ClientIDMode="Static" Visible="false"></asp:Label>
                            <asp:Label ID="lblCustomerID" runat="server" ClientIDMode="Static" Visible="false"></asp:Label>
                            <div class="body">
                                <div class="table-responsive">
                                    <asp:Repeater ID="rDelivered" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>SO #</th>
                                                        <th>Customer Name</th>
                                                        <th>SO Date</th>
                                                        <th>Item</th>
                                                        <th>Quantity</th>
                                                        <th>Ship Quantity</th>
                                                        
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lknBtn" PostBackUrl='<%# "~/Admin/SaleOrderDetails/SaleOrderDetails.aspx?SaleOrderId= "+Eval("SaleOrderID") %>' runat="server">
                                                        <asp:Label ID="lblSOId" runat="server" Text='<%# Eval("SaleOrderID") %>'></asp:Label>
                                                    </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSODate" runat="server" Text='<%# Eval("SaleOrderDate") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("ShipQuantity") %>'></asp:Label>
                                                </td>
                                                <asp:HiddenField ID="HdnSoDetailsID" runat="server" Value='<%# Eval("SaleOrderLineID") %>' />
                                                <asp:HiddenField ID="HdnDiscountRupee" runat="server" Value='<%# Eval("DiscountRupee") %>' />
                                                <asp:HiddenField ID="HdnLastPurchaseCost" runat="server" Value='<%# Eval("LastPurchaseCost") %>' />
                                                <asp:HiddenField ID="HdnItemID" runat="server" Value='<%# Eval("ItemID") %>' />
                                                <asp:HiddenField ID="HdnCustomerID" runat="server" Value='<%# Eval("CustomerId") %>' />
                                                <asp:HiddenField ID="HdnDescription" runat="server" Value='<%# Eval("Description") %>' />
                                                <asp:HiddenField ID="HdnPrice" runat="server" Value='<%# Eval("Price") %>' />
                                                <td>
                                                    <asp:TextBox ID="txtShipQty" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                           </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    
                                    <asp:Label ID="lblchk" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">ship qty not equal to returnqty</asp:Label> 
                                    <asp:Label ID="lblqty" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">fill returnqty or not zero value</asp:Label>
                                    <asp:Label ID="lblChkHeader" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">Header Can not Insert</asp:Label>
                                        <asp:Button ID="BtnShip" runat="server" Text="Ship" CssClass="btn btn-dark float-right" OnClick="BtnShip_Click" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
