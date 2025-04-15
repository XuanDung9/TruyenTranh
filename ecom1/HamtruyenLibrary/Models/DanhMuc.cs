using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class DanhMuc:IObject
    {
        public DanhMuc()
        {
            TenDanhMuc = "Danh mục";
                    
        }
        [BsonElement("TenDanhMuc")]
        public string TenDanhMuc
        {
            get;
            set;
        }
    }
}
