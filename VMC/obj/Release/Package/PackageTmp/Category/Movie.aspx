<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="VMC.Category.Movie" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li class="active">Danh sách thể loại phim</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
    <div class="col-md-3">
      <div class="subcontent">
        <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="false">
          <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOne">
              <h4 class="panel-title">
                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                  Tìm kiếm
                </a>
              </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
              <div class="panel-body">
                <div id="divStatus" class="panel-body">
                  <div id="pnl_search" class="input-group">
                        <asp:TextBox ID="txtQuery" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="input-group-addon btn" OnClick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </asp:LinkButton>        
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOne">
              <h4 class="panel-title">
                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTow" aria-expanded="true" aria-controls="collapseOne">
                  Trạng thái
                </a>
              </h4>
            </div>
            <div id="collapseTow" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
              <div class="panel-body" id="divStatus">
                  <label class="checkbox">
                        <asp:CheckBox ID="chkon" runat="server" ClientIDMode="Static" />
                    <span>Hoạt động</span>
                  </label>
                  <label class="checkbox">
                      <asp:CheckBox ID="chkoff" runat="server" ClientIDMode="Static" />
                    <span>Không hoạt động</span>
                  </label>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-9">
      <div class="subcontent">
        <div class="heading" style="text-transform:uppercase;">
           <i class="fa fa-list"></i>
          Danh sách thể loại
          <a class="btn btn-sm btn-primary-outline pull-right" href="/Category/AddM">
            <i class="fa fa-plus"></i>
            Thêm mới
          </a>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="grvList" CssClass="table table-bordered" runat="server" 
                AutoGenerateColumns="False" OnRowDataBound="grvList_RowDataBound" AllowPaging="True" 
                OnPageIndexChanging="grvList_PageIndexChanging" PageSize="100" 
                OnSelectedIndexChanged="grvList_SelectedIndexChanged" HeaderStyle-CssClass="table-header">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Tên thể loại" ControlStyle-CssClass="col-main" />
                    <asp:TemplateField HeaderText="Trạng thái" ItemStyle-Width="20%">
                        <ItemTemplate><asp:Label ID="lblStatus" runat="server" Text='<%#Eval("status") %>'></asp:Label> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="orders" HeaderText="Order" ItemStyle-Width="20%" />
                    <%--<asp:TemplateField HeaderText="Ngày tạo">
                        <ItemTemplate><asp:Label ID="lblCreated" runat="server" Text='<%#Eval("created", "{0:dd/MM/yyyy HH:mm:ss}") %>'></asp:Label> </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Chức năng" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" CssClass="edit-row btn btn-primary" ID="HyperLink1" NavigateUrl='<%# "Edit?ID=" + Eval("id")  + "&type=0"%>' Text="Thay đổi">
                                <i class="fa fa-edit"></i> Thay đổi
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="created" HeaderText="Ngay tao 1" DataFormatString="{0:dd/MM/yyyy}" />--%>
                </Columns>
            </asp:GridView>
        </div>
      </div>
    </div>  
  </div>
</asp:Content>
