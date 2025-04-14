using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Products")]
    public class Products : IObject
    {
        public Products()
        {
            Name_Product = "iPhone 16 Pro Max (256GB)";
            Image_Product = "path";
            Version = new List<Versions>(); // bộ nhớ 
            Color = new List<Color>();
            ThuongHieu = new List<ThuongHieu>();
        }
        [BsonElement("Name_Product")]
        public string Name_Product
        {
            get;
            set;
        }
        [BsonElement("Image_Product")]
        public string Image_Product
        {
            get;
            set;
        }
        [BsonElement("Version")]
        public List<Versions> Version
        {
            get;
            set;
        }
        [BsonElement("Color")]
        public List< Color> Color
        {
            get;
            set;
        }
        [BsonElement("ThuongHieu")]
        public List<ThuongHieu> ThuongHieu
        {
            get;
            set;
        }
    }
}
