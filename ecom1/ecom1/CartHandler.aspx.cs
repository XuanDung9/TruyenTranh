using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecom1
{
    public partial class CartHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Đảm bảo chỉ xử lý khi có query string hoặc POST
            if (Request["action"] == "getCart")
            {
                var currentUser = (User)Session["UserInfo"];
                CartRepository cartRepo = new CartRepository();
                var cart = cartRepo.GetCartByUserId(currentUser.MongoId);
                var cartItems = cart?.CartItems ?? new List<CartItems>();

                // Chuyển dữ liệu sang JSON và trả về
                var json = new JavaScriptSerializer().Serialize(cartItems);
                Response.ContentType = "application/json";
                Response.Write(json);
                Response.End();
            }
        }
    }
}