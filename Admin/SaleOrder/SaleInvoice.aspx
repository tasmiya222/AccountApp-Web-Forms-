<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleInvoice.aspx.cs" Inherits="AccountApp.Admin.SaleOrder.SaleInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Invoice</title>
    <link rel="stylesheet" href="assets/style.css" />
    <link rel="license" href="https://www.opensource.org/licenses/mit-license/" />
    <script src="script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <h1>Invoice
                </h1>
                <p>
                    <asp:Label ID="lblDate" runat="server" />
                </p>

            </header>
            <br />
            <table class="meta">
                <tr>
                    <th><span contenteditable>Invoice #</span></th>
                    <td><span contenteditable>
                        <asp:Label ID="lblInvoiceID" runat="server" /></span></td>
                </tr>
                <tr>
                    <th><span contenteditable>Invoice Date  </span></th>
                    <td><span contenteditable>
                        <asp:Label ID="lblInvoiceDate" runat="server" /></span></td>
                </tr>

            </table>
            <span style="margin-left: 50%; font-size: 15px;">Bill To
                <br />
                <p style="margin-left: 50%">
                    <asp:Label ID="lblCustomerName" runat="server" />
                    <br />
                    Contact#
                    <asp:Label runat="server" ID="lblContact" />
                </p>
            </span>
            <br />
            <p style="font-size: 12px;">
                <asp:Label runat="server" ID="lblAddres1" />,<asp:Label runat="server" ID="lblAddres2" />

                <br />
                <asp:Label ID="lblEmail" runat="server" />
            </p>


            <br />
            <br />
            <article>
                <asp:Repeater ID="Invoice" runat="server" OnItemDataBound="Invoice_ItemDataBound" >
                    <ItemTemplate>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>SO#</th>
                                    <th>DeliveredDate</th>
                                    <th>ItemName</th>
                                    <th>Description</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>Sub Total</th>
                                </tr>
                            </thead>
                            <tbody>
                
                        <tr>
                            <td><%# Eval("SaleOrderID") %></td>
                            <td><%# Eval("DeliveredDate") %></td>
                            <td><%# Eval("ItemName") %></td>
                            <td><%# Eval("Description") %></td>
                             <td><asp:Label runat="server" ID="qty" Text='<%# Eval("Quantity") %>' /></td>
                            <td><asp:Label runat="server" ID="lblPrice" Text='<%# Eval("Price") %>' /></td>
                            <td><asp:Label runat="server" ID="lblSubTotal"/></td>
                        </tr>
                
                        </tbody>
                    </table>
                    </ItemTemplate>
                
                </asp:Repeater>
                <br />
                <br />

                Name ______________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date _______________<br />
                <br />
                <br />
                <br />
                Sign _____________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Remarks______________<table class="balance">
                    <tr>
                        <th><span contenteditable>Total</span></th>
                        <td>
                            Rs <%Response.Write(Session["Total"]);%>/-
                        </td>
                    </tr>
                    <tr>
                        <th><span contenteditable>Amount Paid</span></th>
                        <td><span data-prefix></span><span contenteditable>0.00</span></td>
                    </tr>
                    <tr>
                        <th><span contenteditable>Balance Due</span></th>
                        <td><span data-prefix></span><span>600.00</span></td>
                    </tr>
                </table>
            </article>
        </div>
    </form>

  <script src="assets/main.js"></script>
</body>
</html>
