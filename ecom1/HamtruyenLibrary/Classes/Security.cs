using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HamtruyenLibrary.Classes
{
    public class Security
    {

        static string sKey = "a178fcc4e88bc61f38583032c36df9dd"; //vdc173@gmail.com-hamtruyen.com-beblue;  

        //static string sKeyNotify = "apphamtruyenandroid.beblue.com";

        public static string GetEnCrypt(string stoEncrypt)
        {

            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(stoEncrypt);


            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey));
            hashmd5.Clear();


            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        public static string GetDeCrypt(string cipherString)
        {

            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);


            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey));
            hashmd5.Clear();


            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                try
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    tdes.Clear();
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch (Exception ex)
                {
                    return "error" + ex.Message;
                }
            }

        
        }
    }
}
