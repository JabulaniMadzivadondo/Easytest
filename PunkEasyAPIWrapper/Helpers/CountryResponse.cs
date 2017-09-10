using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.Helpers
{
    public class CountryResponse
    {
        public CountryResponseObject[] countryResponseObjects { get; set; }
    }

    public class CountryResponseObject
    {
        public string schemaName { get; set; }
        public string countryName { get; set; }
        public string countryRanking { get; set; }
        public string businessUnit { get; set; }
        public string isocode { get; set; }
        public string dialCode { get; set; }
        public int minPhoneLength { get; set; }
        public int maxPhoneLength { get; set; }
        public string[] Languages { get; set; }
        public int MobileStartCode { get; set; }
        public bool ShowInternationalCellFormat { get; set; }
        public bool ShowLocalCellFormat { get; set; }
        public string WebLogo { get; set; }
        public string MobileLogo { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
