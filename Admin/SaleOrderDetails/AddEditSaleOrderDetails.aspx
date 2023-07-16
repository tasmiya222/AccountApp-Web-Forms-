<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddEditSaleOrderDetails.aspx.cs" Inherits="AccountApp.Admin.SaleOrderDetails.AddEditSaleOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="body_scroll">
            <div class="block-header">
                <div class="row">
                    <div class="col-lg-7 col-md-6 col-sm-12">
                        <h2>DashBoard</h2>
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
                <!-- Basic Validation -->
                <div class="row clearfix">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="card">
                            <div class="header">
                                <h2><strong><%Response.Write(Session["AddOrUpdate"]); %></strong> SaleOrder Details</h2>
                            </div>
                         
                            <div class="body" style="border: 1px solid;">
                                <asp:HiddenField ID="hdn" runat="server" />
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">ItemName</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtItemName" runat="server" placeholder=" Enter ItemName..." Required class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                   
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Item</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="DropItemID" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Quantity</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtQuantity" runat="server" placeholder="Enter Quantity..." Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Description</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescription" runat="server" placeholder="Enter Description...." Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Price</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPrice" runat="server" placeholder="Enter Price..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">LastPurchasePrice</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtLastPurchaseCost" runat="server" placeholder="Enter LastPurchaseCost..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Discount</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtDiscount" runat="server" placeholder="Enter Discount..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Discount Rupee</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtDiscountRupee" runat="server" placeholder="Enter DiscountRupee..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-10 offset-sm-2">
                                        <asp:Button ID="BtnAddOrEdit" runat="server" Text="Add" CssClass="btn btn-dark" CausesValidation="false" UseSubmitBehavior="false" OnClick="BtnAddOrEdit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblError" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblCkhPurchase" Visible="false" ForeColor="Red"  ClientIDMode="Static" runat="server">You cannot sell more then purhcase </asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
