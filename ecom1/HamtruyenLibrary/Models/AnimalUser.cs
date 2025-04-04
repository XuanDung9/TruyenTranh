using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("AnimalUser")]
    public class AnimalUser : IObject
    {
        public AnimalUser()
        {
            Level = 0;
            Money = 0;
        }

        public AnimalUser(string _idface)
        {
            IDFace = _idface;
            Level = 0;
        }
        [BsonRequired]
        [BsonElement("Money")]
        public int Money { get; set; }

        [BsonRequired]
        [BsonElement("Level")]
        public int Level { get; set; }

        [BsonRequired]
        [BsonElement("IDFace")]
        public string IDFace { get; set; }
    }


    [CollectionName("ItemGameAnimal")]
    public class ItemGameAnimal : IObject{
        public ItemGameAnimal(){
            Number = 0;
        }
        [BsonRequired]
        [BsonElement("ItemName")]
        public int ItemName{get;set;}

        [BsonRequired]
        [BsonElement("Number")]
        public int Number{get;set;}

        [BsonRequired]
        [BsonElement("IDFacebook")]
        public string IDFacebook { get; set; }
    }
}
