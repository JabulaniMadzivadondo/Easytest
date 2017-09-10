using Microsoft.AspNetCore.Mvc;
using PunkEasyAPIWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CountryController : EasyWrapperController
    {
        // GET: api/Country
        [HttpGet]
        [Produces(typeof(List<CountryResponseObject>))]
        public IActionResult Get(string language = null, string ipAddress = null)
        {
            try
            {
                var _easy = easyAPICall.Countries(new CountryViewModel() { businessUnit = "DStv", InterfaceType = "DStv Facebook and mobi", ipAddress = ipAddress, language = language, vendorCode = "Facebookdstv" });
                if (_easy != null && _easy.Count > 0)
                    return Ok(_easy);
                else
                    return BadRequest(new { message = "No countries found" });
            }
            catch (Exception ex)
            {
                EasyServerError(ex);
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
