using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.ViewModels.UserViewModels
{
    public class RegisterUserViewModel
    {
        public RegisterUserViewModel() { }
        public RegisterUserViewModel(string UserName, string DisplayName, string Email, string Password , string PhoneNumber = "", string Avatar = "")
        {
            this.UserName = UserName;
            this.DisplayName = string.IsNullOrEmpty(DisplayName) ? UserName : DisplayName;
            this.Avatar = Avatar;
            this.Email = string.IsNullOrEmpty(Email) ? UserName : Email; ;
            this.PhoneNumber = PhoneNumber;
            this.Password = Password;
        }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
