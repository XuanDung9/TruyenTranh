<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucBrand.ascx.cs" Inherits="HamtruyenAdmin.wucBrand" %>
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">Quản lý thương hiệu
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
            <li class="active">Quản Lý thương hiệu
            </li>
            <li class="pull-right search-wrap"></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<div class="row-fluid" id="lst_ThuongHieu" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Danh sách các thương hiệu</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body" runat="server">
                <asp:Button ID="btnThemThuongHieu" runat="server" CssClass="btn btn-primary" CommandName="ThemThuongHieu" Text="Thêm thương hiệu" OnClick="btn_Them" />
                <div class="clearfix">
                </div>
                <div class="btn-group pull-right">
                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                        Tools <i class="icon-angle-down"></i>
                    </button>
                    <ul class="dropdown-menu pull-right">
                        <li><a href="#">Print</a></li>
                        <li><a href="#">Save as PDF</a></li>
                        <li><a href="#">Export to Excel</a></li>
                    </ul>
                </div>
            </div>
            <asp:Panel ID="pnlQuanLyThuongHieu" runat="server">
                <asp:GridView ID="gvThuongHieu" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvThuongHieu_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="TenThuongHieu" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Thao tác">
                            <ItemTemplate>
                                <asp:Button ID="btnSua" runat="server" CssClass="btn btn-primary" CommandName="Sua" Text="✎" ToolTip="Sửa" CommandArgument='<%# Eval("Id") %>' />
                                <asp:Button ID="btnXoa" runat="server" CssClass="btn btn-danger" CommandName="Xoa" Text="🗑" ToolTip="Xoá" OnClientClick="return confirm('Bạn có chắc muốn xoá?');" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
</div>

<div class="row-fluid" id="edit_ThuongHieu" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Chỉnh sửa thông tin thương hiệu</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body" runat="server">
                <div class="btn-group pull-right">
                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                        Tools <i class="icon-angle-down"></i>
                    </button>
                    <ul class="dropdown-menu pull-right">
                        <li><a href="#">Print</a></li>
                        <li><a href="#">Save as PDF</a></li>
                        <li><a href="#">Export to Excel</a></li>
                    </ul>
                </div>
            </div>

            <div class="row-fluid">
                <div class="form-group">
                    <label for="txtProductName">Tên :</label>
                    <asp:TextBox ID="txtTenThuongHieu" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save" OnClientClick="return confirm('Xác nhận cập nhật?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
            </div>
        </div>
    </div>
</div>
