<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanTriMenu.ascx.cs" Inherits="HamtruyenAdmin.wucQuanTriMenu" %>
<!-- BEGIN PAGE HEADER-->
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">Quản Lý Danh Sách Menu
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
            <li class="active">Tạo Cây Menu
            </li>
            <li class="pull-right search-wrap"></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<!--START LIST MENU-->
<div class="row-fluid" id="list_menu" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Danh sách các Menu</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="control-group">
                    <asp:Button ID="btnAddMenu" CssClass="btn btn-info" runat="server" Text="Thêm Menu Mới" OnClick="btnAddMenu_Click" />
                </div>
                <asp:GridView ID="gvListMenu" CssClass="table table-striped table-bordered table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="gvListMenu_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnSua" CssClass="btn btn-primary" CommandName="Sua" CommandArgument='<%# Eval("Id") %>'><i class="icon-pencil"></i></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnXoa" CommandName="Xoa" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-danger"><i class="icon-trash "></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Tên Menu" DataField="MenuName" />
                        <asp:TemplateField HeaderText="Kiểu Menu">
                            <ItemTemplate>
                                <%# (bool)Eval("IsHorizontal") ? "Menu ngang" : "Menu dọc" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Loại Menu" DataField="Type" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="green">
                            <div class="metro_tmlabel">
                                <h2>Hiện tại, chưa tạo nội dung cho chức năng này!</h2>
                            </div>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
<!--END LIST MENU-->
<!--START EDIT MENUFORM-->
<div class="row-fluid" id="edit_menu" visible="false" runat="server">
    <div class="widget orange">
        <div class="widget-title">
            <h4><i class="icon-reorder"></i>Thêm/Sửa Menu</h4>
            <span class="tools">
                <a href="javascript:;" class="icon-chevron-down"></a>
                <a href="javascript:;" class="icon-remove"></a>
            </span>
        </div>
        <div class="widget-body">
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Tên Menu : </label>
                    <div class="controls">
                        <asp:TextBox type="text" ID="txtMenuName" runat="server" placeholder="Nhập tên menu" class="input-xlarge" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">Kiểu Menu : </label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlMenuType" runat="server">
                            <asp:ListItem Value="Link">Link</asp:ListItem>
                            <asp:ListItem Value="Bài viết">Bài viết</asp:ListItem>
                            <asp:ListItem Value="Sản phẩm">Sản phẩm</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group" id="div_input_link" runat="server">
                    <label class="control-label">Link : </label>
                    <div class="controls">
                        <asp:TextBox type="text" ID="txtMenuLink" runat="server" class="input-xlarge" />
                        <span class="help-inline">Nhập link cho menu nếu kiểu là Link</span>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="AnhDaiDien">Ảnh đại diện:</label>
                    <div class="controls">
                        <asp:Image ID="Image" runat="server" Width="150px" Height="100px" />
                        <asp:FileUpload ID="fuAnhMenu" runat="server" CssClass="default" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">Menu con :</label>
                    <div class="controls">
                        <div style="display: flex; flex-direction: column; gap: 10px;">
                            <div style="display: flex; flex-wrap: wrap; gap: 10px; align-items: center;">
                                <asp:TextBox ID="txtTenMenuCon" runat="server" CssClass="form-control" Placeholder="Tên Menu" Width="100px" />
                                <asp:Button ID="btnThemMenu" runat="server" Text="+ Thêm Menu"
                                    CssClass="btn btn-primary" OnClick="btnThemMenuCon_Click" />
                            </div>
                        </div>
                        <br />
                        <div style="width: 50%">
                            <asp:GridView ID="gvMenuCon" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="Chưa menu con nào"
                                OnRowCommand="gvMenuCon_RowCommand"
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
                                    <asp:BoundField DataField="MenuName" HeaderText="Tên Menu " />
                                    <asp:BoundField DataField="Type" HeaderText="Loại Menu" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="AnhDaiDien">Hiển thị (Ngang / Dọc)</label>
                    <div class="controls">
                        <asp:CheckBox ID="cbAction" runat="server" />
                    </div>
                </div>

                <div class="control-group">
                    <asp:Button ID="btnUpdate" CssClass="btn btn-large btn-success" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-large btn-danger" runat="server" Text="Hủy Bỏ" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
<!--END EDIT MENUFORM-->
<script type="text/javascript">
    function checkMenuLink() {
        if ($("#<%=ddlMenuType.ClientID%>").val() == "5") {
            $("#div_input_link").show();
        } else {
            $("#div_input_link").hide();
        }
    }
</script>
