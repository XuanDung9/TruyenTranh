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
    public partial class wucQuanLySanPham : System.Web.UI.UserControl
    {
        public string PID
        {
            get
            {
                if (null == ViewState["ProductID"])
                    return string.Empty;
                else
                    return (string)ViewState["ProductID"];
            }
            set { ViewState["ProductID"] = value; }
        }

        int ipage = 1; int ipagesize = 30;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                LoadData();
            }
        }

        public void bindData()
        {
            SanPhamRepo repo = new SanPhamRepo();
            ColorRepo colorRepo = new ColorRepo();
            VersionRepo versionRepo = new VersionRepo();
            long totalrow = 0;
            var lst = repo.List(ipage, ipagesize, out totalrow);
            var lstColor = colorRepo.List();
            var lstVersion = versionRepo.List();
            //int iPageCount = (int)(totalrow / ipagesize);
            //if ((totalrow % ipagesize) > 0)
            //{
            //    iPageCount++;
            //}
            ddlMauSac.DataSource = lstColor;
            ddlMauSac.DataBind();
            ddlVersion.DataSource = lstVersion;
            ddlVersion.DataBind();
            gvSanPham.DataSource = lst;
            gvSanPham.DataBind();
        }

        public void LoadData()
        {
            ShowList();
        }
        public void ShowList()
        {
            lst_SanPham.Visible = true;
            edit_SanPham.Visible = false;
            bindData();

        }
        public void ShowEdit()
        {
            lst_SanPham.Visible = false;
            edit_SanPham.Visible = true;
        }
        public void showDetailItem(string sID)
        {
            SanPhamRepo repo = new SanPhamRepo();
            Products pd = repo.SelectByID(sID);
            if (pd != null)
            {
                txtProductName.Text = pd.Name_Product;
                txtSKU.Text = pd.SKU; 
                txtSoLuong.Text = pd.Quantity;
                txtGia.Text = pd.Price;

                if (!string.IsNullOrEmpty(pd.Color))
                {
                    ddlMauSac.ClearSelection();
                    ddlMauSac.Items.FindByText(pd.Color).Selected = true;
                }

                if (!string.IsNullOrEmpty(pd.Color))
                {
                    ddlVersion.ClearSelection();
                    ddlVersion.Items.FindByText(pd.Version).Selected = true;
                }

                if (!string.IsNullOrEmpty(pd.Image_Product))
                {
                    imgHinhAnh.ImageUrl = pd.Image_Product;
                    imgHinhAnh.Visible = true;
                    fuHinhAnh.Visible = false;
                }
                else
                {
                    imgHinhAnh.Visible = false;
                    fuHinhAnh.Visible = true;
                }
          
            }
        }

        protected void btn_Them(object sender, EventArgs e)
        {
            SanPhamRepo repo = new SanPhamRepo();
            Products product = new Products
            {
                Name_Product = "New Product",
                Image_Product = null,
                SKU = "New SKU",
                Version = "version",
                Color = "Color",
                Quantity = 1.ToString(),
                Price = 0.ToString(),
                Description = "Mô tả",
                Category = "Category"

            };
            repo.Save(product);
            bindData();
        }
        protected void btn_Cancel(object sender, EventArgs e)
        {
            ShowList();
        }

        protected void btn_Save(object sender, EventArgs e)
        {
            string imagePath = "";
            string selectedColor = ddlMauSac.SelectedItem.Text;
            string selectedVersion = ddlVersion.SelectedItem.Text;
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

            SanPhamRepo repo = new SanPhamRepo();
            var itemUpdate = repo.SelectByID(PID);
            itemUpdate.Name_Product = txtProductName.Text;
            itemUpdate.Image_Product = imagePath;
            itemUpdate.SKU = txtSKU.Text;
            itemUpdate.Quantity = txtSoLuong.Text;
            itemUpdate.Color = selectedColor;
            itemUpdate.Version = selectedVersion;
            itemUpdate.Price = txtGia.Text;
            repo.UpdateProduct(itemUpdate, PID);
            LoadData();

        }

        protected void gvSanPham_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SanPhamRepo repo = new SanPhamRepo();
            PID = e.CommandArgument.ToString();
            if (e.CommandName.ToLower() == "sua")
            {
                ShowEdit();
                showDetailItem(PID);
            }
            else if (e.CommandName.ToLower() == "xoa")
            {
                repo.Remove(PID.ToString());
                bindData();
            }

        }
    }
}