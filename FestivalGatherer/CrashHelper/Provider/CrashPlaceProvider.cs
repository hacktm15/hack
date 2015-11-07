using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Helpers;

namespace CrashHelper.Provider
{
    public static class CrashPlaceProvider
    {
        public static dynamic Querry(string latitude, string longitude, Int32 date)
        {
            var url =
                string.Format(
                    "https://zilyo.p.mashape.com/search?resultsperpage=50&isinstantbook=false&stimestamp={0}&latitude={1}&longitude={2}&provider=airbnb%2Chousetrip",
                    date, latitude, longitude);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Headers.Add("X-Mashape-Key", "C3PIdr9Afvmsh31xOxeeXL8rGF1wp1kyBmLjsnZpnHcbxNFQkp");
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
                    var places = Json.Decode(streamResponse);
                    return places;
                }
            }
        }
    }
}