using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using FestivalGatherer.Utilities;

namespace FestivalGatherer.DataProviders
{
    public class Provider
    {
        public static dynamic QuerryFestivals()
        {
            var todayurl = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            todayurl=HttpUtility.UrlPathEncode(todayurl);
            todayurl = string.Format("date_from={0}&size=100", todayurl);
            return QuerryString(todayurl);
        }

        public static dynamic QuerryFestivalsByDate(string date)
        {
            date = HttpUtility.UrlPathEncode(date);
            date = string.Format("date_from={0}&size=100", date);
            return QuerryString(date);
        }

        public static dynamic QuerryFestivalsByPrice(string minPrice, string maxPrice)
        {
            var querryString = string.Format("price_from={0}&price_to={1}&size=100", minPrice,maxPrice);
            return QuerryString(querryString);
        }

        private static dynamic QuerryString(string todayurl)
        {
            string requestUrl = HmcSha1.Hash2("qXVl3oyM75QhQtz4", "MWR6cePblwXxSg38vqAzbJ2rg6u6ykcz", todayurl);
            var request = (HttpWebRequest) WebRequest.Create(requestUrl);
            request.Accept = "application/json;ver=2.0";
            using (var response = (HttpWebResponse) request.GetResponse())
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