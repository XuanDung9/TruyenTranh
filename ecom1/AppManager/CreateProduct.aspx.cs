using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        SanPhamRepo spRepo = new SanPhamRepo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Products product = new Products
            {
                Name_Product = txtTenSP.Text,
                Image_Product = txtHinhAnh.Text,
                SKU = txtSKU.Text,
                Version = txtVersion.Text,
                Color = txtMauSac.Text,
                Quantity = txtSoLuong.Text,
                Price = txtGia.Text,
                Description = txtMieuTa.Text,
                Category = txtCategory.Text,
            };
            spRepo.Save(product);


        }
    }
}