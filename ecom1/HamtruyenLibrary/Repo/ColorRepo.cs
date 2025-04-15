using System;
using System.Collections.Generic;
using HamtruyenLibrary.Models;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace HamtruyenLibrary.Repo
{
    public class ColorRepo:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save(Color color)
        {
            MainDb.Instant.Save(color);
        }
        public IEnumerable<Color> List()
        {
            return MainDb.Instant.All<Color>();
        }
        public IEnumerable<Color> FindByName(string searchKey)
        {
            IMongoQuery query = Query<Color>.Where(c => c.Name_Color.ToLower().Contains(searchKey.ToLower()));
            return MainDb.Instant.Find<Color>(query);
        }

        //public void UpdateColor(string IdStory,List<Color> lstColor)
        //{
        //    IMongoQuery query = Query<Products>.EQ(c => c.Id, ObjectId.Parse(IdStory));
        //    IMongoUpdate update = Update<Products>.Set(c => c.Color, lstColor);
        //    MainDb.Instant.Update<Products>(query, update);
        //}


        //public void UpdateColor(string newName, string newHexCode,int newPrice,string ID)
        //{
        //    IMongoQuery query = Query<Color>.EQ(c => c.Id, ObjectId.Parse(ID));
        //    IMongoUpdate update = Update<Color>.Set(c => c.Name_Color, newName).Set(c => c.Hex_Code_Color, newHexCode);
        //    MainDb.Instant.Update<Color>(query, update);
        //}
        public Color SelectByID(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                throw new Exception("ID is null");
            }
            return MainDb.Instant.GetById<Color>(ID);
        }
        public void Remove(string ID)
        {
            MainDb.Instant.Delete<Color>(ID);

        }
        public void Remove(string [] ID)
        {
            MainDb.Instant.Delete<Color>(ID);
        }
    }
}
