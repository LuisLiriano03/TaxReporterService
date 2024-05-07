using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Rol;
using TaxReporter.Utility;

namespace TaxReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService) 
        { 
            _rolService = rolService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var response = new Response<List<GetRol>>();

            try
            {
                response.status = true;
                response.value = await _rolService.GetListAsycn();
                response.message = "Successful roles";
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
