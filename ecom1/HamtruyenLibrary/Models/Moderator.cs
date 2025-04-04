using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using HamtruyenLibrary;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Moderator")]
    public class Moderator:IObject
    {
        public Moderator()
        {
        }

        //tên menu
        [BsonRequired]
        [BsonElement("PhanKhuc")]
        public string PhanKhuc
        {
            get;
            set;
        }
        //tên menu
        [BsonRequired]
        [BsonElement("Mod")]
        public string Mod
        {
            get;
            set;
        }
    }
}
