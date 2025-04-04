using HamtruyenLibrary.Bussiness;
using HamtruyenLibrary.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (Session["admin"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            
        }
        protected void createControl()
        {
            if (Request.Params["mod"] != null)
            {
                main_content.Controls.Clear();
                switch (Request.Params["mod"].ToString())
                {
                    case "1":
                        {
                            // Quan tri Menu
                            UserControl wucQTUserAdmin = (UserControl)LoadControl("wucQuanLyThanhPho.ascx");
                            main_content.Controls.Add(wucQTUserAdmin);
                            break;
                        }
                    case "2":
                        {
                            // Quan tri NoiDung
                            UserControl wucQTNoiDUng = (UserControl)LoadControl("wucQuanLySanPham.ascx");
                            main_content.Controls.Add(wucQTNoiDUng);
                            break;
                        }
                    case "3":
                        {
                            // Quan tri NoiDung
                            UserControl wucQTNoiDUng = (UserControl)LoadControl("wucQuanLyThanhVien.ascx");
                            main_content.Controls.Add(wucQTNoiDUng);
                            break;
                        }



                    case "4":
                        {
                            // Quan tri NoiDung
                            UserControl wucQTNoiDUng = (UserControl)LoadControl("wucQuanLyComment.ascx");
                            main_content.Controls.Add(wucQTNoiDUng);
                            break;
                        }

                    case "5":
                        {
                            // Quan tri NoiDung
                            UserControl wucQTNoiDUng = (UserControl)LoadControl("wucQuanLyKTV.ascx");
                            main_content.Controls.Add(wucQTNoiDUng);
                            break;
                        }
                    case "6":
                        {
                            // Quan tri NoiDung
                            UserControl wucQTNoiDUng = (UserControl)LoadControl("wucQuanLyTours.ascx");
                            main_content.Controls.Add(wucQTNoiDUng);
                            break;
                        }
                    case "14":
                        {
                            // Quan tri Chapter
                            UserControl wucQTTheLoai = (UserControl)LoadControl("wucConfigXml.ascx");
                            main_content.Controls.Add(wucQTTheLoai);
                            break;
                        }
                 
                    case "16":
                        {
                            // Quan tri Content Manager
                            UserControl wucQTTheLoai = (UserControl)LoadControl("wucQuanTriContentManager.ascx");
                            main_content.Controls.Add(wucQTTheLoai);
                            break;
                        }
                    case "17":
                        {
                            // Quan tri Phan Khuc Quyen
                            UserControl wucQTPK = (UserControl)LoadControl("wucQuanTriModerator.ascx");
                            main_content.Controls.Add(wucQTPK);
                            break;
                        }
                    
                    case "21":
                        {
                            // Quan tri Comment
                            UserControl wucQTEmo = (UserControl)LoadControl("wucQuanTriVideo.ascx");
                            main_content.Controls.Add(wucQTEmo);
                            break;
                        }
                    case "22":
                        {
                            // Quan tri Comment
                            UserControl wucQTEmo = (UserControl)LoadControl("wucProfile.ascx");
                            main_content.Controls.Add(wucQTEmo);
                            break;
                        }
                    case "30":
                        {
                            // Quan tri Comment
                            UserControl wucQTEmo = (UserControl)LoadControl("wucQuanLyUserDevice.ascx");
                            main_content.Controls.Add(wucQTEmo);
                            break;
                        }
                    case "23":
                        {
                            // Quan tri Comment
                            UserControl wucQTEmo = (UserControl)LoadControl("wucQuanLyApplication.ascx");
                            main_content.Controls.Add(wucQTEmo);
                            break;
                        }
                    case "99":
                        {
                            // Quan tri Phan Khuc Quyen
                            UserControl wucQTTheLoai = (UserControl)LoadControl("wucKhongDuQuyenTruyCap.ascx");
                            main_content.Controls.Add(wucQTTheLoai);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                    
                }
            }
        }
        override protected void OnInit(EventArgs e)
        {
            createControl();
            base.OnInit(e);
        }
    }
}