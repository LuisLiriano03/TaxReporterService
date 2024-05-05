using TaxReporter.DTOs.InvoiceState;

namespace TaxReporter.Contracts
{
    public interface IInvoiceStateService
    {
        Task<List<GetState>> GetListAsycn();
    }

}
