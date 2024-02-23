using System.ComponentModel.DataAnnotations;

namespace GeoCRON.Models
{
    public class GeoInfo
    {
        [Key]
        public Guid IpLocal { get; set; }
        public string Ip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Organization { get; set; }
        public string Postal { get; set; }
        public string Timezone { get; set; }
        public string Readme { get; set; }
    }
}
