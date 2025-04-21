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
    class CartRepository : IDisposable
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
            var query = Query<Cart>.EQ(c => c.Id, ObjectId.Parse(idCart));
            var cart = MainDb.Instant.Find<Cart>(query).FirstOrDefault();
            if (cart != null || cart.CartItems.Count > 0 || cart.CartItems != null)
            {
                double total = 0;
                foreach (var item in cart.CartItems)
                {
                    var product = MainDb.Instant.Find<Products>(item.ProductId.ToString())
                        .FindOneById(ObjectId.Parse(item.ProductId.ToString()));

                    if (product != null && product.Options != null && product.Options.Count > item.OptionIndex)
                    {
                        var option = product.Options[item.OptionIndex];
                        total += option.GiaTien * item.SoLuong;
                    }
                }
            }


        }

    }
}


}
