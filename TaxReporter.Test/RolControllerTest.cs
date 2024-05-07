using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.Utility;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.DTOs.Rol;

namespace TaxReporter.Test
{
    public class RolControllerTest
    {
        private readonly Mock<IRolService> _rolServiceMock;
        private readonly RolController _rolController;

        public RolControllerTest()
        {
            _rolServiceMock = new Mock<IRolService>();
            _rolController = new RolController(_rolServiceMock.Object);
        }

        [Fact]
        public async Task GetRoles_Successful_ReturnsOkResult()
        {
            var expectedRoles = new List<GetRol>
            {
                new GetRol { RolId = 1, NameRol = "SuperAdmin" },
                new GetRol { RolId = 2, NameRol = "Admin" }
            };

            _rolServiceMock.Setup(x => x.GetListAsycn())
                .ReturnsAsync(expectedRoles);

            var result = await _rolController.GetRoles() as OkObjectResult;
            var response = result.Value as Response<List<GetRol>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedRoles, response.value);

        }

    }

}

