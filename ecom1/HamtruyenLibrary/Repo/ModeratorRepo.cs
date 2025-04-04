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
    public class ModeratorRepo
    {
        public void Save(Moderator rule)
        {
            MainDb.Instant.Save(rule);
        }

        public IEnumerable<Moderator> List()
        {
            return MainDb.Instant.All<Moderator>();
        }

        public Moderator getByID(ObjectId Id)
        {
            return MainDb.Instant.GetById<Moderator>(Id);
        }

        public IEnumerable<Moderator> List(int iPage, int iPageSize)
        {
            IMongoQuery query = Query<Moderator>.Where(c => c.PhanKhuc!="");
            IMongoSortBy sort = SortBy<Moderator>.Ascending(c => c.Id);
            return MainDb.Instant.Find<Moderator>(query, sort, iPage, iPageSize);

        }

        public Moderator getByID(string sID)
        {
            return MainDb.Instant.GetById<Moderator>(ObjectId.Parse(sID));
        }

        public void remove(string sID)
        {
            MainDb.Instant.Delete<Moderator>(ObjectId.Parse(sID));
        }
    }
}
