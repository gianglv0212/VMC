<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="VMC.FileEdit.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li>
            <asp:HyperLink ID="hpl1" runat="server">
                <asp:Label ID="lbllink1" runat="server" Text=""></asp:Label>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="hpl2" runat="server">
                <asp:Label ID="lbllink2" runat="server" Text=""></asp:Label>
            </asp:HyperLink>
        </li>
        <li class="active">Thay đổi tập</li>
    </ol>
    <% if (lblmess.Text != "")
       {%>
    <div class="alert alert-success alert-dismissible fade in" role="alert">
        <button class="close" aria-label="Close" data-dismiss="alert" type="button">
            <span aria-hidden="true">×</span>
        </button>
        <asp:Label ID="lblmess" runat="server" Text=""></asp:Label>
    </div>
    <% } %>
    <% if(lblerror.Text != ""){ %>
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
        Thay đổi thông tin tập
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Tên tập</label>

        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Tên tập"></asp:TextBox>
        <span class="error"></span>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Tập số</label>
        <asp:TextBox ID="txtOrdering" runat="server" CssClass="form-control" placeholder="Tập số"></asp:TextBox>
        <span class="error"></span>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Mô tả</label>
        <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="multiline" Rows="3" runat="server" placeholder="Mô tả"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Tag</label>
        <asp:ListBox ID="lbtag" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
    </div>
    <div class="form-group">
        <div class="row">
            <label class="control-label col-md-2">Ảnh video</label>
            <div class="col-md-4">
                <div class="avatar postimg" id="output1">
                    <asp:Image ID="avatar" runat="server" ClientIDMode="Static" Width="350" Height="285" />
                    
                </div>
                <span class="btn btn-default btn-file">Chọn ảnh
                <asp:FileUpload ID="avatarinput" runat="server" ClientIDMode="Static" onchange="readURL(this,'avatar','output1');" />
                </span>
            </div>
            <label class="control-label col-md-2">Poster video</label>
            <div class="col-md-4">
                <div class="poster postimg" id="output2">
                    <asp:Image ID="poster" runat="server" ClientIDMode="Static" Width="200" Height="190" />
                </div>
                <span class="btn btn-default btn-file">Chọn ảnh
                    <asp:FileUpload ID="posterinput" runat="server" ClientIDMode="Static" onchange="readURL(this,'poster','output2');" />
                </span>
            </div>
        </div>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="chkstatus" runat="server" data-off-color="warning"  />
    </div>
    <div class="form-group">
        <asp:HiddenField ID="hdfid" runat="server" />
        <asp:Button ID="btnUpdate" CssClass="btn btn-success pull-right" runat="server" Text="Thay đổi" OnClick="btnUpdate_Click" />
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
