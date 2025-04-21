using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class User:IObject
    {
        public User()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            Cart = new Cart();
        }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("LastName")]
        public string Email { get; set; }
        [BsonElement("Email")]
        public string Phone { get; set; }
        [BsonElement("Address")]
        public string Address { get; set; }
        [BsonElement("Cart")]
        public Cart Cart { get; set; }

    }
}
