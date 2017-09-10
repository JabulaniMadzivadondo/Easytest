using PunkEasyAPIWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.EasyAPI
{
    public interface IEasyAPI
    {
        List<CountryResponseObject> Countries(CountryViewModel country);
        SignInResponse SignIn(SignInRequestBody signInView);
    }
}
