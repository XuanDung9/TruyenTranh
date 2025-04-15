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
    public partial class wucDanhMuc : System.Web.UI.UserControl
    {
        public string DMID
        {
            get
            {
                if (null == ViewState["DanhMucID"])
                    return string.Empty;
                else
                    return (string)ViewState["DanhMucID"];
            }
            set
            {
                ViewState["DanhMucID"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ShowList();
            }
        }
        public void BindData()
        {
            DanhMucRepo repo = new DanhMucRepo();
            var lstDanhMuc = repo.GetAll();

            gvDanhMuc.DataSource = lstDanhMuc;
            gvDanhMuc.DataBind();

        }
        public void ShowList()
        {
            lst_DanhMuc.Visible = true;
            edit_DanhMuc.Visible = false;
            BindData();
        }
        public void ShowEdit()
        {
            lst_DanhMuc.Visible = false;
            edit_DanhMuc.Visible = true;
        }
        public void ShowDetailItem(string id)
        {
            DanhMucRepo repo = new DanhMucRepo();
            var item = repo.GetById(id);
            if (item != null)
            {
                txtTenDanhMuc.Text = item.TenDanhMuc;
            }
            ShowEdit();
        }

        public void btn_Them(object sender, EventArgs e)
        {
            DanhMucRepo repo = new DanhMucRepo();
            DanhMuc danhmuc = new DanhMuc();
            repo.Create(danhmuc);
            BindData();
        }
        protected void btn_Save(object sender, EventArgs e)
        {
            DanhMucRepo repo = new DanhMucRepo();
            var updateItem = repo.GetById(DMID);
            updateItem.TenDanhMuc = txtTenDanhMuc.Text;
            repo.Update(updateItem, DMID);
            ShowList();
        }

        protected void gvDanhMuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DanhMucRepo repo = new DanhMucRepo();
            DMID = e.CommandArgument.ToString();
            if (e.CommandName.ToLower() == "sua")
            {
                ShowEdit();
                ShowDetailItem(DMID);
            }
            else if (e.CommandName.ToLower() == "xoa")
            {
                repo.Remove(DMID);
                BindData();
            }
        }
        protected void btn_Cancel(object sender, EventArgs e)
        {
            ShowList();
        }
    }
}