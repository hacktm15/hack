using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;

namespace GeneticSearch.Controllers
{
    public class RouteController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(string start, string stop)
        {
            var result = RouteProvider.Querry(start, stop);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(result)
            };
        }
    }

    public static class RouteProvider
    {
        public static object Querry(string start, string stop)
        {
            var url =
             string.Format(
                 "http://akai-docker-host.cloudapp.net:8080/distanceAPI/api/distanceCar?start={0}&dest={1}",
                 start, stop);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            //request.Headers.Add("Content-Encoding", "gzip");
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