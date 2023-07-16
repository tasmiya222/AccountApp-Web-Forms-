<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SaleOrderReturn.aspx.cs" Inherits="AccountApp.Return.SaleOrderReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .main-table {
            width: 60%;
            height: 100px;
            text-align: center;
            margin-top: 10px;
            border: 1px solid #E5E4E2;
            border-collapse: collapse;
        }

            .main-table td, th {
                padding: 10px;
            }

            .main-table td {
                text-align: center;
            }

        .btn {
            float: left;
            margin-right: 50%;
            border: 1px solid black;
        }


        .returenDate {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="body_scroll">
            <div class="block-header">
                <div class="row">
                    <div class="col-lg-7 col-md-6 col-sm-12">
                        <h2>aDashboard</h2>
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
                                <h2><strong>Return</strong></h2>
                            </div>
                            <div class="body">
                                <div class="table-responsive">
                                    <asp:Label ID="lblDate" runat="server" ClientIDMode="Static" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCustomerID" runat="server" ClientIDMode="Static" Visible="false"></asp:Label>
                                    <asp:Label ID="lblItemID" runat="server" ClientIDMode="Static" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInvoiceID" runat="server" ClientIDMode="Static" Visible="false"></asp:Label>
                                    <asp:Repeater ID="rReturn" runat="server">
                                        <itemtemplate>
                                            <table class="table table-striped">
                                                <tr>
                                                    <th>SO #</th>
                                                    <th>Customer Name</th>
                                                    <th>SO Date</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSOId" runat="server" Text='<%# Eval("SOId") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CutomerName") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSODate" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>
                                                    </td>
                                                    <asp:HiddenField ID="lblItemID" Value='<%# Eval("ItemID") %>' runat="server" />
                                                    <asp:HiddenField ID="lblSaleDetailId" Value='<%# Eval("SaleOrderLineID") %>' runat="server" />

                                                </tr>
                                            <hr />
                                                <tr>
                                                    <th>ItemName</th>
                                                    <th>Quantity</th>
                                                    <th>Return Quantity</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>' />
                                                    </td>
                                                    <td class="qty">
                                                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("ShipQuantity") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtShipQuantity" runat="server" Style="width: 80px" ClientIDMode="Static" CssClass="check txtShipQuantity "></asp:TextBox>

                                                    </td>
                                                </tr>

                                            </table>
                                        </itemtemplate>
                                    </asp:Repeater>

                                    <div class="returenDate">
                                        <label style="font-weight: bold">Return Date:</label>
                                        <asp:TextBox ID="txtReturnDate" runat="server" TextMode="Date" ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                    <asp:Label ID="lblChkQty" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">ship qty not equal to returnqty</asp:Label> 
                                    <asp:Label ID="lblChkHeader" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">Header can not insert </asp:Label> 
                                    <asp:Label ID="lblchk" runat="server" ClientIDMode="Static" Visible="false" ForeColor="Red">fill returnqty or not zero value</asp:Label>
                                    <asp:Button ID="BtnRetuen" runat="server" Text="Save" CssClass="btn btn-dark" ClientIDMode="Static" OnClientClick="return Validate();" OnClick="BtnRetuen_Click" />


                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblErorr" runat="server" Visible="false" />
                    </div>
                </div>
            </div>
        </div>
      <%--  <script>
            $(".txtShipQuantity").focusout(function () {
                var qty = $(this).closest('td').siblings('۔qty').find('span').html();
                var ship = parseInt($(this).val());
                if (ship > parseInt(qty)) {
                    $(this).val(qty);
                }
            });
            function Validate() {
                debugger;
                var isValid = false;
                $('.check').each(function () {
                    if ($(this).val() != '') {
                        isValid = true;
                    }

                });
                if (isValid == false) {
                    $('#lblChkQty').show();
                    return false;
                }
                return true;
            };
        </script>--%>
    </section>
</asp:Content>

