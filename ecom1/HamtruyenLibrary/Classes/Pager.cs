using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Classes
{
    public class Pager
    {
        public static string CreateLink(string szDisplayText, string sURL)
        {
            return "<li><a href='" + sURL + "'>" + szDisplayText + "</a>";
        }

        public static string CreatePrevLink(string sUrl)
        {
            return String.Format("<li><a href=\"{0}\"><span aria-hidden=\"true\">&laquo;</span><span class=\"sr-only\">Previous</span></a></li>",sUrl);
        }
        public static string CreateNextLink(string sUrl)
        {
            return String.Format("<li><a href=\"{0}\"><span aria-hidden=\"true\">&raquo;</span><span class=\"sr-only\">Next</span></a></li>",sUrl);
        }
      

        public static string CreateLinkActive(string szDisplayText, string sURL)
        {
            return "<li class=\"active\"><a href='#'>" + szDisplayText + "<span class=\"sr-only\">(current)</span></a>";
        }

        public static string CreateLinkAjaxStatic(string szDisplayText)
        {
            //if (sParam.IndexOf(",") == 0) sParam = sParam.Substring(1);
            string sTemp = "<a href=\"javascript:void(0)\" class=\"current_page\">{0}</a>";
            return string.Format(sTemp, szDisplayText);
        }

        public static string CreateLinkAjax(string szDisplayText, string sFunctionName, string sParam)
        {
            if (sParam.IndexOf(",") == 0) sParam = sParam.Substring(1);
            string sTemp = "<a href=\"javascript:void(0)\" class=\"page\" onclick=\"javascript:{0}({1});\">{2}</a>";
            return string.Format(sTemp, sFunctionName, sParam, szDisplayText);
        }

      
        public static string CustomizePagerAjax(string sFunctionName, string sParam, int PageCount, int PageIndex)
        {
            string sReturn = "";

            int nLastRenderedPage = 1;


            if (PageCount >= 1)
            {
                sReturn = "<div class=\"pager\" style=\"margin-top:15px;\">";
                if (10 < PageCount && (PageIndex + 1) > 10)
                {

                    sReturn += CreateLinkAjax("<span class=\"glyphicon glyphicon-chevron-left\"></span>", sFunctionName, sParam + ",1");
                    //sReturn += "&nbsp;&nbsp;...";
                    sReturn += CreateLinkAjax("<span class=\"glyphicon glyphicon-chevron-left\"></span>", sFunctionName, sParam + "," + (PageIndex).ToString());
                    //sReturn += "&nbsp;&nbsp;";
                }
                //sReturn += "Trang &nbsp;";


                int nMultiplier = Convert.ToInt32(PageIndex / 10);
                for (int i = 1; i <= 10; i++)
                {
                    string szPage = ((int)(nMultiplier * 10) + i).ToString();
                    if (Convert.ToInt32(szPage) > PageCount)
                    {
                        break;
                    }
                    // sReturn += "&nbsp;";
                    if (Convert.ToInt32(szPage) == (PageIndex + 1))
                    {
                        sReturn += CreateLinkAjaxStatic(szPage);
                    }
                    else
                    {

                        sReturn += CreateLinkAjax(szPage, sFunctionName, sParam + "," + szPage);

                    }
                   
                    nLastRenderedPage = Convert.ToInt32(szPage);
                }
                if (10 < PageCount && nLastRenderedPage < PageCount)
                {
                    //sReturn += "&nbsp;&nbsp;";
                    sReturn += CreateLinkAjax("<span class=\"glyphicon glyphicon-chevron-right\"></span>", sFunctionName, sParam + "," + (PageIndex + 2).ToString());
                    //sReturn += "&nbsp;&nbsp;...";
                    sReturn += CreateLinkAjax("<span class=\"glyphicon glyphicon-chevron-right\"></span>", sFunctionName, sParam + "," + (PageCount).ToString());

                }
                sReturn += "</div>";
            }
            return sReturn;

        }

        public static string createPager(int PageCount, int PageIndex, string sURL)
        {

            string sReturn = "<div class=\"dataTables_paginate paging_bootstrap pagination\"><ul>";

            int nLastRenderedPage = 1;
            bool bIsFirtsParam = true;
            if (sURL.IndexOf("?") != -1) bIsFirtsParam = false;
            if (PageCount >= 1)
            {
                if (10 < PageCount && (PageIndex + 1) > 10)
                {

                    if (bIsFirtsParam) sReturn += CreateLink("&lt;&lt;", "?P=1");
                    else sReturn += CreateLink("&lt;&lt;", sURL + "&P=1");

                    
                    if (bIsFirtsParam) sReturn += CreateLink("&lt;", "?P=" + (PageIndex).ToString());
                    else sReturn += CreateLink("&lt;", sURL + "&P=" + (PageIndex).ToString());
         
                }
                //sReturn += "";


                int nMultiplier = Convert.ToInt32(PageIndex / 10);
                for (int i = 1; i <= 10; i++)
                {
                    string szPage = ((int)(nMultiplier * 10) + i).ToString();
                    if (Convert.ToInt32(szPage) > PageCount)
                    {
                        break;
                    }
                    if (Convert.ToInt32(szPage) == (PageIndex + 1))
                    {
                        sReturn += "<li class=\"active\"><a href=\"#\">" + szPage + "</a></li>";
                    }
                    else
                    {

                        if (bIsFirtsParam) sReturn += CreateLink(szPage, "?P=" + szPage);
                        else sReturn += CreateLink(szPage, sURL + "&P=" + szPage);
                    }
    
                    if (true && i < 10 && Convert.ToInt32(szPage) < PageCount)
                    {
                        sReturn += "";
                    }
                    nLastRenderedPage = Convert.ToInt32(szPage);
                }
                if (10 < PageCount && nLastRenderedPage < PageCount)
                {
                    sReturn += "&nbsp;&nbsp;";
                    if (bIsFirtsParam) sReturn += CreateLink("&gt;", "?P=" + (PageIndex + 2).ToString());
                    sReturn += CreateLink("&gt;", sURL + "&P=" + (PageIndex + 2).ToString());
                    sReturn += "&nbsp;&nbsp;";
                    if (bIsFirtsParam) sReturn += CreateLink("&gt;&gt;", "?P=" + (PageCount).ToString());
                    sReturn += CreateLink("&gt;&gt;", sURL + "&P=" + (PageCount).ToString());
                }
            }
            return sReturn + "</ul></div>";
        }

        public static string createPagerUser(int PageCount, int PageIndex, string sURL)
        {

            string sReturn = "<nav style=\"text-align:center;\"><ul class=\"pagination\">";

            int nLastRenderedPage = 1;
            bool bIsFirtsParam = true;
            if (sURL.IndexOf("?") != -1) bIsFirtsParam = false;
            if (PageCount >= 1)
            {
                if (10 < PageCount && (PageIndex + 1) > 10)
                {

                   // if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span><span class=\"glyphicon glyphicon-chevron-left\"></span>", "?P=1");
                    //else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span><span class=\"glyphicon glyphicon-chevron-left\"></span>", sURL + "&P=1");


                    if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span>", "?P=" + (PageIndex).ToString());
                    else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span>", sURL + "&P=" + (PageIndex).ToString());

                }
                //sReturn += "";


                int nMultiplier = Convert.ToInt32(PageIndex / 10);
                for (int i = 1; i <= 10; i++)
                {
                    string szPage = ((int)(nMultiplier * 10) + i).ToString();
                    if (Convert.ToInt32(szPage) > PageCount)
                    {
                        break;
                    }
                    if (Convert.ToInt32(szPage) == (PageIndex + 1))
                    {
                        sReturn += "<li class=\"active\"><a href=\"#\">" + szPage + "</a></li>";
                    }
                    else
                    {

                        if (bIsFirtsParam) sReturn += CreateLink(szPage, "?P=" + szPage);
                        else sReturn += CreateLink(szPage, sURL + "&P=" + szPage);
                    }

                    if (true && i < 10 && Convert.ToInt32(szPage) < PageCount)
                    {
                        sReturn += "";
                    }
                    nLastRenderedPage = Convert.ToInt32(szPage);
                }
                if (10 < PageCount && nLastRenderedPage < PageCount)
                {
                    sReturn += "&nbsp;&nbsp;";
                    if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span>", "?P=" + (PageIndex + 2).ToString());
                    else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span>", sURL + "&P=" + (PageIndex + 2).ToString());
                   // sReturn += "&nbsp;&nbsp;";
                    //if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span><span class=\"glyphicon glyphicon-chevron-right\"></span>", "?P=" + (PageCount).ToString());
                    //else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span><span class=\"glyphicon glyphicon-chevron-right\"></span>", sURL + "&P=" + (PageCount).ToString());
                }
            }
            return sReturn + "</ul></nav>";
        }

        public static string createPagerHamtruyen(int PageCount, int PageIndex, string sURL) //url phân trang với page = 1
        {
            string sReturn = "<nav class=\"pagerhamtruyen\"><ul class=\"pagination\">";

            int nLastRenderedPage = 1;
            bool bIsFirtsParam = true;
            if (sURL.IndexOf("?") != -1) bIsFirtsParam = false;
            if (PageCount >= 1)
            {
                if (10 < PageCount && (PageIndex + 1) > 10)
                {

                   // if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span><span class=\"glyphicon glyphicon-chevron-left\"></span>", sURL.Replace("p1", "p1"));
                   // else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span><span class=\"glyphicon glyphicon-chevron-left\"></span>", sURL.Replace("p1", "p1"));


                    if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span>", sURL.Replace("p1", "P" + (PageIndex).ToString()));
                    else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-left\"></span>", sURL.Replace("p1", "P" + (PageIndex).ToString()));

                }
                //sReturn += "";


                int nMultiplier = Convert.ToInt32(PageIndex / 10);
                for (int i = 1; i <= 10; i++)
                {
                    string szPage = ((int)(nMultiplier * 10) + i).ToString();
                    if (Convert.ToInt32(szPage) > PageCount)
                    {
                        break;
                    }
                    if (Convert.ToInt32(szPage) == (PageIndex + 1))
                    {
                        sReturn += CreateLinkActive(szPage, sURL);;
                    }
                    else
                    {

                        if (bIsFirtsParam) sReturn += CreateLink(szPage, sURL.Replace("p1", "P" + (szPage).ToString()));
                        else sReturn += CreateLink(szPage, sURL.Replace("p1", "P" + (szPage).ToString()));
                    }

                    if (true && i < 10 && Convert.ToInt32(szPage) < PageCount)
                    {
                        sReturn += "";
                    }
                    nLastRenderedPage = Convert.ToInt32(szPage);
                }
                if (10 < PageCount && nLastRenderedPage < PageCount)
                {
                    sReturn += "&nbsp;&nbsp;";
                    if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span>", sURL.Replace("p1", "P" + (PageIndex + 2).ToString()));
                    else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span>", sURL.Replace("p1", "P" + (PageIndex + 2).ToString()));

                    //sReturn += "&nbsp;&nbsp;";
                    //if (bIsFirtsParam) sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span><span class=\"glyphicon glyphicon-chevron-right\"></span>", sURL.Replace("p1", "P" + (PageIndex + 2).ToString()));
                    //else sReturn += CreateLink("<span class=\"glyphicon glyphicon-chevron-right\"></span><span class=\"glyphicon glyphicon-chevron-right\"></span>", sURL.Replace("p1", "P" + (PageIndex + 2).ToString()));
                }
            }
            return sReturn + "</ul></nav>";
        }
    }
}
