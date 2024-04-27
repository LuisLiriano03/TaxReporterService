using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaxReporter.Contracts;
using TaxReporter.DBContext;
using TaxReporter.DTOs.User;
using TaxReporter.Entities;
using TaxReporter.Repository.Contract;

namespace TaxReporter.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IGenericRepository<UserInfo> userRepository,IConfiguration configuration ,IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        private string GenerateToken(string UserId)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserId));

            var TokenCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var DecryptionToken = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(15),
                SigningCredentials = TokenCredentials
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenConfig = TokenHandler.CreateToken(DecryptionToken);

            string TokenCreated = TokenHandler.WriteToken(TokenConfig);

            return TokenCreated;
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            try
            {
                var queryUsuario = await _userRepository.VerifyDataExistenceAsync(u => u.Email == email && u.UserPassword == password);

                if (queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("El usuario no existe");

                UserInfo devolverUsuario = queryUsuario.Include(rol => rol.Rol).First();

                // Generar el token
                string token = GenerateToken(devolverUsuario.UserId.ToString()); // Asegúrate de pasar el email u otro identificador único

                // Crear la respuesta con el token
                var loginResponse = _mapper.Map<LoginResponse>(devolverUsuario);
                loginResponse.Token = token;

                return loginResponse;
            }
            catch
            {
                throw;
            }
        }

        public Task<GetUser> Register(CreateUser model)
        {
            throw new NotImplementedException();
        }

        
    }
}
