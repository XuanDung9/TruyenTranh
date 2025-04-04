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
    public class SanPhamRepo:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save(Products product) // lưu
        {
            MainDb.Instant.Save(product);
        }
        public IEnumerable<Products> List(int iPage, int iPageSize, out long totalrows)
        {
            return MainDb.Instant.All<Products>(SortBy<Products>.Descending(c => c.Id), iPage,
                iPageSize, out totalrows);
        }
        public IEnumerable<Products> FindByName(string sKey, int iPage, int iPageSize, out long totalrows)
        {
            IMongoQuery query = Query<Products>.Where(c => c.Name_Product.ToLower().Contains(sKey.ToLower()));
            return MainDb.Instant.Find<Products>(query, iPage, iPageSize, out totalrows);
        }
        public void UpdateProduct(string newName ,string ID)
        {
            IMongoQuery query = Query<Products>.EQ(c => c.Id, ObjectId.Parse(ID));
            IMongoUpdate update = Update<Products>.Set(c => c.Name_Product, newName);
            MainDb.Instant.Update<Products>(query, update);
        }
        public Products SelectByID(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                throw new Exception("null");
            }    
            return MainDb.Instant.GetById<Products>(ID);
        }



        public void Remove(string ID)
        {
            MainDb.Instant.Delete<Products>(ID);
        }
        public void Remove(string [] ID)
        {
            MainDb.Instant.Delete<Products>(ID);
        }


    }
}
