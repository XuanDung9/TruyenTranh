using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Versions")]
    public class Versions 
    {
        public Versions()
        {
            Name_Version = "256GB";
        }
        [BsonElement("Name_Version")]
        public string Name_Version
        {
            get;
            set;
        }
    }
}
