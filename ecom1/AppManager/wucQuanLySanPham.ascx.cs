using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using MongoDB.Bson;
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
            gvSanPham.DataSource = lst;
            gvSanPham.DataBind();
            var dsMau = colorRepo.List().ToList();
            cblMauSac.DataSource = dsMau;
            cblMauSac.DataTextField = "Name_Color";
            cblMauSac.DataValueField = "Id";
            cblMauSac.DataBind();

            for (int i = 0; i < dsMau.Count; i++)
            {
                string colorHex = dsMau[i].Hex_Code_Color;
                cblMauSac.Items[i].Attributes.Add("style", $"background-color: #{colorHex};");
            }
            var dsPhienBan = versionRepo.List().ToList();
            cblPhienBan.DataSource = dsPhienBan;
            cblPhienBan.DataTextField = "Name_Version";
            cblPhienBan.DataValueField = "Id";
            cblPhienBan.DataBind();

            for (int i = 0; i < dsPhienBan.Count; i++)
            {
                string name = dsPhienBan[i].Name_Version;
                cblMauSac.Items[i].Attributes.Add("style", $"background-color: #{name}");
            }
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
                if (!string.IsNullOrEmpty(pd.Image_Product))
                {
                    imgHinhAnh.ImageUrl = pd.Image_Product;
                }

                // Check các màu đã chọn
                var selectedColors = pd.Color?.Select(c => c.Id.ToString()).ToList();
                if (selectedColors != null)
                {
                    foreach (ListItem item in cblMauSac.Items)
                    {
                        if (selectedColors.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                }

                // Check các phiên bản đã chọn
                var selectedVersions = pd.Version?.Select(v => v.Id.ToString()).ToList();
                if (selectedVersions != null)
                {
                    foreach (ListItem item in cblPhienBan.Items)
                    {
                        if (selectedVersions.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
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
            //string selectedColor = ddlMauSac.SelectedItem.Text;
            //string selectedVersion = ddlVersion.SelectedItem.Text;
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
            if (!string.IsNullOrEmpty(imagePath))
            {
                itemUpdate.Image_Product = imagePath;
            }

            List<Color> selectedColor = new List<Color>();
            foreach (ListItem item in cblMauSac.Items)
            {
                if (item.Selected)
                {
                    selectedColor.Add(new Color
                    {
                        Id = new ObjectId(item.Value),
                        Name_Color = item.Text,                         
                    });
                }
            }

            List<Versions> selectedVersion = new List<Versions>();
            foreach(ListItem item in cblPhienBan.Items)
            {
                if(item.Selected)
                {
                    selectedVersion.Add(new Versions
                    {
                        Id = new ObjectId(item.Value),
                        Name_Version = item.Text,
                    });
                }    
            }

            List<ThuongHieu> selectedThuongHieu = new List<ThuongHieu>();
            foreach(ListItem item in cblThuongHieu.Items)
            {
                if(item.Selected)
                {
                    selectedThuongHieu.Add(new ThuongHieu
                    {
                        TenThuongHieu = item.Text,
                    });
                }    
            }    

            itemUpdate.Color = selectedColor;
            itemUpdate.Version = selectedVersion;
            itemUpdate.ThuongHieu = selectedThuongHieu;
            itemUpdate.Name_Product = txtProductName.Text;
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