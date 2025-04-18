﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Menu")]
    public class Menu : IObject
    {
        public Menu()
        {
        }

        //tên menu
        [BsonRequired]      
        [BsonElement("MenuName")]// text 
        public string MenuName { get; set; }

        [BsonElement("Type")] // kiểu menu link , tin tức , sản phẩm
        public string Type { get; set; }

        [BsonElement("ImageUrl")] // hình ảnh của menu 
        public string ImageUrl { get; set; }

        [BsonElement("MenuChild")] // menu cha
        public List<Menu> MenuChild { get; set; }


        [BsonElement("IsHorizontal")] // xác định menu được thể hiện theo ngang hoặc dọc 
        public bool IsHorizontal { get; set; } // true dọc / false ngang 


    }
} 
