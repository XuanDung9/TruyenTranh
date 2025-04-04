<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanTriContentManager.ascx.cs" Inherits="HamtruyenAdmin.wucQuanTriContentManager" %>
<!-- BEGIN PAGE HEADER-->   
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">
            Quản Lý Admin
        </h3>
        <ul class="breadcrumb">
            <li>
                <a href="/Admin.aspx">Home</a>
                <span class="divider">/</span>
            </li>
            <li>
                <a href="/Admin.aspx">Quản Lý Admin</a>
                
            </li>
            
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->

<div class="lstAdmin" id="lstAdmin" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="widget blue">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Danh sách Quản trị viên
                    </h4>
                    <span class="tools">
                        <a class="icon-chevron-down" href="javascript:;"></a>
                        <a class="icon-remove" href="javascript:;"></a>
                    </span>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                        <asp:LinkButton style="margin-top:-10px;" ID="btnThemLuat" CssClass="btn btn-info" runat="server" OnClick="btnThemLuat_Click"><i class="icon-plus"></i> Thêm Quản trị viên</asp:LinkButton>
                    </div>
                    <asp:GridView ID="gvListAdmin" CssClass="table table-striped table-bordered dataTable" runat="server" AutoGenerateColumns="False" OnRowCommand="gvListAdmin_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" ToolTip="Xóa" CssClass="btn btn-success" CommandName="Sua" CommandArgument='<%# Eval("Id") %>' runat="server">
                                         <i class="icon-pencil"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirm('Bạn thực sự muốn xóa quản trị viên này chứ ?');" ToolTip="Xóa" CssClass="btn btn-danger" CommandName="Xoa" CommandArgument='<%# Eval("Id") %>' runat="server">
                                         <i class="icon-remove"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Avatar">
                                
                                <ItemTemplate>
                                   <img src='<%# Eval("AnhDaiDien") %>' width="90" height="90" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="UserName" DataField="UserName" />
                            <asp:TemplateField HeaderText="Lần Truy Cập Cuối">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# ((DateTime) Eval("LanTruyCapCuoi")).ToString("mm-hh dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>

<div id="div_edit_admin" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="widget blue">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Thêm / Chỉnh sửa Admin
                    </h4>
                    <span class="tools">
                        <a class="icon-chevron-down" href="javascript:;"></a>
                        <a class="icon-remove" href="javascript:;"></a>
                    </span>
                </div>
                <div class="widget-body  form-horizontal">
                    
                    <div class="control-group">
                        <label class="control-label">
                            Username :
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtUsername" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            Password :
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            Ảnh đại diện :
                        </label>
                        <div class="controls">
                            <asp:FileUpload ID="fAvatar" runat="server" />
                            <br />
                            <img src="/Pictures/Admin/noimage.jpg" id="img_avatar" runat="server" width="120" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            App sử dụng :
                        </label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlListUngDung" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnThemUngDung" CssClass="btn btn-success" runat="server" Text="Thêm Ứng Dụng" OnClick="btnThemUngDung_Click"/>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:GridView ID="gvListUngDung" CssClass="table table-striped table-bordered dataTable" runat="server" AutoGenerateColumns="False" OnRowCommand="gvListUngDung_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                   
                                            <asp:LinkButton ID="LinkButton3" OnClientClick="return confirm('Bạn thực sự muốn xóa quyền sử dụng ứng dụng này chứ ?');" ToolTip="Xóa" CssClass="btn btn-danger" CommandName="XoaQuyen" CommandArgument='<%# Eval("Id") %>' runat="server">
                                                 <i class="icon-remove"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AppName" HeaderText="Tên Ứng Dụng" />
                                    
                                   
                                </Columns>
                                <EmptyDataTemplate>
                                    Thành Viên chưa có quyền sử dụng ứng dụng nào!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">
                            Quyền của admin :
                        </label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlPhanKhuc" runat="server"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkThem" runat="server" /> Quyền Thêm
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkSua" runat="server" /> Quyền Sửa
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkXoa" runat="server" /> Quyền Xóa
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkToanQuyen" runat="server" /> Toàn Quyền
                            &nbsp;&nbsp;&nbsp;&nbsp;<br /><br />
                            <asp:Button ID="btnThemQuyen" CssClass="btn btn-success" runat="server" Text="Thêm Quyền" OnClick="btnThemQuyen_Click" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:GridView ID="gvListRolesOfUser" CssClass="table table-striped table-bordered dataTable" runat="server" AutoGenerateColumns="False" OnRowCommand="gvListRolesOfUser_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                   
                                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirm('Bạn thực sự muốn xóa quyền này chứ ?');" ToolTip="Xóa" CssClass="btn btn-danger" CommandName="XoaQuyen" CommandArgument='<%# Eval("Mod") %>' runat="server">
                                         <i class="icon-remove"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PhanKhucName" HeaderText="Chức Năng" />
                                    <asp:TemplateField HeaderText="Quyền Thêm">
                                        <ItemTemplate>
                                            <%# (bool)Eval("Add") == true ? "Có" : "Không" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quyền Sửa">
                                        <ItemTemplate>
                                            <%# (bool)Eval("Edit") == true ? "Có" : "Không" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quyền Xóa">
                                        <ItemTemplate>
                                            <%# (bool)Eval("Delete") == true ? "Có" : "Không" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    Thành Viên chưa có quyền nào!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                    
                    <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click"/>
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy Bỏ" OnClick="btnCancel_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

