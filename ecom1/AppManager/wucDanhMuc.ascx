<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDanhMuc.ascx.cs" Inherits="HamtruyenAdmin.wucDanhMuc" %>
<!-- BEGIN PAGE HEADER-->
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">Quản lý danh mục
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
            <li class="active">Quản Lý danh mục 
            </li>
            <li class="pull-right search-wrap"></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<div class="row-fluid" id="lst_DanhMuc" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Danh sách danh mục</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body" runat="server">
                <asp:Button ID="btnThemDanhMuc" runat="server" CssClass="btn btn-primary" CommandName="ThemDanhMuc" Text="Thêm danh mục" OnClick="btn_Them" />
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
            <asp:Panel ID="pnlQuanLyDanhMuc" runat="server">
                <asp:GridView ID="gvDanhMuc" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvDanhMuc_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="TenDanhMuc" HeaderText="Tên Danh Muc" />
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

<div class="row-fluid" id="edit_DanhMuc" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Chỉnh sửa Danh mục</h4>
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
                    <label for="txtTenDanhMuc">Tên :</label>
                    <asp:TextBox ID="txtTenDanhMuc" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save" OnClientClick="return confirm('Xác nhận cập nhật?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
            </div>
        </div>
    </div>
</div>
