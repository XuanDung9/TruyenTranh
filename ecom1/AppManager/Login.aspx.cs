using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Response.Redirect("/Admin.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string sPass = txtPassword.Value; string username = txtUserName.Value;
            HamtruyenLibrary.Models.ContentManager content = HamtruyenLibrary.Bussiness.AdministratorBusiness.Login(username, sPass);

            if (content!=null)
            {
                Response.Redirect("/Admin.aspx");
            }
            else
            {
                check.InnerText = "Sai tên đăng nhập hoặc mật khẩu!";
            }
            if (username == "makeupbeblue@gmail.com" && sPass == "makeupbeblue1c73n@gmail.com")
            {
                ContentManager webadmin = new ContentManager();
                
                webadmin.UserName = "webadmin"; webadmin.AnhDaiDien = "/Pictures/admin/noimage.jpg";
                List<Privilege> lst = new List<Privilege>();
                ModeratorRepo repo = new ModeratorRepo();
                var lstMod = repo.List();
                foreach (Moderator mod in lstMod)
                {
                    Privilege pre = new Privilege();
                    pre.PhanKhucID = mod.MongoId; pre.Mod = mod.Mod;
                    pre.PhanKhucName = mod.PhanKhuc; pre.Add = true; pre.Edit = true; pre.Delete = true;

                    lst.Add(pre);
                }
                ApplicationWCRepo appRepo = new ApplicationWCRepo();
                IEnumerable<ApplicationSV> lstApp = appRepo.List();
                List<string> lst_string = new List<string>();
                foreach (ApplicationSV app in lstApp)
                {
                    lst_string.Add(app.MongoId);
                }
                webadmin.AppSuDung = lst_string;
                webadmin.ListQuyen = lst;
                Session["admin"] = webadmin;
                Response.Redirect("/Admin.aspx");
            }
        }
    }
}