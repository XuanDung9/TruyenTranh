using HamtruyenLibrary.Classes;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Bussiness
{
    public  class AdministratorBusiness
    {
        public static Privilege checkQuyen(ContentManager admin, int Mod)
        {
            Privilege bReturn = new Privilege();
            bReturn.Mod = "-1";
            List<Privilege> lst = admin.ListQuyen;
            foreach (Privilege role in lst)
            {
                if (role.Mod == Mod.ToString())
                {
                    bReturn = role;
                   
                }
            }

            return bReturn;
        }

        public static ContentManager Login(string UserName, string sPassword)
        {
            ContentManagerRepo adminRepo = new ContentManagerRepo();
            ContentManager admin = adminRepo.GetByUserNameAndPassword(UserName, Security.GetEnCrypt(sPassword));
            if (admin != null)
            {
                System.Web.HttpContext.Current.Session["admin"] = admin;
            }
            return admin;
        }

    }
}
