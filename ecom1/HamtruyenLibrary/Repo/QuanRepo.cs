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

    public class QuanRepo : IDisposable
    {
        public void Save(quanmassage mnu)
        {
            MainDb.Instant.Save(mnu);
        }

        public IEnumerable<quanmassage> List(int iPage, int iPageSize,  out long totalrows)
        {
            return MainDb.Instant.All<quanmassage>(SortBy<quanmassage>.Descending(c => c.Id), iPage,
                iPageSize, out totalrows);
        }

        public IEnumerable<quanmassage> List(int iPage, int iPageSize, string thanhphoid, out long totalrows)
        {
            IMongoQuery query = Query<quanmassage>.EQ(c => c.thanhphoid,thanhphoid);
            IMongoSortBy sort = SortBy<quanmassage>.Descending(c => c.Id);
            return MainDb.Instant.Find<quanmassage>(query, sort, iPage, iPageSize, out totalrows);
        }
      
       
        public IEnumerable<quanmassage> FindByName(string sKey, int iPage, int iPageSize, out long totalrows)
        {
            IMongoQuery query = Query<quanmassage>.Where(c => c.tenquan.ToLower().Contains(sKey.ToLower()) || c.tukhoasearch.Contains(sKey));
            IMongoSortBy sort = SortBy<quanmassage>.Descending(c => c.chamdiem);
            return MainDb.Instant.Find<quanmassage>(query, sort, iPage, iPageSize, out totalrows);
        }

        public void UpdateAnhQuan(IEnumerable<string> lst_anhquan, string id)
        {
            IMongoQuery query = Query<quanmassage>.EQ(c => c.Id, ObjectId.Parse(id));
            IMongoUpdate update = Update<quanmassage>.Set(c => c.anhquan, lst_anhquan);
            MainDb.Instant.Update<quanmassage>(query, update);
        }

        public quanmassage SelectByID(string ID)
        {
            return MainDb.Instant.GetById<quanmassage>(ID);
        }

        public quanmassage SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<quanmassage>(ID);
        }

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<quanmassage>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<quanmassage>(ID);
        }


        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool _disposing)
        {
            if (!_disposed)
            {
                if (_disposing)
                {
                    //cleanup managed resources

                    GC.SuppressFinalize(this);
                }

                //cleanup unmanaged resources

                _disposed = true;
            }
        }
    }
}
