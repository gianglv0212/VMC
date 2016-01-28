<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accountinfo.aspx.cs" Inherits="VMC.Account.Accountinfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
   
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Thay đổi thông tin</li>
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
    <div class="row">
        <div class="heading" style="text-transform: uppercase;">
            <i class="fa fa-list"></i>
            Thông tin cá nhân
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Họ tên đầy đủ</label>
            <asp:TextBox ID="fullname" CssClass="form-control" runat="server" placeholder="Tên đầy đủ"></asp:TextBox>
            <span class="error"></span>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Tên đăng nhập</label>
            <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Tên đăng nhập" disabled></asp:TextBox>
            <span class="error"></span>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Email</label>
            <asp:TextBox ID="email" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>
            <span class="error"></span>
        </div>
        <div class="form-inline form-group">
            <label>Phân quyền</label>
            <asp:DropDownList ID="lbRole" runat="server"></asp:DropDownList>

        </div>
        <div class="form-group">
            <label class="control-label col-md-4">Avatar</label>
            <div class="col-md-8">
                <div class="avatar postimg" id="output1">
                    <asp:Image ID="avatar" runat="server" ImageUrl="/Uploads/Core/noimg.jpg" width="96" max-height="54" ClientIDMode="Static"/>
                </div>
                <span class="btn btn-default btn-file">Browse
                    <asp:FileUpload ID="avatarinput" runat="server" ClientIDMode="Static" onchange="readURL(this,'avatar','output1');" />
                </span>
            </div>
        </div>
        <div class="form-group">
            <asp:HiddenField ID="hdfid" runat="server" />
            <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" CssClass="btn btn-success pull-right" Text="Cập nhật thông tin" />
            <button type="button" class="btn btn-danger pull-right" onclick="window.history.back();">Trở lại</button>
            <div class="cleared"></div>
        </div>
    </div>
</asp:Content>
