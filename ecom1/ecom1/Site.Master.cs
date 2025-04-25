using ecom1.Helper;
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
            cart = GetCart();
            if (!IsPostBack)
            {
                LoadCartItem();
            }
        }

        public void LoadCartItem()
        {
            var currentUser = (User)Session["UserInfo"];
            CartRepository cartRepo = new CartRepository();
            cart = cartRepo.GetById(currentUser.Cart.MongoId);
            lblTongTien.Text = string.Format("{0:#,##0} đ", cart.TongTien);
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
                        ProductId = product.MongoId,
                        HinhAnh = $"{ImagePath.Path}" +product.AnhDaiDien,
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

        private Cart GetCart()
        {
            var currentUser = (User)Session["UserInfo"];
            CartRepository cartRepo = new CartRepository();
            return cartRepo.GetById(currentUser.Cart.MongoId);
        }

        protected void rptCartItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                cart = GetCart();
                if (index >= 0 && index < cart.CartItems.Count)
                {
                    cart.CartItems.RemoveAt(index);

                    CartRepository cartRepo = new CartRepository();
                    cartRepo.Update(cart, cart.MongoId);

                }
            }
            LoadCartItem();
        }
        protected void CheckOut_Onclick(object sender, EventArgs e)
        {
            var currentUser = (User)Session["UserInfo"];
            OrderRepository orderRepo = new OrderRepository();
            cart = GetCart();
            var cartItems = (List<CartItems>)Session["CartItemList"];
            cartItems = cart.CartItems;
            Session["CartItemList"] = cartItems;
            if (cartItems != null && cartItems.Count > 0)
            {
                var orderPending = orderRepo.GetPendingOrderByUser(currentUser);
                if (orderPending != null)
                {
                    orderPending.TongTien = cart.TongTien;
                    orderPending.TongSanPham = cart.TongSanPham;
                    orderPending.TrangThai = "Pending";
                    orderPending.NgayDat = null;
                    orderPending.NguoiDat = currentUser;
                    orderPending.OrderItems = cartItems.Select(item => new OrderItems
                    {
                        ProductId = item.ProductId,
                        OptionIndex = item.OptionIndex,
                        SoLuong = item.SoLuong
                    }).ToList();
                    orderRepo.Update(orderPending, orderPending.MongoId);
                }
                else
                {
                    var newOrder = new Order
                    {
                        TongTien = cart.TongTien,
                        TongSanPham = cart.TongSanPham,
                        TrangThai = "Pending",
                        NgayDat = null,
                        NguoiDat = currentUser,
                        OrderItems = cartItems.Select(item => new OrderItems
                        {
                            ProductId = item.ProductId,
                            OptionIndex = item.OptionIndex,
                            SoLuong = item.SoLuong
                        }).ToList()
                    };
                    orderRepo.Create(newOrder);
                }

                // Xóa giỏ hàng sau khi đặt hàng thành công (nếu muốn)
                // Session["CartItemList"] = null;
                Response.Redirect("ViewOrder.aspx");
            }
            else
            {
                // Thông báo lỗi
                // lblMessage.Text = "Giỏ hàng trống. Không thể thanh toán.";
                return;
            }
        }
    }
}