<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="VMC.Role.AddRole" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Role">Danh sách nhóm quyền</a></li>
        <li class="active">Tạo nhóm quyền</li>
    </ol>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="heading" style="text-transform: uppercase;">
                <i class="fa fa-list"></i>
                Tạo nhóm quyền
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Tên nhóm quyền</label>
                <asp:TextBox runat="server" ID="txtrole" CssClass="form-control" placeholder="Tên nhóm quyền" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtrole"
                    CssClass="field-validation-error error" ErrorMessage="Tên nhóm quyền không được để trống." />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Mô tả</label>
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" ID="txtdescription" CssClass="form-control" placeholder="Mô tả" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Ưu tiên</label>
                <asp:TextBox runat="server" ID="txtweight" CssClass="form-control" placeholder="Weight" />
            </div>
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" OnClick="btnCreateRole_Click" ID="btnCreateRole" Text="Thêm quyền" />
            </div>
        </div>
    </div>
</asp:Content>
