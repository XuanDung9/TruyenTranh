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
using static HamtruyenLibrary.Models.Products;

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

        public List<string> lst_AnhSanPham
        {
            get
            {
                if (Session["ImageList"] == null)
                {
                    Session["ImageList"] = new List<string>();
                }
                return (List<string>)Session["ImageList"];
            }
            set
            {
                Session["ImageList"] = value;
            }
        }

        public List<Option> lst_Option
        {
            get
            {
                if (Session["OptionList"] == null)
                {
                    Session["OptionList"] = new List<Option>();
                }
                return (List<Option>)Session["OptionList"];
            }
            set
            {
                Session["OptionList"] = value;
            }
        }

        int ipage = 1; int ipagesize = 30;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                LoadData();
                LoadImages();
                LoadOption();
            }
        }

        public void LoadOption()
        {
            gvTuyChon.DataSource = lst_Option;
            gvTuyChon.DataBind();
        }

        public void LoadImages()
        {
            gvAnhSP.DataSource = lst_AnhSanPham.Select((imageURL, index) => new
            {
                ImageUrl = imageURL
            }).ToList();
            gvAnhSP.DataBind();
        }
        protected void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            if (fuAnhSanPham.HasFile)
            {
                string fileName = Server.MapPath("~/img/") + fuAnhSanPham.FileName;
                fuAnhSanPham.SaveAs(fileName);
                lst_AnhSanPham.Add("~/img/" + fuAnhSanPham.FileName);
                LoadImages();
            }
        }
        protected void gvAnhSP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "xoa")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                lst_AnhSanPham.RemoveAt(index);
                LoadImages();
            }
        }

        public void btnThemTuyChon_Click(object sender, EventArgs e)
        {
            var option = new Products.Option
            {
                ChieuDai = double.Parse(txtChieuDai.Text),
                CanNang = double.Parse(txtCanNang.Text),
                GiaTien = int.Parse(txtGiaTien.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };

            lst_Option.Add(option);
            LoadOption();
            txtChieuDai.Text = "";
            txtCanNang.Text = "";
            txtGiaTien.Text = "";
            txtSoLuong.Text = "";
        }
        protected void gvTuyChon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SanPhamRepo repo = new SanPhamRepo();
            var product = repo.GetById(PID);
            if (e.CommandName.ToLower() == "xoa")
            {
                var lstOption = product.Options;
                int index = Convert.ToInt32(e.CommandArgument);
                lst_Option.RemoveAt(index);
                repo.UpdateOption(PID, lstOption);
                LoadOption();
            }
        }
        public void bindData()
        {
            SanPhamRepo repo = new SanPhamRepo();
            DanhMucRepo danhMucRepo = new DanhMucRepo();
            var lstDanhMuc = danhMucRepo.GetAll();
            long totalrow = 0;
            var lst = repo.GetAll(ipage, ipagesize, out totalrow);
            gvSanPham.DataSource = lst;
            gvSanPham.DataBind();
            ddlDanhMuc.DataSource = lstDanhMuc;
            ddlDanhMuc.DataTextField = "TenDanhMuc";
            ddlDanhMuc.DataValueField = "Id";
            ddlDanhMuc.DataBind();
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
            Products pd = repo.GetById(sID);
            if (pd != null)
            {
                txtTenSP.Text = pd.TenSP;
                txtMauSac.Text = pd.MauSac;
                txtMoTa.InnerText = pd.MoTa;
                Image1.ImageUrl = pd.AnhDaiDien;
                if (pd.DanhMuc != null && !string.IsNullOrEmpty(pd.DanhMuc.Id.ToString()))
                {
                    ddlDanhMuc.ClearSelection();
                    ddlDanhMuc.Items.FindByValue(pd.DanhMuc.Id.ToString()).Selected = true;
                }
                if (pd.TrangThai == true)
                {
                    cbAction.Checked = true; 
                }
                else
                {
                    cbAction.Checked = false; 
                }

                lst_AnhSanPham = pd.HinhAnhs.ToList(); // tính ép cho cho mà nó đ ra
                var imageUrls = pd.HinhAnhs.Select(url => new { ImageUrl = url }).ToList();
                gvAnhSP.DataSource = imageUrls;
                gvAnhSP.DataBind();
                lst_Option = pd.Options;
                gvTuyChon.DataSource = lst_Option;
                gvTuyChon.DataBind();
            }
     
            ShowEdit();
        }

        protected void btn_Them(object sender, EventArgs e)
        {
            SanPhamRepo repo = new SanPhamRepo();
            Products product = new Products
            {
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
            if (fuAnhSP.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(fuAnhSP.FileName);
                    string folderPath = Server.MapPath("~/img/");

                    string savePath = Path.Combine(folderPath, fileName);
                    fuAnhSP.SaveAs(savePath);

                    imagePath = "~/img/" + fileName;

                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi upload ảnh: " + ex.Message + "");
                    return;
                }
            }

            SanPhamRepo repo = new SanPhamRepo();
            var itemUpdate = repo.GetById(PID);
            try
            {
                itemUpdate.TenSP = txtTenSP.Text;
                itemUpdate.HinhAnhs = lst_AnhSanPham;
                itemUpdate.Options = lst_Option;
                itemUpdate.TrangThai = cbAction.Checked;
                if(!string.IsNullOrEmpty(imagePath))
                {
                    itemUpdate.AnhDaiDien = imagePath;
                }    
                itemUpdate.MauSac = txtMauSac.Text;
                itemUpdate.MoTa = txtMoTa.InnerText;
                itemUpdate.DanhMuc = new DanhMuc
                {
                    Id = ObjectId.Parse(ddlDanhMuc.SelectedValue),
                    TenDanhMuc = ddlDanhMuc.SelectedItem.Text
                };
                repo.UpdateProduct(itemUpdate, PID);
                LoadData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : ", ex.Message);
            }
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
            else if (e.CommandName.ToLower() == "khoa")
            {
                var product = repo.GetById(PID);
                if(product.TrangThai==true)
                {
                    repo.SetActiveProduct(product, PID, false);
                }   
                else
                {
                    repo.SetActiveProduct(product, PID, true);
                }    
                bindData();
            }

        }
        protected void btn_TimKiem(object sender, EventArgs e)
        {
            SanPhamRepo repo = new SanPhamRepo();
            string kSearch = txtTimKiem.Text;
            var lstProduct = repo.TimKiem(kSearch);
            gvSanPham.DataSource = lstProduct;
            gvSanPham.DataBind();
        }
    }
}