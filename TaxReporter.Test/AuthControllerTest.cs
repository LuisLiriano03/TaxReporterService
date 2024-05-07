using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Utility;

namespace TaxReporter.Test
{
    public class AuthControllerTest
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly AuthController _authController;

        public AuthControllerTest()
        {
            _authServiceMock = new Mock<IAuthService>();
            _authController = new AuthController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Login_ValidRequest_ReturnsOkResult()
        {
            var loginRequest = new LoginRequest
            {
                Email = "test@example.com",
                UserPassword = "password"
            };

            _authServiceMock.Setup(x => x.Login(loginRequest.Email, loginRequest.UserPassword))
                .ReturnsAsync(new LoginResponse());

            var result = await _authController.login(loginRequest) as OkObjectResult;
            var response = result.Value as Response<LoginResponse>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);

        }

        [Fact]
        public async Task Register_ValidRequest_ReturnsOkResult()
        {
            var userToRegister = new CreateUser
            {
                Email = "test@example.com",
                UserPassword = "password",
                
            };

            var registeredUser = new GetUser {};

            _authServiceMock.Setup(x => x.Register(userToRegister))
                .ReturnsAsync(registeredUser);

            var result = await _authController.register(userToRegister) as OkObjectResult;
            var response = result.Value as Response<GetUser>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(registeredUser, response.value);

        }

    }

}



