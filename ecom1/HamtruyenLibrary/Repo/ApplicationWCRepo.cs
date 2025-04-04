using HamtruyenLibrary.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Repo
{
    public class ApplicationWCRepo
    {
        public void Save(ApplicationSV mnu)
        {
            MainDb.Instant.Save(mnu);
        }


        public IEnumerable<ApplicationSV> List()
        {
            return MainDb.Instant.All<ApplicationSV>(SortBy<ApplicationSV>.Ascending(x => x.AppName));
        }

        public ApplicationSV SelectByID(string ID)
        {
            return MainDb.Instant.GetById<ApplicationSV>(ID);
        }

        public IEnumerable<ApplicationSV> SelectByListID(List<string> ID)
        {
            IMongoQuery query = Query<ApplicationSV>.In(c=>c.MongoId,ID);
            return MainDb.Instant.Find<ApplicationSV>(query);
        }

        public ApplicationSV SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<ApplicationSV>(ID);
        }

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<ApplicationSV>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<ApplicationSV>(ID);
        }
    }
}
