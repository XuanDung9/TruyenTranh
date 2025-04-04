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

    public class AnimalUserRepo
    {
        public void Save(AnimalUser mnu)
        {
            MainDb.Instant.Save(mnu);
        }
       
        public IEnumerable<AnimalUser> List()
        {
            return MainDb.Instant.All<AnimalUser>(SortBy<AnimalUser>.Ascending(x => x.Id));
        }

        
        public AnimalUser SelectByID(string ID)
        {
            return MainDb.Instant.GetById<AnimalUser>(ID);
        }

        public AnimalUser SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<AnimalUser>(ID);
        }

        public AnimalUser SelectByIDFace(string IDFace)
        {
            IMongoQuery query = Query<AnimalUser>.EQ(c => c.IDFace, IDFace);
            return MainDb.Instant.FindOne<AnimalUser>(query);
        }

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<AnimalUser>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<AnimalUser>(ID);
        }

        public void AddScore(AnimalScore score)
        {
            MainDb.Instant.Save<AnimalScore>(score);
        }

        public void AddItem(ItemGameAnimal item)
        {
            MainDb.Instant.Save<ItemGameAnimal>(item);
        }

        public void UpdateItem(int ItemName, int ItemNumber, string sFacebook)
        {
            IMongoQuery query = Query.And(Query<ItemGameAnimal>.EQ(c=>c.IDFacebook,sFacebook),Query<ItemGameAnimal>.EQ(c=>c.ItemName,ItemName));
            IMongoUpdate update = Update<ItemGameAnimal>.Set(c=>c.Number,ItemNumber);
            MainDb.Instant.Update<ItemGameAnimal>(query, update);
        }

        public IEnumerable<ItemGameAnimal> ListItem(string sIDFace)
        {
            IMongoQuery query = Query<ItemGameAnimal>.EQ(c => c.IDFacebook, sIDFace);
            return MainDb.Instant.Find<ItemGameAnimal>(query);
        }

        public AnimalScore ListScore(string IDFace, int Level)
        {
            IMongoQuery query = Query.And(Query<AnimalScore>.EQ(c=>c.IDFacebook,IDFace),Query<AnimalScore>.EQ(c=>c.Level,Level));
            return MainDb.Instant.FindOne<AnimalScore>(query);
        }

        public void UpdateScore(int level, int score, string sFacebook)
        {
            IMongoQuery query = Query.And(Query<AnimalScore>.EQ(c => c.IDFacebook, sFacebook), Query<AnimalScore>.EQ(c => c.Level, level));
            IMongoUpdate update = Update<AnimalScore>.Set(c => c.Score, score);
            MainDb.Instant.Update<AnimalScore>(query, update);
        }
        public void UpdateUser(int level, int money, string sFacebook)
        {
            IMongoQuery query = Query<AnimalUser>.EQ(c => c.IDFace, sFacebook);
            IMongoUpdate update = Update<AnimalUser>.Set(c => c.Money,money ).Set(c=>c.Level,level);
            MainDb.Instant.Update<AnimalUser>(query, update);
        }
    }
}
