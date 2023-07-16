<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddEditItems.aspx.cs" Inherits="AccountApp.Admin.Items.AddEditItems" %>

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
                                <h2><strong><%Response.Write(Session["AddOrUpdate"]); %></strong> Items</h2>

                            </div>

                            <div class="body" style="border: 1px solid">
                                <asp:HiddenField ID="hdn" runat="server" />
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Item Name <span style="color: red">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtItemName" runat="server" placeholder="Item Name..." Required CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Description<span style="color: red">*</span></label>
                                    <div class="col-sm-10">

                                        <asp:TextBox ID="txtdescription" runat="server" placeholder="Description..." CssClass="form-control" Required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Purchase Price</label>
                                    <div class="col-sm-10">

                                        <asp:TextBox ID="txtPurchaePrice" runat="server" placeholder="Purchase Price..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Sale Price<span style="color: red">*</span></label>
                                    <div class="col-sm-10">

                                        <asp:TextBox ID="txtSalePrice" runat="server" placeholder="Sale Price...." Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Select Measurement</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                            <asp:ListItem>Select Measurement</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Select Brand</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                            <asp:ListItem>Select Brand</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Opening Quantity</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtOpeningQuantity" runat="server" placeholder="Opening Quantity..." CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Opening Stock Price</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtOpeningStockPrice" runat="server" placeholder="Opening Stock Price..." CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-10 offset-sm-2">
                                        <asp:Button ID="BtnAddEdit" runat="server" Text="Add" CssClass="btn btn-dark" CausesValidation="false" UseSubmitBehavior="false" OnClick="BtnAddEdit_Click" />
                                    </div>
                                </div>
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
