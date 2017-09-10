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
    public class SignInController : EasyWrapperController
    {

        // POST: api/SignIn
        [HttpPost]
        [Produces(typeof(SignInResponse))]
        public IActionResult Post([FromBody]SignInRequestBody signInRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _easy = easyAPICall.SignIn(signInRequest);
                    if (_easy == null)
                    {
                        return BadRequest(new { message = "Sign in failed" });
                    }
                    return Ok(_easy);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                EasyServerError(ex);
                return BadRequest(new { message = ex.Message });
            }

        }

    }
}
