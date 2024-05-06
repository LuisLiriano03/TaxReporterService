using TaxReporter.DTOs.Invoice;
using TaxReporter.DTOs.User;

namespace TaxReporter.Contracts
{
    public interface IInvoiceService
    {
        Task<GetInvoice> Register(CreateInvoice model);
        Task<List<GetInvoice>> GetAsync();
        Task<List<GetInvoice>> GetPendingInvoicesAsync();
        Task<List<GetInvoice>> GetApprovedInvoicesAsync();
        Task<List<GetInvoice>> GetUnapprovedInvoicesAsync();
        Task<List<GetInvoice>> GetPendingInvoiceByUser(int userId);
        Task<List<GetInvoice>> GetApprovedInvoiceByUser(int userId);
        Task<List<GetInvoice>> GetUnapprovedInvoiceByUser(int userId);
        Task<bool> UpdateAsync(UpdateInvoice model);
        Task<bool> UpdateStateAsync(UpdateState model);
        Task<bool> DeleteAsync(int invoiceId);

    }

}
