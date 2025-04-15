using HamtruyenLibrary.Models;
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
    public partial class CreateProduct : System.Web.UI.Page
    {
        
        SanPhamRepo spRepo = new SanPhamRepo();
        ColorRepo colorRepo = new ColorRepo();
        VersionRepo versionRepo = new VersionRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var lstColor = colorRepo.List();
                var lstVersion = versionRepo.List();
                ddlMauSac.DataSource = lstColor;
                ddlMauSac.DataBind();
                ddlVersion.DataSource = lstVersion;
                ddlVersion.DataBind();

                ddlMauSac.Items.Insert(0, new ListItem("-- Chọn màu --", ""));
                ddlVersion.Items.Insert(0, new ListItem("-- Chọn phiên bản --", ""));
            }

        }
        public void LoadData()
        {
            ShowList();
        }
        public void ShowList()
        {
            lst_Sp.Visible = true;
            edit_sp.Visible = false;
        }
        public void ShowEdit()
        {
            lst_Sp.Visible = false;
            edit_sp.Visible = true;
        }
        public void showDetailItem(string sID)
        {
            SanPhamRepo repo = new SanPhamRepo();
            Products pd = repo.GetById(sID);
            if (pd != null)
            {

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string imagePath = "";

            if (fuHinhAnh.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(fuHinhAnh.FileName);
                    string folderPath = Server.MapPath("~/img/");

                    string savePath = Path.Combine(folderPath, fileName);
                    fuHinhAnh.SaveAs(savePath);

                    imagePath = "~/img/" + fileName;
                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi upload ảnh: " + ex.Message + "");
                    return;
                }
            }
            string selectedColor = ddlMauSac.SelectedItem.Text;
            string selectedVersion = ddlVersion.SelectedItem.Text;
            Products product = new Products
            {
                TenSP = txtTenSP.Text,
                HinhAnh = imagePath,
                //SKU = txtSKU.Text,
                //Version = selectedVersion,
                //Color = selectedColor,
            };
            spRepo.Save(product);
            Response.Redirect("http://localhost:60010/Admin.aspx?mod=2");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60010/Admin.aspx?mod=2");
        }

    }
}