using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.Helpers
{
    public class SignInRequestBody
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string smartCardNumber { get; set; }
        public string country { get; set; }
    }
}
