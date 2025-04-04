using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("RearCamera")]
    public class RearCamera : IObject
    {
        public RearCamera()
        {
            string DoPhanGiai = "Camera siêu rộng 50MP 50MP Camera Tele(3x) 10MP";
            string TinhNang = "Chế độ quay phim 10-bit HDR Quay Log Video Zoom quang học 100x";
            bool Flash = true;
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
        [BsonElement("Flash")]
        public string Flash
        {
            get;
            set;
        }



    }
}
