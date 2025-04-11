using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class wucColor : System.Web.UI.UserControl
    {
        public string PID
        {
            get
            {
                if (null == ViewState["ColorID"])
                    return string.Empty;
                else
                    return (string)ViewState["ColorID"];
            }
            set { ViewState["ColorID"] = value; }
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
            ColorRepo colorRepo = new ColorRepo();
            var lstColor = colorRepo.List();

            gvMauSac.DataSource = lstColor;
            gvMauSac.DataBind();
        }

        public void ShowList()
        {
            lst_MauSac.Visible = true;
            edit_Color.Visible = false;
            bindData();

        }
        public void ShowEdit()
        {
            lst_MauSac.Visible = false;
            edit_Color.Visible = true;
        }
        public void showDetailItem(string sID)
        {
            ColorRepo repo = new ColorRepo();
            Color color = repo.SelectByID(sID);
            if (color != null)
            {
                txtColorName.Text = color.Name_Color;
                txtColorHex.Text = color.Hex_Code_Color;
                if (!string.IsNullOrEmpty(color.Img_Color))
                {
                    imgHinhAnh.ImageUrl = color.Img_Color;
                }

            }
            ShowEdit();
        }
        protected void btn_Save(object sender, EventArgs e)
        {
            string imgPath = "";
            if (fuHinhAnh.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(fuHinhAnh.FileName);
                    string folderPath = Server.MapPath("~/img/");

                    string savePath = Path.Combine(folderPath, fileName);
                    fuHinhAnh.SaveAs(savePath);

                    imgPath = "~/img/" + fileName;

                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.Message);
                    return;
                }
            }



            ColorRepo repo = new ColorRepo();
            var itemUpdate = repo.SelectByID(PID);
            if (!string.IsNullOrEmpty(imgPath))
            {
                itemUpdate.Img_Color = imgPath;
            }
            itemUpdate.Name_Color = txtColorName.Text;

            itemUpdate.Hex_Code_Color = txtColorHex.Text;
            repo.Save(itemUpdate);
            ShowList();

        }

        protected void btn_Them(object sender, EventArgs e)
        {
            ColorRepo repo = new ColorRepo();
            Color color = new Color
            {
                Name_Color = "New color",
                Hex_Code_Color = "New Hex",
                Img_Color = "new img",
            };
            repo.Save(color);
            bindData();
        }
        protected void gvMauSac_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ColorRepo repo = new ColorRepo();
            PID = e.CommandArgument.ToString();
            if (e.CommandName.ToLower() == "sua")
            {
                ShowEdit();
                showDetailItem(PID);
            }
            else if (e.CommandName.ToLower() == "xoa")
            {
                repo.Remove(PID.ToString());
                bindData();
            }

        }
        protected void btn_Cancel(object sender, EventArgs e)
        {
            ShowList();
        }
    }
}