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
    public partial class wucQuanLySanPham : System.Web.UI.UserControl
    {
        int ipage = 1; int ipagesize = 30;
        SanPhamRepo repo = new SanPhamRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }
        public void bindData()
        {
            SanPhamRepo repo = new SanPhamRepo();
            long totalrow = 0;
            var lst = repo.List(ipage, ipagesize, out totalrow);

            //int iPageCount = (int)(totalrow / ipagesize);
            //if ((totalrow % ipagesize) > 0)
            //{
            //    iPageCount++;
            //}
            gvSanPham.DataSource = lst;
            gvSanPham.DataBind();
        }
        protected void btnSua(object sender, EventArgs e)
        {
            var itemUpdate = repo.SelectByID(ID);
            // chuyển tới trang update
        }
        protected void btnXoa(object sender, EventArgs e)
        {
            Button btnXoa = (Button)sender;
            string productId = btnXoa.CommandArgument;
            var itemDelete = repo.SelectByID(productId.ToString());
            if (itemDelete != null)
            {
                repo.Remove(itemDelete.Id.ToString());
            }
            bindData();
        }
    }
}