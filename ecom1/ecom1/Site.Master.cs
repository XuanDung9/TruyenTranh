using ecom1.Models;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecom1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected Cart cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var currentUser = (User)Session["UserInfo"];
                CartRepository cartRepo = new CartRepository();
                cart = cartRepo.GetById(currentUser.Cart.MongoId);
                lblTongTien.Text = string.Format("{0:#,##0} đ", cart.TongTien);
                LoadCartItem();
            }
        }

        public void LoadCartItem()
        {
            var currentUser = (User)Session["UserInfo"];
            CartRepository cartRepo = new CartRepository();
            var cart = cartRepo.GetById(currentUser.Cart.MongoId);
            var lstCartItem = cart.CartItems;

            List<CartItemViewModel> viewModelList = new List<CartItemViewModel>();
            SanPhamRepo spRepo = new SanPhamRepo();

            foreach (var item in lstCartItem)
            {
                var product = spRepo.GetById(item.ProductId);
                if (product != null && item.OptionIndex < product.Options.Count)
                {
                    var option = product.Options[item.OptionIndex];

                    viewModelList.Add(new CartItemViewModel
                    {
                        TenSP = product.TenSP,
                        ProductId=product.MongoId,
                        HinhAnh = product.AnhDaiDien,
                        ChieuDai = option.ChieuDai,
                        CanNang = option.CanNang,
                        GiaTien = option.GiaTien,
                        SoLuong = item.SoLuong
                    });
                }
            }

            rptCartItem.DataSource = viewModelList;
            rptCartItem.DataBind();
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            Button btnXoa = (Button)sender; // Truyền vào đối tượng Button

            string productId = btnXoa.CommandArgument.ToString(); // Lấy giá trị CommandArgument

            // Xử lý xóa sản phẩm khỏi giỏ hàng ở đây
            // Ví dụ: cartRepo.XoaSanPham(productId);

            LoadCartItem(); // Gọi lại sau khi xóa
        }






    }
}