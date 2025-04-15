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
    public partial class wucVersion : System.Web.UI.UserControl
    {
        public string vID
        {
            get
            {
                if (null == ViewState["VersionID"])
                    return string.Empty;
                else
                    return (string)ViewState["VersionID"];
            }
            set { ViewState["VersionID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                ShowList();
            }
        }
        public void bindData()
        {
            VersionRepo repo = new VersionRepo();
            var lstVersion = repo.List();

            gvPhienBan.DataSource = lstVersion;
            gvPhienBan.DataBind();
        }

        public void ShowList()
        {
            lst_PhienBan.Visible = true;
            edit_PhienBan.Visible = false;
            bindData();

        }
        public void ShowEdit()
        {
            lst_PhienBan.Visible = false;
            edit_PhienBan.Visible = true;
        }
        public void showDetailItem(string vID)
        {
            VersionRepo repo = new VersionRepo();
            Versions versions = repo.SelectByID(vID);
            if (versions != null)
            {
                txtTenPhienBan.Text = versions.Name_Version;
            }
            ShowEdit();
        }
        protected void btn_Save(object sender, EventArgs e)
        {
            VersionRepo repo = new VersionRepo();
            var itemUpdate = repo.SelectByID(vID);
            itemUpdate.Name_Version = txtTenPhienBan.Text;
            repo.Save(itemUpdate);
            ShowList();

        }

        protected void btn_Them(object sender, EventArgs e)
        {
            VersionRepo repo = new VersionRepo();
            Versions version = new Versions
            {
                Name_Version = "New version",
            };
            repo.Save(version);
            bindData();
        }
        protected void gvPhienBan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            VersionRepo repo = new VersionRepo();
            vID = e.CommandArgument.ToString();
            if (e.CommandName.ToLower() == "sua")
            {
                ShowEdit();
                showDetailItem(vID);
            }
            else if (e.CommandName.ToLower() == "xoa")
            {
                repo.Remove(vID.ToString());
                bindData();
            }

        }
        protected void btn_Cancel(object sender, EventArgs e)
        {
            ShowList();
        }
    }
}