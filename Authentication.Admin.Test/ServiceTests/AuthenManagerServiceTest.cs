using Authentication.Admin.Service.Services.UserServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Test.ServiceTests
{
    public class AuthenManagerServiceTest
    {
        private readonly AuthenManagerService _authenManagerService;
        public AuthenManagerServiceTest(AuthenManagerService authenManagerService) {

            _authenManagerService = authenManagerService;
        }   
    }
}
