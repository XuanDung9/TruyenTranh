using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HamtruyenLibrary;
using HamtruyenLibrary.Repo;
using HamtruyenLibrary.Models;
using HamtruyenLibrary.Classes;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;

namespace HamtruyenAdmin
{
    public partial class FetchData : System.Web.UI.Page
    {
        //int iPage = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sUrl = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=50&q=hello%20adele&type=video&key=AIzaSyD7wzq4MBbx-kwqa61uFg62VgPZVojBVlc&pageToken=CGQQAQ";
            //using (WebClient wc = new WebClient())
            //{
            //    var json = wc.DownloadString(sUrl);
            //    kid.InnerHtml = json;
            //}
            
        }

        private string Search(string sKey, string iPage)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyD7wzq4MBbx-kwqa61uFg62VgPZVojBVlc",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = sKey; // Replace with your search term.
            //searchListRequest.MaxResults = 50;
            searchListRequest.PageToken = iPage.ToString();

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse =  searchListRequest.Execute();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            string sReturn = "";
            string sImgTemplate = "http://img.youtube.com/vi/XX_ID_XX/hqdefault.jpg";
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        sReturn += searchResult.Snippet.Title+"</br><img src='"+sImgTemplate.Replace("XX_ID_XX",searchResult.Id.VideoId)+"'/><br/><br/><br/>";
                        
                        break;

                    //case "youtube#channel":
                    //    channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                    //    break;

                    //case "youtube#playlist":
                    //    playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                    //    break;
                }
            }
            return sReturn;
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sPage = "";
            if (txtPage.Text != "")
            {
                sPage = (txtPage.Text);
            }
            if (txtKeyword.Text != "")
            {
                Search(txtKeyword.Text, sPage);
            }
            else
            {
                kid.InnerHtml = "Phải chọn từ khóa!";
            }
        }
    }
}