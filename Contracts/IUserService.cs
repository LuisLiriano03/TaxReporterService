using TaxReporter.DTOs.User;

namespace TaxReporter.Contracts
{
    public interface IUserService
    {
        Task<List<GetUser>> GetAsync();
        Task<bool> UpdateAsync(UpdateUser model);
        Task<bool> DeleteAsync(int id);

    }

}
