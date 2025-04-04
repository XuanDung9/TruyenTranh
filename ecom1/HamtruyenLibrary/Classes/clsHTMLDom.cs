using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace HamtruyenLibrary.Classes
{
    public class clsHTMLDom
    {

        public string getContent(string sUrl)
        {
            WebClient wClient = new WebClient();
            //get data as a stream
            
            wClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36");

            Stream data = wClient.OpenRead(new Uri(sUrl));

            //getText
            StreamReader reader = new StreamReader(data);
            string sContent = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return sContent;
        }

        public string getContentWeb(string sUrl)
        {
            string sContent = "";
            //create webclient object
            try
            {
                WebClient wClient = new WebClient();
                //get data as a stream
                wClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");

                wClient.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                wClient.Headers.Add("Accept-Language", "vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
                wClient.Headers.Add("Cache-Control", "max-age=0");
                wClient.Headers.Add("Cookie", "__cfduid=de0f2a39edd68c50df1965f0fca7f84a21434181003; __unam=7639673-14dfce020f2-7eda366e-442; cf_clearance=78cf5a8be9e36ada8d32ee1d77efb1bdea5e9c55-1448022551-86400; ASP.NET_SessionId=ldbazodxgzgbseesbtuoudgp; idtz=117.5.192.104-431958458; __utmt=1; __utma=189678129.1714595411.1434466642.1448018775.1448022549.169; __utmb=189678129.1.10.1448022549; __utmc=189678129; __utmz=189678129.1442396241.123.8.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not%20provided)");
                wClient.Headers.Add("Host", "kissmanga.com");
                wClient.Headers.Add("Upgrade-Insecure-Requests", "1");
                wClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
               
                Stream data = wClient.OpenRead(new Uri(sUrl));
                //getText
                StreamReader reader = new StreamReader(data);
                sContent = reader.ReadToEnd();
                data.Close();
                reader.Close();
            }
            catch (WebException exception)
            {

               
            }
            return sContent;
        }
        public string GetPageHtml(string link, System.Net.WebProxy proxy = null)
        {
            System.Net.WebClient client = new System.Net.WebClient() { Encoding = Encoding.UTF8 };
            client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36");
            var newUri = new Uri("http://blogtruyen.com/");
            var myProxy = new WebProxy();
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            myProxy.Address = newUri;

            client.Proxy = myProxy;
            
            string sContent = "";
            using (client)
            {
                try
                {
                    Stream data = client.OpenRead(new Uri(link));
                    //getText
                    StreamReader reader = new StreamReader(data);
                    sContent = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                    return sContent;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }
        public string getContentHtml2(string sUrl)
        {
            WebRequest req = HttpWebRequest.Create(sUrl);
            req.Headers.Add("referer", "http://stackoverflow.com");
            req.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            req.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            req.Method = "GET";

            string source;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }
            return source;
        }
        public string getContentWeb2(string sUrl)
        {
            string sHtml = "";
            using (WebClient client = new WebClient())
            {
                sHtml = client.DownloadString(sUrl);
            }
            return sHtml;
        }
        private WebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.UserAgent = @".NET Framework Test Client";
            return request;
        }
        //public HtmlAgilityPack.HtmlDocument LoadDocument(string url)
        //{
        //    var document = new HtmlAgilityPack.HtmlDocument();

        //    try
        //    {
        //        using (var responseStream = CreateRequest(url).GetResponse().GetResponseStream())
        //        {
        //            document.Load(responseStream, Encoding.UTF8);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //just do 2 second try
        //        clsFiles.fileWrite(clsConfig.getPhysicalPath() + "test.txt", "Loi lan 1:" + ex.Message + ":" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        //        System.Threading.Thread.Sleep(8000);
        //        try
        //        {

        //            using (var responseStream = CreateRequest(url).GetResponse().GetResponseStream())
        //            {
        //                document.Load(responseStream, Encoding.UTF8);
        //            }
        //        }
        //        catch (Exception ex1)
        //        {
        //            clsFiles.fileWrite(clsConfig.getPhysicalPath() + "test.txt", "Loi lan 2:" + ex1.Message + ":" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        //            System.Threading.Thread.Sleep(10000);
        //            try
        //            {
        //                using (var responseStream = CreateRequest(url).GetResponse().GetResponseStream())
        //                {
        //                    document.Load(responseStream, Encoding.UTF8);
        //                }
        //            }
        //            catch (Exception ex2)
        //            {
        //                clsFiles.fileWrite(clsConfig.getPhysicalPath() + "test.txt", "Loi lan 3:" + ex2.Message + ":" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        //            }

        //        }
        //    }

        //    return document;
        //}
    }
}
