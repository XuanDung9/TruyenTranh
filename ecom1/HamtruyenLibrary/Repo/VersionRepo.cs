using MongoDB.Driver;
using HamtruyenLibrary.Models;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace HamtruyenLibrary.Repo
{
    public class VersionRepo:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save(Versions versions)
        {
            MainDb.Instant.Save(versions);
        }
        public IEnumerable<Versions> List() // danh sách servison
        {
            return MainDb.Instant.All<Versions>();
        }
        public IEnumerable<Versions> FindByName(string sKey)
        {
            IMongoQuery query = Query<Versions>.Where(c => c.Name_Version.ToLower().Contains(sKey.ToLower()));
            return MainDb.Instant.Find<Versions>(query);
        }
        //public void UpdateVersion(string newName, int newPrice,string ID)
        //{
        //    IMongoQuery query = Query<Versions>.EQ(c => c.Id, ObjectId.Parse(ID));
        //    IMongoUpdate update = Update<Versions>.Set(c => c.Name_Version, newName);
        //    MainDb.Instant.Update<Versions>(query, update);
                
        //}
        public Versions SelectByID(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                throw new Exception("ID is null");
            }
            return MainDb.Instant.GetById<Versions>(ID);
        }

        public void Remove(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                throw new Exception("Id is null");
            }
            MainDb.Instant.Delete<Versions>(ID);
        }
        public void Remove(string [] ID)
        {
            MainDb.Instant.Delete<Versions>(ID);
        }
    }
}
