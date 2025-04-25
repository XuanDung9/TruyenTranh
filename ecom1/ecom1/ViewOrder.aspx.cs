using ecom1.Helper;
using ecom1.Models;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecom1
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadOrder();
            }    
        }

        public void LoadOrder()
        {
            // order được gen ra từ cart , cart có gì order có đấy
            var currentUser = (User)Session["UserInfo"];
            CartRepository cartRepo = new CartRepository();
            var cart = cartRepo.GetById(currentUser.Cart.MongoId);
            var lstCartItem = cart.CartItems;
            double tongtien = 0;
            List<CartItemViewModel> viewModelList = new List<CartItemViewModel>();
            SanPhamRepo spRepo = new SanPhamRepo();

            foreach (var item in lstCartItem)
            {
                var product = spRepo.GetById(item.ProductId);
                if (product != null && item.OptionIndex < product.Options.Count)
                {
                    var option = product.Options[item.OptionIndex];
                    double thanhTien = option.GiaTien * item.SoLuong;
                    viewModelList.Add(new CartItemViewModel
                    {
                        TenSP = product.TenSP,
                        ProductId = product.MongoId,
                        HinhAnh = $"{ImagePath.Path}" + product.AnhDaiDien,
                        ChieuDai = option.ChieuDai,
                        CanNang = option.CanNang,
                        GiaTien = option.GiaTien,
                        SoLuong = item.SoLuong
                    });
                    tongtien += thanhTien;
                }
            }
            lblTongTien.Text = "Tổng tiền : " + tongtien.ToString("#,##0") + " vnđ";
            rptCartItem.DataSource = viewModelList;
            rptCartItem.DataBind();
        }
        protected void btnXacNhan_Click(object sender, EventArgs e)
        {

        }
    }
}