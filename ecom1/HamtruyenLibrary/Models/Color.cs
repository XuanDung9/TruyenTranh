using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Color")]
    public class Color: IObject
    {
        public Color()
        {
            string Name_Color = "Xanh mã";
            string Hex_Code_Color = "55ff33";
            int Price = 10000000;

        }
        [BsonElement("Name_Color")]
        public string Name_Color
        {
            get;
            set;
        }
        [BsonElement("Hex_Code_Color")]
        public string Hex_Code_Color
        {
            get;
            set;
        }
        [BsonElement("Price")]
        public string Price
        {
            get;
            set;
        }
    }
}
