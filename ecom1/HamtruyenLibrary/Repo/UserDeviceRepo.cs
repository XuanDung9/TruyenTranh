using System;
using System.Collections.Generic;
using System.Linq;
using HamtruyenLibrary;
using HamtruyenLibrary.Models;
using MongoDB.Driver.Builders;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HamtruyenLibrary.Repo
{
    public class UserDeviceRepo
    {
        public void Save(UserDevice mnu)
        {
            MainDb.Instant.Save(mnu);
        }
    

        public IEnumerable<UserDevice> List()
        {
            return MainDb.Instant.All<UserDevice>(SortBy<UserDevice>.Ascending(x => x.Id));
        }


        public IEnumerable<UserDevice> List(string AppId ,int iPage, int iPageSize, out long totalRow)
        {
            IMongoQuery query = Query<UserDevice>.EQ(c => c.PackageId, AppId);
            IMongoSortBy sort = SortBy<UserDevice>.Descending(c => c.DateSetup);
            return MainDb.Instant.Find<UserDevice>(query, sort, iPage, iPageSize, out totalRow);
        }

        public IEnumerable<UserDevice> FindByApp(string AppID)
        {
            IMongoQuery query = Query<UserDevice>.EQ(c => c.PackageId, AppID);
            return MainDb.Instant.Find<UserDevice>(query, SortBy<UserDevice>.Descending(c => c.DateSetup));
        }

        public UserDevice FindByAppAndToken(string AppID,string Token)
        {
            IMongoQuery query =
                                            Query<UserDevice>.EQ(c => c.TokenUser, Token);
            return MainDb.Instant.FindOne<UserDevice>(query);
        }
      

        public UserDevice SelectByID(string ID)
        {
            return MainDb.Instant.GetById<UserDevice>(ID);
        }

        public UserDevice SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<UserDevice>(ID);
        }


        public void Remove(string ID)
        {
            MainDb.Instant.Delete<UserDevice>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<UserDevice>(ID);
        }


    }
}
