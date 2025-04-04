using HamtruyenLibrary.Classes;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class wucProfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            HamtruyenLibrary.Models.ContentManager admin = (HamtruyenLibrary.Models.ContentManager)Session["admin"];
            img_avatar.Src = admin.AnhDaiDien;

            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ContentManagerRepo repo = new ContentManagerRepo();
            HamtruyenLibrary.Models.ContentManager admin = (HamtruyenLibrary.Models.ContentManager)Session["admin"];
            if(txtMatKhauMoi.Text != txtNhapLaiMatKhauMoi.Text){
                Utility.showErrorStatus(div_error, text_status_error, text_mota_error, "Có Lỗi!", "Mật Khẩu Mới và mật khẩu nhập lại không giống nhau");
                return;
            }
            if (Security.GetEnCrypt(txtMatKhauCu.Text.Trim()) == admin.Password)
            {
                admin.Password = Security.GetEnCrypt(txtMatKhauMoi.Text.Trim());
                repo.Save(admin);
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Bạn đã cập nhật mật khẩu mới thành công!");
            }else{
                Utility.showErrorStatus(div_error, text_status_error, text_mota_error, "Có Lỗi!", "Mật Khẩu cũ không đúng!");
                return;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (fAvatar.HasFile)
                {
                    string sFileName = fAvatar.FileName;
                    ContentManagerRepo repo = new ContentManagerRepo();
                    HamtruyenLibrary.Models.ContentManager admin = (HamtruyenLibrary.Models.ContentManager)Session["admin"];
                    sFileName = Utility.checkAndReName(Utility.getPhysicalPath() + "/Pictures/" + sFileName);
                    fAvatar.SaveAs(sFileName);

                    string[] sArr = sFileName.Split('.');
                    string sNewName = Utility.getPath(admin.UserName) + "." + sArr[sArr.Length - 1];
                    string sFileNameSmall = Utility.checkAndReName(Utility.getPhysicalPath() + "/Pictures/Admin/" + sNewName);
                    FileUtilty.ImageZoomAndSaveWidth(sFileName, sFileNameSmall, 200);
                    FileInfo fi = new FileInfo(sFileNameSmall);
                    admin.AnhDaiDien = "/Pictures/Admin/" + fi.Name;
                    File.Delete(sFileName);

                    repo.Save(admin);

                    Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Bạn đã cập nhật avatar thành công!");
                }
            }
            catch (IOException ex)
            {
                Utility.showErrorStatus(div_error, text_status_error, text_mota_error, "Có Lỗi!", "Không thể ghi ảnh lên server!");

            }
        }
    }
}