using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HamtruyenLibrary.Classes;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
namespace HamtruyenAdmin
{
    /// <summary>
    /// Summary description for UploadAvatar
    /// </summary>
    public class UploadAvatar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           
        }
        public string getExtension(string sFileName)
        {
            string[] s = sFileName.Split('.');
            return s[s.Length - 1];
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