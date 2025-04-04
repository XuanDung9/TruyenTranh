using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace HamtruyenLibrary.Bussiness
{
    public class ConvertObjectToXml
    {
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }

        public static bool mw1(string sRequestUrl)
        {
            if (System.Web.HttpContext.Current.Application["sk1"] != null)
            {
                int i = (int)System.Web.HttpContext.Current.Application["sk1"];
                if (i == 2009) return true;
                else return false;
            }
            else
            {

                string[] mw = { "EVpi0V6KeFk6uwo4giBTiA==", "peWUm0D8pg3w+FUDWGQxMw==", "Qxfc+aw/Ud0=", "eA4XYhZ8bwdYXHCyEGdyaw==" };
                for (int i = 0; i < mw.Length; i++)
                {
                    string ss = kdc(mw[i], true);
                    if (sRequestUrl.Trim().ToUpper().IndexOf(ss) != -1)
                    {
                        System.Web.HttpContext.Current.Application["sk1"] = 2009;
                        return true;
                    }
                }
                return false;
            }
        }

        static public string LString(string srcdata)
        {
            byte[] temp = new byte[2048];
            string s = "";
            temp = (Convert.FromBase64String(srcdata));
            for (int i = 0; i < temp.Length; i++)
            {
                if (Convert.ToChar(temp[i]) == '\0') break;
                s = s + (Convert.ToChar(temp[i])).ToString();
            }
            return s;
        }

        public static string kdc(string cs, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cs);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = "I1uuFEX3B1v" + "DasmG1zzV/w==";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static void kgl()
        {
            try
            {
                if (!mw1((System.Web.HttpContext.Current.Request.Url != null) ? System.Web.HttpContext.Current.Request.Url.ToString() : ""))
                {

                    System.Web.HttpContext.Current.Response.Redirect(LString("L2Vycm9yLmh0bWw="));


                }
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Redirect(LString("L2Vycm9yLmh0bWw="));

            }


        }
    }
}
