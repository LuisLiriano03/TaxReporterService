using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Rol;
using TaxReporter.Exceptions.Rol;
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
            var reponse = new Response<List<GetRol>>();

            try
            {
                reponse.status = true;
                reponse.value = await _rolService.GetListAsycn();
                throw new GetRolSuccessfulException();
            }
            catch (Exception ex)
            {
                reponse.status = false;
                reponse.message = ex.Message;
            }

            return Ok(reponse);

        }

    }

}
