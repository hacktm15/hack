﻿using System;
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

        public static dynamic QuerryFestivals(string minPrice, string maxPrice, string startDate)
        {
            string querryString = string.Empty;
            if (!string.IsNullOrEmpty(minPrice))
            {
                querryString += string.Format("price_from={0}&", minPrice);
            }
            if (!string.IsNullOrEmpty(maxPrice))
            {
                querryString += string.Format("price_to={0}&", maxPrice);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                startDate = HttpUtility.UrlPathEncode(startDate);
                querryString += string.Format("date_from={0}&", startDate);
            }
            querryString += "size=100";
            return QuerryString(querryString);
        }
    }
}