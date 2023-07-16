<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddEditPurchaseOrderDetail.aspx.cs" Inherits="AccountApp.Admin.PurchaseOrderDetail.AddEditPurchaseOrderDetail" %>

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
                                <h2><strong><%Response.Write(Session["AddOrUpdate"]); %></strong> PurchaseOrder Details</h2>
                            </div>
                            <div class="body" style="border: 1px solid">
                                <asp:HiddenField ID="hdn" runat="server" />
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Item</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="DropItemID" runat="server" ClientIDMode="Static" CssClass="form-control" OnSelectedIndexChanged="DropItemID_SelectedIndexChanged1" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Quantity</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtQuantity" runat="server" ClientIDMode="Static" placeholder="Enter Quantity..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Description</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" placeholder="Enter Description...." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">PurchaseCost</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPurchaseCost" runat="server" ClientIDMode="Static" placeholder="Enter PurchaseCost..." CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-10 offset-sm-2">
                                        <asp:Button ID="BtnAddOrEdit" runat="server" Text="Add" ClientIDMode="Static" CssClass="btn btn-dark" CausesValidation="false" UseSubmitBehavior="false" OnClick="BtnAddOrEdit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblError" Visible="false" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
