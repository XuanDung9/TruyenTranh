<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanTriModerator.ascx.cs" Inherits="HamtruyenAdmin.wucQuanTriModerator" %>
<!-- BEGIN PAGE HEADER-->   
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">
            Quản Lý Phân Khúc
        </h3>
        <ul class="breadcrumb">
            <li>
                <a href="/Admin.aspx">Trang chủ</a>
                <span class="divider">/</span>
            </li>
            <li>
                <a href="/Admin.aspx">Quản Lý Phân khúc</a>
                
            </li>
            
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<div id="lst_phankhuc" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="widget blue">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Danh sách phân khúc chia quyền
                    </h4>
                    <span class="tools">
                        <a class="icon-chevron-down" href="javascript:;"></a>
                        <a class="icon-remove" href="javascript:;"></a>
                    </span>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                        <asp:LinkButton style="margin-top:-10px;" ID="btnThemPhanKhuc" CssClass="btn btn-info" runat="server" OnClick="btnThemPhanKhuc_Click"><i class="icon-plus"></i> Thêm Phân Khúc</asp:LinkButton>
                    </div>
                    <asp:GridView ID="gvListMode" CssClass="table table-striped table-bordered dataTable" runat="server" AutoGenerateColumns="False" OnRowCommand="gvListRule_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" ToolTip="Xóa" CssClass="btn btn-success" CommandName="Sua" CommandArgument='<%# Eval("Id") %>' runat="server">
                                         <i class="icon-pencil"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirm('Bạn thực sự muốn xóa phân khúc này chứ ?');" ToolTip="Xóa" CssClass="btn btn-danger" CommandName="Xoa" CommandArgument='<%# Eval("Id") %>' runat="server">
                                         <i class="icon-remove"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Tên Phân Khúc" DataField="PhanKhuc" />
                            <asp:BoundField HeaderText="Mod" DataField="Mod" />
                        </Columns>
                        
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="div_edit_phankhuc" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="widget blue">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Chỉnh sửa phân khúc
                    </h4>
                    <span class="tools">
                        <a class="icon-chevron-down" href="javascript:;"></a>
                        <a class="icon-remove" href="javascript:;"></a>
                    </span>
                </div>
                <div class="widget-body  form-horizontal">
                    <div class="control-group">
                        <div class="control-group">
                        <label class="control-label">
                            Tên Phân Khúc :
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtTenPhanKhuc" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                    </div>
                        <label class="control-label">
                            Mod Number :
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtModNumber" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy Bỏ" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>