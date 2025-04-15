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
    public class DanhMucRepo : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Create(DanhMuc danhMuc)
        {
            MainDb.Instant.Save(danhMuc);
        }

        public IEnumerable<DanhMuc> GetAll()
        {
            return MainDb.Instant.All<DanhMuc>();
        }    

        public DanhMuc GetById(string id)
        {
            return MainDb.Instant.GetById<DanhMuc>(id);
        }

        public void Update(DanhMuc danhMuc , string id)
        {
            IMongoQuery query = Query<DanhMuc>.EQ(d => d.Id, ObjectId.Parse(id));
            IMongoUpdate update = Update<DanhMuc>.Set(d => d.TenDanhMuc, danhMuc.TenDanhMuc);

            MainDb.Instant.Update<DanhMuc>(query, update);
        }

        public void Remove(string id )
        {
            MainDb.Instant.Delete<DanhMuc>(id);
        }
    }
}
