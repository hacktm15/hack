using System.IO;
using System.Net;
using System.Text;
using System.Web.Helpers;
using FestivalGatherer.Controllers;

namespace FestivalGatherer.DataProviders
{
    public class Provider
    {
        public static void QuerryFestivals()
        {
            string requestUrl = HmcSha1.Hash2("qXVl3oyM75QhQtz4", "MWR6cePblwXxSg38vqAzbJ2rg6u6ykcz", "year=2015");
            var request = (HttpWebRequest) WebRequest.Create(requestUrl);
            request.Accept="application/json;ver=2.0";
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream == null)
                {
                    return;
                }
                using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    var streamResponse = readStream.ReadToEnd();
                    var festivals = Json.Decode(streamResponse);
                }
            }
        }
    }
}