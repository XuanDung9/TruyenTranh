using HamtruyenLibrary.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HamtruyenAdmin
{
    /// <summary>
    /// Summary description for UploadAnh
    /// </summary>
    public class UploadAnh : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = context.Request.Files["Filedata"]; 
                if (context.Request["Type"].Trim() == "ChapVip")
                {
                    // string sPicasaAlbumID = context.Request["Chap_A_ID"].Trim();
                    // string savepath = "";
                    // //string tempPath = "";
                    // // string sAlbumID = "";
                    // Directory.CreateDirectory(Utility.getPhysicalPath() + "/Pictures/Chapters/" + sPicasaAlbumID);
                    // savepath = Utility.getPhysicalPath() + "/Pictures/Chapters/" + sPicasaAlbumID;
                    // string filename = postedFile.FileName;

                    // if (!Directory.Exists(savepath))
                    //     Directory.CreateDirectory(savepath);
                    // postedFile.SaveAs(savepath + @"\" + filename);

                    // var saveImgPath = "/Pictures/Chapters/" + sPicasaAlbumID + "/" + filename;

                    // //context.Response.Write(tempPath + "/" + filename);
                    // context.Response.StatusCode = 200;
                    // clsChapters.ImageChapVipAddUpdate("-1", saveImgPath, sPicasaAlbumID);
                    // context.Response.Write("http://localhost:51396" + saveImgPath);

                }
                else
                {
                    //  string sAlbumID = context.Request["ChapID"].Trim();
                    string sPicasaAlbumID = context.Request["Chap_A_ID"].Trim();
                    string savepath = "";
                    //string tempPath = "";
                    // string sAlbumID = "";
                    //string sAlbumID = context.Request["AlbumID"];
                    savepath = Utility.getPhysicalPath() + "/Upload/Temp";
                    string filename = postedFile.FileName;

                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    postedFile.SaveAs(savepath + @"\" + filename);

                    var saveImgPath = savepath + @"\" + filename;

                    //context.Response.Write(tempPath + "/" + filename);
                    context.Response.StatusCode = 200;
                    //  clsChapters objChap = new clsChapters();

                    //string sPicasaAlbumID = "5935293856724395969";

                    UploadPicasa objPicasa = new UploadPicasa();
                    string sUrlImage = objPicasa.UploadPicture(sPicasaAlbumID, saveImgPath);

                    // objChap.ImagesAddUpdate("-1", "Upload bởi Truyenhay24h.com", sUrlImage, sAlbumID);
                    //clsFiles.fileWriteAll(clsConfig.getPhysicalPath() + "test.txt", saveImgPath);
                    File.Delete(saveImgPath);
                    context.Response.Write(sUrlImage);
                }


            }
            catch (Exception ex)
            {
                //FileUtilty.fileWrite(Utility.getPhysicalPath() + "test.txt", ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}