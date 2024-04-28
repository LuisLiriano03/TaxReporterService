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
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginRequest login)
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

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody] CreateUser user)
        {
            var response = new Response<GetUser>();

            try
            {
                response.status = true;
                response.value = await _authService.Register(user);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.mensage = ex.Message;
            }

            return Ok(response);

        }


    }
}
