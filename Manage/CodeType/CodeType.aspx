<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CodeType.aspx.cs" Inherits="AccountApp.Manage.CodeType.CodeType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .btn-add {
            display: inline-block;
            border: none;
            border-radius: 5px;
            padding: 10px 15px;
            text-decoration: none;
            font-size: 11px;
            margin-left: 1100px;
            margin-top: -10px;
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
                            <h2><strong>Code</strong>Type </h2>
                            <div class="body">

                                <div class="table-responsive">
                                    <div class="btn-add">
                                        <asp:LinkButton ID="lkninsert" CssClass="btn btn-dark" runat="server" PostBackUrl="~/Manage/CodeType/AddEditCodeType.aspx">Add New Item</asp:LinkButton>

                                    </div>
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" DataKeyNames="CodeTypeID"  AutoGenerateColumns="False" Width="100%" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                  <ItemTemplate>
                                                    <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "AddEditCodeType.aspx?id="+ Eval("CodeTypeID") %>'>Edit</asp:LinkButton>
                                                    <asp:LinkButton ID="lknDelete" runat="server" OnClick="lknDelete_Click">Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:BoundField HeaderText="Code Type ID" DataField="CodeTypeID" SortExpression="CodeTypeID">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Code Type" DataField="CodeType" SortExpression="CodeType" >
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
        </div>

    </section>
</asp:Content>
