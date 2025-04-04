using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Products")]
    public class Products: IObject
    {
        public Products()
        {
            string Name_Product = "iPhone 16 Pro Max (256GB)";
            string Image_Product = "path";
            string SKU = "MYWX3VN";
            string Version = "256BG";
            string Color = "Titan Sa mạc";
            int Quantity = 11;
            int Price = 12; // đi theo cái version và color
            string Description = "Điện thoại";
            string Category="Điện thoại";// điện thoại 
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
        [BsonElement("SKU")]
        public string SKU
        {
            get;
            set;
        }
        [BsonElement("Version")]
        public string Version
        {
            get;
            set;
        }
        [BsonElement("Color")]
        public string Color
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
        [BsonElement("Description")]
        public string Description
        {
            get;
            set;
        }
        [BsonElement("Category")]
        public string Category
        {
            get;
            set;
        }
        [BsonElement("Quantity")]
        public string Quantity
        {
            get;
            set;
        }




    }
}
