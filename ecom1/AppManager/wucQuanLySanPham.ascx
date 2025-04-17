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
                        <asp:TemplateField HeaderText="Thao tác">
                            <ItemTemplate>
                                <asp:Button ID="btnActive" runat="server" CssClass="btn btn-gray" CommandName="Khoa" Text="🔒" ToolTip="Khóa" OnClientClick="return confirm('Bạn có chắc khóa sản phẩm?');" CommandArgument='<%# Eval("Id") %>' />
                                <asp:Button ID="btnSua" runat="server" CssClass="btn btn-primary" CommandName="Sua" Text="✎" ToolTip="Sửa" CommandArgument='<%# Eval("Id") %>' />
                                <asp:Button ID="btnXoa" runat="server" CssClass="btn btn-danger" CommandName="Xoa" Text="🗑" ToolTip="Xoá" OnClientClick="return confirm('Bạn có chắc muốn xoá?');" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <asp:Image ID="AnhDaiDien" runat="server" ImageUrl='<%# Eval("AnhDaiDien") %>' Width="100px" Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TenSP" HeaderText="Tên Sản Phẩm" />
                        <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
                        <asp:TemplateField HeaderText="Danh mục">
                            <ItemTemplate>
                                <%# Eval("DanhMuc.TenDanhMuc") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <%# (bool)Eval("TrangThai") ? "Đang hoạt động" : "Không hoạt động" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
</div>

<div class="row-fluid" id="edit_SanPham" runat="server">
    <div class="widget orange">
        <div class="widget-title">
            <h4><i class="icon-reorder"></i>Chỉnh sửa thông tin sản phẩm    </h4>
            <span class="tools">
                <a href="javascript:;" class="icon-chevron-down"></a>
                <a href="javascript:;" class="icon-remove"></a>
            </span>
        </div>
        <div class="widget-body">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Tên Sản Phẩm:</label>
                    <div class="controls">
                        <asp:TextBox type="txtTenSP" ID="txtTenSP" runat="server" placeholder="Nhập tên menu" class="input-xlarge" />
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label">Ảnh đại diện:</label>
                    <div class="controls">
                        <asp:Image ID="Image1" runat="server" Width="150px" Height="100px" />
                        <asp:FileUpload ID="fuAnhSP" runat="server" CssClass="default" />
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label">Màu sắc:</label>
                    <div class="controls">
                        <asp:TextBox ID="txtMauSac" runat="server" class="input-xlarge"></asp:TextBox>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label">Ảnh sản phẩm:</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuAnhSanPham" runat="server" CssClass="form-control" Style="width: 200px;" />
                        <asp:Button ID="btnThemHinhAnh" runat="server" Text="+ Thêm Hình Ảnh"
                            CssClass="btn btn-primary" Style="margin-left: 10px;" OnClick="btnThemHinhAnh_Click" />
                        <br />
                        <asp:GridView ID="gvAnhSP" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-hover"
                            EmptyDataText="Chưa có hình ảnh nào"
                            OnRowCommand="gvAnhSP_RowCommand"
                            Style="width: auto;">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnXoa" runat="server" CommandName="Xoa"
                                            CommandArgument='<%# Container.DataItemIndex %>'
                                            CssClass="btn btn-danger btn-sm">
                            <i class="fa fa-times"></i> Xóa
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hình ảnh">
                                    <ItemStyle Width="250px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Image ID="Image2" runat="server"
                                            Width="140px" Height="100px"
                                            CssClass="img-thumbnail"
                                            ImageUrl='<%# Eval("ImageUrl") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>

                </div>

                <div class="control-group">
                    <label class="control-label">xLarge Textarea</label>
                    <div class="controls">
                        <textarea id="txtMoTa" runat="server" class="input-xlarge" rows="3"></textarea>
                    </div>
                </div>


                <div class="control-group">
                    <label class="control-label">Danh mục:</label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="input-large m-wrap" />
                    </div>
                </div>


                <div class="control-group">
                    <label class="control-label">Tùy chọn:</label>
                    <div class="controls">
                        <div style="display: flex; flex-direction: column; gap: 10px;">
                            <!-- Hàng chứa các TextBox và Button -->
                            <div style="display: flex; flex-wrap: wrap; gap: 10px; align-items: center;">
                                <asp:TextBox ID="txtChieuDai" runat="server" CssClass="form-control" Placeholder="Chiều dài" Width="100px" />
                                <asp:TextBox ID="txtCanNang" runat="server" CssClass="form-control" Placeholder="Cân nặng" Width="100px" />
                                <asp:TextBox ID="txtGiaTien" runat="server" CssClass="form-control" Placeholder="Giá tiền" Width="100px" />
                                <asp:TextBox ID="txtSoLuong" runat="server" CssClass="form-control" Placeholder="Số lượng" Width="100px" />
                                <asp:Button ID="btnThemTuyChon" runat="server" Text="+ Thêm Tùy Chọn"
                                    CssClass="btn btn-primary" OnClick="btnThemTuyChon_Click" />
                            </div>
                        </div>
                        <br />
                        <div style="width: 50%">
                            <asp:GridView ID="gvTuyChon" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="Chưa có tùy chọn nào"
                                OnRowCommand="gvTuyChon_RowCommand"
                                CssClass="table table-bordered table-hover"
                                Style="width: 300;">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnXoa" runat="server"
                                                CommandName="Xoa"
                                                CommandArgument='<%# Container.DataItemIndex %>'
                                                CssClass="btn btn-danger">Xóa
                            <i class="fa fa-times"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ChieuDai" HeaderText="Chiều dài" />
                                    <asp:BoundField DataField="CanNang" HeaderText="Cân nặng" />
                                    <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                                    <asp:BoundField DataField="GiaTien" HeaderText="Giá" DataFormatString="{0:N0} VNĐ" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label">Trạng thái:</label>
                    <div class="controls">
                        <asp:CheckBox ID="cbAction" runat="server" Text="Hiển thị" />
                    </div>
                </div>


                <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save" OnClientClick="return confirm('Xác nhận cập nhật?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
            </div>
        </div>
    </div>
</div>


<!-- END PAGE HEADER-->
