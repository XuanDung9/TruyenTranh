using Google.GData.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Google.Picasa;

using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;

using Google.Apis.Services;



namespace HamtruyenLibrary.Classes
{
    public class UploadPicasa
    {
        string sUser = "";
        string sPass = "";
        public void setInfoUser()
        {
            if (sUser == "" || sPass == "")
            {
                XmlDocument objXMLdoc = new XmlDocument();


                // Load file Lang.XML
                objXMLdoc.Load(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "/Config/hethong.xml");

                XmlElement root = objXMLdoc.DocumentElement;
                XmlNode oldNode;
                oldNode = root.SelectSingleNode("/document/Page[@Name='Picasa']/userGmail");
                sUser = oldNode.InnerText;
                oldNode = root.SelectSingleNode("/document/Page[@Name='Picasa']/userPass");
                sPass = oldNode.InnerText;

            }
        }
        public string getImagesResize(string sUrl, string sImgSize)
        {
            string sUrlpart1 = sUrl.Substring(0, sUrl.LastIndexOf('/'));
            sUrlpart1 = sUrlpart1.Replace("4.bp.blogspot.com", "1.bp.blogspot.com")
                .Replace("lh1.googleusercontent.com", "3.bp.blogspot.com")
                .Replace("facebook.com", "bp.blogspot.com")
                .Replace("lh2.googleusercontent.com", "3.bp.blogspot.com")
                .Replace("lh3.googleusercontent.com", "3.bp.blogspot.com")
                .Replace("lh4.googleusercontent.com", "3.bp.blogspot.com")
                .Replace("lh5.googleusercontent.com", "3.bp.blogspot.com")
                .Replace("lh6.googleusercontent.com", "3.bp.blogspot.com").Replace("https", "http");
            string[] sarr1 = sUrl.Split('/');
            string sNewUrl = sUrlpart1 + "/" + sImgSize + "/" + sarr1[sarr1.Length - 1];

            return sNewUrl;
        }

      

        public string UploadPicture(string sAlbumID, string sFileUrl)
        {
            try
            {
                setInfoUser();



                PicasaService service = new PicasaService("exampleCo-exampleApp-1");
                service.setUserCredentials(sUser, sPass);

                

                Uri postUri = new Uri(PicasaQuery.CreatePicasaUri(sUser, sAlbumID));

                // string file = @"G:\Old Data\WebOfVDC\F\Truyen2\59\1\10.jpg";
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(sFileUrl);
                System.IO.FileStream fileStream = fileInfo.OpenRead();

                PicasaEntry entry = (PicasaEntry)service.Insert(postUri, fileStream, "image/jpeg", sFileUrl);
                fileStream.Close();

                return getImagesResize(entry.Media.Content.Url, "s0");
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public string CreateNewAlbum()
        {
            setInfoUser();
            //string sUser = "khotruyenhay24h2@gmail.com";
            PicasaService service = new PicasaService("exampleCo-exampleApp-1");
            service.setUserCredentials(sUser, sPass);

            AlbumEntry newEntry = new AlbumEntry();
            newEntry.Title.Text = "Album images";
            newEntry.Summary.Text = "This is an album";
            AlbumAccessor ac = new AlbumAccessor(newEntry);
            //set to "private" for a private album
            ac.Access = "public";

            Uri feedUri = new Uri(PicasaQuery.CreatePicasaUri(sUser));

            PicasaEntry createdAlbum = (PicasaEntry)service.Insert(feedUri, newEntry);
            //ltrList.Text = createdAlbum.Id.AbsoluteUri;
            string[] arrA = createdAlbum.Id.AbsoluteUri.Split('/');
            string albumid = arrA[arrA.Length - 1];
            return albumid;
        }
        public void UploadImages()
        {
            try
            {
                setInfoUser();
                //string sUser = "diendantruyenhay24h.com@gmail.com";
                PicasaService service = new PicasaService("exampleCo-exampleApp-1");
                service.setUserCredentials(sUser, sPass);

                //create new Album

                AlbumEntry newEntry = new AlbumEntry();
                newEntry.Title.Text = "Test Album";
                newEntry.Summary.Text = "This is an album";
                AlbumAccessor ac = new AlbumAccessor(newEntry);
                //set to "private" for a private album
                ac.Access = "public";

                Uri feedUri = new Uri(PicasaQuery.CreatePicasaUri(sUser));

                PicasaEntry createdAlbum = (PicasaEntry)service.Insert(feedUri, newEntry);
                //ltrList.Text = createdAlbum.Id.AbsoluteUri;
                string[] arrA = createdAlbum.Id.AbsoluteUri.Split('/');
                string albumid = arrA[arrA.Length - 1];
                //ltrList.Text = "<br/>" + createdAlbum.Id.AbsoluteUri;

                //add Pictures
                // string albumid = "5901880384623422433";
                Uri postUri = new Uri(PicasaQuery.CreatePicasaUri(sUser, albumid));

                string file = @"G:\Old Data\WebOfVDC\F\Truyen2\59\1\10.jpg";
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                System.IO.FileStream fileStream = fileInfo.OpenRead();

                PicasaEntry entry = (PicasaEntry)service.Insert(postUri, fileStream, "image/jpeg", file);
                fileStream.Close();

                //get all photo of album

                PhotoQuery query = new PhotoQuery(PicasaQuery.CreatePicasaUri(sUser, albumid));

                PicasaFeed feed = service.Query(query);

                foreach (PicasaEntry pic in feed.Entries)
                {
                    string sUrl = getImagesResize(pic.Media.Content.Url, "s1600");

                    //   ltrList.Text += "<br/>" + sUrl + "<br/>";
                    // ltrList.Text += "<br/>" + String.Format("<img src=\"{0}\" alt=\"{1}\"/>",
                    //sUrl, pic.Title.ToString());

                    //Console.WriteLine(pic.Title.Text);
                }

                // ltrList.Text = "<br/>" + entry.Id.AbsoluteUri;
            }
            catch (Exception ex)
            {
                //ltrList.Text += "<br/>" + ex.Message;
            }
        }
    }
}
