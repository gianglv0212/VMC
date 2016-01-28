<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="VMC.Director.Add" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Director">Danh sách diễn viên</a></li>
        <li class="active">Thêm mới diễn viên</li>
    </ol>
    <% if(check == true) { %>
    <div class="alert alert-success alert-dismissible fade in" role="alert">
          <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
          </button>
          <strong>Thành công!</strong>
          Thể loại đã thêm xong. Nhập thể loại tiếp theo để thêm tiếp.
        </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
	    <div class="heading" style="text-transform:uppercase;">
            <i class="fa fa-plus-circle"></i>
            Thêm mới đạo diễn
        </div>
	      <div class="form-group">
	        <label for="exampleInputEmail1">Tên đạo diễn</label>
              <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
              <asp:Label ID="lblName" runat="server" Text="" CssClass="error"></asp:Label>
	      </div>
	      <div class="form-group <?php if(form_error('description')) echo 'has-error'; ?>">
	        <label for="exampleInputEmail1">Mô tả</label>
	        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
	      </div>
	      <div class="form-group">
	        <label class="control-label col-md-4">Avatar</label>
	        <div class="col-md-8">
	              <div class="avatar" id="output1">
	                      <img id="avatar" src="/Uploads/Core/noimg.jpg"  width="96" max-height="54">
	              </div>        
	              <span class="btn btn-default btn-file">
	                  Browse
                      <asp:FileUpload ID="avatarinput" runat="server" />
	              </span>
	        </div>
	      </div>
	      <div class="form-group">
              <asp:Button ID="btndirector" runat="server" Text="Thêm mới" CssClass="btn btn-success pull-right" OnClick="btndirector_Click" />
	        <div class="cleared"></div>
	      </div>
    </div>
</asp:Content>
