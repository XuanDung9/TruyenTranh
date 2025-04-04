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
    public class VideoBillboardRepo
    {
        public void Save(VideoBillboard mnu)
        {
            MainDb.Instant.Save(mnu);
        }
        public void Add(VideoBillboard mnu)
        {
            MainDb db = new MainDb();
            db.GetCollection("VideoBillboard").Insert(mnu);
        }

        public IEnumerable<VideoBillboard> List()
        {
            return MainDb.Instant.All<VideoBillboard>(SortBy<VideoBillboard>.Ascending(x => x.VideoRating));
        }

        public IEnumerable<VideoBillboard> List(int iPage, int iPageSize, out long totalRow)
        {
            IMongoQuery query = Query<VideoBillboard>.Where(v=>v.VideoRating>0);
            IMongoSortBy sort = SortBy<VideoBillboard>.Ascending(v=>v.VideoRating);
            return MainDb.Instant.Find<VideoBillboard>(query, sort, iPage, iPageSize, out totalRow);
        }

        public IEnumerable<VideoBillboard> List(DateTime StartDate, DateTime EndDate, int iPage, int iPageSize, out long totalRow)
        {
            IMongoQuery query = Query<VideoBillboard>.Where(v => v.DateWeek>=StartDate && v.DateWeek<=EndDate);
            IMongoSortBy sort = SortBy<VideoBillboard>.Ascending(v => v.VideoRating);
            return MainDb.Instant.Find<VideoBillboard>(query, sort, iPage, iPageSize, out totalRow);
        }

       

        public IEnumerable<VideoBillboard> List(string sMenuID, int iPage, int iPageSize, out long totalRow)
        {
            IMongoQuery query = Query<VideoBillboard>.EQ(c => c.Menu, sMenuID);
            IMongoSortBy sort = SortBy<VideoBillboard>.Ascending(v => v.VideoRating);
            return MainDb.Instant.Find<VideoBillboard>(query, sort, iPage, iPageSize, out totalRow);
        }

        public VideoBillboard SelectByID(string ID)
        {
            return MainDb.Instant.GetById<VideoBillboard>(ID);
        }
    
        public VideoBillboard SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<VideoBillboard>(ID);
        }

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<VideoBillboard>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<VideoBillboard>(ID);
        }
        
    }
}
