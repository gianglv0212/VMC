﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC.Publics.Default" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>jQuery File Upload Demo</title>
    <meta name="description" content="File Upload widget with multiple file selection, drag&amp;drop support, progress bar and preview images for jQuery. Supports cross-domain, chunked and resumable file uploads. Works with any server-side platform (Google App Engine, PHP, Python, Ruby on Rails, Java, etc.) that supports standard HTML form file uploads.">
    <meta name="viewport" content="width=device-width">
    <!-- Bootstrap CSS Toolkit styles -->
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">
    <!-- Generic page styles -->
    <link rel="stylesheet" href="css/style.css">
    <!-- Bootstrap styles for responsive website layout, supporting different screen sizes -->
    <!-- Bootstrap CSS fixes for IE6 -->
    <!--[if lt IE 7]><link rel="stylesheet" href="//blueimp.github.com/cdn/css/bootstrap-ie6.min.css"><![endif]-->
    <!-- Bootstrap Image Gallery styles -->
    <link rel="stylesheet" href="//blueimp.github.io/Gallery/css/blueimp-gallery.min.css">
    <!-- CSS to style the file input field as button and adjust the Bootstrap progress bars -->
    <link rel="stylesheet" href="css/jquery.fileupload-ui.css">
    <!-- Shim to make HTML5 elements usable in older Internet Explorer versions -->
    <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
</head>
<body>
    <div class="row" style="padding: 10px 40px;">
        <!-- The file upload form used as target for the file upload widget -->
        <form id="fileupload" action="server/dotnet/Default.aspx" method="POST" enctype="multipart/form-data">
            <!-- The fileupload-buttonbar contains buttons to add/delete files and start/cancel the upload -->
            <div class="row fileupload-buttonbar">
                <div class="span7">
                    <!-- The fileinput-button span is used to style the file input field as button -->
                    <span class="btn btn-success fileinput-button">
                        <i class="fa fa-plus"></i>
                        <span>Thêm tập</span>
                        <input type="file" name="files[]" multiple>
                    </span>
                    <button type="submit" class="btn btn-primary start">
                        <i class="glyphicon glyphicon-upload"></i>
                        <span>Tải lên</span>
                    </button>
                    <button type="reset" class="btn btn-warning cancel">
                        <i class="glyphicon glyphicon-remove"></i>
                        <span>Hủy tải lên</span>
                    </button>
                    <button type="button" class="btn btn-primary-outline" onclick="window.location.href=window.location.href">
                        <i class="glyphicon fa fa-refresh"></i>
                        <span>Reload</span>
                    </button>
                    <!--<input type="checkbox" class="toggle">-->
                </div>
                <!-- The global progress information -->
                <div class="span5 fileupload-progress fade">
                    <!-- The global progress bar -->
                    <div class="progress progress-success progress-striped active">
                        <div class="bar" style="width: 0%;"></div>
                    </div>
                    <!-- The extended global progress information -->
                    <div class="progress-extended">&nbsp;</div>
                </div>

            </div>
            <!-- The loading indicator is shown during file processing -->
            <div class="fileupload-loading"></div>
            <br>

            <!-- The table listing the files available for upload/download -->

            <table class="table table-striped">
                <tbody class="files" data-toggle="modal-gallery" data-target="#modal-gallery">
                </tbody>
            </table>
            <div style="border-top: 1px solid #989898; height: 1px; margin: 15px auto; width: 96%;"></div>
            <div class="heading" style="text-transform: uppercase;">
                <i class="fa fa-list"></i>
                Biên tập videos
            </div>
            <form runat="server">
                <asp:GridView ID="grvFile" runat="server" AutoGenerateColumns="false"
                    ShowHeaderWhenEmpty="true" CssClass="table table-striped" OnRowDataBound="grvFile_RowDataBound"
                    HeaderStyle-CssClass="table-header" BorderStyle="None">
                    <Columns>
                        <asp:TemplateField HeaderText="#" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="lblview" onclick="playvideo(this);" data-stream='<%#Eval("url") %>' CssClass="preview glyphicon glyphicon-facetime-video" runat="server" Font-Size="5em" title="Click to play this video"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên tập">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdftype" runat="server" Value='<%# Eval("type") %>' />
                                <asp:HyperLink ID="hpledit" runat="server" NavigateUrl='<%# "/File/Edit/" +  Eval("id") %>' Target="_parent">
                                    <strong>
                                        <asp:Label Text='<%#Eval("title") %>' ID="lbltitle" runat="server"></asp:Label>
                                    </strong>
                                </asp:HyperLink><br />
                                Id: <i>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("id") %>'></asp:Label></i>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label Text='<%#Eval("status") %>' ID="lblStatus" runat="server"></asp:Label></br>
                                <asp:Label ID="lblusername" runat="server" Text='<%#Eval("uname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ordering" HeaderText="Tập số" ItemStyle-Width="15%" />
                        <%--<asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:HyperLink ID="hplxuatban" OnClick="javascipt:alert(1);" data-id='<%#Eval("id") %>' data-status="1" runat="server" CssClass="btn width-80 btn-xs btn-appro btn-success-outline">
                                    <i class="fa fa-cog"></i>
                                    Xuất bản
                                </asp:HyperLink>
                                <asp:HyperLink ID="hplhaphim" OnClick="javascipt:alert(1);" data-id='<%#Eval("id") %>' data-status="0" runat="server" CssClass="btn width-80 btn-xs btn-appro btn-warning-outline">
                                    <i class="fa fa-cog"></i>
                                    Hạ phim
                                </asp:HyperLink>
                                <asp:Button ID="hplxoa" data-id='<%#Eval("id") %>' runat="server" data-type="POST" data-url='<%#Eval("url") %>' CssClass="btn btn-danger-outline width-80  btn-xs btn-delete "  >
                                    <span class="glyphicon glyphicon-trash"></span>
                                    Xóa phim
                                </asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>

                <!-- The template to display files available for upload -->

                <script id="template-upload" type="text/x-tmpl">
        {% for (var i=0, file; file=o.files[i]; i++) { %}
        <tr class="template-upload fade">
            <td><span class="preview"></span></td>
            <td class="name">
                <span>
                    <asp:HiddenField runat="server" ID="id"></asp:HiddenField>
                    <asp:HiddenField runat="server" ID="type"></asp:HiddenField>
                    <label>Tên tập</label>
                    <input class="form-control valid" type="text" required value="video" name="title">
                    <label>Tập số</label>
                    <input class="form-control" type="text" placeholder="Tập số / Số thứ tự" name="ordering">
                </span>
            </td>
            <td class="size"><span>{%=o.formatFileSize(file.size)%}</span></td>
            {% if (file.error) { %}
            <td class="error" colspan="2"><span class="label label-important">{%=locale.fileupload.error%}</span> {%=locale.fileupload.errors[file.error] || file.error%}</td>
            {% } else if (o.files.valid && !i) { %}
            <td>
                <div class="progress progress-success progress-striped active"><div class="bar" style="width:0%;"></div></div>
            </td>
            <td class="start">
                {% if (!o.options.autoUpload) { %}
                <button class="btn btn-primary">
                    <i class="icon-upload icon-white"></i>
                    <span>{%=locale.fileupload.start%}</span>
                </button>
                {% } %}
            </td>
            {% } else { %}
            <td colspan="2"></td>
            {% } %}
            <td class="cancel">
                {% if (!i) { %}
                <button class="btn btn-warning">
                    <i class="icon-ban-circle icon-white"></i>
                    <span>{%=locale.fileupload.cancel%}</span>
                </button>
                {% } %}
            </td>
        </tr>
        {% } %}
                </script>
            </form>
            <table class="table table-striped">
                <tbody id="list_video_file" class="list" data-toggle="modal-gallery" data-target="#modal-gallery">
                </tbody>
            </table>
        </form>

    </div>


    <!-- The template to display files available for download -->
    <script id="template-download" type="text/x-tmpl">
        <%--{% for (var i=0, file; file=o.files[i]; i++) { %}
        <tr class="template-download fade">
            {% if (file.error) { %}
            <td>
                <span class=" preview glyphicon glyphicon-facetime-video" style="cursor: pointer; font-size: 5em;" title="Click to play this video"></span>
            </td>
            <td class="name"><span>{%=file.name%}</span></td>
            <td class="size"><span>{%=o.formatFileSize(file.size)%}</span></td>
            <td class="error" colspan="2"><span class="label label-important">{%=locale.fileupload.error%}</span> {%=locale.fileupload.errors[file.error] || file.error%}</td>
            {% } else { %}
            <td class="preview">
                <span class=" preview glyphicon glyphicon-facetime-video" onclick="playvideo(this);" data-stream="{%=file.url%}" style="cursor: pointer; font-size: 5em;" title="Click to play this video"></span>
                {% if (file.thumbnail_url) { %}
                <a href="{%=file.url%}" title="{%=file.name%}" rel="gallery" download="{%=file.name%}"></a>
                {% } %}
            </td>
            <!--<td class="name">
                <a href="{%=file.url%}" title="{%=file.name%}" rel="{%=file.thumbnail_url&&'gallery'%}" download="{%=file.name%}">{%=file.name%}</a>
            </td>-->
            <td class="size"><span>{%=o.formatFileSize(file.size)%}</span></td>
            <td colspan="2"></td>
            {% } %}
            <td class="delete">
                <button class="btn btn-danger" data-type="POST" data-url="{%=file.delete_url%}">
                    <i class="icon-trash icon-white"></i>
                    <span>{%=locale.fileupload.destroy%}</span>
                </button>
                <!--<input type="checkbox" name="delete" value="1">-->
            </td>
        </tr>
        {% } %}--%>
    </script>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <!-- The jQuery UI widget factory, can be omitted if jQuery UI is already included -->
    <script src="js/vendor/jquery.ui.widget.js"></script>
    <!-- The Templates plugin is included to render the upload/download listings -->
    <script src="http://blueimp.github.io/JavaScript-Templates/js/tmpl.min.js"></script>
    <!-- The Load Image plugin is included for the preview images and image resizing functionality -->
    <script src="//blueimp.github.io/JavaScript-Load-Image/js/load-image.all.min.js"></script>
    <!-- The Canvas to Blob plugin is included for image resizing functionality -->
    <script src="//blueimp.github.io/JavaScript-Canvas-to-Blob/js/canvas-to-blob.min.js"></script>
    <!-- Bootstrap JS and Bootstrap Image Gallery are not required, but included for the demo -->
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="//blueimp.github.io/Gallery/js/jquery.blueimp-gallery.min.js"></script>
    <!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
    <script src="js/jquery.iframe-transport.js"></script>
    <!-- The basic File Upload plugin -->
    <script src="js/jquery.fileupload.js"></script>
    <!-- The File Upload file processing plugin -->
    <script src="js/jquery.fileupload-fp.js"></script>
    <!-- The File Upload user interface plugin -->
    <script src="js/jquery.fileupload-ui.js"></script>
    <!-- The localization script -->
    <script src="js/locale.js"></script>
    <!-- The main application script -->
    <script src="js/main.js"></script>
    <!-- The File Upload video preview plugin -->
    <script src="js/jquery.fileupload-video.js"></script>
    <!-- The client -->
    <script src="js/Client.js"></script>
    <script src="js/bootstrap-confirmation.js"></script>
    <!-- The XDomainRequest Transport is included for cross-domain file deletion for IE8+ -->
    <!--[if gte IE 8]><script src="js/cors/jquery.xdr-transport.js"></script><![endif]-->
</body>
</html>
