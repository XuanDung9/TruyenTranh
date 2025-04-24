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
    public class OrderRepository : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Create(Order order)
        {
            MainDb.Instant.Save(order);
        }
        public Order GetById(string idOrder)
        {
            return MainDb.Instant.GetById<Order>(idOrder);
        }
        public IEnumerable<Order> GetAll()
        {
            return MainDb.Instant.All<Order>();
        }
        public IEnumerable<Order> GetByUserId(User user)
        {
            return MainDb.Instant.All<Order>().Where(o => o.NguoiDat == user);
        }
        public Order GetPendingOrderByUser(User user)
        {
            var lstOrder = GetByUserId(user);
            var order = lstOrder.Where(o => o.TrangThai == "Pending").FirstOrDefault();
            return order;
        }


        public void Update(Order order, string idOrder)
        {
            IMongoQuery query = Query<Order>.EQ(o => o.MongoId, idOrder);
            IMongoUpdate update = Update<Order>
                .Set(o => o.TrangThai, order.TrangThai)
                .Set(o => o.TongSanPham, order.TongSanPham)
                .Set(o => o.TongTien, order.TongTien)
                .Set(o => o.NgayDat, order.NgayDat)
                .Set(o => o.NguoiDat, order.NguoiDat)
                .Set(o => o.OrderItems, order.OrderItems);
            MainDb.Instant.Update<Order>(query, update);
        }
        public void Remove(string ID)
        {
            MainDb.Instant.Delete<Order>(ID);
        }
        // tìm kiếm 
        // tìm theo ngày đăng 

    }
}
