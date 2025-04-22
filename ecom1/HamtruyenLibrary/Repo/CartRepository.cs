using HamtruyenLibrary.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Repo
{
    public class CartRepository : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Create(Cart cart)
        {
            MainDb.Instant.Save(cart);
        }
        public Cart GetById(string ID) // lấy ra được danh sách sản phẩm trong cart
        {
            return MainDb.Instant.GetById<Cart>(ID);
        }
        public string ToTalMoney(string idCart)
        {
            IMongoQuery query = Query<Cart>.EQ(c => c.Id, ObjectId.Parse(idCart));
            var cart = MainDb.Instant.Find<Cart>(query).FirstOrDefault();
            double total = 0;
            if (cart != null || cart.CartItems.Count > 0 || cart.CartItems != null)
            {

                foreach (var item in cart.CartItems)
                {
                    var product = MainDb.Instant.GetCollection<Products>().FindOneById(ObjectId.Parse(item.ProductId.ToString()));
                    if (product != null && product.Options != null && product.Options.Count > item.OptionIndex)
                    {
                        var option = product.Options[item.OptionIndex];
                        total += option.GiaTien * item.SoLuong;
                    }
                }
            }
            cart.TongTien = total;
            return total.ToString("N0");
        }

        public Cart GetCartByUserId(string idUser)
        {
            UserRepository userRepo = new UserRepository();
            var user = userRepo.GetById(idUser);
            var cart = user.Cart;
            return cart;
        }

        public void AddProductToCart(string idUser, string idProduct, int optionIndex)
        {
            UserRepository userRepo = new UserRepository();
            var cart = GetCartByUserId(idUser);
            IMongoQuery queryProduct = Query<Products>.EQ(p => p.Id, ObjectId.Parse(idProduct));
            var product = MainDb.Instant.Find<Products>(queryProduct).FirstOrDefault();
            if (product == null)
            {
                throw new Exception("Product is null ");
            }
            if (cart == null)
            {
                cart = new Cart();
                cart.CartItems.Add(new CartItems
                {
                    ProductId = idProduct,
                    OptionIndex = optionIndex,
                    SoLuong = 1
                });
                cart.TongSanPham = 1;
                MainDb.Instant.GetCollection<Cart>().Insert(cart);
            }
            else
            {
                // kiểm tra trong giỏ hàng đã có sản phẩm đang thêm vào hay chưa 
                var existingCart = cart.CartItems.FirstOrDefault(ci => ci.ProductId ==idProduct && ci.OptionIndex == optionIndex);
                if(existingCart != null)
                {
                    existingCart.SoLuong += 1;
                }    
                else
                {
                    cart.CartItems.Add(new CartItems
                    {
                        ProductId =idProduct,
                        OptionIndex = optionIndex,
                        SoLuong = 1
                    });
                }

                cart.TongSanPham = cart.CartItems.Sum(ci => ci.SoLuong);
                string totalMoneyCart = ToTalMoney(cart.MongoId);

                MainDb.Instant.GetCollection<Cart>().Save(cart);

            }    
        }

    }
}
