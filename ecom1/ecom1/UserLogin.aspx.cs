using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecom1
{
    public partial class UserLogin : System.Web.UI.Page
    {
        public User user
        {
            get
            {
                if(Session["UserInfo"]==null)
                {
                    Session["UserInfo"] = new User();
                }    
                return(User)Session["UserInfo"];
            }
            set
            {
                Session["UserInfo"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();
            User newUser = new User
            {
                FirstName=txtFullName.Text,
                Email= txtEmail.Text,
                Password=txtPassword.Text
            };
            userRepo.Create(newUser);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();
            string email = txtInputEmail.Text;
            string password = txtInputPassword.Text;
            bool result = userRepo.Login(email, password);
            {
                if(result)
                {
                    user = userRepo.GetUserByEmail(email);
                    Response.Redirect("Product.aspx");
                }    
                else
                {
                    throw new Exception("Đăng nhập không hợp lệ");
                }    
            }
        }
    }
}