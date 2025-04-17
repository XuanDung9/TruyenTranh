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
    public partial class wucBaiViet : System.Web.UI.UserControl
    {
        public string PID
        {
            get
            {
                if (null == ViewState["PostID"])
                    return string.Empty;
                else
                    return (string)ViewState["PostID"];
            }
            set { ViewState["PostID"] = value; }
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
            PostRepo repo = new PostRepo();
            var lstPost = repo.GetAllPost();
            gvListPost.DataSource = lstPost;
            gvListPost.DataBind();
        }
        public void ShowList()
        {
            list_post.Visible = true;
            edit_post.Visible = false;
        }
        public void ShowEdit()
        {
            list_post.Visible = false;
            edit_post.Visible = true;
        }
        public void ShowDetailItem(string idPost)
        {
            PostRepo repo = new PostRepo();
            Post post = repo.GetById(idPost);
            if (post != null)
            {
                txtTieuDe.Text = post.TieuDe;
                txtNoiDung.InnerText = post.NoiDung;
                if (post.TrangThai == true)
                {
                    cbView.Checked = true;
                }
            }
            ShowEdit();
        }
        public void btnAddPost_Click(object sender, EventArgs e)
        {
            PostRepo repo = new PostRepo();
            Post post = new Post
            {
                NgayDang = DateTime.Now
            };
            repo.Save(post);
            BindData();
        }
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            PostRepo repo = new PostRepo();
            Post post = repo.GetById(PID);
            post.TieuDe = txtTieuDe.Text;
            post.NoiDung = txtNoiDung.InnerText;
            post.TrangThai = cbView.Checked;

            repo.UpdatePost(post, PID);
            ShowList();
            BindData();
        }
        protected void gvListPost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PostRepo repo = new PostRepo();
            if(e.CommandName.ToLower()=="sua")
            {
                ShowEdit();
                PID = e.CommandArgument.ToString();
                ShowDetailItem(PID);
            }    
            else if ( e.CommandName.ToLower()=="xoa")
            {
                PID = e.CommandArgument.ToString();
                repo.Delete(PID);
                ShowList();
            }
            BindData();
        }
        public void btnCancel_Click(object sender, EventArgs e)
        {
            ShowList();
        }
    }
}