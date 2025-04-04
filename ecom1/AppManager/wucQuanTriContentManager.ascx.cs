using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HamtruyenLibrary.Classes;
using System.IO;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Classes;
using HamtruyenLibrary.Repo;
using HamtruyenLibrary.Bussiness;

namespace HamtruyenAdmin
{
    public partial class wucQuanTriContentManager : System.Web.UI.UserControl
    {
        public string AID
        {
            get
            {
                if (null == ViewState["AID"])
                    return string.Empty;
                else
                    return (string)ViewState["AID"];
            }
            set { ViewState["AID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkQuyen();
                loadData();
                showList();
                bindPhanKhuc();
                BindListApp();
            }
        }

        #region Function 

        public void checkQuyen()
        {
            int mod = int.Parse(Request.Params["mod"]);
            ContentManager currentAd = (ContentManager)Session["admin"];
            if (currentAd.UserName != "webadmin")
            {
                Privilege role = AdministratorBusiness.checkQuyen(currentAd, mod);
                if (role.Mod != "-1")
                {
                    if (role.Add == false)
                    {
                        btnThemLuat.Visible = false;
                    }
                    if (role.Edit == false)
                    {
                        foreach (GridViewRow item in gvListAdmin.Rows)
                        {

                            LinkButton lbtnEdit = (LinkButton)item.FindControl("LinkButton1");
                            lbtnEdit.Visible = false;

                        }

                    }

                    if (role.Delete == false)
                    {
                        foreach (GridViewRow item in gvListAdmin.Rows)
                        {

                            LinkButton lbtnDelete = (LinkButton)item.FindControl("LinkButton3");
                            lbtnDelete.Visible = false;

                        }

                    }
                }
                else
                {
                    Response.Redirect("/Admin.aspx?mod=99");
                }
            }

        }

        public void showList()
        {
            lstAdmin.Visible = true;
            div_edit_admin.Visible = false;
        }

        public void showEdit()
        {
            lstAdmin.Visible = false;
            div_edit_admin.Visible = true;
        }

        public void loadData()
        {
            ContentManagerRepo repo = new ContentManagerRepo();

            gvListAdmin.DataSource = repo.List();
            gvListAdmin.DataBind();
        }

        public void showDetailAdmin(string sAID)
        {
            ContentManagerRepo repo = new ContentManagerRepo();
            ContentManager sCurrent_Ad = repo.getByID(sAID);
            txtPassword.Attributes.Add("value", Security.GetDeCrypt(sCurrent_Ad.Password));
            txtUsername.Text = sCurrent_Ad.UserName;
            img_avatar.Src = sCurrent_Ad.AnhDaiDien;

            BindListQuyen(sCurrent_Ad.ListQuyen);
            ApplicationWCRepo appRepo = new ApplicationWCRepo();
            var query = appRepo.SelectByListID(sCurrent_Ad.AppSuDung);

            gvListUngDung.DataSource = query;
            gvListUngDung.DataBind();
        }
        public void bindPhanKhuc()
        {
            ModeratorRepo repo = new ModeratorRepo();
            var lst_mod = repo.List();
            Utility.CreateCombo<Moderator>(lst_mod, "PhanKhuc", "Id", ddlPhanKhuc);
        }
        public void BindListApp()
        {
            ApplicationWCRepo repo = new ApplicationWCRepo();
            var query = repo.List();

            Utility.CreateCombo<ApplicationSV>(query, "AppName", "Id", ddlListUngDung);
        }

        public void BindListQuyen(IEnumerable<Privilege> lstRole)
        {
            gvListRolesOfUser.DataSource = lstRole;
            gvListRolesOfUser.DataBind();
        }
        #endregion

        #region Event GUI
        protected void btnThemLuat_Click(object sender, EventArgs e)
        {
            ContentManagerRepo repo = new ContentManagerRepo();

            var lstExist = repo.getByStartwith("NewAdmin");
            string sUserName = "NewAdministrator";
            if (lstExist != null || lstExist.Count()>0)
            {
                sUserName += lstExist.Count()+1;
            }
            string sPass = Security.GetEnCrypt("admin1");
            ContentManager content = new ContentManager();
            content.UserName = sUserName;
            content.Password = sPass;
            content.LanTruyCapCuoi = DateTime.Now;
            content.AppSuDung = new List<string>();
            
            repo.Save(content);
            loadData();
        }

        protected void btnThemQuyen_Click(object sender, EventArgs e)
        {
            Privilege newRole = new Privilege();

            newRole.Add = chkThem.Checked;
            newRole.Edit = chkSua.Checked;
            newRole.Delete = chkXoa.Checked;

            ModeratorRepo mrepo = new ModeratorRepo();
            Moderator curr_mod = mrepo.getByID(ddlPhanKhuc.SelectedValue);
            newRole.PhanKhucName = curr_mod.PhanKhuc;
            newRole.PhanKhucID = curr_mod.MongoId;
            newRole.Mod = curr_mod.Mod;
            ContentManagerRepo repo = new ContentManagerRepo();

            var query = repo.UpdateRoles(AID, newRole, 1);
            BindListQuyen(query);
        }

        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ContentManagerRepo repo = new ContentManagerRepo();
            ContentManager content = new ContentManager();
            if (AID != "-1")
            {
                content = repo.getByID(AID);
            }
            content.UserName = txtUsername.Text;
            content.Password = Security.GetEnCrypt(txtPassword.Text);
            content.LanTruyCapCuoi = DateTime.Now;
            //content.AnhDaiDien = "/Pictures/Admin/noimage.jpg";
            if (fAvatar.HasFile)
            {
                string sFileName = fAvatar.FileName;
                sFileName = Utility.checkAndReName(Utility.getPhysicalPath() + "/Pictures/" + sFileName);
                fAvatar.SaveAs(sFileName);

                string[] sArr = sFileName.Split('.');
                string sNewName = Utility.getPath(txtUsername.Text) + "."+sArr[sArr.Length-1];
                string sFileNameSmall = Utility.checkAndReName(Utility.getPhysicalPath() + "/Pictures/Admin/" + sNewName);
                FileUtilty.ImageZoomAndSaveWidth(sFileName, sFileNameSmall, 200);
                content.AnhDaiDien = "/Pictures/Admin/" + sNewName;
                File.Delete(sFileName);
            }

            repo.UpdateInfoAdmin(AID, txtUsername.Text, Security.GetEnCrypt(txtPassword.Text), content.AnhDaiDien);
            loadData();
            showList();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            showList();
        }


        protected void gvListAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AID = e.CommandArgument.ToString();
            if (e.CommandName.Trim() == "Sua")
            {
                showDetailAdmin(AID);
                showEdit();
            }
            else if (e.CommandName.Trim() == "Xoa")
            {
                ContentManagerRepo repo = new ContentManagerRepo();
                repo.remove(AID);
                loadData();
            }
        }

        protected void gvListRolesOfUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Trim() == "XoaQuyen")
            {
                ContentManagerRepo repo = new ContentManagerRepo();

                Privilege pre = new Privilege();
                pre.Mod = e.CommandArgument.ToString();
                var query  = repo.UpdateRoles(AID, pre, -1);
                BindListQuyen(query);
            }
        }

        protected void btnThemUngDung_Click(object sender, EventArgs e)
        {
            ContentManagerRepo repo = new ContentManagerRepo();

            ContentManager cn = repo.getByID(AID);
            string sIDApp = ddlListUngDung.SelectedValue;
            List<string> lst = cn.AppSuDung;
            lst.Add(sIDApp);
            cn.AppSuDung = lst;

            repo.Save(cn);

            ApplicationWCRepo appRepo = new ApplicationWCRepo();
            var query = appRepo.SelectByListID(cn.AppSuDung);

            gvListUngDung.DataSource = query;
            gvListUngDung.DataBind();
        }

        protected void gvListUngDung_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Trim() == "XoaQuyen")
            {
                ContentManagerRepo repo = new ContentManagerRepo();

                ContentManager cn = repo.getByID(AID);
                string sIDApp = e.CommandArgument.ToString();
                List<string> lst = cn.AppSuDung;
                lst.Remove(sIDApp);
                cn.AppSuDung = lst;

                repo.Save(cn);

                ApplicationWCRepo appRepo = new ApplicationWCRepo();
                var query = appRepo.SelectByListID(cn.AppSuDung);

                gvListUngDung.DataSource = query;
                gvListUngDung.DataBind();
            }
        }

        #endregion

        
    }
}