using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Menu;
using TaxReporter.Exceptions.Menu;
using TaxReporter.Utility;

namespace TaxReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuServices;

        public MenuController(IMenuService menuServices)
        {
            _menuServices = menuServices;
        }

        [Authorize]
        [HttpGet]
        [Route("GetMenus/{userId}")]
        public async Task<IActionResult> GetMenus(int userId)
        {
            var response = new Response<List<GetMenu>>();

            try
            {
                response.status = true;
                response.value = await _menuServices.GetListAsycn(userId);
                throw new GetMenuSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }


    }

}
