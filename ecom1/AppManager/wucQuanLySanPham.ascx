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
                        <asp:BoundField DataField="Name_Product" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("Image_Product") %>' Width="100px" Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Màu">
                            <ItemTemplate>
                                <%# string.Join(", ", ((List<HamtruyenLibrary.Models.Color>)Eval("Color")).Select(c => c.Name_Color)) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Phiên bản">
                            <ItemTemplate>
                                <%# string.Join(", ", ((List<HamtruyenLibrary.Models.Versions>)Eval("Version")).Select(c => c.Name_Version)) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Thương hiệu">
                            <ItemTemplate>
                                <%# string.Join(", ", ((List<HamtruyenLibrary.Models.ThuongHieu>)Eval("ThuongHieu")).Select(c => c.TenThuongHieu)) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Thao tác">
                            <ItemTemplate>
                                <%-- <asp:Button ID="btnChiTiet" runat="server" CssClass="btn btn-success" CommandName="ChiTiet" Text="✔" ToolTip="Chi tiết" />--%>
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
                </span>f
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
                    <label for="txtProductName">Tên Sản Phẩm:</label>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Tên Sản Phẩm"></asp:TextBox>
                </div>
                <div class="control-group">
                    <label class="control-label">Hình ảnh</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuHinhAnh" runat="server" CssClass="default" />
                        <br />
                        <asp:Image ID="imgHinhAnh" runat="server" Width="150px" Height="150px" />
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label">Phiên bản</label>
                    <div class="controls">
                        <asp:TextBox ID="txtTenPhienBan" runat="server" CssClass="form-control" placeholder="Tên Phiên bản"></asp:TextBox>
                        <asp:TextBox ID="txtGiaPhienBan" runat="server" CssClass="form-control" placeholder="Gía tiền"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">Màu sắc</label>
                    <div class="controls">
                        <asp:Repeater ID="rptColorImages" runat="server">
                            <ItemTemplate>
                                <div style="display: inline-block; margin: 10px; text-align: center;">
                                    <asp:Image ID="imgColorItem" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("Img_Color") %>' />
                                    <br />
                                    <asp:Label ID="lblColorName" runat="server" Text='<%# Eval("Name_Color") %>'></asp:Label>
                                </div>
                                <br />
                                <asp:FileUpload ID="fuColor" runat="server" CssClass="default" />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:TextBox ID="txtTenMauSac" runat="server" CssClass="form-control" placeholder="Tên màu sắc"></asp:TextBox>
                        <asp:TextBox ID="txtMaMau" runat="server" CssClass="form-control" placeholder="Mã màu"></asp:TextBox>
                        <asp:TextBox ID="txtImgColor" runat="server" CssClass="form-control" placeholder="Gía tiền"></asp:TextBox>

                        <br />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">Thương hiệu </label>
                    <div class="controls">
                        <asp:TextBox ID="txtTenThuongHieu" runat="server" CssClass="form-control" placeholder="Tên Thương hiệu"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save" OnClientClick="return confirm('Xác nhận cập nhật?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
            </div>
        </div>
    </div>
</div>



<!-- END PAGE HEADER-->

