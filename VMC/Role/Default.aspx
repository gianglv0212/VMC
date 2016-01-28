<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC.Role.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Danh sách nhóm quyền</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="heading" style="text-transform: uppercase;">
                <i class="fa fa-list"></i>
                Danh sách nhóm quyền
                <a class="btn btn-sm btn-primary-outline pull-right" href="/Role/AddRole">
                    <i class="fa fa-plus"></i>
                    Thêm nhóm quyền
                </a>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="grvRole" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                     CssClass="table table-bordered" HeaderStyle-CssClass="table-header" OnRowDataBound="grvRole_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tên nhóm quyền" ItemStyle-Width="25%" >
                            <ItemTemplate>
                                <asp:HyperLink ID="hplLink" runat="server" NavigateUrl='<%# "/Role/Permission/"+Eval("id") %>'>
                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Mô tả" />
                        <asp:BoundField DataField="weight" HeaderText="Ưu tiên"  ItemStyle-Width="20%"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
