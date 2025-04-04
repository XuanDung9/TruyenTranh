<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucKhongDuQuyenTruyCap.ascx.cs" Inherits="HamtruyenAdmin.wucKhongDuQuyenTruyCap" %>
<div class="row-fluid">
    <div class="span12">
              
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <h3 class="page-title">
            Không Đủ Quyền Truy Cập
        </h3>
        
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<div class="row-fluid">
    <div class="span12">
        <div class="widget red">
            <div class="widget-title">
                <h4><i class="icon-frown"></i> About Us</h4>
               
            </div>
            <div class="widget-body">
                <div class="about-us">
                   <h3> Xin chào, <%= ((HamtruyenLibrary.Models.ContentManager)Session["admin"]).UserName %>. Bạn chưa được cấp quyền để sử dụng tính năng này!<br />
                    Xin vui lòng liên hệ với người quản trị cấp cao hơn để được cấp quyền truy cập trang này
                       </h3>
                </div>
            </div>
        </div>
        
    </div>
</div>