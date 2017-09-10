using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.Helpers
{
    public class CountryViewModel
    {
        public string businessUnit { get; set; }
        public string vendorCode { get; set; }
        public string language { get; set; }
        public string InterfaceType { get; set; }
        public string ipAddress { get; set; }

        public override string ToString()
        {
            return $"businessUnit={businessUnit}&vendorCode={vendorCode}&language={language}&InterfaceType={InterfaceType}&ipAddress={ipAddress}";
        }
    }
}
