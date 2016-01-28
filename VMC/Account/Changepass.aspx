<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Changepass.aspx.cs" Inherits="VMC.Account.Changepass" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Thay đổi mật khẩu</li>
    </ol>
     <% if (lblerror.Text != "") { %>
        <div class="alert alert-danger alert-dismissible fade in" role="alert">
            <button class="close" aria-label="Close" data-dismiss="alert" type="button">
                <span aria-hidden="true">×</span>
            </button>
            <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
        </div>
     <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="heading" style="text-transform: uppercase;">
        <i class="fa fa-list"></i>
        Thay đổi mật khẩu
    </div>
    <% if (Request.QueryString["ID"] == null)
       { %>
    <div class="alert alert-info alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        Khi thay đổi mật khẩu hoàn thành hệ thống sẽ tự động đăng xuất tài khoản. Bạn vui lòng
          nhập tài khoản và mật khẩu mới để tiếp tục làm việc.
    </div>
    <% } %>
    
    <div class="form-group">
        <label for="exampleInputEmail1">Mật khẩu mới</label>
        <asp:TextBox ID="txtpassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Nhập mật khẩu mới" required></asp:TextBox>
        <span class="error"></span>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Nhập lại mật khẩu mới</label>
        <asp:TextBox ID="txtrepassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Nhập lại mật khẩu mới" required></asp:TextBox>
        <span class="error"></span>
    </div>
    <div class="form-group">
        <asp:HiddenField ID="hdfid" runat="server" />
        <asp:Button ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" CssClass="btn btn-success pull-right" Text="Thay đổi mật khẩu" />
        <div class="cleared"></div>
    </div>

</asp:Content>
