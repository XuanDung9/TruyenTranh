<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucConfigXml.ascx.cs" Inherits="HamtruyenAdmin.wucConfigXml" %>
<div class="row-fluid">
    <div class="span12">
                   <!-- BEGIN THEME CUSTOMIZER-->
                   <div id="theme-change" class="hidden-phone">
                       <i class="icon-cogs"></i>
                        <span class="settings">
                            <span class="text">Theme Color:</span>
                            <span class="colors">
                                <span class="color-default" data-style="default"></span>
                                <span class="color-green" data-style="green"></span>
                                <span class="color-gray" data-style="gray"></span>
                                <span class="color-purple" data-style="purple"></span>
                                <span class="color-red" data-style="red"></span>
                            </span>
                        </span>
                   </div>
                   <!-- END THEME CUSTOMIZER-->
                  <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                   <h3 class="page-title">
                     Quản lý danh sách chương truyện <span runat="server" id="nametruyen"></span>
                   </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="/admin.aspx">Home</a>
                           <span class="divider">/</span>
                       </li>
                       <li>
                           <a href="/admin.aspx?mod=2">Content</a>
                           <span class="divider">/</span>
                       </li>
                       <li class="active">
                            Danh sách chương
                       </li>
                   </ul>
                   <!-- END PAGE TITLE & BREADCRUMB-->
               </div>
</div>
<!-- start error label-->
<div class="alert alert-block alert-success fade in" id="div_error" runat="server" visible="false">
    <button data-dismiss="alert" class="close" type="button">×</button>
    <h4 class="alert-heading" runat="server" id="text_status_error">Success!</h4>
    <p runat="server" id="text_mota_error">
        Best check yo self, you're not looking too good. Nulla vitae elit libero, a pharetra augue. Praesent commodo cursus magna, vel scelerisque nisl consectetur et.
    </p>
</div>
<!-- end error label-->
<div class="span12" style="margin-left:0">
        <div class="widget blue">
            <div class="widget-title">
                <h4>
                    <i class="icon-reorder"></i>
                    Danh sách Thông tin cấu hình
                </h4>
                <span class="tools">
                    <a class="icon-chevron-down" href="javascript:;"></a>
                    <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="row-fluid" style="margin-bottom:10px;">
                    <div class="controls">
                        <asp:LinkButton style="margin-top:-10px;" ID="btnThemChuong" CssClass="btn btn-info" runat="server" OnClick="btnThemChuong_Click"><i class="icon-success"></i> Cập nhật</asp:LinkButton>
                    </div>
                </div>
                <div class="tab-content">
                    <h3>
                        Picasa Account
                    </h3>
                    <div class="control-group">
                        <label class="control-label">Username</label>
                        <div class="controls">
                            <asp:TextBox ID="txtUserNamePicasa" runat="server"></asp:TextBox>
                            <span class="help-inline">Username gmail đã kích hoạt picasa web</span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Password</label>
                        <div class="controls">
                            <asp:TextBox ID="txtPasswordPicasa" runat="server"></asp:TextBox>
                            <span class="help-inline">Password mail</span>
                        </div>
                    </div>
                </div>
                <div class="tab-content">
                    <h3>
                        Cookie
                    </h3>
                    <div class="control-group">
                        <label class="control-label">Username</label>
                        <div class="controls">
                            <asp:TextBox ID="txtCookie" TextMode="MultiLine" Row="5" Width="75%" CssClass="controls" runat="server"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:LinkButton style="margin-top:-10px;" ID="LinkButton1" CssClass="btn btn-info" runat="server" OnClick="LinkButton1_Click"><i class="icon-success"></i> Cập nhật</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
</div>