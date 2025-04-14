using System;
using System.Collections.Generic;
using System.Linq;
using HamtruyenLibrary;
using HamtruyenLibrary.Models;
using MongoDB.Driver.Builders;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HamtruyenLibrary.Repo
{
    public class MenuRepo
    {
        public void Create (Menu menu)
        {
            MainDb.Instant.Save(menu);
        }
        public IEnumerable<Menu> GetAllMenu()
        {
            return MainDb.Instant.All<Menu>();
        }    
        public IEnumerable<Menu> GetByTypeParentName(string searchKey)
        {
            IMongoQuery query = Query<Menu>.Where(m => m.MenuName.ToLower().Contains(searchKey.ToLower()));
            return MainDb.Instant.Find<Menu>(query);
        }
    }
}
