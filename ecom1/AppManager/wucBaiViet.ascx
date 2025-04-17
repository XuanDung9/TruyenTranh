<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucBaiViet.ascx.cs" Inherits="HamtruyenAdmin.wucBaiViet" %>
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">Quản Lý Bài Viết
        </h3>
        <ul class="breadcrumb">
            <li>
                <a href="/Admin.aspx">Home</a>
                <span class="divider">/</span>
            </li>
            <li>
                <a href="/Admin.aspx">Quản Lý Nội Dung</a>
                <span class="divider">/</span>
            </li>
            <li class="active">Tạo Bài Viết
            </li>
            <li class="pull-right search-wrap"></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<!--START LIST MENU-->
<div class="row-fluid" id="list_post" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Danh sách Bìa Viết</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="control-group">
                    <asp:Button ID="btnAddPost" CssClass="btn btn-info" runat="server" Text="Thêm Bài Viết Mới" OnClick="btnAddPost_Click" />
                </div>
                <asp:GridView ID="gvListPost" CssClass="table table-striped table-bordered table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="gvListPost_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnSua" CssClass="btn btn-primary" CommandName="Sua" CommandArgument='<%# Eval("Id") %>'><i class="icon-pencil"></i></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnXoa" CommandName="Xoa" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-danger"><i class="icon-trash "></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Tiêu đề" DataField="TieuDe" />
                        <asp:BoundField HeaderText="Nội dung " DataField="NoiDung" />
                        <asp:BoundField HeaderText="Ngày đăng" DataField="NgayDang" />
                        <asp:BoundField HeaderText="Trạng thái" DataField="TrangThai" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="green">
                            <div class="metro_tmlabel">
                                <h2>Hiện tại, chưa tạo nội dung cho chức năng này!</h2>
                            </div>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
<!--END LIST MENU-->
<!--START EDIT MENUFORM-->
<div class="row-fluid" id="edit_post" visible="false" runat="server">
    <div class="widget orange">
        <div class="widget-title">
            <h4><i class="icon-reorder"></i>Chỉnh sửa bài viết</h4>
            <span class="tools">
                <a href="javascript:;" class="icon-chevron-down"></a>
                <a href="javascript:;" class="icon-remove"></a>
            </span>
        </div>
        <div class="widget-body">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Tiêu đề : </label>
                    <div class="controls">
                        <asp:TextBox type="text" ID="txtTieuDe" runat="server" placeholder="Nhập tiêu đề" class="input-xlarge" />
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label">Nội dung : </label>
                    <div class="controls">
                        <textarea type="text" id="txtNoiDung" runat="server" placeholder="Nhập nội dung bài viết" class="input-xxlarge" rows="4" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">Hiển thị</label>
                    <div class="controls">
                        <asp:CheckBox ID="cbView" runat="server" />
                    </div>
                </div>

                <div class="control-group">
                    <asp:Button ID="btnUpdate" CssClass="btn btn-large btn-success" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-large btn-danger" runat="server" Text="Hủy Bỏ" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
