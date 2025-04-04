using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("AnimalScore")]
    public class AnimalScore : IObject
    {
        public AnimalScore()
        {
        }
        public AnimalScore(int _score, int _level, string _idface)
        {
            Score = _score;
            Level = _level;
            IDFacebook = _idface;
        }

        [BsonRequired]
        [BsonElement("Score")]
        public int Score { get; set; }

        [BsonRequired]
        [BsonElement("Level")]
        public int Level { get; set; }

        [BsonRequired]
        [BsonElement("IDFacebook")]
        public string IDFacebook { get; set; }
    }
}
