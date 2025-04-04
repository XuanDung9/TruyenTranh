using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HamtruyenLibrary.Classes
{
    public class URLRewrite
    {
        public static string Extention = ".html";
        private static string getPathTextByID(string sMenuID)
        {
            string sReturn = ""; // Lay ra path dang text cua menu
            return sReturn;
        }

        public static string getLinkMenu2(string sMenuID, string sMenuName){
            return "/i" + sMenuID + "/" + Utility.getPath(sMenuName) +Extention;
        }
        public static string getLinkMenu(string sContext, string sForm, string sMenuID, string sStyle)
        {
              switch (sStyle)
                {
                    case "1":
                        return "/t" + sMenuID +  sMenuID + Extention;
                    case "2":
                        return "/i"  + sMenuID  + sMenuID + Extention;
                    case "3":
                        return "/Timkiem.html";
                    case "4":
                        return "/Lien-he.html";
                    case "6":
                        return "/Thu-vien-anh" +   sMenuID + "/index" + sMenuID + Extention;
                    case "10":
                        return "/Hoi-dap" +  sMenuID + "/index" + sMenuID + Extention;
                    default:
                        return sForm + "?Menu=" + sMenuID + "&Style=" + sStyle;
                }

            
        }
        public static string getLinkMenuPage(string sMenuID, string sMenuName, string sPage)
        {
            return "/i" + sMenuID + "/p"+sPage+"/" + Utility.getPath(sMenuName) + Extention;
        }
        public static string getLinkMenu(string sContext, string sForm, string sMenuID,string sPage, string sStyle)
        {
                switch (sStyle)
                {
                    case "1":
                        return "/t" + sMenuID + "/p" + sPage +  sMenuID +  Extention;
                    case "2":
                        return "/i" + sMenuID + "/p" + sPage  + sMenuID + Extention;
                    case "3":
                        return "/Timkiem.html";
                    case "4":
                        return "/Lien-he.html";
                    case "6":
                        return "/Thu-vien-anh" + sMenuID + "/P" + sPage + "/index" + sMenuID + Extention;
                    case "10":
                        return "/Hoi-dap" + sMenuID + "/index" + sMenuID + Extention;
                    default:
                        return sForm + "?Menu=" + sMenuID + "&Style=" + sStyle + "&Page=" + sPage;
                }
         
        }

        public static string getLinkMenuDetail(string sForm, string sMenuID, string sStyle, string sDetailID)
        {
            
                switch (sStyle)
                {
                    case "1":
                        return "/t/" + sMenuID +  "/" + sDetailID + Extention;
                    case "2":
                        return "/" + sDetailID + '-'+sMenuID + Extention;
                    case "3":
                        return "/Tim-kiem/" + sDetailID + ".html";
                    case "4":
                        return "/Lien-he.html";
                    default:
                        return sForm + "?Menu=" + sMenuID + "&Style=" + sStyle + "&Chitiet=" + sDetailID;
                }

           
        }
        public static string getLinkMenuDetailPage(string sForm, string sMenuID, string sStyle, string sDetailID,string sPage)
        {

            switch (sStyle)
            {
                case "1":
                    return "/t/" + sMenuID + "/" + sDetailID + Extention;
                case "2":
                    return "/p"+sPage+"/" + sDetailID + '-' + sMenuID + Extention;
                case "3":
                    return "/Tim-kiem/" + sDetailID + ".html";
                case "4":
                    return "/Lien-he.html";
                default:
                    return sForm + "?Menu=" + sMenuID + "&Style=" + sStyle + "&Chitiet=" + sDetailID;
            }


        }
       
        public static string getTheLoaiLink(string sTLName, string sTLID)
        {
            return "/Theloai/"+sTLID+"/" + Utility.getPath(sTLName)  + Extention;
        }
        public static string getNhomDichLink(string NhomDichID, string NhomDichName)
        {
            return "http://hamtruyen.com";
        }
        public static string getLinkTacGia(string sTacGiaID, string sTacGiaName)
        {
            return "/Tacgia/" + sTacGiaID + "/" + Utility.getPath(sTacGiaName) + Extention;
        }
        public static string getLinkTacGiaPage(string sTacGiaID, string sTacGiaName, string sPage)
        {
            return "/Tacgia/" + sTacGiaID + "/p" +sPage+"/"+ Utility.getPath(sTacGiaName) + Extention;
        }
        public static string getTheLoaiLinkPage(string sTLName, string sTLID,string sPage)
        {
            return "/Theloai/" + sTLID + "/p" +sPage+ "/" + Utility.getPath(sTLName) + Extention;
        }

        public static string getMangaListKeyword(string sKw,string sStatus)
        {
           
            switch (sStatus)
            {
                case "-1":
                    if (sKw.Trim() == "-1")
                    {
                        return "/danhsach/index.html";
                    }
                    else
                    {
                        return "/danhsach/" + sKw + "/index.html";
                    }
                   
                case "0":
                    if (sKw.Trim() == "-1")
                    {
                        return "/trangthai/dang-tien-hanh/index.html";
                    }
                    else
                    {
                        return "/trangthai/dang-tien-hanh/" + sKw + "/index.html";
                    }
                   
                case "1":
                    if (sKw.Trim() == "-1")
                    {
                        return "/trangthai/hoan-thanh/index.html";
                    }
                    else
                    {
                        return "/trangthai/hoan-thanh/" + sKw + "/index.html";
                    }
                default:
                    return "/danhsach/index.html";
                   
            }
        }
        public static string getMangaListKeyword(string sKw, string sPage, string sStatus, string sSort)
        {
            string sSortkey = "?sort="+sSort;
            switch (sStatus)
            {
                case "-1":
                    if (sKw.Trim() == "-1")
                    {
                        return "/danhsach/p" + sPage + "/index.html"+sSortkey;
                    }
                    else
                    {
                        return "/danhsach/" + sKw + "/p" + sPage + "/index.html" + sSortkey;
                    }

                case "0":
                    if (sKw.Trim() == "-1")
                    {
                        return "/trangthai/dang-tien-hanh/p" + sPage + "/index.html" + sSortkey;
                    }
                    else
                    {
                        return "/trangthai/dang-tien-hanh/" + sKw + "/p" + sPage + "/index.html" + sSortkey;
                    }

                case "1":
                    if (sKw.Trim() == "-1")
                    {
                        return "/trangthai/hoan-thanh/p" + sPage + "/index.html" + sSortkey;
                    }
                    else
                    {
                        return "/trangthai/hoan-thanh/" + sKw + "/p" + sPage + "/index.html" + sSortkey;
                    }
                default:
                    return "/danhsach/p" + sPage + "/index.html" + sSortkey;
            }
           
        }
        public static string getLinkMenuDetail2(string sForm, string sMenuID, string sPID, string sDetailID)
        {
            
                return "/Doc-truyen/m"+sMenuID+"/"+sPID+"/Chuong-"+sDetailID+Extention;
            
        }
        public static string getLinkMenuDetail4(string sForm, string sPID, string sPNameK, string sDetailID)
        {
            return "/" + sPNameK + "-chapter-" + sDetailID.Replace(",", "-") + "-" + sPID + Extention;
        }
        public static string getLinkMenuDetail4(string sForm, string sCNameK)
        {
           
                return "/doc-truyen/" + sCNameK + Extention;
            
        }
        public static string getLinkMenuDetailVip(string sForm, string sCNameK)
        {
              return "/xem-vip/" + sCNameK + Extention;
            
        }

        public static string getLinkNhomDich(string sTenNhomDich, string sID)
        {
            return "/nhom-dich/" + sID + "/" + Utility.getPath(sTenNhomDich) + Extention;
        }
        public static string getLinkNhomDich(string sTenNhomDich, string sID, string sPage)
        {
            return "/nhom-dich/" + sID + "/p"+sPage+"/" + Utility.getPath(sTenNhomDich) + Extention;
        }
    }
}
