using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Color")]
    public class Color
    {
        public Color()
        {
            Name_Color = "Xanh mã";
            Hex_Code_Color = "55ff33";
            Img_Color = "path";

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
        [BsonElement("Img_Color")]
        public string Img_Color
        {
            get;
            set;
        }
    }
}
