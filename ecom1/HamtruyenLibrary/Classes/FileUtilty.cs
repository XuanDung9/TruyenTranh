using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.Web.UI;
using System.Drawing.Drawing2D;
using System.Net;


namespace HamtruyenLibrary.Classes
{
    public class FileUtilty
    {
        public static string fileWrite(string filename, string data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    sw.WriteLine(data);
                    sw.Close();
                }
                return "Write successfull!";
            }
            catch (Exception err)
            {
                return  err.Message;
            }

        }
        public static string IsFileType(string fileName)
        {
            string strRT = "";
            int i = fileName.Length;
            strRT = fileName.Substring(i - 4, 4);
            return strRT.ToUpper();
        }

        public static string getCookie()
        {
            return fileReadAll(Utility.getPhysicalPath() + "/Templates/tmp_cookie.vdc");
        }

        public static void saveImage(string sUrl, string sPath)
        {
            WebClient wClient = new WebClient();
            try
            {
               

                wClient.DownloadFile(sUrl, sPath);
            }
            catch (Exception ex)
            {
                sUrl = "https://2.bp.blogspot.com/-hKLW1dLGrsQ/Vk7wpxdIBQI/AAAAAAADUJ0/3SGij5CFY0g/s320/logo%2Bsky.png";
                wClient.DownloadFile(sUrl, sPath);
            }
            wClient.Dispose();

        }
        public static bool ImageZoomAndSaveWidth(string URLFileName, string destinationLocation, int iLimitDimension)
        {
            try
            {
                string imageUrl = URLFileName;
                string sFnExt = IsFileType(imageUrl);
                if (sFnExt.ToUpper() == ".GIF" || sFnExt.ToUpper() == ".SWF")
                {
                    try
                    {
                        File.Copy(URLFileName, destinationLocation, true);
                    }
                    catch
                    {

                    }

                    return true;
                }
                System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imageUrl);
                System.Drawing.Bitmap imgFoto = null;
                // Neu la .GIF thi bo qua

                //Read in the image filename whose thumbnail has to be created
                float scale = 1;//160.0f /
                float fWiHe = ((float)fullSizeImg.Height) / fullSizeImg.Width;

                float fImageWidth;
                int imageWidth = fullSizeImg.Width;
                int imageHeight = fullSizeImg.Height;

                scale = ((float)iLimitDimension) / fullSizeImg.Width;

                if (scale < 1)
                {
                    fImageWidth = (scale * ((float)fullSizeImg.Width));
                    imageWidth = (int)fImageWidth;
                    imageHeight = (int)(fImageWidth * fWiHe);

                    imgFoto = new System.Drawing.Bitmap(imageWidth, imageHeight);

                    Rectangle recDest = new Rectangle(0, 0, imageWidth, imageHeight);
                    Graphics gphCrop = Graphics.FromImage(imgFoto);

                    gphCrop.SmoothingMode = SmoothingMode.HighQuality;
                    gphCrop.CompositingQuality = CompositingQuality.HighQuality;
                    gphCrop.InterpolationMode = InterpolationMode.High;

                    gphCrop.DrawImage(fullSizeImg, recDest, 0, 0, fullSizeImg.Width, fullSizeImg.Height, GraphicsUnit.Pixel);


                    if (sFnExt.ToUpper() == ".JPG")
                    {
                        System.Drawing.Imaging.Encoder myEncoder = null;
                        System.Drawing.Imaging.EncoderParameter myEncoderParameter = null;
                        System.Drawing.Imaging.EncoderParameters myEncoderParameters = null;

                        System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
                        System.Drawing.Imaging.ImageCodecInfo jpegICI = null;

                        for (int x = 0; x < arrayICI.Length; x++)
                        {
                            if (arrayICI[x].FormatDescription.Equals("JPEG"))
                            {
                                jpegICI = arrayICI[x];
                                break;
                            }
                        }
                        // thiet lap thong so ma hoa
                        myEncoder = System.Drawing.Imaging.Encoder.Quality;
                        myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 90L);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        // luu anh
                        imgFoto.Save(destinationLocation, jpegICI, myEncoderParameters);
                    }
                    else
                        imgFoto.Save(destinationLocation);
                    imgFoto.Dispose();
                    fullSizeImg.Dispose();
                }
                else
                {
                    try
                    {
                        File.Copy(URLFileName, destinationLocation, true);
                    }
                    catch
                    {

                    }
                }

                return true;
            }
            catch
            {
                //Response.Write("An error occurred - " + ex.ToString());
                return false;
            }

        }
        // tinh do cao cua anh
        public static string fileReadAll(string filename)
        {
            string strReaded = "";
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        strReaded = strReaded + line + "\r\n";
                    }
                    sr.Close();
                }
            }
            catch
            {
                //filename=filename.Replace(System.Web.HttpContext.Current.Request.PhysicalApplicationPath,"");
                return "<b><font color=#FF0000>Lỗi: Không tìm được file \"" + filename + "\"</font></b>";
            }
            return strReaded;
        }
        public static int getImageHeigth(string URLFileName, int iImageWidth)
        {
            float fRatio = getImageRatio(URLFileName);
            int iImageHeight = (int)(iImageWidth * fRatio);
            return iImageHeight;


        }
        public static float getImageRatio(string URLFileName)
        {
            try
            {
                string imageUrl = URLFileName;
                System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imageUrl);

                float fWiHe = ((float)fullSizeImg.Height) / fullSizeImg.Width;
                fullSizeImg.Dispose();
                return fWiHe;
            }
            catch (Exception ex)
            {

                string s = ex.Message;
                return 1;
            }

        }

        public static string fileWriteAll(string filename, string data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    sw.WriteLine(data);
                    sw.Close();
                }
                return "Write successfull!";
            }
            catch (Exception err)
            {
                return "<b><font color=#FF0000>Error: " + err.Message + "</font></b>";
            }

        }
    }
}
