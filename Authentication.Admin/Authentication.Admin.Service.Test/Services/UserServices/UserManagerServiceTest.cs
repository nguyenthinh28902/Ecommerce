using Authentication.Admin.Service.Services.UserServices.Interfaces;
using Authentication.Admin.Service.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.Test.Services.UserServices
{
    public class UserManagerServiceTest
    {
        private readonly IUserManagerService _userManagerService;
        public UserManagerServiceTest(IUserManagerService userManagerService) {
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

        [Fact]
        public async Task CreatedUserAsync_ValidCredentials_ReturnToken()
        {
            var emailString = GenerateRandomString();
            var userRegister = new RegisterUserViewModel();
            userRegister.PhoneNumber = GenerateRandomPhoneNumber();
            userRegister.UserName = Guid.NewGuid().ToString();
            userRegister.Password = "Pass123!";
            userRegister.Email = emailString + "@gmail.com";
            userRegister.Avatar = string.Empty;
            userRegister.DisplayName = "Buồn buồn";
            var userResult = await _userManagerService.CreatedUserAsync(userRegister);
            Assert.True(userResult.IsSuccess);
            Assert.NotNull(userResult);
            Assert.NotNull(userResult.Value);
        }

        [Fact]
        public async Task CreatedUserAsync_InValidCredentials_ReturnToken()
        {
            var emailString = GenerateRandomString();
            //tất cả thông tin đã tồn tại
            var userRegister = new RegisterUserViewModel();
            userRegister.PhoneNumber = GenerateRandomPhoneNumber();
            userRegister.UserName = "1";
            userRegister.Password = "Pass123!";
            userRegister.Email = "thinh48691953@gmail.com";
            userRegister.Avatar = string.Empty;
            userRegister.DisplayName = "Super Admin";
            var userResult = await _userManagerService.CreatedUserAsync(userRegister);
            Assert.False(userResult.IsSuccess);
            Assert.NotNull(userResult);
            Assert.Null(userResult.Value);

            //phone đã tồn tại
            var userRegister1 = new RegisterUserViewModel();
            userRegister1.PhoneNumber = "0359342009";
            userRegister1.UserName = "demo";
            userRegister1.Password = "Pass123!";
            userRegister1.Email = emailString+"@gmail.com";
            userRegister1.Avatar = string.Empty;
            userRegister1.DisplayName = "Super Admin";
            var userResult1 = await _userManagerService.CreatedUserAsync(userRegister1);
            Assert.False(userResult1.IsSuccess);
            Assert.NotNull(userResult1);
            Assert.Null(userResult1.Value);

            //email tồn tại
            var userRegister2 = new RegisterUserViewModel();
            userRegister2.PhoneNumber = GenerateRandomPhoneNumber();
            userRegister2.UserName = "demo";
            userRegister2.Password = "Pass123!";
            userRegister2.Email = "thinh48691953@gmail.com";
            userRegister2.Avatar = string.Empty;
            userRegister2.DisplayName = "Super Admin";
            var userResult2 = await _userManagerService.CreatedUserAsync(userRegister2);
            Assert.False(userResult2.IsSuccess);
            Assert.NotNull(userResult2);
            Assert.Null(userResult2.Value);

            //UserName tồn tại
            var userRegister3 = new RegisterUserViewModel();
            userRegister3.PhoneNumber = GenerateRandomPhoneNumber();
            userRegister3.UserName = "1";
            userRegister3.Password = "Pass123!";
            userRegister3.Email = emailString + "@gmail.com";
            userRegister3.Avatar = string.Empty;
            userRegister3.DisplayName = "Super Admin";
            var userResult3 = await _userManagerService.CreatedUserAsync(userRegister3);
            Assert.False(userResult3.IsSuccess);
            Assert.NotNull(userResult3);
            Assert.Null(userResult3.Value);
        }
    }
}
