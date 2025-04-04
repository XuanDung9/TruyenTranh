using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using HamtruyenLibrary.Bussiness;
using HamtruyenLibrary.Classes;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using Newtonsoft.Json.Linq;

namespace HamtruyenAdmin
{
    public partial class wucManagerApp : System.Web.UI.UserControl
    {
        public string AMID
        {
            get
            {
                if (null == ViewState["AMID"])
                    return string.Empty;
                else
                    return (string)ViewState["AMID"];
            }
            set { ViewState["AMID"] = value; }
        }
        int iPage = 1; int iPageSize = 30;
        string sMenu = "";
        public string GetAppType(string sType)
        {
            string sreturn = "Android";
            switch (sType)
            {
                case "0":
                    sreturn = "IOS";
                    break;
                case "1":
                    sreturn = "Android";
                    break;
                case "3":
                    sreturn = "Window Phone";
                    break;
                default:
                    sreturn = "Android";
                    break;
            }
            return sreturn;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["P"] != null)
            {
                iPage = int.Parse(Request.Params["P"]);
            }
            if(!IsPostBack){
                BindData(iPage);
                ShowList();
            }
        }

        #region UserFunction

        public void checkQuyen()
        {
            int mod = int.Parse(Request.Params["mod"]);
            ContentManager currentAd = (ContentManager)Session["admin"];
            if (currentAd.UserName != "webadmin")
            {
                Privilege role = AdministratorBusiness.checkQuyen(currentAd, mod);
                if (role.Mod != "-1")
                {
                    if (role.Add == false)
                    {
                        btnThemTruyen.Visible = false;
                    }
                    if (role.Edit == false)
                    {
                        foreach (RepeaterItem item in rptListContent.Items)
                        {
                            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                            {
                                LinkButton lbtnEdit = (LinkButton)item.FindControl("LinkButton1");
                                lbtnEdit.Visible = false;
                            }
                        }

                    }

                    if (role.Delete == false)
                    {
                        foreach (RepeaterItem item in rptListContent.Items)
                        {
                            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                            {
                                LinkButton lbtnDelete = (LinkButton)item.FindControl("LinkButton3");
                                lbtnDelete.Visible = false;
                                LinkButton lbtnpush = (LinkButton)item.FindControl("LinkButton2");
                                lbtnpush.Visible = false;
                            }
                        }
                        btnPushNotifyAllApp.Visible = false;

                    }
                }
                else
                {
                    Response.Redirect("/Admin.aspx?mod=99");
                }
            }

        }

        public void ShowList()
        {
            list_tintuc.Visible = true;
            edit_tintuc.Visible = false;
            div_gui_notification.Visible = false;
            div_admod_ads.Visible = false;
            div_facebook_ads.Visible = false;
            div_unity_ads.Visible = false;
        }
        public void ShowEdit()
        {
            list_tintuc.Visible = false;
            edit_tintuc.Visible = true;
            div_gui_notification.Visible = false;
            div_admod_ads.Visible = false;
            div_facebook_ads.Visible = false;
            div_unity_ads.Visible = false;
        }
        public void ShowEditNotify()
        {
            list_tintuc.Visible = false;
            edit_tintuc.Visible = false;
            div_gui_notification.Visible = true;
            div_admod_ads.Visible = false;
            div_facebook_ads.Visible = false;
            div_unity_ads.Visible = false;
        }
        public void showEditFacebookAds()
        {
            list_tintuc.Visible = false;
            edit_tintuc.Visible = false;
            div_gui_notification.Visible = false;
            div_admod_ads.Visible = false;
            div_facebook_ads.Visible = true;
            div_unity_ads.Visible = false;
        }

        public void showEditUnityAds()
        {
            list_tintuc.Visible = false;
            edit_tintuc.Visible = false;
            div_gui_notification.Visible = false;
            div_admod_ads.Visible = false;
            div_facebook_ads.Visible = false;
            div_unity_ads.Visible = true;
        }
        public void showEditAdmodAds()
        {
            list_tintuc.Visible = false;
            edit_tintuc.Visible = false;
            div_gui_notification.Visible = false;
            div_admod_ads.Visible = true;
            div_facebook_ads.Visible = false;
            div_unity_ads.Visible = false;
        }   

        public void BindData(int iPage){
            long totalRow=0;

            AppMobileRepo repo = new AppMobileRepo();
            var lst = repo.List(iPage,iPageSize, out totalRow);
            
            rptListContent.DataSource= lst;
            rptListContent.DataBind();

             int iPageCount = (int)totalRow / iPageSize;
            if (((int)totalRow % iPageSize) > 0)
            {
                iPageCount++;
            }
            checkQuyen();
            ltrPager.Text = Pager.createPager(iPageCount, iPage - 1, "/Admin.aspx?mod=2");
        }


        public void ShowDetail(string sAppID)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile mobi = repo.SelectByID(sAppID);
            txtTenUngDung.Text = mobi.AppName;
            txtServerKey.Text = mobi.AppServerKey;
            txtAndroidKey.Text = mobi.AndroidIOSKey;
            txtAppUpdateThongBao.Text = mobi.AppUpdateThongBao;
            txtAppVersion.Text = mobi.AppVersion;
            txtLinkInStore.Text = mobi.LinkInStore;
            txtPackageId.Text = mobi.PackageID;

            ddlAppType.ClearSelection();
            ddlAppType.Items.FindByValue(mobi.AppType.ToString()).Selected = true;
            ShowEdit();
        }

        public void showDetailAdmod(string sAppID)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile mobi = repo.SelectByID(sAppID);
            txtAdmodAccountId.Text = mobi.QuangCaoAdmod.AccountId;
            txtAdmodBannerId.Text = mobi.QuangCaoAdmod.BannerId;
            txtAdmodFullId.Text = mobi.QuangCaoAdmod.FullID;
            string isDisplay =  mobi.QuangCaoAdmod.Display == true ? "1":"0";


            ddlAdmodDisplay.ClearSelection();
            ddlAdmodDisplay.Items.FindByValue(isDisplay).Selected = true;
        }

        public void showDetailFacebook(string appId)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile mobi = repo.SelectByID(appId);
            txtFacebookBanner.Text = mobi.QuangCaoFaceBook.FBBanner;
            txtFacebookFullId.Text = mobi.QuangCaoFaceBook.FBFull;
            txtFacebookNativeId.Text = mobi.QuangCaoFaceBook.FBNativeId;
            string isDisplay = mobi.QuangCaoFaceBook.Display == true ? "1" : "0";


            ddlFacebookDisplay.ClearSelection();
            ddlFacebookDisplay.Items.FindByValue(isDisplay).Selected = true;
        }

        public void showDetailUnity(string sAppID)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile mobi = repo.SelectByID(sAppID);
            txtUnityId.Text = mobi.QuangCaoUnity.IDUnity;
            string isDisplay = mobi.QuangCaoUnity.Display == true ? "1" : "0";


            ddlUnityDisplay.ClearSelection();
            ddlUnityDisplay.Items.FindByValue(isDisplay).Selected = true;
        }

        #endregion

        #region EventUI
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile mobi = new AppMobile();
            if (AMID != "-1")
            {
                mobi = repo.SelectByID(AMID);
            }

            mobi.AppType = int.Parse(ddlAppType.SelectedValue);
            mobi.AppName = txtTenUngDung.Text.Trim();
            mobi.AppServerKey = txtServerKey.Text.Trim();
            mobi.AndroidIOSKey = txtAndroidKey.Text.Trim();
            mobi.AppUpdateThongBao = txtAppUpdateThongBao.Text.Trim();
            mobi.AppVersion = txtAppVersion.Text.Trim();
            mobi.LinkInStore = txtLinkInStore.Text.Trim();
            mobi.PackageID = txtPackageId.Text.Trim();
           

            repo.Save(mobi);
            BindData(iPage);
            ShowList();
            Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Cập Nhật thông tin Ứng dụng " + mobi.AppName + " thành công!");
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowList();
        }

        public string SendMessage(string sMessage, string API_KEY)
        {
            //string API_KEY = "AIzaSyAOXtOcuh1R95HsVCpShAnBBYlqPbxsHt0";
            string sReturn = "";
            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", sMessage);
            jGcmData.Add("to", "/topics/global");
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + API_KEY);

                    Task.WaitAll(client.PostAsync(url,
                        new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
                            .ContinueWith(response =>
                            {
                                sReturn = string.Format("response : {0}", response.Result.Content.ReadAsStringAsync().Result) + "<br/>";

                            }));
                }
            }
            catch (Exception ex)
            {
                sReturn = string.Format("Unable to send GCM message:<br/>") + ex.StackTrace;

            }
            return sReturn; 
        }

        protected void rptListContent_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            AMID = e.CommandArgument.ToString();
            if (e.CommandName == "Sua")
            {
                ShowDetail(AMID);
            }
            else if (e.CommandName == "Xoa")
            {
                UserDeviceRepo uRepo = new UserDeviceRepo();
                AppMobileRepo repo = new AppMobileRepo();

                var lst_user = uRepo.FindByApp(AMID);
                if (lst_user == null)
                {
                   repo.Remove(AMID);
                }
                else
                {
                    repo.RemoveSafe(AMID);
                }
                BindData(iPage);
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Xóa Ứng dụng thành công!");
            }
            else if (e.CommandName == "Notify")
            {
                AppMobileRepo repo = new AppMobileRepo();

                AppMobile mobi = repo.SelectByID(AMID);
                lblAppName.InnerHtml = mobi.AppName;
                ShowEditNotify();
            }
            else if (e.CommandName == "facebook_ads")
            {
                showDetailFacebook(AMID);
                showEditFacebookAds();
            }
            else if (e.CommandName == "admod_ads")
            {
                showDetailAdmod(AMID);
                showEditAdmodAds();
            }
            else if (e.CommandName == "unity_ads")
            {
                showDetailUnity(AMID);
                showEditUnityAds();
            }
        }

        protected void btnThemTruyen_Click(object sender, EventArgs e)
        {
            AppMobile mobile = new AppMobile();

            AMID = "-1";
            AppMobileRepo repo = new AppMobileRepo();
            repo.Save(mobile);
            BindData(1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AppMobileRepo repo = new AppMobileRepo();
            var lst = repo.FindByName(txtSearch.Text.Trim());

            rptListContent.DataSource = lst;
            rptListContent.DataBind();
        }

        protected void btnPushNotifyAllApp_Click(object sender, EventArgs e)
        {
            AMID = "-1";
            lblAppName.InnerHtml = "Của Beblue Team";
            ShowEditNotify();
        }
        protected void btn_add_thongbao_Click(object sender, EventArgs e)
        {
            AppMobileRepo repo = new AppMobileRepo();

            NotificationGCM gcm = new NotificationGCM();
            gcm.Content = txtThongBaoThanhVien.Text.Trim();
            gcm.Link = txtLink_Update.Text.Trim(); gcm.Title = txtTitle.Text.Trim(); gcm.TypeAction = int.Parse(ddlType_gcm.SelectedValue);

            JavaScriptSerializer js = new JavaScriptSerializer();

            string sMessage = HttpUtility.UrlEncode(js.Serialize(gcm));
           
            if (AMID == "-1")
            {
                var lstUser = repo.List();
                string sReturn = "";
                foreach (AppMobile mobile in lstUser)
                {
                    sReturn+= SendMessage(sMessage, mobile.AppServerKey);
                }
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Gửi thông báo tới tất cả người dùng ứng dụng của Beblue Team thành công!" + sReturn);
            }
            else
            {
                AppMobile mobile = repo.SelectByID(AMID);
                string sReturn = SendMessage(sMessage, mobile.AppServerKey);
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Gửi thông báo tới người dùng ứng dụng " + mobile.AppName + " thành công!<br/>"+ sReturn);
            }
            ShowList();
        }

        protected void btn_huybo_Click(object sender, EventArgs e)
        {
            ShowList();
        }
        #endregion

        protected void updateFaceBookAds_Click(object sender, EventArgs e)
        {
            QuangCaoFacebook face = new QuangCaoFacebook();
            face.Display = ddlFacebookDisplay.SelectedValue == "1" ? true : false;
            face.FBBanner = txtFacebookBanner.Text.Trim();
            face.FBFull = txtFacebookFullId.Text.Trim();
            face.FBNativeId = txtFacebookNativeId.Text.Trim();
            try
            {
                AppMobileRepo repo = new AppMobileRepo();
                AppMobile app = repo.SelectByID(AMID);
                repo.UpdateQuangCaoFacebook(AMID, face);
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Cập nhật thông tin quảng cáo facebook cho ứng dụng "+app.AppName+" thành công!");
            }catch(Exception ex){
                Utility.showErrorStatus(div_error, text_status_error, text_mota_error, "Thất bại!", "Có lỗi trong quá trình cập nhật "+ex.Message);
            }
            ShowList();
        }

        protected void updateAdmodAd_Click(object sender, EventArgs e)
        {
            QuangCaoAdmod admod = new QuangCaoAdmod();
            admod.BannerId = txtAdmodBannerId.Text.Trim();
            admod.FullID = txtAdmodFullId.Text.Trim();
            admod.AccountId = txtAdmodAccountId.Text.Trim();
            admod.Display = ddlAdmodDisplay.SelectedValue == "1" ? true : false;
            
            try
            {
                AppMobileRepo repo = new AppMobileRepo();
                AppMobile app = repo.SelectByID(AMID);
                repo.UpdateQuangCaoAdmod(AMID, admod);
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Cập nhật thông tin quảng cáo Admod cho ứng dụng " + app.AppName + " thành công!");
            }
            catch (Exception ex)
            {
                Utility.showErrorStatus(div_error, text_status_error, text_mota_error, "Thất bại!", "Có lỗi trong quá trình cập nhật " + ex.Message);
            }
            ShowList();
        }

        protected void btn_Update_untiy_ads_Click(object sender, EventArgs e)
        {
            QuangCaoUnity unity = new QuangCaoUnity();
            unity.IDUnity = txtUnityId.Text.Trim();
            unity.Display = ddlUnityDisplay.SelectedValue == "1" ? true : false;

            try
            {
                AppMobileRepo repo = new AppMobileRepo();
                AppMobile app = repo.SelectByID(AMID);
                repo.UpdateQuangCaoUnity(AMID, unity);
                Utility.showSuccessStatus(div_error, text_status_error, text_mota_error, "Thành Công!", "Cập nhật thông tin quảng cáo Admod cho ứng dụng " + app.AppName + " thành công!");
            }
            catch (Exception ex)
            {
                Utility.showErrorStatus(div_error, text_status_error, text_mota_error, "Thất bại!", "Có lỗi trong quá trình cập nhật " + ex.Message);
            }
            ShowList();
        }

        

       
    }
}