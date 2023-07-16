<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddOrUpdatePayment.aspx.cs" Inherits="AccountApp.Admin.Payment.AddOrUpdatePayment" %>

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
                <div class="row clearfix">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="card">
                            <div class="body" style="border: 1px solid">
                                <asp:Label ID="lblCustomer" runat="server" Visible="false" />
                                <asp:HiddenField ID="hdn" runat="server" />
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">InvoiceNo</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="InvoiceNo" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="InvoiceNo_SelectedIndexChanged">
                                            <asp:ListItem>Invoice No#</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Payment Date</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="PaymentDate" runat="server" TextMode="Date" placeholder="Date" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Payment Type</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="PaymentType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="PaymentType_SelectedIndexChanged">
                                            <asp:ListItem>Select Payment Type</asp:ListItem>
                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                            <asp:ListItem Value="Bank">Bank</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlTextBox" runat="server" Visible="false">
                                    <div class="row mb-3">
                                        <label for="inputItemName" class="col-sm-2 col-form-label">Check No</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="lblOnlineOrCheck" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Check No# / Online No#" />

                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <label for="inputItemName" class="col-sm-2 col-form-label">Bank</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="dropBank" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                <asp:ListItem>Select Bank</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Amount</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="Amount" runat="server" CssClass="form-control-sm" ClientIDMode="Static" placeholder="Amount" />
                                        &nbsp;&nbsp;
                                    <asp:Label ID="lblAmount" ClientIDMode="Static" runat="server">Rs <%Response.Write(Session["Total_amount"]); %></asp:Label>
                                    </div>
                                </div>
                                <asp:Panel ID="txtNote" runat="server" Visible="true">
                                    <div class="row mb-3">
                                        <label for="inputItemName" class="col-sm-2 col-form-label">Bank</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtNotes" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Notes" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="row">
                                    <div class="col-sm-10 offset-sm-2">
                                        <asp:Button ID="BtnAddEdit" runat="server" Text="Add" CssClass="btn btn-dark" CausesValidation="false" ClientIDMode="Static" UseSubmitBehavior="false" OnClick="BtnAddEdit_Click" />
                                    </div>
                                </div>
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <asp:Label ID="lblAmountError" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">Cannot Pay More Than Total Amount</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
