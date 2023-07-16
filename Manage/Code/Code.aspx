<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Code.aspx.cs" Inherits="AccountApp.Manage.Code.Code" %>
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
                            <h2><strong>Code</strong> </h2>
                            <div class="body">

                                <div class="table-responsive">
                                    <div class="btn-add">
                                        <asp:LinkButton ID="lkninsert" CssClass="btn btn-dark" runat="server" PostBackUrl="~/Manage/Code/AddEditCode.aspx">Add New Code

                                        </asp:LinkButton>
                                    </div>
                               <asp:GridView ID="Table" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  Width="100%">
                                        <Columns>
                                            
                                            <asp:TemplateField HeaderText="Action">


                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkn" runat="server" PostBackUrl='<%# "AddEditCode.aspx?id="+ Eval("Id") %>'>Edit</asp:LinkButton>

                                                    <asp:LinkButton ID="lknDelete" runat="server" OnClick="lknDelete_Click">Delete</asp:LinkButton>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CodeValue" HeaderText="Code Value" SortExpression="Code Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodeShortValue" HeaderText="Code Short Value" SortExpression="CodeShortValue">
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
