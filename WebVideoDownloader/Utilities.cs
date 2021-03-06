﻿using System.Web;
using System.Net;


namespace WebVideoDownloader
{
    public class Utilities
    {
        public string DecodeUrlString(string url)
        {
            string newUrl = HttpUtility.UrlDecode(url);

            return newUrl;
        }
        public string GetSource(string link) //constructor
        {
            WebRequest Request = WebRequest.Create(link);
            WebResponse Response = Request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(Response.GetResponseStream());
            string pagesource = sr.ReadToEnd();
            return pagesource;
        }
        public string RemoveInvalidChar(string txt, string domain)
        {
            if (domain == "youtube")
            {
                txt = txt.Replace("-", "");
                txt = txt.Replace("YouTube", "");
            }
            
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                txt = txt.Replace(c.ToString(), "");
            }
            txt = txt.Trim();
            return txt;
        }

    }
}