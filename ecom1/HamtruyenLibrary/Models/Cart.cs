using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class Cart : IObject
    {
        public Cart()
        {
            CartItems = new List<CartItems>();
            TongTien = 0;
            TongSanPham = 0;
        }
        [BsonElement("TongTien")]
        public double TongTien { get; set; }
        [BsonElement("CartItems")]
        public List<CartItems> CartItems { get; set; }
        [BsonElement("TongSanPham")]
        public double TongSanPham { get; set; }

    }
    public class CartItems
    {
        public CartItems()
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
