using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.ViewModel.SignInViewModels
{
    public class SignInViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; } = false;
        public string AppName { get; set; }
    }
}
