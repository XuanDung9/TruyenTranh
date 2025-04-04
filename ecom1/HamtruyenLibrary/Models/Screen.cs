using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Screen")]
    public class Screen:IObject
    {
        public Screen()
        {
            string TanSoQuet = "1 - 120Hz";
            string CongNgheManHinh = "Dynamic AMOLED 2X";
            string DoPhanGiai = "3120x1440";
            double KichThuoc = 6.9;
            string DoSang = "2600nits";
        }
        [BsonElement("TanSoQuet")]
        public string TanSoQuet
        {
            get;
            set;
        }
        [BsonElement("CongNgheManHinh")]
        public string CongNgheManHinh
        {
            get;
            set;
        }
        [BsonElement("DoPhanGiai")]
        public string DoPhanGiai
        {
            get;
            set;
        }
        [BsonElement("KichThuoc")]
        public string KichThuoc
        {
            get;
            set;
        }
        [BsonElement("DoSang")]
        public string DoSang
        {
            get;
            set;
        }



    }
}
