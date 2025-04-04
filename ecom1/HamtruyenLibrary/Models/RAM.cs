using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("RAM")]
    public class RAM : IObject
    {
        public RAM()
        {
            int Ram = 12;
            int BoNhoTrong = 256;
        }
        [BsonElement("Ram")]
        public int Ram
        {
            get;
            set;
        }
        [BsonElement("BoNhoTrong")]
        public int BoNhoTrong
        {
            get;
            set;
        }
    }
}
