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
    public class AppMobileRepo
    {
        public void Save(AppMobile mnu)
        {
            MainDb.Instant.Save(mnu);
        }
        public void Add(AppMobile mnu)
        {
            MainDb db = new MainDb();
            db.GetCollection("AppMobile").Insert(mnu);
        }
        
        public IEnumerable<AppMobile> List()
        {
            return MainDb.Instant.All<AppMobile>(SortBy<AppMobile>.Ascending(x => x.Id));
        }

        public IEnumerable<AppMobile> List(int iPage, int iPageSize, out long totalRow)
        {
             IMongoQuery query = Query<AppMobile>.GT(c=>c.AppType,-1);
            IMongoSortBy sort = SortBy<AppMobile>.Ascending(c=>c.Id);
            return MainDb.Instant.Find<AppMobile>(query, sort, iPage, iPageSize, out totalRow);
        }

        public void UpdateQuangCaoFacebook(string idApp, QuangCaoFacebook face_ads)
        {
            IMongoQuery query = Query<AppMobile>.EQ(c => c.MongoId, idApp);
            IMongoUpdate update = Update<AppMobile>.Set(c => c.QuangCaoFaceBook, face_ads);
            MainDb.Instant.Update<AppMobile>(query, update);
        }

        public void UpdateQuangCaoAdmod(string idApp, QuangCaoAdmod admod_ads)
        {
            IMongoQuery query = Query<AppMobile>.EQ(c => c.MongoId, idApp);
            IMongoUpdate update = Update<AppMobile>.Set(c => c.QuangCaoAdmod, admod_ads);
            MainDb.Instant.Update<AppMobile>(query, update);
        }

        public void UpdateQuangCaoUnity(string idApp, QuangCaoUnity unity_ads)
        {
            IMongoQuery query = Query<AppMobile>.EQ(c => c.MongoId, idApp);
            IMongoUpdate update = Update<AppMobile>.Set(c => c.QuangCaoUnity, unity_ads);
            MainDb.Instant.Update<AppMobile>(query, update);
        }


        public IEnumerable<AppMobile> FindByName(string sName)
        {
            IMongoQuery query = Query<AppMobile>.Where(c=>c.AppName.ToLower().Contains(sName.ToLower()));
            return MainDb.Instant.Find<AppMobile>(query,SortBy<AppMobile>.Ascending(c=>c.Id));
        }

        public AppMobile FindByPackageId(string sPackageId)
        {
            IMongoQuery query = Query<AppMobile>.EQ(c=>c.PackageID,sPackageId);
            return MainDb.Instant.FindOne<AppMobile>(query);
        }
        public IEnumerable<AppMobile> ListByType(int iStyle)
        {
            IMongoQuery query = Query<AppMobile>.Where(c => c.AppType == iStyle);
           
            return MainDb.Instant.Find<AppMobile>(query);
        }

        public AppMobile SelectByID(string ID)
        {
            return MainDb.Instant.GetById<AppMobile>(ID);
        }
    


        public AppMobile SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<AppMobile>(ID);
        }


        public void Remove(string ID)
        {
            MainDb.Instant.Delete<AppMobile>(ID);
           
        }

        public void RemoveSafe(string ID)
        {
            //MainDb.Instant.Delete<AppMobile>(ID);
            IMongoQuery query = Query<AppMobile>.EQ(c => c.MongoId, ID);
            IMongoUpdate update = Update<AppMobile>.Set(c => c.AppType, -5);
            MainDb.Instant.Update<AppMobile>(query, update);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<AppMobile>(ID);
        }
        

    }


}
