<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC.Actor.Default" %>

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
            Danh sách diễn viên
            <a class="btn btn-sm btn-primary-outline pull-right" href="/Actor/Add">
              <i class="fa fa-plus"></i>
              Thêm mới diễn viên
            </a>
          </div>
            <div class="table-responsive">
                <asp:GridView ID="gvactor" CssClass="table table-bordered tbldirector" 
                    runat="server" AutoGenerateColumns="false" OnRowDataBound="gvactor_RowDataBound"  
                     AllowPaging="True" OnPageIndexChanging="gvactor_PageIndexChanging" PageSize="20"
                    ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderText="#" />
                        <asp:BoundField DataField="name" HeaderText="Tên diễn viên" ItemStyle-Width="15%" />
                        <asp:ImageField DataImageUrlField="avatar" HeaderText="Avatar" ControlStyle-Width="96" ItemStyle-Width="10%"></asp:ImageField>     
                        <asp:BoundField DataField="description" HeaderText="Mô tả" />
                        <asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="20%">
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
