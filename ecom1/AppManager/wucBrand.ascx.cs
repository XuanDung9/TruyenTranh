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
    public partial class wucBrand : System.Web.UI.UserControl
    {
        public string THID
        {
            get
            {
                if (null == ViewState["ThuongHieuID"])
                    return string.Empty;
                else
                    return (string)ViewState["ThuongHieuID"];
            }
            set { ViewState["ThuongHieuID"] = value; }
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
            ThuongHieuRepo repo = new ThuongHieuRepo();
            var lstThuongHieu = repo.List();

            gvThuongHieu.DataSource = lstThuongHieu;
            gvThuongHieu.DataBind();
        }

        public void ShowList()
        {
            lst_ThuongHieu.Visible = true;
            edit_ThuongHieu.Visible = false;
            bindData();

        }
        public void ShowEdit()
        {
            lst_ThuongHieu.Visible = false;
            edit_ThuongHieu.Visible = true;
        }
        public void showDetailItem(string sID)
        {
            ThuongHieuRepo repo = new ThuongHieuRepo();
            ThuongHieu thuongHieu = repo.SelectByID(sID);
            if (thuongHieu != null)
            {
                txtTenThuongHieu.Text = thuongHieu.TenThuongHieu;

            }
            ShowEdit();
        }
        protected void btn_Save(object sender, EventArgs e)
        {
            ThuongHieuRepo repo = new ThuongHieuRepo();
            var itemUpdate = repo.SelectByID(THID);
            itemUpdate.TenThuongHieu = txtTenThuongHieu.Text;
            repo.Save(itemUpdate);
            ShowList();

        }

        protected void btn_Them(object sender, EventArgs e)
        {
            ThuongHieuRepo repo = new ThuongHieuRepo();
            ThuongHieu thuongHieu = new ThuongHieu
            {
                TenThuongHieu = "New Brand",
            };
            repo.Save(thuongHieu);
        }
        protected void gvThuongHieu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ThuongHieuRepo repo = new ThuongHieuRepo();
            THID = e.CommandArgument.ToString();
            if (e.CommandName.ToLower() == "sua")
            {
                ShowEdit();
                showDetailItem(THID);
            }
            else if (e.CommandName.ToLower() == "xoa")
            {
                repo.Remove(THID.ToString());
                bindData();
            }

        }
        protected void btn_Cancel(object sender, EventArgs e)
        {
            ShowList();
        }

    }
}