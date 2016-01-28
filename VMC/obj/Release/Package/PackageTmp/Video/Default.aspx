<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC.Video.Default" EnableViewState="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Danh sách video</li>
    </ol>
    <% if (Request.QueryString["success"] != null)
       {%>
    <div class="alert alert-success alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        Video đã được thay đổi thành công.
    </div>
    <% } %>
    <% if (lblmess.Text != "") { %>
        <div class="alert alert-success alert-dismissible fade in" role="alert">
            <button class="close" aria-label="Close" data-dismiss="alert" type="button">
                <span aria-hidden="true">×</span>
            </button>
            <asp:Label ID="lblmess" runat="server" Text=""></asp:Label>
        </div>
     <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
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
                                    <asp:TextBox ID="txtQuery" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="input-group-addon btn" OnClick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTow" aria-expanded="true" aria-controls="collapseOne">Kiểu video
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTow" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">
                            <asp:ListItem id="rd1" Selected="True">
                                <label class="checkbox">
                                    <asp:RadioButton ID="rdall" runat="server" GroupName="type" />
                                    <span>Tất cả</span>
                                </label>
                                <label class="checkbox">
                                    <asp:RadioButton ID="rdbo" runat="server" GroupName="type" />
                                    <span>Video bộ</span>
                                </label>
                                <label class="checkbox">
                                    <asp:RadioButton ID="rdle" runat="server" GroupName="type" />
                                    <span>Video lẻ</span>
                                </label>
                            </asp:ListItem>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTow" aria-expanded="true" aria-controls="collapseOne">Trạng thái
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTow" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body" id="divStatus">
                            <label class="checkbox">
                                <asp:Label ID="test" runat="server" Text=""></asp:Label>
                                <asp:CheckBox ID="chkcreate" runat="server" value="0" />
                                <span>Tạo nội dung</span>
                            </label>
                            <label class="checkbox">
                                <asp:CheckBox ID="chkpublish" runat="server" value="1" />
                                <span>Đã xuất bản</span>
                            </label>
                            <label class="checkbox">
                                <asp:CheckBox ID="chkunpublish" runat="server" value="2" />
                                <span>Đã gỡ bỏ</span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingthree">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapsethree" aria-expanded="true" aria-controls="collapsethree">Thể loại
                            </a>
                        </h4>
                    </div>
                    <div id="collapsethree" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingthree">
                        <div class="panel-body">

                            <asp:Repeater ID="rptCate" runat="server">
                                <HeaderTemplate>
                                    <ul class="list-group" id="CateList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li class="list-group-item" data-id="<%# Eval("id") %>" onclick="vodCateSelect('/Video?',this)">
                                        <span class="badge"><%# Eval("SO_LUONG") %></span>
                                        <%--<% if(Request.QueryString["cate"] == null){ %>--%>
                                        <span class="icon glyphicon glyphicon-unchecked"></span>
                                        <%-- <% }else{ if(Request.QueryString["cate"].ToString() == Container.DataItem("id")){ %>
                               <span class="icon glyphicon glyphicon-check"></span>
                              <% }} %>--%>
                                        <%# Eval("name") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></ul></FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-9">

            <div class="heading" style="text-transform: uppercase;">
                <i class="fa fa-list"></i>
                Danh sách video
        <a class="btn btn-sm btn-primary-outline pull-right" href="/Video/Add">
            <i class="fa fa-plus"></i>
            Thêm video
        </a>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="grvList" CssClass="table table-bordered" runat="server" DataKeyNames="id" BorderWidth="0"
                    AutoGenerateColumns="False" OnRowDataBound="grvList_RowDataBound" AllowPaging="True"
                    HeaderStyle-CssClass="table-header" ShowHeaderWhenEmpty="True" EmptyDataText="khong co du lieu tim kiem" OnRowCommand="grvList_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="#" />
                        <asp:TemplateField HeaderText="Tên video">
                            <ItemTemplate>
                                <asp:Image ID="imglogo" runat="server" Width="64" Height="36" ImageUrl='<%# Eval("avatar") %>' />
                                <asp:HyperLink ID="hplname" CssClass="name" runat="server" NavigateUrl='<%# "Edit?ID=" + Eval("id") %>'>
                                <%#Eval("name") %>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái/Người tạo" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label Text='<%#Eval("status") %>' ID="lblStatus" runat="server"></asp:Label>
                                <asp:Label ID="lblusername" runat="server" Text='<%#Eval("uname") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:BoundField DataField="created" HeaderText="Ngày tạo" ItemStyle-Width="10%">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="total" HeaderText="Số tập" ItemStyle-Width="10%">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:LinkButton ID="hplxuatban" runat="server" CommandName="cmdXuatBan" CssClass="btn btn-xs btn-success-outline width-80" CommandArgument='<%#Container.DataItemIndex %>'><span class="glyphicon glyphicon-cog"></span>Xuất bản</asp:LinkButton>
                                <asp:LinkButton ID="hplhavideo" runat="server" CommandName="cmdHaVideo" CommandArgument='<%#Container.DataItemIndex %>' CssClass="btn btn-xs btn-danger-outline width-80 btn-delete">
                                <span class="glyphicon glyphicon-cog"></span>Hạ video
                                </asp:LinkButton>
                                <asp:LinkButton ID="hplxoa" CommandName="cmdXoa" CommandArgument='<%#Container.DataItemIndex %>' runat="server" CssClass="btn btn-xs btn-danger-outline width-80 btn-delete">
                                <span class="fa fa-trash-o"></span>Xóa video
                                </asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>

                    <HeaderStyle CssClass="table-header"></HeaderStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
