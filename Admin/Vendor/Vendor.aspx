<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="AccountApp.Admin.Vendor.Vendor" %>

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
                            <h2><strong>Vendor</strong> </h2>
                        </div>

                        <div class="btn-add">
                            <asp:LinkButton ID="lkninsert" CssClass="btn btn-dark" runat="server" PostBackUrl="~/Admin/Vendor/AddEditVendor.aspx">Add New Vendor </asp:LinkButton>
                        </div>
                        <div class="body">
                            <div class="table-responsive">
                                <asp:GridView ID="Table" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="657px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "AddEditVendor.aspx?id="+ Eval("Id") %>'>Edit</asp:LinkButton>

                                                <asp:LinkButton ID="lknDelete" runat="server" OnClick="lknDelete_Click">Delete</asp:LinkButton>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VendorCode" HeaderText="VendorCode" SortExpression="VendorCode">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" SortExpression="PhoneNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="Address1">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="Address2">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Province" HeaderText="Province" SortExpression="Province">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="openingBalance" HeaderText="openingBalance" SortExpression="openingBalance">
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
