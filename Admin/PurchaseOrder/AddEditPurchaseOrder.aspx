<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddEditPurchaseOrder.aspx.cs" Inherits="AccountApp.Admin.PurchaseOrder.AddEditPurchaseOrder" %>
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
                                <h2><strong><%Response.Write(Session["AddOrUpdate"]); %></strong> PurchaseOrder</h2>

                            </div>

                            <div class="body">
                                <asp:HiddenField ID="hdn" runat="server" />
                            
                                
                                <div class="form-group form-float">
                                    
                                    <asp:RadioButton ID="RadioCash" runat="server"  CssClass="form-control" Text="Cash" GroupName="PoType"/>
                                    <asp:RadioButton ID="RadioCredit"  runat="server" CssClass="form-control" Text="Credit" GroupName="PoType" />
                                </div>
                                <div class="form-group form-float">
                                    <asp:TextBox ID="txtCounterVendorName" runat="server" placeholder="CounterVendorName...." Required CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group form-float">
                                    <asp:DropDownList ID="VendorId" runat="server" CssClass="form-control">
                                       
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group form-float">
                                    <asp:TextBox ID="txtCounterVendorPhone" runat="server" placeholder="CounterVendorPhone..." CssClass="form-control"></asp:TextBox>
                                </div>
                              
                                <asp:Button ID="BtnAddEdit" runat="server" Text="Add" CssClass="btn btn-dark" CausesValidation="false" UseSubmitBehavior="false" OnClick="BtnAddEdit_Click" />
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
