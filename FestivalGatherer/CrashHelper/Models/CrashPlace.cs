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
}