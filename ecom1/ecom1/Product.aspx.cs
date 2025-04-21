using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecom1
{
    public partial class Product : System.Web.UI.Page
    {
        int ipage = 1; int ipagesize = 30;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadListProduct();
            }
        }
        public void LoadListProduct()
        {
            long totalRow = 0;
            SanPhamRepo repo = new SanPhamRepo();
            var products = repo.GetAll(ipage, ipagesize, out totalRow); // lấy danh sách sản phẩm
            rptProducts.DataSource = products;
            rptProducts.DataBind();

        }
    }
}