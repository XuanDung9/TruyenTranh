using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class Order:IObject
    {
        public Order()
        {
            OrderItems = new List<OrderItems>();
            TongTien = 0;
            TongSanPham = 0;
            TrangThai = "";
        }
        [BsonElement("TongTien")]
        public double TongTien { get; set; }
        [BsonElement("OrderItems")]
        public List<OrderItems> OrderItems { get; set; }
        [BsonElement("TongSanPham")]
        public double TongSanPham { get; set; }
        [BsonElement("TrangThai")]
        public string TrangThai { get; set; }
        [BsonElement("NgayDat")]
        public DateTime? NgayDat { get; set; }
        [BsonElement("NguoiDat")]
        public User NguoiDat { get; set; }
    }
    public class OrderItems
    {
        public OrderItems()
        {
            ProductId = "";
            OptionIndex = 0;
            SoLuong = 0;
        }
        [BsonElement("ProductId")]
        public string ProductId { get; set; }
        [BsonElement("OptionIndex")] // chỉ số danh mục của sản phẩm , mỗi danh mục ứng với 1 biến thể của sản phẩm 
        public int OptionIndex { get; set; }
        [BsonElement("SoLuong")]
        public int SoLuong { get; set; }

    }
}
