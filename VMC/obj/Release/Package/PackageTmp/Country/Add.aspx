<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="VMC.Country.Add" %>

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
        <li><a href="/Country">Danh sách quốc gia</a></li>
        <li class="active">Thêm mới quốc gia</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
	    <div class="heading" style="text-transform:uppercase;">
            <i class="fa fa-plus-circle"></i>
            Thêm mới quốc gia
        </div>
	      <div class="form-group">
	        <label for="exampleInputEmail1">Tên quốc gia</label>
              <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
              <asp:Label ID="lblName" runat="server" Text="" CssClass="error"></asp:Label>
	      </div>
	      <div class="form-group">
	        <label for="exampleInputEmail1">Mô tả</label>
	        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
	      </div>
	      <div class="form-group">
              <asp:Button ID="btnactor" runat="server" Text="Thêm mới" CssClass="btn btn-success pull-right" OnClick="btnCountry_Click" />
	        <div class="cleared"></div>
	      </div>
    </div>
</asp:Content>
