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
    public class StoreRepo:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save(StoreRepo store)
        {
            MainDb.Instant.Save(store);
        }
        public IEnumerable<Store> List()
        {
            return MainDb.Instant.All<Store>();
        }
        public IEnumerable<Store> GetByName(string searchKey)
        {
            IMongoQuery query = Query<Store>.Where(c => c.Address.ToLower().Contains(searchKey.ToLower()));
            return MainDb.Instant.Find<Store>(query);
        }
    }
}
