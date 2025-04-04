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
<div class="row-fluid" id="list_menu" runat="server">
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
                <li>
                    <a href="/CreateProduct.aspx">Thêm mới sản phẩm</a>
                </li>
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
                <asp:GridView ID="gvSanPham" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField DataField="Name_Product" HeaderText="Tên Sản Phẩm" />
                        <asp:BoundField DataField="Image_Product" HeaderText="Hình ảnh" />
                        <asp:BoundField DataField="SKU" HeaderText="SKU" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Số lượng" />
                        <asp:BoundField DataField="Color" HeaderText="Màu" />
                        <asp:BoundField DataField="Version" HeaderText="Phiên bản" />
                        <asp:BoundField DataField="Price" HeaderText="Gía" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                        <asp:TemplateField HeaderText="Thao tác">
                            <ItemTemplate>
                                <asp:Button ID="btnChiTiet" runat="server" CssClass="btn btn-success" CommandName="ChiTiet" Text="✔" ToolTip="Chi tiết" />                   
                                <asp:Button ID="btnSua" runat="server" CssClass="btn btn-primary" CommandName="Sua" Text="✎" ToolTip="Sửa" />
                                <asp:Button ID="btnXoa" runat="server" CssClass="btn btn-danger" CommandName="Xoa" Text="🗑" ToolTip="Xoá" OnClientClick="return confirm('Bạn có chắc muốn xoá?');" OnClick="btnXoa" CommandArgument='<%# Eval("Id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </div>
    </div>
</div>

</div>
<!-- END PAGE HEADER-->
