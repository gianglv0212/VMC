<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VMC.Account.Register" %>


<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <ol class="breadcrumb">
        <li><a href="/"><i class="fa fa-home"></i></a></li>
        <li><a href="/Account/Manage">Danh sách user</a></li>
        <li class="active">Tạo tài khoản</li>
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
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="heading" style="text-transform: uppercase;">
        <i class="fa fa-list"></i>
        Thêm mới user
    </div>

    <%--<asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">--%>
                <ContentTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Họ tên</label>
                            <asp:TextBox runat="server" ID="Full" CssClass="form-control" placeholder="Họ tên" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Full"
                                CssClass="field-validation-error error" ErrorMessage="Tên đầy đủ không được để trống." />
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email</label>
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" placeholder="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="field-validation-error error" ErrorMessage="Email không được để trống." />
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Tên đăng nhập</label>
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" placeholder="Tên đăng nhập" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="field-validation-error error" ErrorMessage="Tên đăng nhập không được để trống." />
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Mật khẩu</label>
                            <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="field-validation-error error" ErrorMessage="Nhập mật khẩu người dùng." />
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Xác nhận mật khẩu</label>
                            <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="form-control" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="field-validation-error error" Display="Dynamic" ErrorMessage="Nhập xác nhận mật khẩu." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="field-validation-error error" Display="Dynamic" ErrorMessage="Xác nhận mật khẩu và mật khẩu không khớp." />
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Quyền sử dụng</label>
                            <asp:DropDownList ID="ddlRole" runat="server"  CssClass="form-control">

                            </asp:DropDownList>
                        </div>
                        <asp:Button runat="server" CssClass="btn btn-success pull-right" OnClick="btnCreateUser_Click" ID="btnCreateUser"  Text="Đăng ký" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            <%--</asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>--%>
</asp:Content>
