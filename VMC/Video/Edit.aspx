<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="VMC.Video.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Video">Danh sách video</a></li>
        <li class="active">Thay đổi video</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-content">
        <div class="row">
            <div class="col-md-4">
                <div class="heading" style="text-transform: uppercase;">
                    <i class="fa fa-list"></i>
                    Thay đổi video
                        <a class="btn btn-sm btn-primary-outline pull-right" href="/Video/add">
                            <i class="fa fa-plus"></i>
                            Thêm video
                        </a>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Tên Video</label>
                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Tên video"></asp:TextBox>
                    <span class="error">
                        <asp:Label ID="lblname" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Tên gốc</label>
                    <asp:TextBox ID="txtfullname" runat="server" CssClass="form-control" placeholder="Tên gốc"></asp:TextBox>
                    <span class="error">
                        <asp:Label ID="lblfullname" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Mô tả</label>
                    <asp:TextBox ID="txtDescription" TextMode="multiline" CssClass="form-control" Rows="3" runat="server" placeholder="Mô tả" />
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Năm phát hành</label>
                    <asp:TextBox ID="txtreleaseyear" runat="server" CssClass="form-control" placeholder="Năm phát hành"></asp:TextBox>
                    <span class="error">
                        <asp:Label ID="lblreleaseyear" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="form-group">
                    <label>Loại</label>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control type">
                        <asp:ListItem Text="Video lẻ" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Video bộ" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Thuộc danh mục</label>
                    <asp:ListBox ID="lbCate" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" TabIndex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
                    <asp:Label ID="lblCate" CssClass="error" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Tag</label>
                    <asp:ListBox ID="lbTag" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" TabIndex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
                    <asp:Label ID="lblTag" CssClass="error" runat="server" Text=""></asp:Label>
                </div>
                <script type="text/javascript" class="js-code-placeholder">
                    $(".js-example-basic-multiple").select2();
                </script>
                <div class="form-group">
                    <label for="exampleInputEmail1">Thiết bị</label>
                    <asp:ListBox ID="lbDevice" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" TabIndex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="control-label col-md-12">Ảnh video</label>
                        <div class="col-md-12">
                            <div class="avatar postimg" id="output1">
                                <asp:Image ID="avatar" runat="server" ImageUrl="/Uploads/Core/noimg.jpg" ClientIDMode="Static" Width="350" Height="285" />
                            </div>
                            <span class="btn btn-default btn-file">Browse 
                                      <asp:FileUpload ID="avatarinput" runat="server" />
                            </span>
                        </div>
                        <label class="control-label col-md-12">Poster video</label>
                        <div class="col-md-12">
                            <div class="poster postimg" id="output2">
                                <asp:Image ID="poster" runat="server" ImageUrl="/Uploads/Core/noimg.jpg" ClientIDMode="Static" Width="200" Height="190" />
                            </div>
                            <span class="btn btn-default btn-file">Browse 
                                      <asp:FileUpload ID="posterinput" runat="server" ClientIDMode="Static" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:CheckBox ID="status" runat="server" data-off-color="warning" Checked />
                </div>
                <div class="form-group">
                    <asp:HiddenField ID="hdid" runat="server" />
                    <asp:Button ID="btnupdatevideo" runat="server" Text="Thêm mới" CssClass="btn btn-success pull-right" OnClick="btnupdatevideo_Click" />
                    <div class="cleared"></div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="heading" style="text-transform: uppercase;">
                    <i class="fa fa-list"></i>
                    Tải videos
                </div>
                <iframe id="IfUpload" runat="server" width="100%" style="height: 1206px;" class="iframe-Upload " frameborder="0" scrolling="no">
                    <p>Your browser does not support iframes.</p>
                </iframe>

            </div>
        </div>
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
