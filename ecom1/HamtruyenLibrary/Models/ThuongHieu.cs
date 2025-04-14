using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("ThuongHieu")]
    public class ThuongHieu
    {
        public ThuongHieu()
        {
            TenThuongHieu = "SamSung";
            MoTa = "SamSung";

        }
        [BsonElement("TenThuongHieu")]
        public string TenThuongHieu { get; set; }
        [BsonElement("MoTa")]
        public string MoTa { get; set; }
    }
}
