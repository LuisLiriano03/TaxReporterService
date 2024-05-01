using TaxReporter.DTOs.Rol;

namespace TaxReporter.Contracts
{
    public interface IRolService
    {
        Task<List<GetRol>> GetListAsycn();

    }

}
