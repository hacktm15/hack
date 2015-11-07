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
                var newFestival = new Festival();
                newFestival.Name = festival.title;
                var memberNames = festival.images.GetDynamicMemberNames() as IEnumerable<string>;
                var imageName=memberNames.First();
                newFestival.ImagePath=festival.images[imageName].versions.original.url;
                newFestival.Location = festival.venue.address;
                var performances = festival.performances as IEnumerable<dynamic>;
                if (performances != null)
                {
                    var enumerable = performances as IList<dynamic> ?? performances.ToList();
                    newFestival.Price = enumerable.First().price.ToString();
                    var startDate = enumerable.First().start;
                    var endDate = enumerable.Last().end;
                    newFestival.Date = startDate + "-" + endDate;
                }
                Add(newFestival);
            }
        }
    }
}