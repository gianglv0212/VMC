<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC.Country.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <% if (lblmess.Text != "")
       { %>
    <div class="alert alert-success alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        <asp:Label ID="lblmess" runat="server" Text=""></asp:Label>
    </div>
    <% } %>
    <% if (lblerror.Text != "")
       { %>
    <div class="alert alert-danger alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    </div>
    <% } %>

    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Danh sách quốc gia</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="heading" style="text-transform: uppercase;">
            <i class="fa fa-list"></i>
            Danh sách quốc gia
            <a class="btn btn-sm btn-primary-outline pull-right" href="/Country/Add">
                <i class="fa fa-plus"></i>
                Thêm mới quốc gia
            </a>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvcountry" CssClass="table table-bordered tbldirector"
                runat="server" AutoGenerateColumns="false" OnRowDataBound="gvcountry_RowDataBound1" PageSize="20"
                ShowHeaderWhenEmpty="true" OnRowCommand="gvcountry_RowCommand" OnPageIndexChanging="gvcountry_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="#" />
                    <asp:BoundField DataField="name" HeaderText="Tên quốc gia" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="description" HeaderText="Mô tả" />
                    <asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" CssClass="edit-row btn btn-primary" ID="HyperLink1" NavigateUrl='<%# "Edit?ID=" + Eval("id")%>' Text="Thay đổi">
                                    <i class="fa fa-edit"></i> Thay đổi
                            </asp:HyperLink>
                            <asp:HiddenField ID="hdfname" runat="server" Value='<%# Eval("name") %>' />
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="cmdDelete" CommandArgument='<%# Eval("id")%>' CssClass="delete-row btn btn-danger" OnClientClick="return confirm('Bạn chắc chắn muốn xóa không?')" Text="Delete">
                                    <i class="fa fa-trash-o"></i> Delete
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
