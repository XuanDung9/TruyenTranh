using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class ApplicationSV:IObject
    {
        [BsonElement("AppName")]
        public string AppName
        {
            get;
            set;
        }

        [BsonElement("AppDescription")]
        public string AppDescription
        {
            get;
            set;
        }
    }
}
