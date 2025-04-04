using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Versions")]
    public class Versions : IObject
    {
        public Versions()
        {
            string Name_Version = "256GB";
            int Price = 10000000;
        }
        [BsonElement("Name_Version")]
        public string Name_Version
        {
            get;
            set;
        }
        [BsonElement("Price")]
        public int Price
        {
            get;
            set;
        }
    }
}
