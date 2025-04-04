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
    public class CityRepo: IDisposable
    {
        public void Save(thanhpho mnu)
        {
            MainDb.Instant.Save(mnu);
           
        }
        public void Add(thanhpho mnu)
        {
            MainDb db = new MainDb();
            db.GetCollection("thanhpho").Insert(mnu);
        }

        public IEnumerable<thanhpho> List()
        {
            return MainDb.Instant.All<thanhpho>(SortBy<thanhpho>.Ascending(x => x.Id));
        }
       
     

        public thanhpho SelectByID(string ID)
        {
            return MainDb.Instant.GetById<thanhpho>(ID);
        }



        public thanhpho SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<thanhpho>(ID);
        }

       

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<thanhpho>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<thanhpho>(ID);
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
