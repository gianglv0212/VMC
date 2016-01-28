<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="VMC.Category.Add" %>


<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Category/Video">Danh sách thể loại video</a></li>
        <li class="active">Thêm mới thể loại</li>
    </ol>
    <% if(lblerror.Text != null){ %>
    <div class="alert alert-danger alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    </div>
    <% } %>
    <% if(lblmess.Text != null){ %>
    <div class="alert alert-success alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        <asp:Label ID="lblmess" runat="server" Text=""></asp:Label>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="heading" style="text-transform:uppercase;">
        <i class="fa fa-plus-circle"></i>
        Thêm mới thể loại
    </div>
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
  <div class="form-group>">
    <label for="exampleInputEmail1">Tên thể loại</label>
    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"  ></asp:TextBox>
      <asp:Label ID="lblName" runat="server" Text="" CssClass="error"></asp:Label>
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
  </div>
  <div class="form-group">
    <label class="control-label col-md-4">Avatar</label>
    <div class="col-md-8">
          <div class="avatar postimg" id="output1">
                  <img id="avatar" src="/Uploads/Core/noimg.jpg" width="200" height="150">
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
      <asp:Button ID="btncatevideo" OnClick="btncatevideo_Click" runat="server" Text="Đồng ý" CssClass="btn btn-success pull-right"/>
      <asp:Button ID="btnback" runat="server" Text="Trở lại" CssClass="btn btn-danger pull-right"/>
    <div class="cleared"></div>
  </div>

</asp:Content>
