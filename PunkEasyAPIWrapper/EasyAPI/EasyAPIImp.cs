using Newtonsoft.Json;
using PunkEasyAPIWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.EasyAPI
{
    public class EasyAPIImp:IEasyAPI
    {
        private const string url = "http://uat-vscapi.mcadmg.com/VendorSelfCareWebApi/api/";
        public List<CountryResponseObject> Countries(CountryViewModel country)
        {
            using (var client = new HttpClient())
            {
                var res = client.GetAsync($"{url}Country/GetCountriesByBusinessUnit?{country.ToString()}").Result;
                if (res.IsSuccessStatusCode)
                {
                    var responseBody = res.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<CountryResponseObject>>(responseBody);
                }
                return new List<CountryResponseObject>();
            }
        }

        public SignInResponse SignIn(SignInRequestBody signInView)
        {
            using (var client = new HttpClient())
            {
                var signInRequest = new SignInRequest() { businessUnit = "DStv", currencyCode = "", dataSource = signInView.country, ipAddress = "", language = "", number = signInView.smartCardNumber, ReferenceValue = signInView.username, type = "SmartCardNumber", vendorCode = "Facebookdstv" };

                var response = client.GetAsync($"{url}Logon/LogOnWithReference?{signInRequest.ToString()}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    var responseObject = JsonConvert.DeserializeObject<LogOnEasyResponse>(responseBody);
                    return new SignInResponse(responseObject) { customerName = responseObject.customerDetails.FirstName + " " + responseObject.customerDetails.surname, smartCards = new List<SmartCard>() { } };
                }

                return null;

            }
        }
    }

}
