using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.Service.Services.UserServices.Interfaces;
using Authentication.Admin.Service.Services.UserServices.Services;
using Authentication.Admin.Service.ViewModels.SignInViewModels;
using Authentication.Admin.Service.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Test.ServiceTests
{
    public class AuthenManagerServiceTest
    {
        private readonly IAuthenManagerService _authenManagerService;
        private readonly IUserManagerService _userManagerService;
        public AuthenManagerServiceTest(IAuthenManagerService authenManagerService, IUserManagerService userManagerService)
        {

            _authenManagerService = authenManagerService;
            _userManagerService = userManagerService;
        }
        public static string GenerateRandomString(int length = 7)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
        public static string GenerateRandomPhoneNumber()
        {
            Random random = new Random();

            // Start the phone number with a '0'
            string phoneNumber = "0";

            // Generate the remaining 9 digits
            for (int i = 0; i < 9; i++)
            {
                phoneNumber += random.Next(0, 10); // Generates a number between 0 and 9
            }

            return phoneNumber;
        }


        // hàm check mã xác nhận thông tin email
        [Fact]
        public async Task GenerateEmailConfirmationToken_ConfirmEmail_InValidCredentials_ReturnTrue()
        {
            var emailString = GenerateRandomString();
            var userRegister = new RegisterUserViewModel();
            userRegister.PhoneNumber = GenerateRandomPhoneNumber();
            userRegister.UserName = Guid.NewGuid().ToString();
            userRegister.Password = "Pass123!";
            userRegister.Email = emailString+"@gmail.com";
            userRegister.Avatar = string.Empty;
            userRegister.DisplayName = "Buồn buồn";
            var userResult = await _userManagerService.CreatedUserAsync(userRegister);
            Assert.True(userResult.IsSuccess);
            Assert.NotNull(userResult);
            Assert.NotNull(userResult.Value);

            var codeConfirm = await _authenManagerService.GenerateEmailConfirmationTokenAsync(userResult.Value);
            Assert.NotEmpty(codeConfirm);

            var emailConfirm = await _authenManagerService.ConfirmEmailAsync(userResult.Value, codeConfirm);
            Assert.NotNull(emailConfirm);
            Assert.True(emailConfirm.IsSucceeded);
        }
    }
}
