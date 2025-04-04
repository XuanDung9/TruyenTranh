using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;

namespace HamtruyenAdmin
{
    /// <summary>
    /// Summary description for ServiceInfo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Script.Services.ScriptService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceInfo : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public InfoVersionApp GetInfoApp(string idApp)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile app = repo.SelectByID(idApp);

            InfoVersionApp info = new InfoVersionApp(app.AppVersion,app.LinkInStore,app.AppUpdateThongBao);
            return info;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public QuangCaoForApp GetQuangCaoForApp(string idApp)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile app = repo.SelectByID(idApp);

            QuangCaoForApp qc = new QuangCaoForApp();
            qc.Admod = app.QuangCaoAdmod;
            qc.Facebook = app.QuangCaoFaceBook;
            qc.Unity = app.QuangCaoUnity;
            return qc;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public bool AddTokenInfo(string sDeviceID, string sPackageId, string sTokenUser, int OsTypeID)
        {

            UserDeviceRepo repo = new UserDeviceRepo();

            string OsTypeName = "Android";
            switch (OsTypeID)
            {
                case 0:
                    OsTypeName = "Android";
                    break;
                case 1:
                    OsTypeName = "IOS";
                    break;
                case 2:
                    OsTypeName = "Window Phone";
                    break;
                default:
                    OsTypeName = "Android";
                    break;
            }

            UserDevice device = repo.FindByAppAndToken(sPackageId, sTokenUser);
            if (device == null)
            {
                device = new UserDevice();
                device.DateSetup = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                device.IDDevice = sDeviceID;
                device.PackageId = sPackageId;
                device.TokenUser = sTokenUser; device.OSTypeId = OsTypeID;
                device.OSTypeName = OsTypeName;

                repo.Save(device);
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
