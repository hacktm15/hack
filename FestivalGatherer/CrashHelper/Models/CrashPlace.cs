using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrashHelper.Models
{
    public class CrashPlace
    {
        public string Url { get; set; }
        public string Price { get; set; }
        public string Beds { get; set; }
        public string Id { get; set; }
        public Availability[] Availabilities { get; set; }
        public string Address { get; set; }
    }

    public class Availability
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class CrashPlaces:List<CrashPlace>
    {
        public CrashPlaces(IEnumerable<dynamic> crashPlaces)
        {
            foreach (dynamic crashPlace in crashPlaces)
            {
                var newCrashPlace = new CrashPlace();
                newCrashPlace.Id = crashPlace.id;
                newCrashPlace.Beds = crashPlace.attr.beds.ToString();
                newCrashPlace.Price = crashPlace.price.nightly.ToString();
                newCrashPlace.Address = crashPlace.location.streetName;
                newCrashPlace.Url = crashPlace.provider.url;
                var availabilities = crashPlace.availability as IEnumerable<dynamic>;
                if (availabilities != null)
                {
                    newCrashPlace.Availabilities =
                        availabilities.Select(e => new Availability { End = ToDateTime(e.end), Start = ToDateTime(e.start) }).ToArray();
                }
                Add(newCrashPlace);
            }
        }

        public DateTime ToDateTime(long unixDateTime)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dateTime.AddSeconds(unixDateTime);
        }
    }

    
}