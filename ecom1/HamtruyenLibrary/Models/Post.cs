using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class Post:IObject
    {
        public Post()
        {
            TieuDe = "";
            NoiDung = "";
            TrangThai = false;

        }
        [BsonElement("TieuDe")]
        public string TieuDe
        {
            get;
            set;
        }
        [BsonElement("NoiDung")]
        public string NoiDung
        {
            get;
            set;
        }
        [BsonElement("NgayDang")]
        public DateTime NgayDang
        {
            get;
            set;
        }
        [BsonElement("TrangThai")]
        public bool TrangThai
        {
            get;
            set;
        }
    }
}
