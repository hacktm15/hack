using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using FestivalTracker.Utilities.Utilities;

namespace FestivalGatherer.DataProviders
{
    public class Provider
    {
        public static dynamic QuerryFestivals(string minPrice, string maxPrice, string startDate,string type)
        {
            startDate = HttpUtility.UrlPathEncode(startDate);
            var url = string.Format(
                "http://api.eventful.com/json/events/search?app_key=VBbxVjCfdVBGnnHv&t>={0}&q={1}", startDate,type);
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream == null)
                {
                    return null;
                }
                using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    var streamResponse = readStream.ReadToEnd();
                    var festivals = Json.Decode(streamResponse);
                    return festivals;
                }
            }
        }
    }
}