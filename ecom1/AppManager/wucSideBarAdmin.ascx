<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucSideBarAdmin.ascx.cs" Inherits="HamtruyenAdmin.wucSideBarAdmin" %>
<!-- BEGIN SIDEBAR -->
      <div class="sidebar-scroll">
          <div id="sidebar" class="nav-collapse collapse">
              <!-- BEGIN SIDEBAR MENU -->
              <ul class="sidebar-menu">
                  <li class="sub-menu">
                      <a class="" href="index.html">
                          <i class="icon-dashboard"></i>
                          <span>Trang Chủ</span>
                      </a>
                  </li>
                  <li class="sub-menu active">
                      <a href="javascript:;" class="">
                          <i class="icon-book"></i>
                          <span>Quản Lý Nội Dung</span>
                          <span class="arrow"></span>
                      </a>
                      <ul class="sub">
                          
                          <li><a class="" href="/Admin.aspx?mod=1">Thành Phố</a></li>
                          <li><a class="" href="/Admin.aspx?mod=2">Sản Phẩm</a></li>
                          <li><a class="" href="/Admin.aspx?mod=3">Thành Viên</a></li>
                          <li><a class="" href="/Admin.aspx?mod=4">Bình Luận</a></li>
                          <li><a class="" href="/Admin.aspx?mod=6">Tours</a></li>
                      </ul>
                  </li>
                  <li class="sub-menu">
                      <a href="javascript:;" class="">
                          <i class="icon-user"></i>
                          <span>Quản trị viên</span>
                          <span class="arrow"></span>
                      </a>
                      <ul class="sub">
                          <li><a class="" href="/Admin.aspx?mod=17">Quản Lý Phân Khúc <br />Quyền</a></li>
                          <li><a class=""  href="/Admin.aspx?mod=16">Quản Lý Danh Sách <br />Thành Viên Quản Trị</a></li>
                
                      </ul>
                  </li>

              </ul>
              <!-- END SIDEBAR MENU -->
          </div>
      </div>
      <!-- END SIDEBAR -->