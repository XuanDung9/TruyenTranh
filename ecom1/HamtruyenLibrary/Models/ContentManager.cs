using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using HamtruyenLibrary;

namespace HamtruyenLibrary.Models
{
    [CollectionName("ContentManager")]
    public class ContentManager : IObject
    {
        public ContentManager()
        {
            AnhDaiDien = "/Pictures/Admin/noimage.jpg";
            LanTruyCapCuoi = DateTime.Now;
            ListQuyen = new List<Privilege>();
        }

        [BsonElement("UserName")]
        public string UserName
        {
            get;
            set;
        }

        [BsonElement("Password")]
        public string Password
        {
            get;
            set;
        }

        [BsonElement("AnhDaiDien")]
        public string AnhDaiDien
        {
            get;
            set;
        }

        

        [BsonElement("LanTruyCapCuoi")]
        [BsonDateTimeOptions(Representation = BsonType.Document)]
        public DateTime LanTruyCapCuoi
        {
            get;
            set;
        }

        [BsonElement("ListQuyen")]
        public List<Privilege> ListQuyen
        {
            get;
            set;
        }

        [BsonElement("AppSuDung")]
        public List<string> AppSuDung
        {
            get;
            set;
        }
    }
}
