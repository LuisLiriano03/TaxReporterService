using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.Utility;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.DTOs.User;

namespace TaxReporter.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetUsers_Successful_ReturnsOkResult()
        {
            var expectedUsers = new List<GetUser>
            {
                new GetUser { UserId = 1, FullName = "John Doe", Email = "john@example.com" },
                new GetUser { UserId = 2, FullName = "Jane Smith", Email = "jane@example.com" }
            };

            _userServiceMock.Setup(x => x.GetAsync())
                .ReturnsAsync(expectedUsers);

            var result = await _userController.GetUsers() as OkObjectResult;
            var response = result.Value as Response<List<GetUser>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedUsers, response.value);

        }

        [Fact]
        public async Task EditUser_Successful_ReturnsOkResult()
        {
            var updateUserRequest = new UpdateUser
            {
                UserId = 1,
                FullName = "John Doe",
                Email = "john@example.com",
            };

            _userServiceMock.Setup(x => x.UpdateAsync(It.IsAny<UpdateUser>()))
                .ReturnsAsync(true);

            var result = await _userController.EditUser(updateUserRequest) as OkObjectResult;
            var response = result.Value as Response<bool>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.True(response.value);

        }

        [Fact]
        public async Task DeleteUser_Successful_ReturnsOkResult()
        {
            var userId = 1;

            _userServiceMock.Setup(x => x.DeleteAsync(userId))
                .ReturnsAsync(true);

            var result = await _userController.DeleteUser(userId) as OkObjectResult;
            var response = result.Value as Response<bool>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.True(response.value);

        }

    }

}

