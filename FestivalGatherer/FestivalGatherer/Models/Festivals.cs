using System;
using System.Collections.Generic;
using System.Linq;

namespace FestivalGatherer.Models
{
    public class Festivals : List<Festival>
    {
        public Festivals(IEnumerable<dynamic> festivals)
        {
            foreach (dynamic festival in festivals)
            {
                var performances = festival.performances as IEnumerable<dynamic>;
                if (performances != null)
                {
                    foreach (dynamic performance in performances)
                    {
                        var newFestival = new Festival();
                        newFestival.Name = festival.title;
                        var memberNames = festival.images.GetDynamicMemberNames() as IEnumerable<string>;
                        var imageName = memberNames.First();
                        newFestival.ImagePath = festival.images[imageName].versions.original.url;
                        newFestival.Location = festival.venue.address;
                        newFestival.Latitude = festival.latitude.ToString();
                        newFestival.Longitude = festival.longitude.ToString();
                        newFestival.Price = performance.price.ToString();
                        newFestival.StartDate = performance.start;
                        newFestival.EndDate = performance.end;
                        newFestival.FestivalUrl = festival.url;
                        newFestival.Description = festival.description;
                        Add(newFestival);
                        break;
                    }
                  
                }
              
            }
        }

        public Festivals(dynamic festivals, string startDate)
        {
            foreach (dynamic festival in festivals)
            {
                var performances = festival.performances as IEnumerable<dynamic>;
                if (performances != null)
                {
                    foreach (dynamic performance in performances)
                    {
                        var startDateTime = DateTime.Parse(startDate);
                        var startDateTimePerformance = DateTime.Parse(performance.start);
                        var result=DateTime.Compare(startDateTime, startDateTimePerformance);
                        if (result >= 0)
                        {
                            continue;
                        }
                        var newFestival = new Festival();
                        newFestival.Name = festival.title;
                        var memberNames = festival.images.GetDynamicMemberNames() as IEnumerable<string>;
                        var imageName = memberNames.First();
                        newFestival.ImagePath = festival.images[imageName].versions.original.url;
                        newFestival.Location = festival.venue.address;
                        newFestival.Latitude = festival.latitude.ToString();
                        newFestival.Longitude = festival.longitude.ToString();
                        newFestival.Price = performance.price.ToString();
                        newFestival.StartDate = performance.start;
                        newFestival.EndDate = performance.end;
                        newFestival.FestivalUrl = festival.url;
                        newFestival.Description = festival.description;
                        Add(newFestival);
                        break;
                    }

                }
            }
        }
    }
}