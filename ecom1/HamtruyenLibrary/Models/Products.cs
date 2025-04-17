using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Products")]
    public class Products : IObject
    {
        public Products()
        {
            TenSP = "";
            HinhAnhs = new List<string>();
            MauSac = "Màu";
            MoTa = "Mô tả sp";
            Options = new List<Option>();
            DanhMuc = null; // truy vấn theo id danh mục 
            TrangThai = false;
            AnhDaiDien = "";
            
        }
        [BsonElement("TenSP")]
        public string TenSP
        {
            get;
            set;
        }
        [BsonElement("HinhAnhs")]
        public List<string> HinhAnhs
        {
            get;
            set;
        }
        [BsonElement("MauSac")]
        public string MauSac
        {
            get;
            set;
        }
        [BsonElement("MoTa")]
        public string MoTa
        {
            get;
            set;
        }
        [BsonElement("DanhMuc")]
        public DanhMuc DanhMuc { get; set; }

        [BsonElement("TrangThai")]
        public bool TrangThai { get; set; }

        [BsonElement("AnhDaiDien")]
        public string AnhDaiDien { get; set; }
        [BsonElement("Options")]
        public List<Option> Options { get; set; } // option giống như biến thể sp


        public class Option
        {
            public Option()
            {

            }
            [BsonElement("ChieuDai")]
            public double ChieuDai { get; set; }

            [BsonElement("CanNang")]
            public double CanNang { get; set; }

            [BsonElement("GiaTien")]
            public int GiaTien { get; set; }

            [BsonElement("SoLuong")]
            public int SoLuong { get; set; }
        }
    }
}
