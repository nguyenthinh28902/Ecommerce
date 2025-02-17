using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.ViewModels.Settings
{
    public class GoogleApiSetting
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUris { get; set; }
        public string TokenUri { get; set; }
    }
}
