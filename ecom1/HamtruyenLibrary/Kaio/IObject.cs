using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.Text;

namespace HamtruyenLibrary
{
    public abstract class IObject
    {
        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }
        public void Save()
        {
            MainDb.Instant.Save(this);
        }

        public void Save(string connectionName)
        {
            MainDb.Create(connectionName).Save(this);
        }
    }
}
