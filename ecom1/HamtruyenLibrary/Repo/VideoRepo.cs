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
    public class VideoRepo
    {
        public void Save(Video mnu)
        {
            MainDb.Instant.Save(mnu);
        }


        public IEnumerable<Video> List(int iPage, int iPageSize, string MenuID, out long totalrows)
        {
            IMongoQuery query = Query<Video>.Where(c => c.Menu.Equals(MenuID));
            IMongoSortBy sort = SortBy<Video>.Descending(c => c.PostDate);
            return MainDb.Instant.Find<Video>(query, sort, iPage, iPageSize, out totalrows);
        }
        public IEnumerable<Video> ListInWeb(int iPage, int iPageSize, string MenuID, out long totalrows)
        {
            IMongoQuery query = Query<Video>.Where(c => c.Menu.Equals(MenuID));
            IMongoSortBy sort = SortBy<Video>.Descending(c => c.PostDate);
            return MainDb.Instant.Find<Video>(query, sort, iPage, iPageSize, out totalrows);
        }

        public long getNumberRows()
        {
            return MainDb.Instant.Count<Video>();
        }

        public void UpdateView(string sID, int numberCount)
        {
            IMongoQuery query = Query<Video>.Where(c => c.MongoId.Equals(sID));
            IMongoUpdate update = Update<Video>.Set(c => c.VideoView, numberCount);
             MainDb.Instant.Update<Video>(query,update);
        }

       
        public IEnumerable<Video> FindByName(string sKey, int iPage, int iPageSize, out long totalrows)
        {
            IMongoQuery query = Query<Video>.Where(c => c.VideoName.ToLower().Contains(sKey.ToLower()));
            IMongoSortBy sort = SortBy<Video>.Descending(c => c.PostDate);
            return MainDb.Instant.Find<Video>(query, sort, iPage, iPageSize, out totalrows);
        }
        public Video FindByNameK(string sNameK)
        {
            IMongoQuery query = Query<Video>.Where(c => c.VideoNameK.Equals(sNameK));
       
            return MainDb.Instant.FindOne<Video>(query);
        }
        public Video SelectByID(string ID)
        {
            return MainDb.Instant.GetById<Video>(ID);
        }

        public Video SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<Video>(ID);
        }

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<Video>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<Video>(ID);
        }
    }
}
