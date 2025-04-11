using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("DanhMuc")]
    public class DanhMuc 
    {
        public DanhMuc()
        {
             TenDanhMuc = "Điện thoại";
        }    
        [BsonElement("TenDanhMuc")]
        public string TenDanhMuc { get; set; }
    }
}
