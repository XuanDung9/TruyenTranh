using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using HamtruyenLibrary;
namespace HamtruyenLibrary.Models
{
    [CollectionName("Privilege")]
    public class Privilege : IObject
    {
        public Privilege()
        {
            Add = false;
            Edit = false;
            Delete = false;
        }

        
        [BsonRequired]
        [BsonElement("PhanKhucID")]
        public string PhanKhucID
        {
            get;
            set;
        }

        [BsonRequired]
        [BsonElement("Mod")]
        public string Mod
        {
            get;
            set;
        }


        [BsonRequired]
        [BsonElement("PhanKhucName")]
        public string PhanKhucName
        {
            get;
            set;
        }

        [BsonRequired]
        [BsonElement("Add")]
        public bool Add
        {
            get;
            set;
        }
        [BsonRequired]
        [BsonElement("Edit")]
        public bool Edit
        {
            get;
            set;
        }
        [BsonRequired]
        [BsonElement("Delete")]
        public bool Delete
        {
            get;
            set;
        }
    }
}
