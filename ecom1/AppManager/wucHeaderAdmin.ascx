<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucHeaderAdmin.ascx.cs" Inherits="HamtruyenAdmin.wucHeaderAdmin" %>
<!-- BEGIN HEADER -->
   <div id="header" class="navbar navbar-inverse navbar-fixed-top">
       <!-- BEGIN TOP NAVIGATION BAR -->
       <div class="navbar-inner">
           <div class="container-fluid">
               <!--BEGIN SIDEBAR TOGGLE-->
               <div class="sidebar-toggle-box hidden-phone">
                   <div class="icon-reorder"></div>
               </div>
               <!--END SIDEBAR TOGGLE-->
               <!-- BEGIN LOGO -->
               <a class="brand" href="index.html">
                   <strong style="color:#fff;">Administrator</strong>
               </a>
               <!-- END LOGO -->
               <!-- BEGIN RESPONSIVE MENU TOGGLER -->
               <a class="btn btn-navbar collapsed" id="main_menu_trigger" data-toggle="collapse" data-target=".nav-collapse">
                   <span class="icon-bar"></span>
                   <span class="icon-bar"></span>
                   <span class="icon-bar"></span>
                   <span class="arrow"></span>
               </a>
               <!-- END RESPONSIVE MENU TOGGLER -->
               <div id="top_menu" class="nav notify-row">
                </div>
               <div class="top-nav ">
                   <ul class="nav pull-right top-menu" >
                      
                       <!-- BEGIN USER LOGIN DROPDOWN -->
                       <li class="dropdown">
                           <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                               <img src='<%= ((HamtruyenLibrary.Models.ContentManager)Session["admin"]).AnhDaiDien %>' style="width:32px;height:32px;" alt="">
                               <span class="username"><%= ((HamtruyenLibrary.Models.ContentManager)Session["admin"]).UserName %></span>
                               <b class="caret"></b>
                           </a>
                           <ul class="dropdown-menu extended logout">
                               <li><a href="/admin.aspx?mod=22"><i class="icon-user"></i> My Profile</a></li>
                              <li><a href="/ChooseApp.aspx"><i class="icon-windows"></i> Chọn ứng dụng</a></li>
                               <li>
                                   <asp:LinkButton ID="lbkLogout" runat="server" OnClick="lbkLogout_Click">
                                       <i class="icon-key"></i>
                                       Logout
                                   </asp:LinkButton>
                               </li>
                           </ul>
                       </li>
                       <!-- END USER LOGIN DROPDOWN -->
                   </ul>
                   <!-- END TOP NAVIGATION MENU -->
               </div>
           </div>
       </div>
       <!-- END TOP NAVIGATION BAR -->
   </div>
   <!-- END HEADER -->