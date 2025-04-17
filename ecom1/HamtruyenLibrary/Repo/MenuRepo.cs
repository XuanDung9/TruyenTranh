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

        public Menu GetById(string IdMenu)
        {
            return MainDb.Instant.GetById<Menu>(IdMenu);
        }

        public void UpdateMenu(Menu menu , string idMenu)
        {
            IMongoQuery query = Query<Menu>.EQ(m => m.Id, ObjectId.Parse(idMenu));
            IMongoUpdate update = Update<Menu>
                .Set(m => m.MenuName, menu.MenuName)
                .Set(m => m.Type, menu.Type)
                .Set(m => m.MenuParentID, menu.MenuParentID)
                .Set(m => m.IsHorizontal, menu.IsHorizontal)
                .Set(m => m.ImageUrl, menu.ImageUrl);
            MainDb.Instant.Update<Menu>(query, update);
        }

        public void SetMenuDisplay(Menu menu, string idMenu , bool isHorizontal)
        {
            IMongoQuery query = Query<Menu>.EQ(m => m.Id, ObjectId.Parse(idMenu));
            IMongoUpdate update = Update<Menu>.Set(m => m.IsHorizontal , isHorizontal);

            MainDb.Instant.Update<Menu>(query, update);
        }

        public void DeleteMenu(string idMenu)
        {
            MainDb.Instant.Delete<Menu>(idMenu);
        }
    }
}
