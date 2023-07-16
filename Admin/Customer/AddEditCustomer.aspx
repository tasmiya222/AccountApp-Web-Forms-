<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddEditCustomer.aspx.cs" Inherits="AccountApp.Admin.Customer.AddEditCustomer" %>

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
                            <div class="header">
                                <h2><strong><%Response.Write(Session["AddOrUpdate"]); %></strong> Customer</h2>
                            </div>
                            <div class="body" style="border:1px solid">
                                <asp:HiddenField ID="hdn" runat="server" />
                                   <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">ComapnyName<span style="color: red">*</span></label>
                                    <div class="col-sm-10">
                                    <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Enter Company Name..." Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                              
                                   <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Full Name<span style="color: red">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtFullName" runat="server" placeholder="Enter Your Full Name..." CssClass="form-control" Required></asp:TextBox>

                                    </div>
                                </div>

                                    <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">PhoneNumber<span style="color: red">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter Your Phone NO..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Email</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Your Email..." TextMode="Email" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Address1</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtAddre1" runat="server" placeholder="Enter Your Addres1..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Address2</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtAddre2" runat="server" placeholder="Enter Your Address2..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">City</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtCity" runat="server" placeholder="Enter Your City..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                               <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Province</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtProvince" runat="server" placeholder="Enter Your Province..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Postal Code</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPostalCode" runat="server" placeholder="Enter Your PostalCode..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                               <div class="row mb-3">
                                    <label for="inputItemName" class="col-sm-2 col-form-label">Opening Balance</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtOpeningBalance" runat="server" placeholder="Enter Opening Balance..." CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                   <div class="row">
                                    <div class="col-sm-10 offset-sm-2">
                                <asp:Button ID="BtnAddEdit" runat="server" Text="Add" CssClass="btn btn-dark" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnAdd_Click" />
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
