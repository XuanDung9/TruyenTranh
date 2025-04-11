<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucColor.ascx.cs" Inherits="HamtruyenAdmin.wucColor" %>
<!-- BEGIN PAGE HEADER-->
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">Quản lý màu sắc
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
            <li class="active">Quản Lý Màu Sắc
            </li>
            <li class="pull-right search-wrap"></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<div class="row-fluid" id="lst_MauSac" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Danh sách các màu sắc</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body" runat="server">
                <asp:Button ID="btnThemMauSac" runat="server" CssClass="btn btn-primary" CommandName="ThemMauSac" Text="Thêm Màu Sắc" OnClick="btn_Them" />
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
            <asp:Panel ID="pnlQuanLyMauSac" runat="server">
                <asp:GridView ID="gvMauSac" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvMauSac_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Name_Color" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Img_Color" runat="server" ImageUrl='<%# Eval("Img_Color") %>' Width="100px" Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Hex_Code_Color" HeaderText="Mã hex" DataFormatString="{0:N0}" />
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

<div class="row-fluid" id="edit_Color" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Chỉnh sửa thông tin màu sắc</h4>
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
                    <asp:TextBox ID="txtColorName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                      <div class="form-group">
                    <label for="txtProductName">Mã màu:</label>
                    <asp:TextBox ID="txtColorHex" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="control-group">
                    <label class="control-label">Hình ảnh</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuHinhAnh" runat="server" CssClass="default" />
                        <br />
                        <asp:Image ID="imgHinhAnh" runat="server" Width="150px" Height="150px" />
                    </div>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CommandName="Update" CssClass="btn btn-success" OnClick="btn_Save" OnClientClick="return confirm('Xác nhận cập nhật?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btn_Cancel" />
            </div>
        </div>
    </div>
</div>

