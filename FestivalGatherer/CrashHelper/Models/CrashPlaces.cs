using System;
using System.Collections.Generic;
using System.Linq;

namespace CrashHelper.Models
{
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