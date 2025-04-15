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
            DanhMucRepo danhMucRepo = new DanhMucRepo();
            var lstDanhMuc = danhMucRepo.GetAll();
            long totalrow = 0;
            var lst = repo.List(ipage, ipagesize, out totalrow);
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
                if (!string.IsNullOrEmpty(pd.HinhAnh))
                {
                    imgAnhSP.ImageUrl = pd.HinhAnh;
                }
                txtChieuDai.Text = pd.ChieuDai.ToString();
                txtCanNang.Text = pd.CanNang.ToString();
                txtMauSac.Text = pd.MauSac;
                txtMoTa.Text = pd.MoTa;
                txtSoLuong.Text = pd.SoLuong.ToString();
                if(pd.DanhMuc!= null && !string.IsNullOrEmpty(pd.DanhMuc.Id.ToString()))
                {
                    ddlDanhMuc.ClearSelection();
                    ddlDanhMuc.Items.FindByValue(pd.DanhMuc.Id.ToString()).Selected = true;
                }    
      
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

        protected void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            cbFalse.Checked = !cbTrue.Checked;
        }

        protected void cbFalse_CheckedChanged(object sender, EventArgs e)
        {
            cbTrue.Checked = !cbFalse.Checked;
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
                if (!string.IsNullOrEmpty(imagePath))
                {   
                    itemUpdate.HinhAnh = imagePath;
                }    
                itemUpdate.ChieuDai = double.Parse(txtChieuDai.Text);
                itemUpdate.CanNang = double.Parse(txtCanNang.Text);
                itemUpdate.MauSac = txtMauSac.Text;
                itemUpdate.GiaTien =int.Parse(txtGiaTien.Text);
                itemUpdate.MoTa = txtMoTa.Text;
                itemUpdate.SoLuong = int.Parse(txtSoLuong.Text);
                itemUpdate.DanhMuc = new DanhMuc
                {
                    Id = ObjectId.Parse(ddlDanhMuc.SelectedValue),
                    TenDanhMuc = ddlDanhMuc.SelectedItem.Text
                };

                if (cbFalse.Checked)
                {
                    itemUpdate.HoatDong = false;
                }
                else if (cbTrue.Checked)
                {
                    itemUpdate.HoatDong = true;
                }
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

        }
    }
}