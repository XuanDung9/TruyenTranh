<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucManagerQuangCao.ascx.cs" Inherits="HamtruyenAdmin.wucManagerQuangCao" %>
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
                Quản Lý Quảng Cáo Của Ứng Dụng
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
<