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
        public void Update(Cart cart, string id)
        {
            var tongSanPham = ToTalQuantity(cart);
            var tongTien = ToTalMoney(cart);
            IMongoQuery query = Query<Cart>.EQ(c => c.Id, ObjectId.Parse(id));
            IMongoUpdate update = Update<Cart>
                .Set(c => c.CartItems, cart.CartItems)
                .Set(c => c.TongSanPham, tongSanPham)
                .Set(c => c.TongTien, tongTien);
            MainDb.Instant.Update<Cart>(query, update);

        }
        public double ToTalMoney(Cart cart)
        {
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
            return total;
        }

        public int ToTalQuantity(Cart cart)
        {
            if (cart == null || cart.CartItems == null)
                return 0;

            return cart.CartItems.Sum(item => item.SoLuong);
        }


        public Cart GetCartByUserId(string idUser)
        {
            UserRepository userRepo = new UserRepository();
            var user = userRepo.GetById(idUser);
            var cart = user.Cart;
            return cart;
        }
        public void AddToCart(string userId, string idProduct, int optionIndex)
        {
            SanPhamRepo spRepo = new SanPhamRepo();
            CartRepository cartRepo = new CartRepository();

            var product = spRepo.GetById(idProduct);
            var cart = cartRepo.GetCartByUserId(userId);

            if (cart.CartItems == null)
                cart.CartItems = new List<CartItems>();

            if (product != null && product.Options.Count > optionIndex)
            {
                var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == idProduct && ci.OptionIndex == optionIndex);

                if (existingItem != null)
                {
                    existingItem.SoLuong += 1;
                }
                else
                {
                    var newCartItem = new CartItems
                    {
                        ProductId = idProduct,
                        OptionIndex = optionIndex,
                        SoLuong = 1
                    };
                    cart.CartItems.Add(newCartItem);
                }

                cartRepo.Update(cart, cart.MongoId);
            }
        }




    }
}
