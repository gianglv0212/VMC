<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="VMC.Account.Manage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <% if (lblmess.Text != "") { %>
        <div class="alert alert-success alert-dismissible fade in" role="alert">
            <button class="close" aria-label="Close" data-dismiss="alert" type="button">
                <span aria-hidden="true">×</span>
            </button>
            <asp:Label ID="lblmess" runat="server" Text=""></asp:Label>
        </div>
     <% } %>
    <% if (lblerror.Text != "") { %>
        <div class="alert alert-danger alert-dismissible fade in" role="alert">
            <button class="close" aria-label="Close" data-dismiss="alert" type="button">
                <span aria-hidden="true">×</span>
            </button>
            <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
        </div>
     <% } %>
    
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Danh sách user</li>
    </ol>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="false">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Tìm kiếm
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">
                            <div id="divStatus" class="panel-body">
                                <div id="pnl_search" class="input-group">
                                    <asp:TextBox ID="txtQuery" CssClass="form-control" runat="server" placeholder="Tìm kiếm theo Họ tên"></asp:TextBox>
                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="input-group-addon btn" OnClick="btnSearch_Click">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-9">

            <div class="heading" style="text-transform: uppercase;">
                <i class="fa fa-list"></i>
                Danh sách user
                <a class="btn btn-sm btn-primary-outline pull-right" href="/Account/Register">
                    <i class="fa fa-plus"></i>
                    Add user
                </a>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="grvUser" runat="server" ShowHeaderWhenEmpty="true"
                    AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDataBound="grvList_RowDataBound"
                    HeaderStyle-CssClass="table-header" OnRowCommand="grvUser_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="#" ItemStyle-Width="5%" />
                        <asp:TemplateField HeaderText="Avatar" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="Avatar" ImageUrl='<%# Eval("avatar") %>' Width="90" ></asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="username" HeaderText="Tên đăng nhập" ItemStyle-Width="20%">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="fullname" HeaderText="Họ tên" ItemStyle-Width="20%">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="40%">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" CssClass="edit-row btn btn-primary" NavigateUrl='<%# "Accountinfo?ID=" + Eval("id") %>' ID="hplEdit" Text="Thay đổi">
                                <i class="fa fa-edit"></i> Thay đổi
                                </asp:HyperLink>
                                <asp:HyperLink runat="server" CssClass="edit-row btn btn-primary" NavigateUrl='<%# "Changepass?ID=" + Eval("id") %>' ID="hplchangepass" Text="Reset Pass">
                                <i class="fa fa-edit"></i> Change Password
                                </asp:HyperLink>
                                <asp:LinkButton runat="server" CssClass="edit-row btn btn-danger" CommandArgument='<%# Eval("id") %>' CommandName="cmdDelete" ID="lbtnDelete" Text="Delete">
                                <i class="fa fa-trash-o"></i> Delete
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
