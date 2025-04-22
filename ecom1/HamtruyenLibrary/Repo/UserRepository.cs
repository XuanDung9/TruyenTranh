using HamtruyenLibrary.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Repo
{
    public class UserRepository : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Create(User user)
        {
            // khi tạo user đồng thời tạo mới cart 
            Cart cart = new Cart
            {
                CartItems = new List<CartItems>(),
                TongSanPham = 0,
                TongTien = 0
            };
            MainDb.Instant.GetCollection<Cart>().Insert(cart);
            user.Cart = cart;
            MainDb.Instant.Save(user);
        }
        public User GetById(string ID) // lấy ra được danh sách sản phẩm trong cart
        {
            return MainDb.Instant.GetById<User>(ID);
        }

        public IEnumerable<User> GetAll()
        {
            return MainDb.Instant.All<User>();
        }

        public bool Login(string email, string password)
        {
            // Kiểm tra nếu người dùng có trong danh sách (hoặc kiểm tra với cơ sở dữ liệu thực tế)
            var lstUser = GetAll();
            var user = lstUser.FirstOrDefault(u => u.Email == email && u.Password == password); // nếu thấy user trả về true
            return user != null;
        }
        public User GetUserByEmail(string email)
        {
            IMongoQuery query = Query<User>.EQ(p => p.Email, email);
            return MainDb.Instant.Find<User>(query).FirstOrDefault();
        }


    }
}
