using TaxReporter.DTOs.User;

namespace TaxReporter.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(string email, string password);
        Task<GetUser> Register(CreateUser model);

    }

}
