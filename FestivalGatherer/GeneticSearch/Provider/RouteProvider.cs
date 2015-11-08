using System.IO;
using System.Net;
using System.Text;
using System.Web.Helpers;

namespace GeneticSearch.Provider
{
    public static class RouteProvider
    {
        public static dynamic Querry(string start, string stop)
        {
            var url =
                string.Format(
                    "http://akai-docker-host.cloudapp.net:8080/distanceAPI/api/distanceCar?start={0}&dest={1}",
                    start, stop);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
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

        public static dynamic QuerryFlight(string start, string stop, string startDate, string returnDate)
        {
              
            var url =
              string.Format(
                  " http://akai-docker-host.cloudapp.net:8080/distanceAPI/api/distanceAir?start={0}&dest={1}&startDate={2}&destDate={3}",
                  start, stop,startDate,returnDate);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html,application/xhtml+xml,application/xml";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
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