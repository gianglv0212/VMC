<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="VMC.Video.Add" %>



<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Video">Danh sách video</a></li>
        <li class="active">Thay đổi video</li>
    </ol>
    <% if(error == 1){ %>
      <div class="alert alert-danger alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
          <span aria-hidden="true">×</span>
        </button>
        <strong>Lỗi!</strong>
        Video chưa thêm được vui lòng kiểm tra lại chuỗi nhập.
      </div>
    <% } %>
  <% if(success == 1){ %>
  <div class="alert alert-success alert-dismissible fade in" role="alert">
    <button class="close" aria-label="Close" data-dismiss="alert" type="button">
      <span aria-hidden="true">×</span>
    </button>
    <strong>Thành công!</strong>
    Video đã thêm xong.
  </div>
   <% } %> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="heading" style="text-transform:uppercase;">
<i class="fa fa-plus-circle"></i>
Thêm mới video
</div>

  <div class="form-group">
    <label for="exampleInputEmail1">Tên Video</label>
      <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:Label ID="lblName" runat="server" CssClass="error" Text=""></asp:Label>
  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Tên gốc</label>
      <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:Label ID="lblFullName" runat="server" CssClass="error" Text=""></asp:Label>
  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Mô tả</label>
      <asp:TextBox id="txtDescription" TextMode="multiline" CssClass="form-control" Rows="3" runat="server" />
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">Năm phát hành</label>
      <asp:TextBox ID="txtReleaseYear" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:Label ID="lblReleaseYear" runat="server" CssClass="error" Text=""></asp:Label>
  </div>
  <div class="form-group">
    <label>Loại</label>
      <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control type">
          <asp:ListItem Text="Video lẻ" Value="0"></asp:ListItem>
          <asp:ListItem Text="Video bộ" Value="1"></asp:ListItem>
      </asp:DropDownList>
  </div>
  <%--<div class="form-group">
    <label for="exampleInputPassword1">Order</label>
      <asp:TextBox ID="txtOrders" runat="server" CssClass="form-control"></asp:TextBox>
  </div>--%>
  <div class="form-group">
  	<label>Thuộc danh mục</label>
      <asp:ListBox ID="lbCate" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" tabindex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
      <asp:Label ID="lblCate" CssClass="error" runat="server" Text=""></asp:Label>
  </div>
  <div class="form-group">
    <label for="exampleInputEmail1">Tag</label>
      <asp:ListBox ID="lbTag" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" tabindex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
  </div>
    <script type="text/javascript" class="js-code-placeholder">
        $(".js-example-basic-multiple").select2();
    </script>
  <div class="form-group">
    <label for="exampleInputEmail1">Thiết bị</label>
      <asp:ListBox ID="lbDevice" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" tabindex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
  </div>
  <div class="form-group">
      <div class="row">
        <label class="control-label col-md-2">Ảnh video</label>
        <div class="col-md-4">
              <div class="avatar postimg" id="output1">
                  <asp:Image ID="avatar" runat="server" ImageUrl="/Uploads/Core/noimg.jpg" ClientIDMode="Static" Width="350" Height="285"/>
              </div>        
              <span class="btn btn-default btn-file">
                  Browse 
                  <asp:FileUpload ID="avatarinput" runat="server" />
              </span>
        </div>
        <label class="control-label col-md-2">Poster video</label>
        <div class="col-md-4">
              <div class="poster postimg" id="output2">
                  <asp:Image ID="poster" runat="server" ImageUrl="/Uploads/Core/noimg.jpg" ClientIDMode="Static" Width="200" Height="190" />
              </div>
              <span class="btn btn-default btn-file">
                  Browse 
                  <asp:FileUpload ID="posterinput" runat="server" ClientIDMode="Static" />
              </span>
        </div>
     </div>
  </div>
  <div class="form-group">
      <asp:CheckBox ID="status" runat="server" data-off-color="warning" checked />
  </div>
  <div class="form-group">
    <asp:Button ID="btnaddvideo" runat="server" Text="Thêm mới" CssClass="btn btn-success pull-right" OnClick="btnaddvideo_Click" />
      <asp:Button ID="Button2" runat="server" Text="Trở lại" CssClass="btn btn-danger pull-right" />
    <div class="cleared"></div>
  </div>


<script type="text/javascript">
    var $states = $(".js-source-states");
    var statesOptions = $states.html();
    $states.remove();

    $(".js-states").append(statesOptions);

  

    prettyPrint();

    $.fn.select2.amd.require([
      "select2/core",
      "select2/utils",
      "select2/compat/matcher"
    ], function (Select2, Utils, oldMatcher) {
        var $basicSingle = $(".js-example-basic-single");
        var $basicMultiple = $(".js-example-basic-multiple");
        var $limitMultiple = $(".js-example-basic-multiple-limit");

        var $dataArray = $(".js-example-data-array");
        var $dataArraySelected = $(".js-example-data-array-selected");

        var data = [
          { id: 0, text: 'enhancement' },
          { id: 1, text: 'bug' },
          { id: 2, text: 'duplicate' },
          { id: 3, text: 'invalid' },
          { id: 4, text: 'wontfix' }
        ];

       
        $.fn.select2.defaults.set("width", "100%");

        $basicSingle.select2();
        $basicMultiple.select2();
        $limitMultiple.select2({
            maximumSelectionLength: 2
        });

        function formatState(state) {
            if (!state.id) {
                return state.text;
            }
            var $state = $(
              '<span>' +
                '<img src="vendor/images/flags/' +
                  state.element.value.toLowerCase() +
                '.png" class="img-flag" /> ' +
                state.text +
              '</span>'
            );
            return $state;
        };

        $(".js-example-tokenizer").select2({
            tags: true,
            tokenSeparators: [',', ' ']
        });


    });
</script>
</asp:Content>
