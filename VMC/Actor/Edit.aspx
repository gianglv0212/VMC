<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="VMC.Actor.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Actor">Danh sách diễn viên</a></li>
        <li class="active">Sửa diễn viên</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
	    <div class="heading" style="text-transform:uppercase;">
            <i class="fa fa-plus-circle"></i>
            Thay đổi thông tin
        </div>
	      <div class="form-group <?php if(form_error('name')) echo 'has-error'; ?>">
	        <label for="exampleInputEmail1">Tên diễn viên</label>
              <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
	      </div>
	      <div class="form-group <?php if(form_error('description')) echo 'has-error'; ?>">
	        <label for="exampleInputEmail1">Mô tả</label>
	        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
	      </div>
	      <div class="form-group">
	        <label class="control-label col-md-4">Avatar</label>
	        <div class="col-md-8">
	              <div class="avatar" id="output1">
	                      <%--<img id="avatar" src="/Uploads/Core/noimg.jpg" width="96" max-height="54">--%>
                        <asp:Image ID="avatar" runat="server" ImageUrl="/Uploads/Core/noimg.jpg" width="96" max-height="54"/>
	              </div>        
	              <span class="btn btn-default btn-file">
	                  Browse
                      <asp:FileUpload ID="avatarinput" runat="server" />
	              </span>
	        </div>
	      </div>
	      <div class="form-group">
              <asp:HiddenField ID="hdid" runat="server" />
              <asp:Button ID="btnactor" runat="server" Text="Thay đổi" CssClass="btn btn-success pull-right" OnClick="btnactor_Click" />
	        <div class="cleared"></div>
	      </div>
    </div>
</asp:Content>
