using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class InfoVersionApp
    {
        public InfoVersionApp() { }
        public InfoVersionApp(string ver, string linkUpdate, string note)
        {
            Version = ver;
            LinkUpdate = linkUpdate;
            Note = note;
        }
        public string Version { get; set; }
        public string LinkUpdate { get; set; }
        public string Note { get; set; }
    }
    public class QuangCaoFacebook
    {
        public QuangCaoFacebook()
        {
            Display = false;
            FBNativeId = "";
            FBFull = "";
            FBBanner = "";
        }
        public string FBNativeId { get; set; }
        public string FBFull { get; set; }
        public string FBBanner { get; set; }
        public bool Display { get; set; }

    }
    public class QuangCaoAdmod
    {
        public QuangCaoAdmod()
        {
            AccountId = "";
            Display = false;
            FullID = "";
            BannerId = "";
        }
        public string AccountId { get; set; }
        public string BannerId { get; set; }
        public string FullID { get; set; }
        public bool Display { get; set; }
    }
    public class QuangCaoUnity
    {
        public QuangCaoUnity()
        {
            IDUnity = "";
            Display = false;
        }
        public string IDUnity { get; set; }
        public bool Display { get; set; }
    }

    public class QuangCaoForApp
    {
        public QuangCaoAdmod Admod { get; set; }
        public QuangCaoFacebook Facebook { get; set; }
        public QuangCaoUnity Unity { get; set; }
    }
}
