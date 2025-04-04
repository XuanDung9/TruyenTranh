<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanTriMenu.ascx.cs" Inherits="HamtruyenAdmin.wucQuanTriMenu" %>
<!-- BEGIN PAGE HEADER-->   
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">
            Quản Lý Danh Sách Menu
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
            <li class="active">
                Tạo Cây Menu
            </li>
            <li class="pull-right search-wrap">
             
            </li>
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
                <h4><i class="icon-reorder"></i> Danh sách các Menu</h4>
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
                                <asp:LinkButton runat="server" ID="btnSua" CssClass="btn btn-primary" CommandName ="Sua" CommandArgument='<%# Eval("Id") %>'><i class="icon-pencil"></i></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnXoa" CommandName="Xoa" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-danger"><i class="icon-trash "></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Tên Menu" DataField="MenuName" />
                        <asp:TemplateField HeaderText="Kiểu Menu">
                            <ItemTemplate>
                                <asp:Label ID="lblMenu" runat="server" Text='<%# Eval("IsMenuNgang").ToString().Trim()=="1"?"Menu Ngang":"Menu Dọc" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Loại Menu" DataField="MenuTypeName" />
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
    <div class="widget green">
        <div class="widget-title">
            <h4><i class="icon-reorder"></i> Thêm/Sửa Menu</h4>
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
                    <input type="text" id="txtMenuName" runat="server" placeholder="Nhập tên menu" class="input-xlarge" />
                    <span class="help-inline">Nhập tên menu vào đây</span>
                </div>
            </div>
            
            <div class="control-group">
                <label class="control-label">Menu ID cũ : </label>
                <div class="controls">
                    <input type="text" id="txtMenuIDOld" runat="server" placeholder="Nhập id menu cũ" class="input-xlarge" />
                    
                </div>
            </div>
            
            <div class="control-group">
                <label class="control-label">Kiểu Menu : </label>
                <div class="controls">
                    <asp:DropDownList ID="ddlMenuType" runat="server">
                        <asp:ListItem Value="5">Menu Playlist</asp:ListItem>
                        <asp:ListItem Value="3">Menu Top Song</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;</div>
                <p class="help-block">Nếu là link thì để Menu Link To, còn nếu là menu Update truyện thì chọn Menu Link Nhỏ</p>
            </div>
            <div class="control-group" id="div_app_menu" visible="false" runat="server">
                <label class="control-label">Menu Application : </label>
                <div class="controls">
                    <asp:DropDownList ID="ddlListApp" runat="server">
                        
                    </asp:DropDownList>
                    &nbsp;</div>
                <p class="help-block">Chọn ứng dụng để thêm menu</p>
            </div>
            <div class="control-group">
                <label class="control-label">Menu Parent : </label>
                <div class="controls">
                    <asp:DropDownList ID="ddlListMenuParent" runat="server">
                       
                    </asp:DropDownList>
                    &nbsp;</div>
                <p class="help-block">Nếu là link thì để Menu Link To, còn nếu là menu Update truyện thì chọn Menu Link Nhỏ</p>
            </div>

            <div class="control-group" id="div_input_link" runat="server">
                <label class="control-label">Link : </label>
                <div class="controls">
                    <input type="text" id="txtMenuLink" runat="server" class="input-xlarge" />
                    <span class="help-inline">Nhập link cho menu nếu kiểu là Link</span>
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