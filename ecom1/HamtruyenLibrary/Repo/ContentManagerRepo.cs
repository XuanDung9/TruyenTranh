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
    public class ContentManagerRepo
    {
        public void Save(ContentManager rule)
        {
            MainDb.Instant.Save(rule);
        }

        public IEnumerable<ContentManager> List()
        {
            return MainDb.Instant.All<ContentManager>();
        }

        public ContentManager getByID(ObjectId Id)
        {
            return MainDb.Instant.GetById<ContentManager>(Id);
        }

        public IEnumerable<ContentManager> List(int iPage, int iPageSize)
        {
            IMongoQuery query = Query<ContentManager>.Where(c => c.UserName != "");
            IMongoSortBy sort = SortBy<ContentManager>.Ascending(c => c.Id);
            return MainDb.Instant.Find<ContentManager>(query, sort, iPage, iPageSize);

        }
        public ContentManager GetByUserNameAndPassword(string sUserName, string sPassword)
        {
            IMongoQuery query = Query<ContentManager>.Where(c => c.UserName.Equals(sUserName) && c.Password.Equals(sPassword));
            return MainDb.Instant.FindOne<ContentManager>(query);
        }
        public void UpdateInfoAdmin(string sID, string sUserName, string sPassword, string sAvatar)
        {
            IMongoQuery query = Query<ContentManager>.EQ(c => c.MongoId, sID);
            IMongoUpdate update = Update<ContentManager>.Set(c=>c.UserName,sUserName).Set(c => c.Password, sPassword).Set(c=>c.AnhDaiDien,sAvatar);
            MainDb.Instant.Update<ContentManager>(query, update);
        }

        public void UpdateLastAccess(string sUserName)
        {
            IMongoQuery query = Query<ContentManager>.EQ(c => c.UserName, sUserName);
            IMongoUpdate update = Update<ContentManager>.Set(c => c.LanTruyCapCuoi, DateTime.Now);
            MainDb.Instant.Update<ContentManager>(query, update);
        }

        public List<Privilege> UpdateRoles(string sUserName, Privilege role, int iStatus)
        {
            ContentManager current = getByID(sUserName);
            List<Privilege> lstCurrentRole = current.ListQuyen;
            if (iStatus == 1)
            {
                IEnumerable<Privilege> existRole = lstCurrentRole.Where<Privilege>(c => c.Mod.Equals(role.Mod));

                if (existRole == null || existRole.Count() == 0)
                {
                    lstCurrentRole.Add(role);
                }
            }
            else
            {
                IEnumerable<Privilege> existRole = lstCurrentRole.Where<Privilege>(c => c.Mod.Equals(role.Mod));

                if (existRole != null || existRole.Count() > 0)
                {
                    lstCurrentRole.Remove(existRole.First());
                }
                
            }

            IMongoQuery query = Query<ContentManager>.EQ(c => c.Id, current.Id);
            IMongoUpdate update = Update<ContentManager>.Set(c => c.ListQuyen, lstCurrentRole);
            MainDb.Instant.Update<ContentManager>(query, update);
            return lstCurrentRole;
        }

        public ContentManager getByUserName(string sUserName)
        {
            IMongoQuery query = Query<ContentManager>.Where(c => c.UserName.Equals(sUserName));

            return MainDb.Instant.FindOne<ContentManager>(query);
        }

        public IEnumerable<ContentManager> getByStartwith(string sUserName)
        {
            IMongoQuery query = Query<ContentManager>.Where(c => c.UserName.StartsWith(sUserName));

            return MainDb.Instant.Find<ContentManager>(query);
        }

        public ContentManager getByID(string sID)
        {
            return MainDb.Instant.GetById<ContentManager>(ObjectId.Parse(sID));
        }

        public void remove(string sID)
        {
            MainDb.Instant.Delete<ContentManager>(ObjectId.Parse(sID));
        }
    }
}
