using HamtruyenLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HamtruyenAdmin
{
    public partial class wucConfigXml : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XmlDocument objXMLdoc = new XmlDocument();


                // Load file Lang.XML
                objXMLdoc.Load(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "/Config/hethong.xml");

                XmlElement root = objXMLdoc.DocumentElement;
                XmlNode oldNode;

                //Picasa...
                oldNode = root.SelectSingleNode("/document/Page[@Name='Picasa']/userGmail");
                txtUserNamePicasa.Text = oldNode.InnerText;
                oldNode = root.SelectSingleNode("/document/Page[@Name='Picasa']/userPass");
                txtPasswordPicasa.Text = oldNode.InnerText;

            }
        }

        protected void btnThemChuong_Click(object sender, EventArgs e)
        {
            XmlDocument objXMLdoc = new XmlDocument();
            objXMLdoc.Load(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "Config/hethong.xml");
            XmlElement root = objXMLdoc.DocumentElement;
            XmlNode oldNode;
            try
            {
                oldNode = root.SelectSingleNode("/document/Page[@Name='Picasa']/userGmail");

                oldNode.InnerText = txtUserNamePicasa.Text.Trim();
                //clsConfig.SetValue("TintucNumrecordmax", iMaxbaiviet.ToString());
                oldNode = root.SelectSingleNode("/document/Page[@Name='Picasa']/userPass");

                oldNode.InnerText = txtPasswordPicasa.Text.Trim();
                objXMLdoc.Save(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "Config/hethong.xml");
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành công!", "Cập nhật thông tin picasa thành công!");

            }
            catch
            {
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Có Lỗi!", "Cập nhật thông tin picasa thất bại!");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FileUtilty.fileWriteAll(Utility.getPhysicalPath() + "/templates/tmp_cookie.vdc",txtCookie.Text);
        }
    }
}