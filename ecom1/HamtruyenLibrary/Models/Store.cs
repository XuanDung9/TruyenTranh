using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Store")]
    public class Store:IObject
    {
        public Store()
        {
             Address = "Thái hà";
             Phone = "0987654321";

        }
        [BsonElement("Address")]
        public string Address
        {
            get;
            set;
        }
        [BsonElement("Phone")]
        public string Phone
        {
            get;
            set;
        }
    }
}
