using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.User;
using TaxReporter.Utility;

namespace TaxReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var respuesta = new Response<LoginResponse>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _authService.Login(login.Email, login.UserPassword);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }


    }
}
