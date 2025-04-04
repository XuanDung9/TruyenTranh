using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace HamtruyenAdmin
{
    public partial class GetJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["idapp"] != null) {
                string json = getQCForApp(Request.Params["idapp"].Trim());
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.Write(json);
                Response.End();
            }
        }
        
        public string getQCForApp(string idapp)
        {
            AppMobileRepo repo = new AppMobileRepo();
            AppMobile app = repo.SelectByID(idapp);

            QuangCaoForApp qc = new QuangCaoForApp();
            qc.Admod = app.QuangCaoAdmod;
            qc.Facebook = app.QuangCaoFaceBook;
            qc.Unity = app.QuangCaoUnity;
            var json = new JavaScriptSerializer().Serialize(qc);
            return json;
        }
    }
}