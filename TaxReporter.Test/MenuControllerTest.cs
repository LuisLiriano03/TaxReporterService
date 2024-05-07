using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.Utility;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.DTOs.Menu;

namespace TaxReporter.Test
{
    public class MenuControllerTest
    {
        private readonly Mock<IMenuService> _menuServiceMock;
        private readonly MenuController _menuController;

        public MenuControllerTest()
        {
            _menuServiceMock = new Mock<IMenuService>();
            _menuController = new MenuController(_menuServiceMock.Object);
        }

        [Fact]
        public async Task GetMenus_Successful_ReturnsOkResult()
        {
            int userId = 1;
            var expectedMenus = new List<GetMenu>
            {
                new GetMenu { MenuId = 1, NameMenu = "Menu 1", IconMenu = "icon1", UrlMenu = "url1" },
                new GetMenu { MenuId = 2, NameMenu = "Menu 2", IconMenu = "icon2", UrlMenu = "url2" }
            };

            _menuServiceMock.Setup(x => x.GetListAsycn(userId))
                .ReturnsAsync(expectedMenus);

            var result = await _menuController.GetMenus(userId) as OkObjectResult;
            var response = result.Value as Response<List<GetMenu>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedMenus, response.value);

        }

    }

}

