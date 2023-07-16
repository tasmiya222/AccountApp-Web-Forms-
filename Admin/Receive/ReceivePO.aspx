<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReceivePO.aspx.cs" Inherits="AccountApp.Admin.Receive.ReceivePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .main-table {
            width: 50%;
            height: 100px;
            text-align: center;
            margin-top: 50px;
            border: 1px solid #E5E4E2;
            border-collapse: collapse;
        }

            .main-table td, th {
                padding: 10px;
            }

            .main-table td {
                text-align: center;
            }

        .Main {
            float: right;
            width: 25%;
            height: 100px;
            margin-right: 20%;
            margin-top:-2%;
        }

        .tb td, th {
            padding: 10px;
        }

        .tb td {
            text-align: center;
        }

        .tb {
            width: 50%;
            height: 100px;
            text-align: center;
            margin-top: -50%;
            border: 1px solid #E5E4E2;
            border-collapse: collapse;
        }
        .btn
        {
            float:left;
            margin-right:-20%;
            border:1px solid black;

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
                            <h2><strong>Receive Purchase</strong>Order </h2>
                            <div class="body">
                                <asp:Repeater ID="rReceivedPo" runat="server">
                                    <ItemTemplate>
                                        <table class="table table-striped">
                                          
                                                <th>PurchaseOrder#:</th>
                                                <th>Vendor Name:</th>
                                                <th>OrderDate:</th>
                                                <th>Items:</th>
                                                <th>Description:</th>
                                          
                                                <tr>
                                                    <td>
                                                       <asp:Label ID="lblPurchaseOrderID" runat="server" Text='<%# Eval("PurchaseOrderID") %>' /></td>
                                                       <asp:HiddenField ID="lblItemID" runat="server" Value='<%# Eval("ItemID") %>' />
                                                       <asp:HiddenField ID="lblPurchaseOrderLineID" runat="server" Value='<%# Eval("PurchaseOrderLineID") %>' />
                                                    <td>
                                                        <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("PurchaseOrderDate") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ItemName") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>' /></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <hr />
                                        <table class="main-table table-striped" border="1">
                                            <tr>
                                                <th>Order 
                                                    Quanity</th>
                                                <td>
                                                    <asp:Label ID="lblqty" runat="server" Text='<%# Eval("Quantity") %>' /></td>

                                            </tr>
                                            <tr>
                                                <th>Received</th>
                                                <td>
                                                    <asp:Label ID="lblReceived" runat="server" Text='<%# Eval("IsReceived") %>' /></td>
                                            </tr>
                                        
                                            <tr>
                                                <th>Received Quantity</th>
                                                <td>
                                                    <asp:TextBox ID="lblReceivQty" runat="server" Width="80" Height="30" Wrap="False"></asp:TextBox></td>

                                            </tr>
                                            <tr>
                                                <th>Received Date</th>
                                                <td>
                                                    <asp:TextBox ID="txtReceiveDate" TextMode="Date" runat="server"></asp:TextBox></td>
                                            </tr>
                                        </table>

                                        <div class="Main">
                                            <table class="tb table-striped" border="1">
                                                <tr>
                                                    <th>Rent</th>
                                                    <td>
                                                        <asp:TextBox ID="lblRent" Width="90" Height="30" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th>Labour</th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" Width="90" Height="30" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th>Discount</th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox2" Width="90" Height="30" runat="server"></asp:TextBox></td>
                                                </tr>
                                               
                                                
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                              <asp:Button ID="BtnShip" class="btn" runat="server" Text="Ship" CssClass="btn btn-dark"  Onclick="BtnShip_Click"   />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
