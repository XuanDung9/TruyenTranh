using HamtruyenLibrary.Bussiness;
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
    public partial class wucQuanTriModerator : System.Web.UI.UserControl
    {
        public string PKID
        {
            get
            {
                if (null == ViewState["PKID"])
                    return string.Empty;
                else
                    return (string)ViewState["PKID"];
            }
            set { ViewState["PKID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkQuyen();
                loadData();
                showList();
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
                        btnThemPhanKhuc.Visible = false;
                    }
                    if (role.Edit == false)
                    {
                        foreach (GridViewRow item in gvListMode.Rows)
                        {

                            LinkButton lbtnEdit = (LinkButton)item.FindControl("LinkButton1");
                            lbtnEdit.Visible = false;

                        }

                    }

                    if (role.Delete == false)
                    {
                        foreach (GridViewRow item in gvListMode.Rows)
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
        public void showEdit()
        {
            div_edit_phankhuc.Visible = true;
            lst_phankhuc.Visible = false;
        }

        public void showList()
        {
            div_edit_phankhuc.Visible = false;
            lst_phankhuc.Visible = true;
        }

        public void loadData()
        {
            ModeratorRepo repo = new ModeratorRepo();

            gvListMode.DataSource = repo.List();
            gvListMode.DataBind();
        }

        public void showDetailMod(string sID)
        {
            ModeratorRepo repo = new ModeratorRepo();
            Moderator mod = repo.getByID(sID);

            txtModNumber.Text = mod.Mod;
            txtTenPhanKhuc.Text = mod.PhanKhuc;

        }

        #endregion

        #region Control Event
        protected void gvListRule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PKID = e.CommandArgument.ToString();
            if (e.CommandName.Trim() == "Sua")
            {
                showDetailMod(PKID);
                showEdit();
            }
            else if (e.CommandName.Trim() == "Xoa")
            {
                ModeratorRepo repo = new ModeratorRepo();
                repo.remove(PKID);

                loadData();
            }
        }

        protected void btnThemPhanKhuc_Click(object sender, EventArgs e)
        {
            PKID = "-1";
            showEdit();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ModeratorRepo repo = new ModeratorRepo();
            Moderator mod = new Moderator();
            if (PKID != "-1")
            {
                mod = repo.getByID(PKID);
            }
            mod.PhanKhuc = txtTenPhanKhuc.Text;
            mod.Mod = txtModNumber.Text;

            repo.Save(mod);
            loadData();
            showList();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            showList();
        }

        #endregion

    }
}