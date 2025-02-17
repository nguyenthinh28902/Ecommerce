using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.ViewModels.Enum
{
    public class EmailBody
    {
        public const string AuthenticationMailCode = "@Model.Code";
        public const string AuthenticationMailUserId = "@Model.UserId";
        public const string AuthenticationMailUrl = "@Model.ConfirmedEmailUrl";
    }
}
