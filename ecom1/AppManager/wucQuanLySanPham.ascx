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
                </span>f
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
            <asp:Panel ID="pnlQuanLySanPham" runat="server">
                <asp:GridView ID="gvSanPham" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvSanPham_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Name_Product" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("Image_Product") %>' Width="100px" Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SKU" HeaderText="SKU" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Số lượng" />
                        <asp:BoundField DataField="Color" HeaderText="Màu" />
                        <asp:BoundField DataField="Version" HeaderText="Phiên bản" />
                        <asp:BoundField DataField="Price" HeaderText="Gía" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                        <asp:TemplateField HeaderText="Thao tác">
                            <ItemTemplate>
                                <asp:Button ID="btnChiTiet" runat="server" CssClass="btn btn-success" CommandName="ChiTiet" Text="✔" ToolTip="Chi tiết" />
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
<div id="edit_SanPham" runat="server" class="row-fluid">
    <h4>Sửa Sản Phẩm</h4>
    <div class="form-group">
        <label for="txtProductName">Tên Sản Phẩm:</label>
        <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Tên Sản Phẩm"></asp:TextBox>
    </div>
    <div class="control-group">
        <label class="control-label">Hình ảnh</label>
        <div class="controls">
            <asp:FileUpload ID="fuHinhAnh" runat="server" CssClass="default" />
            <asp:Image ID="imgHinhAnh" runat="server" Width="150px" Height="150px" />
        </div>
    </div>
    <div class="form-group">
        <label for="txtProductName">SKU:</label>
        <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" placeholder="Tên Sản Phẩm"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtProductName">Số lượng:</label>
        <asp:TextBox ID="txtSoLuong" runat="server" CssClass="form-control" placeholder="Tên Sản Phẩm"></asp:TextBox>
    </div>
    <div class="control-group">
        <label class="control-label">Phiên bản</label>
        <div class="controls">
            <asp:DropDownList ID="ddlVersion" runat="server" CssClass="input-xlarge"
                DataTextField="Name_Version" DataValueField="Id">
            </asp:DropDownList>

            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success"
                NavigateUrl="~/CreateVersion.aspx" Style="margin-left: 10px;">
                                <i class="icon-plus"></i>
            </asp:HyperLink>
        </div>
    </div>

    <div class="control-group">
        <label class="control-label">Màu sắc</label>
        <div class="controls">
            <asp:DropDownList ID="ddlMauSac" runat="server" CssClass="input-xlarge"
                DataTextField="Name_Color" DataValueField="Id">
            </asp:DropDownList>

            <asp:HyperLink ID="lnkThemMau" runat="server" CssClass="btn btn-success"
                NavigateUrl="~/CreateColor.aspx" Style="margin-left: 10px;">
                                <i class="icon-plus"></i>
            </asp:HyperLink>
        </div>
    </div>
    <div class="form-group">
        <label for="txtProductName">Gía:</label>
        <asp:TextBox ID="txtGia" runat="server" CssClass="form-control" placeholder="Tên Sản Phẩm"></asp:TextBox>
    </div>
    <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save"  OnClientClick="return confirm('Xác nhận cập nhật?');"/>
    <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
</div>


<!-- END PAGE HEADER-->

