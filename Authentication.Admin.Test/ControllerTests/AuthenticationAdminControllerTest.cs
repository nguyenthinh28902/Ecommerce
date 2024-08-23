using Authentication.Admin.Api.Controllers;
using Authentication.Admin.Service.ViewModels.SignInViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Admin.Test.ControllerTests
{
    public class AuthenticationAdminControllerTest
    {
        private readonly AuthenticationController _authenticationController;
        public AuthenticationAdminControllerTest (AuthenticationController authenticationController) { 
            _authenticationController = authenticationController;
        }
        [Fact]
        public async void SignIn_ValidCredentials_ReturnToken()
        {
            var signInViewModel = new SignInViewModel();
            signInViewModel.UserName = "1";
            signInViewModel.PassWord = "Pass123!";
            signInViewModel.RememberMe = false;
            signInViewModel.AppName = "Authentication";
           var successResult = await _authenticationController.SignIn(signInViewModel);

            var successModel = successResult as OkObjectResult;
            var fetchedEmp = successModel?.Value as SignInResultViewModel;

            Assert.NotNull(successModel);
            
            Assert.Equal(fetchedEmp?.IsSucceeded, true);
            Assert.NotEmpty(fetchedEmp?.Token ?? string.Empty);

        }

        [Fact]
        public async void SignIn_InValidCredentials_ReturnToken()
        {
            var signInViewModel = new SignInViewModel();
            signInViewModel.UserName = "2";
            signInViewModel.PassWord = "Pass123123!";
            signInViewModel.RememberMe = false;
            signInViewModel.AppName = "Authentication";
            var successResult = await _authenticationController.SignIn(signInViewModel);

            var successModel = successResult as OkObjectResult;
            var fetchedEmp = successModel?.Value as SignInResultViewModel;

            Assert.NotNull(successModel);

            Assert.Equal(fetchedEmp?.IsSucceeded, false);
            Assert.Empty(fetchedEmp?.Token ?? string.Empty);

        }
    }
}