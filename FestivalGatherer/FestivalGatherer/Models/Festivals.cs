using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FestivalGatherer.Models
{
    public class Festivals : List<Festival>
    {
        public Festivals(dynamic festivals, string startDate,string minPriceString,string maxPriceString)
        {
            foreach (dynamic festival in festivals.events.@event)
            {
                if (festival.image == null)
                {
                    continue;
                }
                var startDateTime = DateTime.Parse(startDate);
                var startDateTimePerformance = DateTime.Parse(festival.start_time);
                var result = DateTime.Compare(startDateTime, startDateTimePerformance);
                if (result >= 0)
                {
                    continue;
                }
                int price = (new Random()).Next(0, 100);
                if (!string.IsNullOrEmpty(minPriceString))
                {
                    int minPrice = int.Parse(minPriceString);
                    if (minPrice > price)
                    {
                        continue;
                    }
                }
                if (!string.IsNullOrEmpty(maxPriceString))
                {
                    int maxPrice = int.Parse(maxPriceString);
                    if (maxPrice < price)
                    {
                        continue;
                    }
                }
                string priceString = price.ToString(CultureInfo.InvariantCulture);
                var newFestival = new Festival();
                newFestival.Name = festival.title;
                newFestival.ImagePath = festival.image.url;
                newFestival.Location = festival.venue_address;
                newFestival.Latitude = festival.latitude.ToString();
                newFestival.Longitude = festival.longitude.ToString();
                newFestival.Price = priceString;
                newFestival.StartDate = festivals.start_time;
                newFestival.FestivalUrl = festival.url;
                newFestival.Description = festival.description;
                Add(newFestival);
            }
        }
    }
}