using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using URL_Shorten_API.App_Start;

namespace URL_Shorten_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ValuesController : ApiController
    {
        ShortURLEntities1 entities = new ShortURLEntities1();
        
        
        [HttpPost]
        public string GetLongURL([FromBody]string value)
        {
            string longURL = string.Empty;
            try
            { 
                var item = entities.urls.FirstOrDefault(e => e.short_url == value);
                      
                if (item == null)
                {
                    longURL = Utility.unShortenIt(value);
                }
                else
                    longURL = item.real_url;
            }
            catch(Exception ex)
            {

            }
            return longURL;
        }

        [HttpPost]
        public string GetShortURL([FromBody]string value)
        {

             return GetShortURLDetails(value);

        }
             
        private string GetShortURLDetails(string url)
        {
            string shortURL = string.Empty;
            try
            { 
            var item = entities.urls.FirstOrDefault(e => e.real_url == url);             
                if (item == null)
                {
                    url values = new url();
                    values.real_url = url;
                    values.short_url = Utility.shortenIt(url);
                    entities.urls.Add(values);
                    entities.SaveChanges();
                    shortURL = values.short_url;
                }
                else
                    shortURL = item.short_url;
            }
            catch(Exception ex)
            {

            }
            return shortURL;
        }
    }
}
