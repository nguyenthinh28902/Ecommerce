using Authentication.Admin.Service.Services.UserServices.Services;
using Authentication.Admin.Service.ViewModels.SignInViewModels;
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
        [Fact]
        public async Task SignInAsync_ValidCredentials_ReturnToken()
        {
            var signInViewModel = new SignInViewModel();
            signInViewModel.UserName = "1";
            signInViewModel.PassWord = "Pass123!";
            signInViewModel.RememberMe = false;
            signInViewModel.AppName = "Authentication";
            var link = "https://localhost:7228/api/Authentication/v1/admin/confirm-email";
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel, link);
            Assert.NotNull(userSignIn);
            Assert.NotEmpty(userSignIn.Token);
            Assert.True(userSignIn.IsSucceeded);
        }

        [Fact]
        public async Task SignInAsync_InValidCredentials_ReturnEmpty()
        {
            var signInViewModel = new SignInViewModel();
            signInViewModel.UserName = "2";
            signInViewModel.PassWord = "Pass123123!";
            signInViewModel.RememberMe = false;
            signInViewModel.AppName = "Authentication";
            var link = "https://localhost:7228/api/Authentication/v1/admin/confirm-email";
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel, link);
            Assert.NotNull(userSignIn);
            Assert.Empty(userSignIn.Token);
            Assert.False(userSignIn.IsSucceeded);
        }

        [Fact]
        public async Task SignInAsync_EmailNotConfirmed_ReturnEmpty()
        {
            var signInViewModel = new SignInViewModel();
            signInViewModel.UserName = "2";
            signInViewModel.PassWord = "Pass123123!";
            signInViewModel.RememberMe = false;
            signInViewModel.AppName = "Authentication";
            var link = "https://localhost:7228/api/Authentication/v1/admin/confirm-email";
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel, link);
            Assert.NotNull(userSignIn);
            Assert.Empty(userSignIn.Token);
            Assert.False(userSignIn.IsSucceeded);
        }

    }
}
