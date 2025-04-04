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
                checkQuyen();
                ContentManager currentAd = (ContentManager)Session["admin"];
                Privilege roleApp = AdministratorBusiness.checkQuyen(currentAd, 23);
                if (roleApp.Mod != "-1")
                {
                    div_app_menu.Visible = true;
                    ApplicationWCRepo repo = new ApplicationWCRepo();
                    Utility.CreateCombo(repo.List(), "AppName", "Id", ddlListApp);

                }
                
            }
            
        }
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
                        btnAddMenu.Visible = false;
                    }
                    if (role.Edit == false)
                    {
                        foreach (GridViewRow item in gvListMenu.Rows)
                        {
                           
                                LinkButton lbtnEdit = (LinkButton)item.FindControl("btnSua");
                                lbtnEdit.Visible = false;
                            
                        }

                    }

                    if (role.Delete == false)
                    {
                        foreach (GridViewRow item in gvListMenu.Rows)
                        {
                            
                                LinkButton lbtnDelete = (LinkButton)item.FindControl("btnXoa");
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
        public void loadData()
        {
            var query = menuRepo.List();
            if (Session["AppID"] != null)
            {
                query = menuRepo.ListByApp(Session["AppID"].ToString());
            }
            query = menuRepo.OrderListMenu(query);
            gvListMenu.DataSource = query;
            gvListMenu.DataBind();
            CreateCombo("--Chọn Menu--", query, ddlListMenuParent, "MenuName", "MongoId");
            
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
       
        static public void CreateCombo(string sTextO,IEnumerable<HamtruyenLibrary.Models.Menu> Reader, DropDownList drop, string sText, string sValue)
        {
            drop.Items.Clear();

            if (sTextO != "")
            {
                ListItem lst_ote = new ListItem(sTextO, "0");
                drop.Items.Add(lst_ote);
                foreach (HamtruyenLibrary.Models.Menu mnu in Reader)
                {
                    drop.Items.Add(new ListItem(mnu.MenuName, mnu.MongoId));
                }
            }
            else
            {
                drop.DataTextField = sText;
                drop.DataValueField = sValue;
                drop.DataSource = Reader;
                drop.DataBind();
            }
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
                menuRepo.Remove(sMID);
                loadData();
            }
        }
        public void showDetailMenu(string sMenuID)
        {
            ddlMenuType.ClearSelection();
            HamtruyenLibrary.Models.Menu mb = menuRepo.SelectByID(sMenuID);
            txtMenuName.Value = mb.MenuName;
            txtMenuIDOld.Value = mb.MenuLevel.ToString();

            ddlListMenuParent.ClearSelection();
            if (mb.MenuParent != "0")
            {
                ddlListMenuParent.Items.FindByValue(mb.MenuParent).Selected = true;
            }
            ddlMenuType.Items.FindByValue(mb.MenuTypeID.ToString()).Selected = true;
          
            txtMenuLink.Value = mb.MenuLink;
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            HamtruyenLibrary.Models.Menu mb = new HamtruyenLibrary.Models.Menu();
            if (sMID != "-1")
            {
               mb = menuRepo.SelectByID(sMID);
            }
            string smnuParent = "0";int mnuLevel = 0;
            string sMenuPathText = "";
            if (ddlListMenuParent.SelectedValue != "0")
            {
                HamtruyenLibrary.Models.Menu mnu_parent = menuRepo.SelectByID(ddlListMenuParent.SelectedValue);
                smnuParent = mnu_parent.MongoId;
                sMenuPathText = mnu_parent.MenuPathText + "  " + mnu_parent.MongoId;
                mnuLevel= mnu_parent.MenuLevel+1;
            }
            ContentManager currentAd = (ContentManager)Session["admin"];
            Privilege roleApp = AdministratorBusiness.checkQuyen(currentAd, 23);
            if (roleApp.Mod != "-1")
            {
                mb.MenuAppID = ddlListApp.SelectedValue;
            }
            else
            {
                mb.MenuAppID = Session["AppID"].ToString();
            }
            mb.MenuTypeID = int.Parse(ddlMenuType.SelectedValue);
            mb.MenuTypeName = (ddlMenuType.SelectedItem.Text);
            mb.MenuName = txtMenuName.Value;
            mb.MenuLink = txtMenuLink.Value;
            mb.MenuLevel = mnuLevel ;
            
            mb.MenuParent = smnuParent;
            mb.MenuPathText = sMenuPathText;
            
            menuRepo.Save(mb);

            loadData();
            showListMenu();
        }

        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            showListMenu();
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            sMID = "-1";
            showEditGroup();
        }
    }
}