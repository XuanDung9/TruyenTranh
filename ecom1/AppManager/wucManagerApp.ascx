<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucManagerApp.ascx.cs" Inherits="HamtruyenAdmin.wucManagerApp" %>
<style>
    .input-xlarge
    {
        width: 50%;
    }
</style>
<!-- BEGIN PAGE HEADER-->   
<div class="row-fluid" id="notification">
    <div class="span12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">
            Quản Lý Danh Sách Ứng Dụng
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
                Danh sách Ứng Dụng
            </li>
            <li class="pull-right search-wrap">
              
            </li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<!-- END PAGE HEADER-->
<!-- start error label-->
<div class="alert alert-block alert-success fade in" id="div_error" runat="server" visible="false">
    <button data-dismiss="alert" class="close" type="button">×</button>
    <h4 class="alert-heading" runat="server" id="text_status_error">Success!</h4>
    <p runat="server" id="text_mota_error">
        Best check yo self, you're not looking too good. Nulla vitae elit libero, a pharetra augue. Praesent commodo cursus magna, vel scelerisque nisl consectetur et.
    </p>
</div>
<!-- end error label-->

<div class="row-fluid" id="list_tintuc" runat="server">
    <div class="widget blue">
        <div class="widget-title">
            <h4>
                <i class="icon-reorder"></i>
                Danh sách Ứng Dụng
            </h4>
            <span class="tools">
                <a class="icon-chevron-down" href="javascript:;"></a>
                <a class="icon-remove" href="javascript:;"></a>
            </span>
        </div>
        <div class="widget-body">
            <div class="control-group">
                <div class="controls">
                    <asp:LinkButton style="margin-top:-10px;" ID="btnThemTruyen" CssClass="btn btn-info" runat="server" OnClick="btnThemTruyen_Click"><i class="icon-plus"></i> Thêm App</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    <asp:LinkButton style="margin-top:-10px;" CssClass="btn btn-primary" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="icon-search"></i>Tìm kiếm</asp:LinkButton>
                    
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    <asp:LinkButton style="margin-top:-10px;" ID="btnPushNotifyAllApp" CssClass="btn btn-info" runat="server" OnClick="btnPushNotifyAllApp_Click"><i class="icon-mail-reply-all"></i> Thông Báo Cho Toàn Bộ Thiết Bị</asp:LinkButton>
                </div>
            </div>
            <div class="control-group">
                <asp:Repeater ID="rptListContent" runat="server" OnItemCommand="rptListContent_ItemCommand">
                    <HeaderTemplate>
                        <table id="gvListStory" class="table table-striped table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th style="width:8px;"></th>
                                    <th>Tên App</th>
                                    <th>ID App</th>
                                    <th>API KEY</th>
                                    <th>Phiên Bản</th>
                                    <th>Loại Ứng Dụng</th>
                                </tr>
                            </thead><tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td width="200px">
                                <asp:LinkButton ID="LinkButton1" ToolTip="Sửa" CssClass="btn btn-success" CommandName="Sua" CommandArgument='<%# Eval("Id") %>' runat="server">
                                     <i class="icon-pencil"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" ToolTip="Xóa" OnClientClick ="return confirm('Bạn có chắc muốn xóa ứng dụng này không! Các thông tin liên quan đến ứng dụng cũng sẽ bị xóa theo ?')" CssClass="btn btn-danger" CommandName="Xoa" CommandArgument='<%# Eval("Id") %>' runat="server">
                                     <i class="icon-remove"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" ToolTip="Nhắn tới người dùng" CssClass="btn btn-success" CommandName="Notify" CommandArgument='<%# Eval("Id") %>' runat="server">
                                     <i class="icon-bell"></i>
                                </asp:LinkButton>
                                <a class="btn btn-info" title="Danh sách thiết bị đã cài Ứng dụng" href='/Admin.aspx?mod=30&AMID=<%# Eval("PackageID") %>'>
                                     <i class="icon-list"></i> 
                                </a><br /><br />
                                <asp:LinkButton ID="LinkButton4" ToolTip="Facebook Ads" CssClass="btn btn-primary" CommandName="facebook_ads" CommandArgument='<%# Eval("Id") %>' runat="server">
                                     <i class="icon-facebook"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" ToolTip="Admod Ads" CssClass="btn btn-primary" CommandName="admod_ads" CommandArgument='<%# Eval("Id") %>' runat="server">
                                     <i class="icon-google-plus"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton6" ToolTip="Unity Ads" CssClass="btn btn-primary" CommandName="unity_ads" CommandArgument='<%# Eval("Id") %>' runat="server">
                                     Unity Ads
                                </asp:LinkButton>
                            </td>
                            <td>
                                <strong><%# Eval("AppName") %></strong>
                            </td>
                            <td>
                                <%# Eval("MongoId") %>
                            </td>
                            <td>
                               <%# Eval("AppServerKey").ToString()=="" ? "Chưa Tạo":Eval("AppServerKey").ToString() %>
                            </td>
                            <td>
                                <%# Eval("AppVersion") %>
                            </td>
                            <td>
                                <%# GetAppType(Eval("AppType").ToString()) %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                    
                </asp:Repeater>
            </div>
            <div class="control-group row-fluid">
                <asp:Literal ID="ltrPager" runat="server"></asp:Literal>
            </div>
            
                
        </div>
    </div>
</div>
<!--START LIST TINTUC-->

<!-- START EDIT TINTUC -->
<div class="row-fluid" id="edit_tintuc" runat="server">
     <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4>
                    <i class="icon-reorder"></i>
                    Sửa Thông Tin Ứng Dụng
                </h4>
                <span class="tools">
                    <a class="icon-chevron-down" href="javascript:;"></a>
                    <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body form-horizontal">
                <div class="control-group">
                    <label class="control-label">
                        Tên Ứng Dụng :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtTenUngDung" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Server Key :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtServerKey" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
              <div class="control-group">
                    <label class="control-label">
                        Android Key :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtAndroidKey" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Loại Ứng Dụng :
                    </label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlAppType" runat="server">
                            <asp:ListItem Value="0">IOS</asp:ListItem>
                            <asp:ListItem Value="1">Android</asp:ListItem>
                            <asp:ListItem Value="3">Window Phone</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Phiên Bản :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtAppVersion" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Thông Báo Khi Update
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtAppUpdateThongBao" TextMode="MultiLine" CssClass="input-xlarge" runat="server" Rows="10"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Link Update :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtLinkInStore" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Package ID :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtPackageId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="control-group">
                    <label class="control-label">
                        &nbsp;
                    </label>
                    <div class="controls">
                        <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Hủy Bỏ" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!--END EDIT TINTUC -->
<div class="row-fluid" id="div_gui_notification" runat="server" visible="false">
  <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i> Thông Báo Tới Thiết Bị Sử Dụng App <span id="lblAppName" runat="server"></span></h4>
                <span class="tools">
                <a class="icon-chevron-down" href="javascript:;"></a>
                <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="control-group">
                    <label class="control-label">
                        Tiêu Đề : 
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtTitle" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>

                 </div>
                <div class="control-group">
                    <label class="control-label">
                        Link Ứng dụng (Nếu là cập nhật phiên bản) : 
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtLink_Update" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        Loại Thông Báo : 
                    </label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlType_gcm" runat="server">
                            <asp:ListItem Value="0">Update Truyện Mới</asp:ListItem>
                            <asp:ListItem Value="1">Cập Nhật Phi&#234;n Bản</asp:ListItem>
                            <asp:ListItem Value="2">Th&#244;ng B&#225;o Kh&#225;c</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                        <label class="control-label">
                            Thông Báo : 
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtThongBaoThanhVien" Width="70%" TextMode="MultiLine" Rows="7" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>

                    </div>
                <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:Button ID="btn_add_thongbao" CssClass="btn btn-primary" runat="server" Text="Cập Nhật" style="height: 29px" OnClick="btn_add_thongbao_Click" />
                            <asp:Button ID="btn_huybo" CssClass="btn btn-warning" runat="server" Text="Hủy Bỏ" OnClick="btn_huybo_Click"/>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>
<div class="row-fluid" id="div_admod_ads" runat="server" visible="false">
  <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i> Thêm Thông Tin Quảng Cáo Admod <span id="Span1" runat="server"></span></h4>
                <span class="tools">
                <a class="icon-chevron-down" href="javascript:;"></a>
                <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="control-group">
                    <label class="control-label">
                        Account Id: 
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtAdmodAccountId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>

                 </div>
                <div class="control-group">
                    <label class="control-label">
                        Banner Id :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtAdmodBannerId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="control-group">
                        <label class="control-label">
                            FullId : 
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtAdmodFullId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>

                    </div>
                <div class="control-group">
                        <label class="control-label">
                            Hiển Thị : 
                        </label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlAdmodDisplay" runat="server">
                                <asp:ListItem Value="1">C&#243;</asp:ListItem>
                                <asp:ListItem Value="0">Kh&#244;ng</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:Button ID="updateAdmodAd" CssClass="btn btn-primary" runat="server" Text="Cập Nhật" style="height: 29px" OnClick="updateAdmodAd_Click"/>
                            <asp:Button ID="Button2" CssClass="btn btn-warning" runat="server" Text="Hủy Bỏ" OnClick="btn_huybo_Click"/>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>
<div class="row-fluid" id="div_facebook_ads" runat="server" visible="false">
  <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i> Thêm Thông Tin Quảng Cáo Facebook <span id="Span2" runat="server"></span></h4>
                <span class="tools">
                <a class="icon-chevron-down" href="javascript:;"></a>
                <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="control-group">
                    <label class="control-label">
                        Fb Native Id: 
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtFacebookNativeId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>

                 </div>
                <div class="control-group">
                    <label class="control-label">
                        Fb Full Id :
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtFacebookFullId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="control-group">
                        <label class="control-label">
                          Fb Banner : 
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtFacebookBanner" Width="70%" TextMode="MultiLine" Rows="7" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>

                    </div>
                <div class="control-group">
                        <label class="control-label">
                            Hiển Thị : 
                        </label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlFacebookDisplay" runat="server">
                                <asp:ListItem Value="1">C&#243;</asp:ListItem>
                                <asp:ListItem Value="0">Kh&#244;ng</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:Button ID="updateFaceBookAds" CssClass="btn btn-primary" runat="server" Text="Cập Nhật" style="height: 29px"  OnClick="updateFaceBookAds_Click"/>
                            <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Hủy Bỏ" OnClick="btn_huybo_Click"/>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>
<div class="row-fluid" id="div_unity_ads" runat="server" visible="false">
  <div class="span12">
        <div class="widget orange">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i> Thêm Thông Tin Quảng Cáo Unity <span id="Span3" runat="server"></span></h4>
                <span class="tools">
                <a class="icon-chevron-down" href="javascript:;"></a>
                <a class="icon-remove" href="javascript:;"></a>
                </span>
            </div>
            <div class="widget-body">
                <div class="control-group">
                    <label class="control-label">
                       Unity Id: 
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtUnityId" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>

                 </div>
                
                <div class="control-group">
                        <label class="control-label">
                            Hiển Thị : 
                        </label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlUnityDisplay" runat="server">
                                <asp:ListItem Value="1">C&#243;</asp:ListItem>
                                <asp:ListItem Value="0">Kh&#244;ng</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                <div class="control-group">
                        <label class="control-label">
                            &nbsp;
                        </label>
                        <div class="controls">
                            <asp:Button ID="btn_Update_untiy_ads" CssClass="btn btn-primary" runat="server" Text="Cập Nhật" style="height: 29px" OnClick="btn_Update_untiy_ads_Click" />
                            <asp:Button ID="Button6" CssClass="btn btn-warning" runat="server" Text="Hủy Bỏ" OnClick="btn_huybo_Click"/>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>