using HamtruyenLibrary.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HamtruyenLibrary.Models.Products;

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

        public IEnumerable<Products> GetAll(int iPage, int iPageSize, out long totalrows)
        {
            return MainDb.Instant.All<Products>(SortBy<Products>.Descending(c => c.Id), iPage,
                iPageSize, out totalrows);
        }

        public IEnumerable<Products> GetByType () // danh sách các sản phẩm đang hoạt động 
        {
            IMongoQuery query = Query<Products>.EQ(p => p.TrangThai, true);
            List<Products> products = MainDb.Instant.Find<Products>(query).ToList();
            return products;
        }


        public IEnumerable<Products> FindByName(string sKey, int iPage, int iPageSize, out long totalrows)
        {
            IMongoQuery query = Query<Products>.Where(c => c.TenSP.ToLower().Contains(sKey.ToLower()));
            return MainDb.Instant.Find<Products>(query, iPage, iPageSize, out totalrows);
        }

        public void SetActiveProduct(Products product, string id, bool active)
        {
            IMongoQuery query = Query<Products>.EQ(C => C.Id, ObjectId.Parse(id));
            IMongoUpdate update = Update<Products>.Set(c => c.TrangThai, active);
            MainDb.Instant.Update<Products>(query, update);
        }
        public void UpdateProduct(Products updatedProduct, string ID)
        {
            IMongoQuery query = Query<Products>.EQ(c => c.Id, ObjectId.Parse(ID));
            IMongoUpdate update = Update<Products>
                .Set(c => c.TenSP, updatedProduct.TenSP)
                .Set(c => c.HinhAnhs, updatedProduct.HinhAnhs)
                .Set(c => c.MauSac, updatedProduct.MauSac)
                .Set(c => c.MoTa, updatedProduct.MoTa)
                .Set(c => c.DanhMuc, updatedProduct.DanhMuc)
                .Set(c => c.TrangThai, updatedProduct.TrangThai)
                .Set(c => c.AnhDaiDien, updatedProduct.AnhDaiDien)
                .Set(c => c.Options, updatedProduct.Options);

            MainDb.Instant.Update<Products>(query, update);
        }

        public void UpdateOption(string idProduct, List<Option> lstOption) // cập nhật các option
        {
            IMongoQuery query = Query<Products>.EQ(c => c.Id, ObjectId.Parse(idProduct));
            IMongoUpdate update = Update<Products>.Set(c => c.Options, lstOption);

            MainDb.Instant.Update<Products>(query, update);
        }

        public void UpdateImage(string idProduct, List<string> newImage)
        {
            IMongoQuery query = Query<Products>.EQ(c => c.Id, ObjectId.Parse(idProduct));
            IMongoUpdate update = Update<Products>.Set(c => c.HinhAnhs, newImage);

            MainDb.Instant.Update<Products>(query, update);
        }

        public IEnumerable<Products> TimKiemTheoDanhMuc(string sKey)
        {
            var danhMucId = ObjectId.Parse(sKey); //ép kiểu cho nó trước
            IMongoQuery query = Query<Products>.EQ(c => c.DanhMuc.Id, danhMucId);
            return MainDb.Instant.Find<Products>(query);
        }


        public Products GetById(string ID)
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
