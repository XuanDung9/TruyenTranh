using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("FontCamera")]
    public class FontCamera : IObject
    {
        public FontCamera()
        {
            string DoPhanGiai = "12MP";
            string TinhNang = "Tự động lấy nét";
        }
        [BsonElement("DoPhanGiai")]
        public string DoPhanGiai
        {
            get;
            set;
        }
        [BsonElement("TinhNang")]
        public string TinhNang
        {
            get;
            set;
        }
    }
}
