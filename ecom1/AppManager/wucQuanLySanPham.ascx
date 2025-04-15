<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLySanPham.ascx.cs" Inherits="HamtruyenAdmin.wucQuanLySanPham" %>
<!-- BEGIN PAGE HEADER-->
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">Quản Lý Danh Sách Sản Phẩm
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
            <li class="active">Quản Lý Sản Phẩm
            </li>
            <li class="pull-right search-wrap"></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<div class="row-fluid" id="lst_SanPham" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Danh sách các Sản Phẩm</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
                <asp:Button ID="btnThemSP" runat="server" CssClass="btn btn-primary" CommandName="ThemSanPham" Text="Thêm Sản Phẩm" ToolTip="Thêm SP" OnClick="btn_Them" />
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
            <asp:Panel ID="pnlQuanLySanPham" runat="server" CssClass="table table-striped" Style="table-layout: fixed; width: 100%;">
                <asp:GridView ID="gvSanPham" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvSanPham_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="TenSP" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("HinhAnh") %>' Width="100px" Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ChieuDai" HeaderText="Chiều dài" />
                        <asp:BoundField DataField="CanNang" HeaderText="Cân nặng" />
                        <asp:BoundField DataField="MauSac" HeaderText="Màu sắc" />
                        <asp:BoundField DataField="GiaTien" HeaderText="Gía tiền" />
                        <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                        <asp:TemplateField HeaderText="Danh mục">
                            <ItemTemplate>
                                <%# Eval("DanhMuc.TenDanhMuc") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hoạt động">
                            <ItemTemplate>
                                <%# (bool)Eval("HoatDong") ? "Đang hoạt động" : "Không hoạt động" %>
                            </ItemTemplate>
                        </asp:TemplateField>

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
<div class="row-fluid" id="edit_SanPham" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Chỉnh sửa thông tin sản phẩm    </h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
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
                    <label for="txtTenSP">Tên Sản Phẩm:</label>
                    <asp:TextBox ID="txtTenSP" runat="server" CssClass="form-control" placeholder="Tên Sản Phẩm"></asp:TextBox>
                </div>
                <div class="control-group">
                    <label class="control-label">Hình ảnh</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuAnhSP" runat="server" CssClass="default" />
                        <br />
                        <asp:Image ID="imgAnhSP" runat="server" Width="100px" Height="80px" />
                    </div>
                </div>
                <div class="form-group">
                    <label>Chiều dài:</label>
                    <asp:TextBox ID="txtChieuDai" runat="server" CssClass="form-control" placeholder="Nhập chiều dài "></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Cân nặng:</label>
                    <asp:TextBox ID="txtCanNang" runat="server" CssClass="form-control" placeholder="Nhập cân nặng"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Màu sắc:</label>
                    <asp:TextBox ID="txtMauSac" runat="server" CssClass="form-control" placeholder="Nhập màu sắc"></asp:TextBox>
                </div>
                           <div class="form-group">
                    <label for="txtGiaTien">Gía tiền</label>
                    <asp:TextBox ID="txtGiaTien" runat="server" CssClass="form-control" placeholder="Nhập mô tả"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtProductName">Mô tả:</label>
                    <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control" placeholder="Nhập mô tả"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtProductName">Số lượng:</label>
                    <asp:TextBox ID="txtSoLuong" runat="server" CssClass="form-control" placeholder="Nhập số lượng"></asp:TextBox>
                </div>
                <div class="control-group">
                    <label class="control-label">Chọn danh mục sản phẩm </label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="input-large m-wrap" />
                    </div>
                </div>
                <asp:CheckBox ID="cbTrue" runat="server" AutoPostBack="true"  Text="Đang hoạt động" />
                <asp:CheckBox ID="cbFalse" runat="server" AutoPostBack="true"  Text="Không hoạt động" />

                <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save" OnClientClick="return confirm('Xác nhận cập nhật?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
            </div>
        </div>
    </div>
</div>



<!-- END PAGE HEADER-->

