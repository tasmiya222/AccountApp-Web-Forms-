<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SaleOrdeDetails.aspx.cs" Inherits="AccountApp.Admin.SaleOrderDetails.SaleOrdeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-add {
            display: inline-block;
            border: none;
            border-radius: 5px;
            padding: 10px 15px;
            text-decoration: none;
            font-size: 11px;
            margin-left: 1100px;
            margin-top: -10px;
            cursor: pointer;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <h2><strong>SaleOrder </strong>Details </h2>
                            <div class="body">

                                <div class="table-responsive">
                                    
                                    <asp:GridView ID="SaleOrderDetails" CssClass="table table-striped" runat="server" AutoGenerateColumns="False"  DataKeyNames="SaleOrderID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "AddEditSaleOrderDetails.aspx?id="+ Eval("SaleOrderLineID") %>'>Edit</asp:LinkButton>
                                                    <asp:LinkButton ID="lknDelete" runat="server" OnClick="lknDelete_Click">Delete</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                        
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SaleOrderID" HeaderText="SO#" SortExpression="SaleOrderID">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                               
                                              <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                                 <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             
                                                 <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="LastPurchaseCost" HeaderText="LastPurchaseCost" SortExpression="LastPurchaseCost">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DiscountRupee" HeaderText="DiscountRupee" SortExpression="DiscountRupee">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ModifyBy" HeaderText="ModifyBy" SortExpression="ModifyBy">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                                <asp:BoundField DataField="ModifyDate" HeaderText="ModifyDate" SortExpression="ModifyDate">
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
        </div>

    </section>
</asp:Content>
