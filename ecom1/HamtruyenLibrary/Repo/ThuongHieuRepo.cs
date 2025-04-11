using HamtruyenLibrary.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Repo
{
    public class ThuongHieuRepo:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save(ThuongHieu thuongHieu)
        {
            MainDb.Instant.Save(thuongHieu);
        }
        public IEnumerable<ThuongHieu> List()
        {
            return MainDb.Instant.All<ThuongHieu>();
        }
        public IEnumerable<ThuongHieu> FindByName(string searchKey)
        {
            IMongoQuery query = Query<ThuongHieu>.Where(c => c.TenThuongHieu.ToLower().Contains(searchKey.ToLower()));
            return MainDb.Instant.Find<ThuongHieu>(query);
        }
        //public void UpdateColor(string newName, string newHexCode, int newPrice, string ID)
        //{
        //    IMongoQuery query = Query<Color>.EQ(c => c.Id, ObjectId.Parse(ID));
        //    IMongoUpdate update = Update<Color>.Set(c => c.Name_Color, newName).Set(c => c.Hex_Code_Color, newHexCode);
        //    MainDb.Instant.Update<Color>(query, update);
        //}
        public ThuongHieu SelectByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new Exception("ID is null");
            }
            return MainDb.Instant.GetById<ThuongHieu>(ID);
        }
        public void Remove(string ID)
        {
            MainDb.Instant.Delete<ThuongHieu>(ID);

        }
        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<ThuongHieu>(ID);
        }
    }
}
