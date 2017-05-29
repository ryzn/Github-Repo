using Google.Apis.Services;
using Google.Apis.Urlshortener.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URL_Shorten_API.App_Start
{
    public static class Utility
    {
        //private const string googleAPIKey = "AIzaSyBIkkmagfceBNyRo7wW3dCOTMk03ycjYJY";


        public static string shortenIt(string url)
        { 
            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBIkkmagfceBNyRo7wW3dCOTMk03ycjYJY",
                ApplicationName = "Daimto URL shortener Sample",
            });
            var m = new Google.Apis.Urlshortener.v1.Data.Url();
            m.LongUrl = url;
            return service.Url.Insert(m).Execute().Id;
        }
        public static string unShortenIt(string url)
        {
            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBIkkmagfceBNyRo7wW3dCOTMk03ycjYJY",
                ApplicationName = "Daimto URL shortener Sample",
            });
            return service.Url.Get(url).Execute().LongUrl;
        }
    }
}