using HamtruyenLibrary.Repo;
using HamtruyenLibrary.Models;
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
        public List<CartItems> lst_CartItem
        {
            get
            {
                if (Session["CartItemList"] == null)
                {
                    Session["CartItemList"] = new List<CartItems>();
                }
                return (List<CartItems>)Session["CartItemList"];
            }
            set
            {
                Session["CartItemList"] = value;
            }
        }
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

        protected void rptOptions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int index = e.Item.ItemIndex;

                Button btn = (Button)e.Item.FindControl("btnOption");
                if (btn != null)
                {
                    btn.CommandArgument = index.ToString();
                }
            }
        }

        protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CartRepository cartRepo = new CartRepository();
            if (e.CommandName == "SelectOption")
            {
                int optionIndex = Convert.ToInt32(e.CommandArgument);
                RepeaterItem optionItem = e.Item;
                Repeater rptOptionsInstance = (Repeater)optionItem.NamingContainer;
                RepeaterItem productItem = (RepeaterItem)rptOptionsInstance.NamingContainer; 
                HiddenField hfProductId = (HiddenField)productItem.FindControl("hfProductId");

                if (hfProductId != null)
                {
                    string productIdString = hfProductId.Value;

                    SanPhamRepo spRepo = new SanPhamRepo();
                    var selectedProduct = spRepo.GetById(productIdString);
                    if (selectedProduct != null && selectedProduct.Options.Count > optionIndex)
                    {
                        var selectedOption = selectedProduct.Options[optionIndex];
                        
                        cartRepo.AddProductToCart(null, productIdString, optionIndex);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi: Không tìm thấy HiddenField hfProductId.");
                }
            }
        }


    }
}