<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucProfile.ascx.cs" Inherits="HamtruyenAdmin.wucProfile" %>
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
                     Content Manager Profile
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
                            Thông tin quản trị viên
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

<div id="div_edit_event" runat="server">
    <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4>
                    <i class="icon-reorder"></i>
                    Đổi Mật Khẩu </h4>
                <span class="tools">
                    <a class="icon-chevron-down" href="javascript:;"></a>
                    <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body form-horizontal">
                <div class="control-group">
                    <label class="control-label">
                        Password cũ :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtMatKhauCu" CssClass="input-xlarge" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                        <label class="control-label">
                            Password mới :
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtMatKhauMoi" TextMode="Password" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                    </div>
                <div class="control-group">
                        <label class="control-label">
                            Nhập lại Password mới :
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtNhapLaiMatKhauMoi" TextMode="Password" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                    </div>
                 
                
                <div class="control-group">
                    <label class="control-label">
                        &nbsp;
                    </label>
                    <div class="controls">
                        <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" Width="82px"/>
                  
                    </div>
                </div>
            </div>
        </div>
    </div>

   
</div>
<div id="csavatar">
     <div class="span12">
        <div class="widget blue">
            <div class="widget-title">
                <h4>
                    <i class="icon-reorder"></i>
                    Đổi Avatar </h4>
                <span class="tools">
                    <a class="icon-chevron-down" href="javascript:;"></a>
                    <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body form-horizontal">
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
                        &nbsp;
                    </label>
                    <div class="controls">
                        <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Cập Nhật"  Width="82px" OnClick="Button2_Click"/>
                  
                    </div>
                </div>
                
                
            </div>
        </div>
    </div>
</div>