<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="VMC.Category.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li>Danh sách thể loại</li>
        <li class="active">Sửa thể loại</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="heading" style="text-transform:uppercase;">
<i class="fa fa-plus-circle"></i>
Thêm mới thể loại
</div>
    <% if(error == true) { %>
        <div class="alert alert-danger alert-dismissible fade in" role="alert">
          <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
          </button>
          <strong>Lỗi!</strong>
          Thể loại chưa được sửa vui lòng kiểm tra lại chuỗi nhập.
        </div>
    <% } %>
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
  <div class="form-group <?php if(form_error('name')) echo 'has-error'; ?>">
    <label for="exampleInputEmail1">Tên thể loại</label>
    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"  ></asp:TextBox>
      <asp:Label ID="lblName" CssClass="error" runat="server" Text=""></asp:Label>
  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Mô tả</label>
     <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">Order</label>
    <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control" ></asp:TextBox>
  </div>
  <div class="form-group">
  	<label>Danh mục cha</label>
    <asp:DropDownList runat="server" CssClass="form-control"  id="ddparentid" >
        <asp:ListItem Text="-- Chọn danh mục --" Value="0"></asp:ListItem>
     </asp:DropDownList>
    <asp:HiddenField ID="txtType" runat="server" Value="1" />
      <asp:Label ID="lblparentid" CssClass="error" runat="server" Text=""></asp:Label>
  </div>
  <div class="form-group">
    <label class="control-label col-md-4">Avatar</label>
    <div class="col-md-8">
          <div class="avatar postimg" id="output1">
              <asp:Image ID="avatar" runat="server" ClientIDMode="Static" />
          </div>        
          <span class="btn btn-default btn-file">
              Browse 
              <asp:FileUpload ID="avatarinput" runat="server" />
          </span>
    </div>
  </div>
  <div class="form-group">
      <asp:CheckBox ID="chkstatus" runat="server" data-off-color="warning" checked />
  </div>
  <div class="form-group">
      <asp:HiddenField ID="hdid" runat="server" />
      <asp:HiddenField ID="hdleveltree" runat="server" />
      <asp:HiddenField ID="hdlevel" runat="server" />
      <asp:Button ID="btncate" OnClick="btncate_Click" runat="server" Text="Đồng ý" CssClass="btn btn-success pull-right"/>
      <asp:Button ID="btnback" runat="server" Text="Trở lại" CssClass="btn btn-danger pull-right"/>
    <div class="cleared"></div>
  </div>
</asp:Content>
