<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddEditBank.aspx.cs" Inherits="AccountApp.Admin.Bank.AddEditBank" %>
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
                                <h2k><strong><%Response.Write(Session["AddOrUpdate"]); %> </strong> Bank</h2k>

                            </div>

                            <div class="body">
                                <asp:HiddenField ID="hdn" runat="server" />
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtBankName" runat="server" placeholder="Bank Name..." Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtBankTitle" runat="server" placeholder="Bank Title..." CssClass="form-control" Required></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtOpeningBalance" runat="server" placeholder="Opening Balance..." Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtOpeningBalanceDate"  runat="server" TextMode="DateTime" placeholder="Opening Balance Date..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtBankAccountNumber" runat="server" placeholder="BankAccountNumber..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtBankAddress" runat="server" placeholder="Bank Address..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-float">
                                        <asp:TextBox ID="txtBranchName" runat="server" placeholder="Branch Name..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add" CssClass="btn btn-dark"  CausesValidation="false" UseSubmitBehavior="false" OnClick="BtnAddEdit_Click" />
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                       
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
