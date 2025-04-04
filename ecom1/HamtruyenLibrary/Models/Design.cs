using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Design")]
    public class Design:IObject
    {
        public Design()
        {
            string KichThuoc = "162.8mm x 77.6mm x 8.2mm";
            double TrongLuong = 33.2;
            string ChatLieu = "Titanium";
            string ThietKe = "Nguyên khối, Màn hình nốt ruồi(Hole - In Display)";
        }
        [BsonElement("KichThuoc")]
        public string KichThuoc
        {
            get;
            set;
        }
        [BsonElement("TrongLuong")]
        public string TrongLuong
        {
            get;
            set;
        }
        [BsonElement("ChatLieu")]
        public string ChatLieu
        {
            get;
            set;
        }
        [BsonElement("ThietKe")]
        public string ThietKe
        {
            get;
            set;
        }
    }
}
