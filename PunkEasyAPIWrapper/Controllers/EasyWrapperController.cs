using Microsoft.AspNetCore.Mvc;
using PunkEasyAPIWrapper.EasyAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.Controllers
{
    public class EasyWrapperController: Controller
    {
        public IEasyAPI easyAPICall;

        public EasyWrapperController()
        {
            easyAPICall = new EasyAPIImp();
        }

        protected void EasyServerError(Exception exception)
        {

        }
    }
}
