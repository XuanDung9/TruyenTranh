using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("SystemAndCPU")]
    public class SystemAndCPU:IObject
    {
        public SystemAndCPU()
        {
            string ViXuLy = "Snapdragon 8 Elite dành cho Galaxy(3nm)";
            string HeDieuHanh = "Android 15, One UI 7";
        }
        [BsonElement("ViXuLy")]
        public string ViXuLy
        {
            get;
            set;
        }
        [BsonElement("HeDieuHanh")]
        public string HeDieuHanh
        {
            get;
            set;
        }
    }
}
