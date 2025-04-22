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
            Password = "";
            Phone = "";
            Address = "";
            Cart = new Cart();
        }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        [BsonElement("Address")]
        public string Address { get; set; }
        [BsonElement("Cart")]
        public Cart Cart { get; set; }

    }
}
