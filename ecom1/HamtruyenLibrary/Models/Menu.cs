using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Menu")]
    public class Menu : IObject{
        public Menu()
        {
        }
        //menu id
        [BsonRequired]
        [BsonElement("MenuID")]
        public int MenuLevel
        {
            get;
            set;
        }
        
        //tên menu
        [BsonRequired]
        [BsonElement("MenuName")]
        public string MenuName
        {
            get;
            set;
        }
        
        //id menu cha
   
        [BsonElement("MenuParentID")]
        public string MenuParent
        {
            get;
            set;
        }

        //ngôn ngữ của menu

        [BsonElement("Language")]
        public int Language
        {
            get;
            set;
        }

        //mô tả về menu
        [BsonElement("Description")]
        public string Description
        {
            get;
            set;
        }
        
        //ảnh đại diện cho menu
        [BsonElement("MenuImage")]
        public string MenuImage
        {
            get;
            set;
        }
        
        //link của menu nếu menu thuộc dạng link
        [BsonElement("MenuLink")]
        public string MenuLink
        {
            get;
            set;
        }

        //id kiểu menu 
        
        [BsonElement("MenuTypeID")]
        public int MenuTypeID
        {
            get;
            set;
        }

        //tên kiểu menu
        
        [BsonElement("MenuTypeName")]
        public string MenuTypeName
        {
            get;
            set;
        }

        //có phải menu ngang hay không
        
        [BsonElement("IsMenuNgang")]
        public int IsMenuNgang
        {
            get;
            set;
        }

        //đường dẫn link của menu
        
        [BsonElement("MenuPathText")]
        public string MenuPathText
        {
            get;
            set;
        }
        //đường dẫn link của menu

        [BsonElement("MenuAppID")]
        public string MenuAppID
        {
            get;
            set;
        }
    }
}
