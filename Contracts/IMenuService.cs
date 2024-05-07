using TaxReporter.DTOs.Menu;

namespace TaxReporter.Contracts
{
    public interface IMenuService
    {
        Task<List<GetMenu>> GetListAsycn(int userId);
    }

}
