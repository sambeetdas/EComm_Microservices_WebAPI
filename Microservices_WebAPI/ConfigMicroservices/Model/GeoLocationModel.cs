using System;

namespace Model
{
    public class GeoLocationModel
    {
        public Guid GeoLocationId { get; set; }
        public string CurrencyType { get; set; }
        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }
        public string Status { get; set; }
    }
}
