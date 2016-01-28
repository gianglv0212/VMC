<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="VMC.Role.Permission" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Role">Danh sách nhóm quyền</a></li>
        <li class="active">Thay đổi & cấp quyền</li>
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
                <label for="exampleInputEmail1">Chọn chức năng</label>
                <asp:ListBox ID="lbLink" runat="server" CssClass="form-control js-example-basic-multiple js-states form-control select2-hidden-accessible" aria-hidden="true" TabIndex="-1" multiple="multiple" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="form-group">
                <asp:HiddenField ID="hdfid" runat="server" />
                <asp:Button runat="server" CssClass="btn btn-success pull-right" OnClick="btnUpdateRole_Click" ID="btnUpdateRole" Text="Cập nhật" />
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
