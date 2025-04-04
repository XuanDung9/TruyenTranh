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
        public void Save(Menu mnu)
        {
            MainDb.Instant.Save(mnu);
            if (mnu.MenuLevel == 0)
            {
                
                mnu.MenuPathText = mnu.MongoId;
                MainDb.Instant.Save(mnu);
            }

        }
        public void Add(Menu mnu)
        {
            MainDb db = new MainDb();
            db.GetCollection("Menu").Insert(mnu);
        }
        
        public IEnumerable<Menu> List()
        {
            return MainDb.Instant.All<Menu>(SortBy<Menu>.Ascending(x => x.MenuAppID));
        }
        public IEnumerable<Menu> ListByApp(string sAppID)
        {
            IMongoQuery query = Query<Menu>.EQ(c => c.MenuAppID, sAppID);
            return MainDb.Instant.Find<Menu>(query,SortBy<Menu>.Ascending(x => x.MenuPathText));
        }

        public IEnumerable<Menu> ListByType(int iStyle)
        {
            IMongoQuery query = Query<Menu>.Where(c => c.MenuTypeID == iStyle);
            string[] sFields = new string[] {"MenuName", "MenuLink","MenuID" };
            return MainDb.Instant.Find<Menu>(sFields,query);
        }

        public Menu SelectByID(string ID)
        {
            return MainDb.Instant.GetById<Menu>(ID);
        }
    


        public Menu SelectByID(ObjectId ID)
        {
            return MainDb.Instant.GetById<Menu>(ID);
        }

        public IEnumerable<Menu> OrderListMenu(IEnumerable<Menu> lst_menu)
        {
            IEnumerable<Menu> lst_order = lst_menu.Where(c=>c.MenuParent=="0")
                .OrderByDescending(c=>c.MenuParent).OrderBy(c=>c.MenuPathText);

            List<Menu> lst_return = new List<Menu>();
            foreach (Menu lst in lst_order)
            {
                IEnumerable<Menu> lst_c = OrderListMenu2(lst_menu, lst.MongoId);
                lst_return.AddRange(lst_c);
            }
            return lst_return;
        }

        public IEnumerable<Menu> OrderListMenu2(IEnumerable<Menu> lst_menu, string sIDMenu)
        {
            List<Menu> lstReturn = lst_menu.Where(c => c.MongoId.Equals(sIDMenu)).ToList();
            IEnumerable<Menu> lst_child = lst_menu.Where(c => c.MenuParent.Equals(sIDMenu));
            if (lst_child != null || lst_child.Count() != 0)
            {
                foreach (Menu child in lst_child)
                {
                    string sTiento = "";
                    for (int i = 0; i < child.MenuLevel; i++)
                    {
                        sTiento += "--";
                    }
                    child.MenuName = sTiento + child.MenuName;
                    lstReturn.Add(child);
                    List<Menu> lst_child_v = OrderListMenu2(lst_menu, child.MongoId).ToList();
                    if (lst_child_v!=null )
                    {
                        IEnumerable<Menu> menu_remvoe = lst_child_v.Where(c => c.MongoId.Equals(child.MongoId));
                        if (menu_remvoe != null) lst_child_v.Remove(menu_remvoe.First());
                        lstReturn.AddRange(lst_child_v);
                    }
                    
                }
            }
            
            return lstReturn;
        }
       

        public void Remove(string ID)
        {
            MainDb.Instant.Delete<Menu>(ID);
        }

        public void Remove(string[] ID)
        {
            MainDb.Instant.Delete<Menu>(ID);
        }
        

    }
}
