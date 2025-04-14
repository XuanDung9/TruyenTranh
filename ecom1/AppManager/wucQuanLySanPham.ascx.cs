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
            long totalrow = 0;
            var lst = repo.List(ipage, ipagesize, out totalrow);
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
            ColorRepo coloRep = new ColorRepo();
            Products pd = repo.SelectByID(sID);
            if (pd != null)
            {
                txtProductName.Text = pd.Name_Product;
                if (!string.IsNullOrEmpty(pd.Image_Product))
                {
                    imgHinhAnh.ImageUrl = pd.Image_Product;
                }
            } 
            if(pd.Color!= null && pd.Color.Count>0)
            {
                rptColorImages.DataSource = pd.Color;
                rptColorImages.DataBind();
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
            string imgColor = "";
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
            foreach (RepeaterItem item in rptColorImages.Items)
            {
                FileUpload fu = (FileUpload)item.FindControl("fuColor");
                if (fu.HasFile)
                {
                    try
                    {
                        string fileName = Path.GetFileName(fu.FileName);
                        string folderPath = Server.MapPath("~/img/");

                        string savePath = Path.Combine(folderPath, fileName);
                        fu.SaveAs(savePath);

                        imgColor = "~/img/" + fileName;

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Lỗi upload ảnh: " + ex.Message + "");
                        return;
                    }
                }
            }


            SanPhamRepo repo = new SanPhamRepo();
            var itemUpdate = repo.SelectByID(PID);
            if (!string.IsNullOrEmpty(imagePath))
            {
                itemUpdate.Image_Product = imagePath;
            }
            itemUpdate.Color = new List<Color>
            {
                new Color
                {
                    Name_Color = txtTenMauSac.Text,
                    Hex_Code_Color=txtMaMau.Text,
                    Img_Color=imgColor
                }
            };     
            itemUpdate.ThuongHieu = new List<ThuongHieu>
            {
                new ThuongHieu
                {
                    TenThuongHieu = txtTenThuongHieu.Text
                }
            };
            itemUpdate.Version = new List<Versions>
            {
                new Versions
                {
                     Name_Version = txtTenPhienBan.Text,
                     
                }
            };

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