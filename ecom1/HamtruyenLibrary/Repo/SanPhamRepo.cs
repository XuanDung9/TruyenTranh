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
    public class SanPhamRepo : IDisposable
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

        public object List(object iPage, object iPageSize)
        {
            throw new NotImplementedException();
        }

        public object List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> FindByName(string sKey, int iPage, int iPageSize, out long totalrows)
        {
            IMongoQuery query = Query<Products>.Where(c => c.Name_Product.ToLower().Contains(sKey.ToLower()));
            return MainDb.Instant.Find<Products>(query, iPage, iPageSize, out totalrows);
        }
        public void UpdateProduct(Products updatedProduct, string ID)
        {
            IMongoQuery query = Query<Products>.EQ(c => c.Id, ObjectId.Parse(ID));
            IMongoUpdate update = Update<Products>.Set(c => c.Name_Product, updatedProduct.Name_Product)
                                                    .Set(c => c.Image_Product, updatedProduct.Image_Product)
                                                    .Set(c => c.SKU, updatedProduct.SKU)
                                                    .Set(c => c.Quantity, updatedProduct.Quantity)
                                                    .Set(c => c.Color, updatedProduct.Color)
                                                    .Set(c => c.Version, updatedProduct.Version)
                                                    .Set(c => c.Price, updatedProduct.Price)
                                                    .Set(c => c.Description, updatedProduct.Description)
                                                    .Set(c => c.Category, updatedProduct.Category);
            MainDb.Instant.Update<Products>(query, update);
        }
        public Products SelectByID(string ID)
        {
            return MainDb.Instant.GetById<Products>(ID);
        }



        public void Remove(string ID)
        {
            MainDb.Instant.Delete<Products>(ID);
        }
        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<Products>(ID);
        }


    }
}
