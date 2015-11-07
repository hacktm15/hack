using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;

namespace CrashHelper.Controllers
{
    public class FindController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get()
        {
           var result=CrashPlaceProvider.Querry();
            //return Json.Encode(myFestivals);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(result)
            };
        }
    }

    public static class CrashPlaceProvider
    {
        public static dynamic Querry()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://zilyo.p.mashape.com/search?isinstantbook=true&nelatitude=22.37&nelongitude=-154.48000000000002&provider=airbnb%2Chousetrip&swlatitude=18.55&swlongitude=-160.52999999999997");
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
                    return streamResponse;
                    //var places = Json.Decode(streamResponse);
                    //return places;
                }
            }
        }
    }
}