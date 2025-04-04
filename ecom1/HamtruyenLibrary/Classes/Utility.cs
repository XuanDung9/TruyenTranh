using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HamtruyenLibrary.Classes
{
    public class Utility
    {
        public static void showSuccessStatus(HtmlGenericControl div_error, HtmlGenericControl h4Status, HtmlGenericControl pDescription, string sStatus, string sDescription)
        {
            div_error.Visible = true;
            div_error.Attributes["class"] = "alert alert-block alert-success fade in";
            h4Status.InnerText = sStatus;
            pDescription.InnerText = sDescription;
        }

        /// <summary>
        /// Convert datetime dạng dd/MM/yyyy thành yyyy/MM/dd hh:mm:ss để insert vào db
        /// </summary>
        /// <param name="sDateTime"></param>
        /// <returns></returns>
        public static string ConvertDateTime(string sDateTime)
        {
            string[] sTemp = sDateTime.Split('/');
            if (sTemp.Length != 3) return DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            else
            {
                return sTemp[2] + "/" + sTemp[1] + "/" + sTemp[0] + " 10:00:00";
            }
        }
        public static bool checkExtensionFileImage(string sFileName)
        {
            string FileExtension = sFileName.Substring(sFileName.LastIndexOf('.') + 1).ToLower();
            bool sreturn = false;
            if (FileExtension == "jpeg" || FileExtension == "png" || FileExtension == "jpg")
            {
                sreturn = true;
            }
            return sreturn;
        }

        public static string StripHTML(string source)
        {


            // Removes tags from passed HTML            
            System.Text.RegularExpressions.Regex objRegEx = new System.Text.RegularExpressions.Regex("<[^>]*>");

            return objRegEx.Replace(source, "");

        }
        public static string getSubString(string sInput, int iLength)
        {

            if (sInput.Length <= iLength) return sInput;
            else
            {

                return sInput.Substring(0, iLength) + "...";
            }
        }

        public static string getUrlFolderLarge()
        {
            return ConfigurationManager.AppSettings["UrlLarge"];
        }
        public static string getUrlFolderUser()
        {
            return ConfigurationManager.AppSettings["UrlUser"];
        }

        public static string getUrlFolderSmall()
        {
            return ConfigurationManager.AppSettings["UrlSmall"];
        }
        public static string getUrlFolderCustom(string sKey)
        {
            return ConfigurationManager.AppSettings[sKey];
        }
        public static void showErrorStatus(HtmlGenericControl div_error, HtmlGenericControl h4Status, HtmlGenericControl pDescription, string sStatus, string sDescription)
        {
            div_error.Visible = true;
            div_error.Attributes["class"] = "alert alert-block alert-warning fade in";
            h4Status.InnerText = sStatus;
            pDescription.InnerText = sDescription;
        }


        public static string getPath(string sPath)
        {
            sPath = RemoveMark(sPath.ToLower());

            sPath = sPath.Replace("'", "").Replace("\"", "").Replace("/", "-").Replace("%", "_").Replace(":", "").Replace(",", "").Replace("?", "").Replace(".", "-").Replace("&", "-");
            return sPath.Replace(" ", "-").Replace("#","").Replace("~","");
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || c == '-')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string RemoveMark(string text)
        {

            string[] pattern = new string[7];

            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";

            pattern[1] = "o|(ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ)";

            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";

            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";

            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";

            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";

            pattern[6] = "d|đ";



            for (int i = 0; i < pattern.Length; i++)
            {

                // kí tự sẽ thay thế

                char replaceChar = pattern[i][0];

                MatchCollection matchs = Regex.Matches(text, pattern[i]);

                foreach (Match m in matchs)
                {

                    text = text.Replace(m.Value[0], replaceChar);

                }

            }

            return text;

        }
        public static string checkAndReName(string sFullPath)
        {
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(sFullPath);
            string extension = Path.GetExtension(sFullPath);
            string path = Path.GetDirectoryName(sFullPath);
            string newFullPath = sFullPath;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}_{1}", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }
            return newFullPath;
        }



        public static string getPhysicalPath()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
        }

        public static void CreateCombo<T>(IEnumerable<T> lstQuery, string sText, string sValue, DropDownList ddl){
            
            ddl.DataTextField = sText;
            ddl.DataValueField = sValue;
            ddl.DataSource = lstQuery;
            ddl.DataBind();
        }

        public static string RandomText(int iNumText)
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < iNumText; i++)
            {
                int iTemp = random.Next(2);
                switch (iTemp)
                {
                    case 0:
                        {
                            s += random.Next(0, 9).ToString();
                            break;
                        }
                    case 1:
                        {
                            s += Convert.ToChar(random.Next('a', 'z')).ToString();
                            break;
                        }
                    default:
                        {
                            s += Convert.ToChar(random.Next('A', 'Z')).ToString().ToUpper();
                            break;
                        }
                }
            }
            return s;
        }
       
    }
}
