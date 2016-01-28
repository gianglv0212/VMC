<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC.Director.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Danh sách diễn viên</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
	    <div class="heading" style="text-transform:uppercase;">
             <i class="fa fa-list"></i>
            Danh sách đạo diễn
            <a class="btn btn-sm btn-primary-outline pull-right" href="/Director/Add">
              <i class="fa fa-plus"></i>
              Thêm mới đạo diễn
            </a>
          </div>
            <div class="table-responsive">
                <asp:GridView ID="gvdirector" CssClass="table table-bordered tbldirector" runat="server" 
                    AutoGenerateColumns="false" OnRowDataBound="gvdirector_RowDataBound"   
                    AllowPaging="True" OnPageIndexChanging="gvdirector_PageIndexChanging" PageSize="20"
                    ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderText="#" />
                        <asp:BoundField DataField="name" HeaderText="Tên đạo diễn" ItemStyle-Width="15%" />
                        <asp:ImageField DataImageUrlField="avatar" ControlStyle-Width="96" HeaderText="Avatar" ItemStyle-Width="10%"></asp:ImageField>     
                        <%--<asp:TemplateField HeaderText="Avatar">
                            <ItemTemplate>
                                <asp:Image ID="avatar" runat="server" ImageUrl="<%#Eval("avatar") %>" />     
                            </asp:TemplateField>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="description" HeaderText="Mô tả" />
                        <asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="20%" >
                            <ItemTemplate>
                                <asp:HyperLink runat="server" CssClass="edit-row btn btn-primary" ID="HyperLink1" NavigateUrl='<%# "Edit?ID=" + Eval("id")%>' Text="Thay đổi">
                                    <i class="fa fa-edit"></i> Thay đổi
                                </asp:HyperLink>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("id")%>' CssClass="delete-row btn btn-danger" OnClientClick="return confirm('Bạn chắc chắn muốn xóa không?')" Text="Delete" OnClick="lbtnDelete_Click">
                                    <i class="fa fa-trash-o"></i> Delete
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              
            </div>
    </div>
</asp:Content>
