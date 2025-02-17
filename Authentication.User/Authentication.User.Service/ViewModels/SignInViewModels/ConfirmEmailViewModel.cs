using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.ViewModels.SignInViewModels
{
    public class ConfirmEmailViewModel
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }
}
