using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using HamtruyenLibrary;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Bussiness;
using HamtruyenLibrary.Repo;
using HamtruyenLibrary.Classes;
using Menu = HamtruyenLibrary.Models.Menu;
using System.IO;

namespace HamtruyenAdmin
{
    public partial class wucQuanTriMenu : System.Web.UI.UserControl
    {
        HamtruyenLibrary.Repo.MenuRepo menuRepo = new HamtruyenLibrary.Repo.MenuRepo();
        public string sMID
        {
            get
            {
                if (null == ViewState["MenuID"])
                    return string.Empty;
                else
                    return (string)ViewState["MenuID"];
            }
            set { ViewState["MenuID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                showListMenu();
            }

        }

        public void loadData()
        {
            MenuRepo repo = new MenuRepo();
            var lstMenu = repo.GetAllMenu();
            gvListMenu.DataSource = lstMenu;
            gvListMenu.DataBind();
        }

        public void showListMenu()
        {
            list_menu.Visible = true;
            edit_menu.Visible = false;
        }
        public void showEditGroup()
        {
            list_menu.Visible = false;
            edit_menu.Visible = true;
        }

        protected void gvListMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Trim() == "Sua")
            {
                showEditGroup();
                sMID = e.CommandArgument.ToString();
                showDetailMenu(sMID);
            }
            else if (e.CommandName.Trim() == "Xoa")
            {
                sMID = e.CommandArgument.ToString();
                menuRepo.DeleteMenu(sMID);
                loadData();
            }
        }
        public void showDetailMenu(string sMenuID)
        {
            ddlMenuType.ClearSelection();
            HamtruyenLibrary.Models.Menu mb = menuRepo.GetById(sMenuID);
            txtMenuName.Text = mb.MenuName;

            ddlMenuType.ClearSelection();
            ddlMenuType.Items.FindByText(mb.Type);
            Image.ImageUrl = mb.ImageUrl;
            cbAction.Checked = mb.IsHorizontal;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string imagePath = "";
            if (fuAnhMenu.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(fuAnhMenu.FileName);
                    string folderPath = Server.MapPath("~/img/");

                    string savePath = Path.Combine(folderPath, fileName);
                    fuAnhMenu.SaveAs(savePath);

                    imagePath = "~/img/" + fileName;

                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi upload ảnh: " + ex.Message + "");
                    return;
                }
            }
            MenuRepo repo = new MenuRepo();
            var menu = repo.GetById(sMID);
            try
            {
                menu.MenuName = txtMenuName.Text;
                menu.Type = ddlMenuType.SelectedValue;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    menu.ImageUrl = imagePath;
                }
                //menu.MenuParentID =;
                menu.IsHorizontal = cbAction.Checked;
                repo.UpdateMenu(menu, sMID);
            }
            catch
            {

            }


            loadData();
            showListMenu();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            showListMenu();
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            MenuRepo repo = new MenuRepo();
            Menu mn = new Menu
            {

            };
            repo.Create(mn);
            loadData();
        }
    }
}