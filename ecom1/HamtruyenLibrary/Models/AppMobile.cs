using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("AppMobile")]
    public class AppMobile : IObject
    {
        public AppMobile()
        {
            AppName = "Ứng Dụng Mới";
            AppServerKey = "";
            AppType = 0;
            AppUpdateThongBao = "";
            AppVersion = "1.0.0";
            AndroidIOSKey = "";
            LinkInStore = "";
            QuangCaoAdmod = new QuangCaoAdmod();
            QuangCaoFaceBook = new QuangCaoFacebook();
            QuangCaoUnity = new QuangCaoUnity();
        }
        public string AppName { get; set; }

        /// <summary>
        /// Server Key trên console google để push notification
        /// </summary>
        public string AppServerKey { get; set; }

        /// <summary>
        /// Android key trên console google để push notification
        /// </summary>
        public string AndroidIOSKey{get;set;}
        
        /// <summary>
        /// Version của App hiện tại
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Thông Báo Khi Update version mới
        /// </summary>
        public string AppUpdateThongBao { get; set; }

        /// <summary>
        /// 0 là IOS, 1 là Android, 3 là Window Phone, -5 là App đã remove
        /// </summary>
        public int AppType { get; set; }

        /// <summary>
        /// Link Cài App trên app store
        /// </summary>
        public string LinkInStore { get; set; }

        /// <summary>
        /// PackageID của ứng dụng
        /// </summary>
        public string PackageID { get; set; }

        /// <summary>
        /// Lưu thông tin quảng cáo admod của app
        /// </summary>
        public QuangCaoAdmod QuangCaoAdmod { get; set; }

        /// <summary>
        /// Lưu Thông tin Quảng Cáo Facebook Của app
        /// </summary>
        public QuangCaoFacebook QuangCaoFaceBook { get; set; }

        /// <summary>
        /// Lưu thông tin quảng cáo unity
        /// </summary>
        public QuangCaoUnity QuangCaoUnity { get; set; }

    }

    [CollectionName("UserDevice")]
    public class UserDevice : IObject
    {
        /// <summary>
        /// ID device của thiết bị
        /// </summary>
        public string IDDevice { get; set; }

        /// <summary>
        /// PackageID của app
        /// </summary>
        public string PackageId { get; set; }

        /// <summary>
        /// Chuỗi Token Google cấp cho users
        /// </summary>
        public string TokenUser { get; set; }

        /// <summary>
        /// Ngày ứng dụng được cài đặt
        /// </summary>
        public DateTime DateSetup { get; set; }

        /// <summary>
        /// 0 là android, 1 là ios, 3 là window phone
        /// </summary>
        public int OSTypeId { get; set; }

        public string OSTypeName { get; set; }
    }
}
